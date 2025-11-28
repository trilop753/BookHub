using BL.DTOs.OrderDTOs;
using BL.DTOs.UserDTOs;
using DAL.UtilityModels;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Result<OrderDto>> CreateOrderFromUserCartAsync(UserCartDto user);

        Task<Result<OrderDto>> GetByIdAsync(int id);

        Task<Result<IEnumerable<OrderDto>>> GetAllAsync();

        Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId);

        Task<Result<OrderDto>> UpdateOrderPaymentStatusAsync(int id, PaymentStatus status);

        Task<Result> DeleteAsync(int id);
    }
}
