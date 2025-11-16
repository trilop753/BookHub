using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book.IsFailed)
            {
                return View("NotFound");
            }

            return View(book.Value.MapToDetailView());
        }
    }
}
