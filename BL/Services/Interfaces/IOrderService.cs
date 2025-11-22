using BL.DTOs.OrderDTOs;
using BL.DTOs.UserDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Result<OrderDto>> CreateOrderFromUserCartAsync(UserCartDto user);
        Task<Result<IEnumerable<OrderDto>>> GetAllAsync();
        Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId);
        Task<Result> DeleteAsync(int id);
    }
}
