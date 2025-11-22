using BL.DTOs.CartItemDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<Result<CartItemDto>> CreateCartItemAsync(CartItemCreateDto cartItem);
        Task<Result> DeleteCartItemAsync(int id);
        Task<Result> DeleteCartItemsAsync(IEnumerable<int> ids);
        Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity);
        Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId);
    }
}
