using BL.DTOs.BookReviewDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewFacade _facade;

        public BookReviewController(IBookReviewFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetAll()
        {
            var result = await _facade.GetAllAsync();

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookReviewDto>> GetById(int id)
        {
            var result = await _facade.GetByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return Ok(result.Value);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetByBook(int bookId)
        {
            var result = await _facade.GetByBookAsync(bookId);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult<BookReviewDto>> Create([FromBody] BookReviewCreateDto dto)
        {
            var result = await _facade.CreateAsync(dto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.Select(e => e.Message));
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{userId}/{id}")]
        public async Task<IActionResult> Update(
            int id,
            int userId,
            [FromBody] BookReviewUpdateDto dto
        )
        {
            var result = await _facade.UpdateAsync(id, userId, dto);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.Select(e => e.Message));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _facade.DeleteAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return NoContent();
        }
    }
}
