using BL.DTOs.CartItemDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface ICartFacade
    {
        Task<Result<CartItemDto>> AddToCartAsync(CartItemCreateDto cartItem);
        Task<Result> RemoveFromCartAsync(int userId, int bookId);
        Task<Result> DeleteCartItemByIdAsync(int id);
        Task<Result> DeleteCartItemsByUserIdAsync(int userId);
        Task<Result<CartItemDto>> UpdateItemQuantityAsync(int id, int quantity);
        Task<Result<IEnumerable<CartItemDto>>> GetCartItemsByUserIdAsync(int userId);
    }
}
