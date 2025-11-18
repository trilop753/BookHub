using BL.Facades.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;
using WebMVC.Models.Book;

namespace WebMVC.Controllers
{
    [Authorize]
    public class BookReviewController : Controller
    {
        private readonly IBookReviewFacade _bookReviewFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public BookReviewController(
            IBookReviewFacade bookReviewFacade,
            UserManager<LocalIdentityUser> userManager
        )
        {
            _bookReviewFacade = bookReviewFacade;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(int bookId)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var currentUser = identityUser.User;

            var review = new BookReviewCreateViewModel()
            {
                BookId = bookId,
                UserId = currentUser.Id,
            };

            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookReviewCreateViewModel review)
        {
            var res = await _bookReviewFacade.CreateAsync(review.MapToCreateDto());

            if (res.IsFailed)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }

                return View(review);
            }

            return RedirectToAction("Detail", "Book", new { id = res.Value.Book.Id });
        }
    }
}
