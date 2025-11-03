using BL.DTOs.OrderDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderFacade _orderFacade;
        private readonly ICartFacade _cartFacade;

        public OrderController(IOrderFacade orderFacade, ICartFacade cartFacade)
        {
            _orderFacade = orderFacade;
            _cartFacade = cartFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var result = await _orderFacade.GetAllAsync();
            return Ok(result.Value);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserId(int userId)
        {
            var result = await _orderFacade.GetOrdersByUserIdAsync(userId);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderDto>>> CreateOrderFromUserCart(int userId)
        {
            var orderRes = await _orderFacade.CreateOrderFromUserCartAsync(userId);

            if (orderRes.IsFailed)
            {
                return NotFound(orderRes.Errors.Select(e => e.Message));
            }

            var cartRes = await _cartFacade.DeleteCartItemsByUserIdAsync(userId);

            if (cartRes.IsFailed)
            {
                return NotFound(cartRes.Errors.Select(e => e.Message));
            }

            return Ok(orderRes.Value);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> DeleteOrder(int id)
        {
            var result = await _orderFacade.DeleteAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(e => e.Message));
            }

            return NoContent();
        }
    }
}
