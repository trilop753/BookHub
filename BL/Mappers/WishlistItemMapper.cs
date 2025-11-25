using BL.DTOs.WishlistItemDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class WishlistItemMapper
    {
        public static WishlistItemDto MapToDto(this WishlistItem wishlistItem)
        {
            return new WishlistItemDto
            {
                Id = wishlistItem.Id,
                User = wishlistItem.User.MapToSummaryDto(),
                Book = wishlistItem.Book.MapToSummaryDto(),
            };
        }

        public static WishlistItemSummaryDto MapToSummaryDto(this WishlistItem wishlistItem)
        {
            return new WishlistItemSummaryDto
            {
                Id = wishlistItem.Id,
                UserId = wishlistItem.UserId,
                BookId = wishlistItem.BookId,
            };
        }

        public static WishlistItem MapToModel(this WishlistItemCreateDto wishlistItem)
        {
            return new WishlistItem()
            {
                UserId = wishlistItem.UserId,
                BookId = wishlistItem.BookId,
            };
        }
    }
}
