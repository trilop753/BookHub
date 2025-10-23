using BL.DTOs.BookDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("search")]
        public async Task<ActionResult<BookSummaryDto>> GetFiltered(
            [FromQuery] BookSearchCriteriaDto searchCriteria
        )
        {
            var books = await _bookService.GetFiltered(searchCriteria);

            return Ok(books);
        }

        #endregion

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] BookCreateDto dto)
        {
            var created = await _bookService.CreateBookAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto dto)
        {
            var updated = await _bookService.UpdateBookAsync(id, dto);
            if (!updated.Success)
            {
                return NotFound(updated.Error);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted)
            {
                return NotFound($"Book with ID {id} was not found.");
            }

            return NoContent();
        }
    }
}
