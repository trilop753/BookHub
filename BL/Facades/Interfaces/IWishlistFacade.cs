using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IWishlistFacade
    {
        public Task<Result<WishlistItemDto>> WishlistBookAsync(int userId, int bookId);

        public Task<Result<WishlistItemDto>> RemoveFromWishlistAsync(int userId, int bookId);

        public Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByUserIdAsync(int userId);

        public Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByBookIdAsync(int userId);
    }
}
