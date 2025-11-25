using BL.DTOs.WishlistItemDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistFacade _wishlistFacade;
        private readonly IBookService _bookService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public WishlistController(
            IWishlistFacade wishlistFacade,
            IBookService bookService,
            UserManager<LocalIdentityUser> userManager
        )
        {
            _wishlistFacade = wishlistFacade;
            _bookService = bookService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var res = await _wishlistFacade.GetAllWishlistedByUserIdAsync(identityUser.User.Id);
            if (res.IsFailed)
            {
                return View("InternalServerError");
            }
            return View(res.Value.MapToView());
        }

        [HttpPost]
        public async Task<IActionResult> Add(int bookId)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var currentUser = identityUser.User;

            var res = await _wishlistFacade.WishlistBookAsync(
                new WishlistItemCreateDto() { BookId = bookId, UserId = currentUser.Id }
            );

            if (res.IsFailed)
            {
                return View("InternalServerError");
            }

            return RedirectToAction("Detail", "Book", new { id = bookId });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int bookId, string? returnUrl)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var currentUser = identityUser.User;

            var res = await _wishlistFacade.RemoveFromWishlistAsync(currentUser.Id, bookId);

            if (res.IsFailed)
            {
                return View("InternalServerError");
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Detail", "Book", new { id = bookId });
        }
    }
}
