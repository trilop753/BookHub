using BL.DTOs.BookDTOs;
using BL.DTOs.WishlistItemDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IWishlistFacade
    {
        Task<Result<WishlistItemDto>> WishlistBookAsync(WishlistItemCreateDto wishlistItem);
        Task<Result<WishlistItemDto>> RemoveFromWishlistAsync(int userId, int bookId);
        Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByUserIdAsync(int userId);
        Task<Result<IEnumerable<WishlistItemDto>>> GetAllWishlistedByBookIdAsync(int userId);
        Task<Result<IEnumerable<BookDto>>> GetAllWishlistedBooksByUserIdAsync(int userId);
    }
}
