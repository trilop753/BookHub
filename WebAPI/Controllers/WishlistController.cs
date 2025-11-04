using BL.DTOs.WishlistItemDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistFacade _facade;

        public WishlistController(IWishlistFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WishlistItemDto>>> GetAllWishlistedByUserId(
            int userId
        )
        {
            var result = await _facade.GetAllWishlistedByUserIdAsync(userId);
            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }
            return Ok(result.Value);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<WishlistItemDto>>> GetAllWishlistedByBookId(
            int bookId
        )
        {
            var result = await _facade.GetAllWishlistedByBookIdAsync(bookId);
            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }
            return Ok(result.Value);
        }

        [HttpPost("add")]
        public async Task<IActionResult> WishlistBook([FromBody] WishlistItemCreateDto wishlistItem)
        {
            var result = await _facade.WishlistBookAsync(wishlistItem);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return Ok(result.Value);
        }

        [HttpDelete("remove/{userId}/{bookId}")]
        public async Task<IActionResult> RemoveFromWishlist(int userId, int bookId)
        {
            var result = await _facade.RemoveFromWishlistAsync(userId, bookId);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return NoContent();
        }
    }
}
