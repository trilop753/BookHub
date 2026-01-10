using BL.Facades.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Book;

namespace WebMVC.Controllers
{
    [Authorize]
    public class BookReviewController : Controller
    {
        private readonly IBookReviewFacade _bookReviewFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IAppCache _cache;

        public BookReviewController(
            IBookReviewFacade bookReviewFacade,
            UserManager<LocalIdentityUser> userManager,
            IAppCache cache
        )
        {
            _bookReviewFacade = bookReviewFacade;
            _userManager = userManager;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int bookId)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var review = new BookReviewCreateViewModel
            {
                BookId = bookId,
                UserId = identityUser.User.Id,
            };

            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookReviewCreateViewModel review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            review.UserId = identityUser.User.Id;

            var res = await _bookReviewFacade.CreateAsync(review.MapToCreateDto());

            if (res.IsFailed)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }

                return View(review);
            }

            _cache.Remove(CacheKeys.BookDetail(res.Value.Book.Id));
            return RedirectToAction("Detail", "Book", new { id = res.Value.Book.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, int? bookId = null)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var currentUser = identityUser.User;

            var reviewRes = await _bookReviewFacade.GetByIdAsync(id);
            if (reviewRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var review = reviewRes.Value;

            var isAdmin = User.IsInRole(Roles.Admin);
            if (!isAdmin && review.User.Id != currentUser.Id)
            {
                return Forbid();
            }

            var resolvedBookId = review.Book?.Id ?? bookId ?? 0;

            var model = new BookReviewUpdateViewModel
            {
                Id = review.Id,
                BookId = resolvedBookId,
                Stars = review.Stars,
                Body = review.Body,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookReviewUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var currentUser = identityUser.User;

            var reviewRes = await _bookReviewFacade.GetByIdAsync(model.Id);
            if (reviewRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var isAdmin = User.IsInRole(Roles.Admin);

            if (!isAdmin && reviewRes.Value.User.Id != currentUser.Id)
            {
                return Forbid();
            }

            var ownerId = reviewRes.Value.User.Id;

            var updateRes = await _bookReviewFacade.UpdateAsync(
                model.Id,
                ownerId,
                model.MapToUpdateDto()
            );

            if (updateRes.IsFailed)
            {
                foreach (var error in updateRes.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }

                model.BookId = reviewRes.Value.Book?.Id ?? model.BookId;
                return View(model);
            }

            var bookId = reviewRes.Value.Book?.Id ?? model.BookId;

            _cache.Remove(CacheKeys.BookDetail(bookId));
            return RedirectToAction("Detail", "Book", new { id = bookId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int? bookId = null)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var currentUser = identityUser.User;

            var reviewRes = await _bookReviewFacade.GetByIdAsync(id);
            if (reviewRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var isAdmin = User.IsInRole(Roles.Admin);
            if (!isAdmin && reviewRes.Value.User.Id != currentUser.Id)
            {
                return Forbid();
            }

            var resolvedBookId = reviewRes.Value.Book?.Id ?? bookId ?? 0;

            var deleteRes = await _bookReviewFacade.DeleteAsync(id);
            if (deleteRes.IsFailed)
            {
                return View("InternalServerError");
            }

            _cache.Remove(CacheKeys.BookDetail(resolvedBookId));
            return RedirectToAction("Detail", "Book", new { id = resolvedBookId });
        }
    }
}
