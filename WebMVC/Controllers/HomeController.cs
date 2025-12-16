using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Book;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAppCache _cache;

        public HomeController(IBookService bookService, IAppCache cache)
        {
            _bookService = bookService;
            _cache = cache;
        }

        // Page size can be updated, 4 is for development purposes
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize is < 1 or > 96 ? 24 : pageSize;

            var booksRes = await _cache.GetOrCreateAsync(
                CacheKeys.BookAll(),
                () => _bookService.GetAllBooksAsync()
            );

            if (booksRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var all = booksRes.Value
                .Select(b => b.MapToView())
                .ToList();

            var totalCount = all.Count;

            var items = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new PaginatedResultModel<BookViewModel>
            {
                Items = items,
                PageIndex = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}