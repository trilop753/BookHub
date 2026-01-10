using BL.DTOs.OrderDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using DAL.UtilityModels;
using FluentResults;

namespace BL.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public OrderFacade(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public async Task<Result<OrderDto>> CreateOrderFromUserCartAsync(int userId)
        {
            var userRes = await _userService.GetUserCartByIdAsync(userId);
            if (userRes.IsFailed)
            {
                return Result.Fail(userRes.Errors);
            }

            var orderRes = await _orderService.CreateOrderFromUserCartAsync(userRes.Value);
            if (orderRes.IsFailed)
            {
                return Result.Fail(orderRes.Errors);
            }
            return Result.Ok(orderRes.Value);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _orderService.DeleteAsync(id);
        }

        public async Task<Result<IEnumerable<OrderDto>>> GetAllAsync()
        {
            return await _orderService.GetAllAsync();
        }

        public async Task<Result<OrderDto>> GetByIdAsync(int id)
        {
            return await _orderService.GetByIdAsync(id);
        }

        public async Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId)
        {
            var userRes = await ValidateUserAsync(userId);

            if (userRes.IsFailed)
            {
                return Result.Fail(userRes.Errors);
            }

            return await _orderService.GetOrdersByUserIdAsync(userId);
        }

        public async Task<Result<OrderDto>> UpdateOrderPaymentStatusAsync(
            int id,
            PaymentStatus status
        )
        {
            return await _orderService.UpdateOrderPaymentStatusAsync(id, status);
        }

        private async Task<Result> ValidateUserAsync(int userId)
        {
            var userRes = await _userService.GetUserByIdAsync(userId);

            if (userRes.IsFailed)
            {
                return Result.Fail(userRes.Errors);
            }
            return Result.Ok();
        }

        public Task<Result> AssignGiftcardCodeAsync(int orderId, int giftcardCodeId)
        {
            return _orderService.AssignGiftcardCodeAsync(orderId, giftcardCodeId);
        }
    }
}
