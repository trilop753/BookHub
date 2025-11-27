using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Constants;
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
        private readonly ICoverImageService _coverImageService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IGenreService genreService,
            ICoverImageService coverImageService,
            UserManager<LocalIdentityUser> userManager
        )
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _genreService = genreService;
            _coverImageService = coverImageService;
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
            var booksInCart = currentUser?.Cart.Select(i => i.BookId);

            return View(
                book.Value.MapToDetailView(
                    wishlistedBooksIds ?? new List<int>(),
                    booksInCart ?? new List<int>()
                )
            );
        }

        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Create()
        {
            return View(await FillDropdownsAsync(new BookCreateViewModel()));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await FillDropdownsAsync(model));
            }

            var imgRes = await _coverImageService.AddCoverImageAsync(model.CoverImageFile);
            if (imgRes.IsFailed)
            {
                foreach (var error in imgRes.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }
                return View(await FillDropdownsAsync(model));
            }

            model.CoverImageName = imgRes.Value;
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
