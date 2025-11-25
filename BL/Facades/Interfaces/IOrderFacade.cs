using BL.DTOs.OrderDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IOrderFacade
    {
        Task<Result<OrderDto>> CreateOrderFromUserCartAsync(int userId);
        Task<Result<IEnumerable<OrderDto>>> GetAllAsync();
        Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId);
        Task<Result> DeleteAsync(int id);
    }
}
