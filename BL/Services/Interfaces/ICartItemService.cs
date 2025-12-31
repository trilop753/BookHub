using BL.DTOs.CartItemDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<Result<CartItemDto>> CreateCartItemAsync(CartItemCreateDto cartItem);
        Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity);
        Task<Result> DeleteCartItemsAsync(IEnumerable<int> ids);
        Task<Result> DeleteCartItemAsync(int userId, int bookId);
        Task<Result> DeleteCartItemByIdAsync(int id);
        Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId);
    }
}
