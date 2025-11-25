using BL.DTOs.WishlistItemDTOs;
using BL.Facades.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistFacade _wishlistFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public WishlistController(
            IWishlistFacade wishlistFacade,
            UserManager<LocalIdentityUser> userManager
        )
        {
            _wishlistFacade = wishlistFacade;
            _userManager = userManager;
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
        public async Task<IActionResult> Remove(int bookId)
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

            return RedirectToAction("Detail", "Book", new { id = bookId });
        }
    }
}
