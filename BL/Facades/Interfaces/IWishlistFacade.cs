using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IWishlistFacade
    {
        public Task<Result<WishlistItemDto>> WishlistBook(int userId, int bookId);

        public Task<Result<WishlistItemDto>> RemoveFromWishlist(int userId, int bookId);
    }
}
