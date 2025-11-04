using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IWishlistItemService
    {
        public Task<IEnumerable<WishlistItemDto>> GetAllUserWishlistItemsAsync(int userId);
        public Task<IEnumerable<WishlistItemDto>> GetAllBookWishlistItemsAsync(int bookId);
        public Task<Result<WishlistItemDto>> CreateWishlistItemAsync(
            WishlistItemCreateDto wishlistItem
        );
        public Task<Result> DeleteWishlistItemAsync(int userId, int bookId);
    }
}
