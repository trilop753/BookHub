using BL.DTOs.CartItemDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<Result<CartItemDto>> CreateCartItemAsync(int userId, int bookId, int quantity = 1);

        Task<Result> DeleteCartItemAsync(int id);

        Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity);

        Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId);
    }
}
