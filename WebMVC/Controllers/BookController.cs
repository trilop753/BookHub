using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Mappers;
using WebMVC.Models.Book;

namespace WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IGenreService _genreService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IGenreService genreService,
            UserManager<LocalIdentityUser> userManager
        )
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _genreService = genreService;
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

        // TODO remove comment when roles are added
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View(await FillDropdownsAsync(new BookCreateViewModel()));
        }

        // TODO remove comment when roles are added
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await FillDropdownsAsync(model));
            }

            var createDto = model.MapToCreateDto();
            var res = await _bookService.CreateBookAsync(createDto);
            if (res.IsFailed)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }
                return View(await FillDropdownsAsync(model));
            }
            return RedirectToAction("Index", "Home");
        }

        private async Task<BookCreateViewModel> FillDropdownsAsync(BookCreateViewModel model)
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var publishers = await _publisherService.GetAllPublishersAsync();
            var genres = await _genreService.GetAllGenresAsync();

            model.Authors = authors
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                .ToList();

            model.Publishers = publishers
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
                .ToList();

            model.Genres = genres
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();
            return model;
        }
    }
}
