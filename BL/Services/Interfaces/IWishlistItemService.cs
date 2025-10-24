using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IWishlistItemService
    {
        //public Task<Result<WishlistItemDto>> GetWishlistItemByIdAsync(int id);
        public Task<IEnumerable<WishlistItemDto>> GetAllUserWishlistItemsAsync(int userId);
        public Task<IEnumerable<WishlistItemDto>> GetAllBookWishlistItemsAsync(int bookId);
        public Task<Result<WishlistItemDto>> CreateWishlistItemAsync(int userId, int bookId);
        public Task<Result> DeleteWishlistItemAsync(int userId, int bookId);
        //public Task<Result> DeleteWishlistItemByIdAsync(int id);
    }
}
