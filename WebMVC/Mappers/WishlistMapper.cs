using BL.DTOs.WishlistItemDTOs;
using WebMVC.Models.Wishlist;

namespace WebMVC.Mappers;

public static class WishlistMapper
{
    public static WishlistItemViewModel MapToView(this WishlistItemDto wishlistItem)
    {
        return new WishlistItemViewModel
        {
            Id = wishlistItem.Id,
            Book = wishlistItem.Book.MapToView(),
        };
    }

    public static WishlistViewModel MapToView(this IEnumerable<WishlistItemDto> wishlist)
    {
        return new WishlistViewModel { Items = wishlist.Select(i => i.MapToView()).ToList() };
    }
}
