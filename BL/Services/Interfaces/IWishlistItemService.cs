using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IWishlistItemService
    {
        Task<IEnumerable<WishlistItemDto>> GetAllUserWishlistItemsAsync(int userId);
        Task<IEnumerable<WishlistItemDto>> GetAllBookWishlistItemsAsync(int bookId);
        Task<Result<WishlistItemDto>> CreateWishlistItemAsync(WishlistItemCreateDto wishlistItem);
        Task<Result> DeleteWishlistItemAsync(int userId, int bookId);
    }
}
