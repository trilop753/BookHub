using BL.DTOs.BookDTOs;
using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IWishlistFacade
    {
        public Task<Result<WishlistItemDto>> WishlistBookAsync(WishlistItemCreateDto wishlistItem);

        public Task<Result<WishlistItemDto>> RemoveFromWishlistAsync(int userId, int bookId);

        public Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByUserIdAsync(int userId);

        public Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByBookIdAsync(int userId);

        public Task<Result<IEnumerable<BookDto>>> GetAllWishlistedBooksByUserIdAsync(int userId);
    }
}
