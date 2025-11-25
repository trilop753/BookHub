using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public BookController(IBookService bookService, UserManager<LocalIdentityUser> userManager)
        {
            _bookService = bookService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book.IsFailed)
            {
                return View("NotFound");
            }

            var identityUser = await _userManager.GetUserAsync(User);
            var currentUser = identityUser?.User;
            var wishlistedBooksIds = currentUser?.Wishlist.Select(i => i.BookId);

            return View(book.Value.MapToDetailView(wishlistedBooksIds ?? new List<int>()));
        }
    }
}
