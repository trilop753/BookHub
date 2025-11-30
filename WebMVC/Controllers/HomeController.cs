using System.Diagnostics;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models;

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

        public async Task<IActionResult> Index()
        {
            var booksRes = await _cache.GetOrCreateAsync(
                CacheKeys.BookAll(),
                () => _bookService.GetAllBooksAsync()
            );
            return View(booksRes.Value.Select(b => b.MapToView()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                }
            );
        }
    }
}
