using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Caching;
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
        private readonly IWishlistFacade _wishlistFacade;
        private readonly ICartFacade _cartFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IAppCache _cache;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IGenreService genreService,
            ICoverImageService coverImageService,
            IWishlistFacade wishlistFacade,
            ICartFacade cartFacade,
            UserManager<LocalIdentityUser> userManager,
            IAppCache cache
        )
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _genreService = genreService;
            _coverImageService = coverImageService;
            _wishlistFacade = wishlistFacade;
            _cartFacade = cartFacade;
            _userManager = userManager;
            _cache = cache;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var bookRes = await _cache.GetOrCreateAsync(
                CacheKeys.BookDetail(id),
                () => _bookService.GetBookByIdAsync(id)
            );
            if (bookRes.IsFailed)
            {
                return View("NotFound");
            }

            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }
            var currentUser = identityUser.User;

            var wishlistRes = await _cache.GetOrCreateAsync(
                CacheKeys.UserWishlistAll(currentUser.Id),
                () => _wishlistFacade.GetAllWishlistedByUserIdAsync(currentUser.Id)
            );
            if (wishlistRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var cartRes = await _cache.GetOrCreateAsync(
                CacheKeys.UserCartAll(currentUser.Id),
                () => _cartFacade.GetCartItemsByUserIdAsync(currentUser.Id)
            );
            if (cartRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var wishlistedBooksIds = wishlistRes.Value.Select(i => i.Book.Id);
            var booksInCartIds = cartRes.Value.Select(i => i.Book.Id);

            return View(
                bookRes.Value.MapToDetailView(
                    wishlistedBooksIds ?? new List<int>(),
                    booksInCartIds ?? new List<int>()
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
            _cache.Remove(CacheKeys.BookAll());
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var bookRes = await _cache.GetOrCreateAsync(
                CacheKeys.BookDetail(id),
                () => _bookService.GetBookByIdAsync(id)
            );
            if (bookRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var model = bookRes.Value.MapToUpdateView();

            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }
            model.LastEditedById = identityUser.UserId;

            return View(await FillDropdownsAsync(model, model.GenreIds));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Edit(BookUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await FillDropdownsAsync(model, model.GenreIds));
            }

            var oldImageName = model.CoverImageName;
            if (model.CoverImageFile != null)
            {
                var imgAddRes = await _coverImageService.AddCoverImageAsync(model.CoverImageFile);
                if (imgAddRes.IsFailed)
                {
                    foreach (var error in imgAddRes.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }
                    return View(await FillDropdownsAsync(model, model.GenreIds));
                }
                model.CoverImageName = imgAddRes.Value;
            }

            var updateRes = await _bookService.UpdateBookAsync(model.Id, model.MapToDto());
            if (updateRes.IsFailed)
            {
                if (model.CoverImageFile != null)
                {
                    _coverImageService.DeleteCoverImage(model.CoverImageName);
                }
                model.CoverImageName = oldImageName;
                foreach (var error in updateRes.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }
                return View(await FillDropdownsAsync(model, model.GenreIds));
            }

            if (model.CoverImageFile != null)
            {
                _coverImageService.DeleteCoverImage(oldImageName);
            }
            _cache.Clear();
            return RedirectToAction("Detail", "Book", new { id = model.Id });
        }

        private async Task<T> FillDropdownsAsync<T>(T model, IEnumerable<int>? oldGenres = null)
            where T : BookDropDownViewModel
        {
            var authorsRes = await _cache.GetOrCreateAsync(
                CacheKeys.AuthorAll(),
                () => _authorService.GetAllAuthorsAsync()
            );

            var publishersRes = await _cache.GetOrCreateAsync(
                CacheKeys.PublisherAll(),
                () => _publisherService.GetAllPublishersAsync()
            );

            var genresRes = await _cache.GetOrCreateAsync(
                CacheKeys.GenreAll(),
                () => _genreService.GetAllGenresAsync()
            );

            model.Authors = authorsRes
                .Value.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                .ToList();

            model.Publishers = publishersRes
                .Value.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
                .ToList();

            model.Genres = genresRes
                .Value.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name,
                    Selected = oldGenres != null && oldGenres.Contains(g.Id),
                })
                .ToList();
            return model;
        }
    }
}
