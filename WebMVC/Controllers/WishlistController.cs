using BL.DTOs.WishlistItemDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistFacade _wishlistFacade;
        private readonly IBookService _bookService;
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IAppCache _cache;

        public WishlistController(
            IWishlistFacade wishlistFacade,
            IBookService bookService,
            UserManager<LocalIdentityUser> userManager,
            IAppCache cache
        )
        {
            _wishlistFacade = wishlistFacade;
            _bookService = bookService;
            _userManager = userManager;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var wishlistRes = await _cache.GetOrCreateAsync(
                CacheKeys.UserWishlistAll(identityUser.User.Id),
                () => _wishlistFacade.GetAllWishlistedByUserIdAsync(identityUser.User.Id)
            );
            if (wishlistRes.IsFailed)
            {
                return View("InternalServerError");
            }
            return View(wishlistRes.Value.MapToView());
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

            _cache.Remove(CacheKeys.UserWishlistAll(identityUser.User.Id));
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

            _cache.Remove(CacheKeys.UserWishlistAll(identityUser.User.Id));
            return RedirectToAction("Detail", "Book", new { id = bookId });
        }
    }
}
