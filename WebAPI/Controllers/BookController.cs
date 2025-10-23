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
            var result = await _bookService.GetBookByIdAsync(id);
            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return Ok(result.Value);
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
            var result = await _bookService.CreateBookAsync(dto);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto dto)
        {
            var result = await _bookService.UpdateBookAsync(id, dto);
            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return NoContent();
        }
    }
}
