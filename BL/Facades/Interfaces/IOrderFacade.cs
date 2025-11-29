using BL.DTOs.OrderDTOs;
using DAL.UtilityModels;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IOrderFacade
    {
        Task<Result<OrderDto>> CreateOrderFromUserCartAsync(int userId);

        Task<Result<OrderDto>> GetByIdAsync(int id);

        Task<Result<IEnumerable<OrderDto>>> GetAllAsync();

        Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId);

        Task<Result<OrderDto>> UpdateOrderPaymentStatusAsync(int id, PaymentStatus status);

        Task<Result> DeleteAsync(int id);

        Task<Result> AssignGiftcardCodeAsync(int orderId, int giftcardCodeId);
    }
}
