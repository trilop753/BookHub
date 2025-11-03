using BL.DTOs.CartItemDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartFacade _cartFacade;

        public CartController(ICartFacade cartFacade)
        {
            _cartFacade = cartFacade;
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> CreateCartItem(CartItemCreateDto cartItem)
        {
            var result = await _cartFacade.CreateCartItemAsync(cartItem);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }
            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cartFacade.DeleteCartItemAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartItemDto>> UpdateCartItemQuantity(int id, int quantity)
        {
            var result = await _cartFacade.UpdateItemQuantityAsync(id, quantity);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return Ok(result.Value);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetUserCartItems(int userId)
        {
            var result = await _cartFacade.GetCartItemsByUserIdAsync(userId);
            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }
            return Ok(result.Value);
        }
    }
}
