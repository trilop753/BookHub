using BL.DTOs.AuthorDTOs;
using BL.DTOs.BookDTOs;
using BL.DTOs.CartItemDTOs;
using BL.DTOs.GenreDTOs;
using BL.DTOs.PublisherDTOs;
using BL.DTOs.WishlistItemDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IGenreService genreService,
            ICoverImageService coverImageService,
            IWishlistFacade wishlistFacade,
            ICartFacade cartFacade,
            UserManager<LocalIdentityUser> userManager,
            IMemoryCache cache
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
            var cacheKey = CacheKeys.BookDetail(id);
            if (!_cache.TryGetValue(cacheKey, out BookDto? book))
            {
                var res = await _bookService.GetBookByIdAsync(id);
                if (res.IsFailed)
                {
                    return View("NotFound");
                }

                book = res.Value;
                _cache.Set(
                    cacheKey,
                    book,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }

            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }
            var currentUser = identityUser.User;

            cacheKey = CacheKeys.UserWishlistAll(currentUser.Id);
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<WishlistItemDto>? wishlistedBooks))
            {
                var res = await _wishlistFacade.GetAllWishlistedByUserIdAsync(currentUser.Id);
                if (res.IsFailed)
                {
                    return View("InternalServerError");
                }
                wishlistedBooks = res.Value;

                _cache.Set(
                    cacheKey,
                    wishlistedBooks,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }

            cacheKey = CacheKeys.UserCartAll(currentUser.Id);
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<CartItemDto>? booksInCart))
            {
                var res = await _cartFacade.GetCartItemsByUserIdAsync(currentUser.Id);
                if (res.IsFailed)
                {
                    return View("InternalServerError");
                }
                booksInCart = res.Value;

                _cache.Set(
                    cacheKey,
                    booksInCart,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }

            var wishlistedBooksIds = wishlistedBooks!.Select(i => i.Book.Id);
            var booksInCartIds = booksInCart!.Select(i => i.Book.Id);

            return View(
                book!.MapToDetailView(
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
            return RedirectToAction("Index", "Home");
        }

        private async Task<BookCreateViewModel> FillDropdownsAsync(BookCreateViewModel model)
        {
            var cacheKey = CacheKeys.AuthorAll();
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<AuthorDto>? authors))
            {
                authors = await _authorService.GetAllAuthorsAsync();
                _cache.Set(
                    cacheKey,
                    authors,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }

            cacheKey = CacheKeys.PublisherAll();
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<PublisherDto>? publishers))
            {
                publishers = await _publisherService.GetAllPublishersAsync();
                _cache.Set(
                    cacheKey,
                    publishers,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }

            cacheKey = CacheKeys.GenreAll();
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<GenreDto>? genres))
            {
                genres = await _genreService.GetAllGenresAsync();
                _cache.Set(
                    cacheKey,
                    genres,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }

            model.Authors = authors!
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                .ToList();

            model.Publishers = publishers!
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name })
                .ToList();

            model.Genres = genres!
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();
            return model;
        }
    }
}
