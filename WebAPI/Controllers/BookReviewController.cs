using BL.DTOs.BookReviewDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewService _service;

        public BookReviewController(IBookReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookReviewDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.IsFailed)
                return NotFound(result.Errors.Select(e => e.Message));

            return Ok(result.Value);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetByBook(int bookId)
        {
            return Ok(await _service.GetByBookAsync(bookId));
        }

        [HttpPost]
        public async Task<ActionResult<BookReviewDto>> Create([FromBody] BookReviewCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (result.IsFailed)
                return BadRequest(result.Errors.Select(e => e.Message));

            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookReviewUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result.IsFailed)
                return NotFound(result.Errors.Select(e => e.Message));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result.IsFailed)
                return NotFound(result.Errors.Select(e => e.Message));

            return NoContent();
        }
    }
}
