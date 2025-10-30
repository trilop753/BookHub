using BL.DTOs.CartItemDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface ICartFacade
    {
        Task<Result<CartItemDto>> CreateCartItemAsync(int userId, int bookId, int quantity = 1);

        Task<Result> DeleteCartItemAsync(int id);

        Task<Result> DeleteCartItemsByUserIdAsync(int userId);

        Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity);

        Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId);
    }
}
