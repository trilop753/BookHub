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

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
        {
            page = page < 1 ? 1 : page;
            pageSize = (pageSize < 1 || pageSize > 96) ? 24 : pageSize;

            var booksRes = await _cache.GetOrCreateAsync(
                CacheKeys.BookPage(page, pageSize),
                () => _bookService.GetAllBooksAsync(page: page, pageSize: pageSize)
            );

            if (booksRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var model = new PaginatedResultModel<BookViewModel>
            {
                Items = booksRes.Value.Items.Select(b => b.MapToView()),
                PageIndex = page,
                PageSize = pageSize,
                TotalCount = booksRes.Value.TotalCount,
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
