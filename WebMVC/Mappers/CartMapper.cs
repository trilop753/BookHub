using BL.DTOs.CartItemDTOs;
using WebMVC.Models.Cart;

namespace WebMVC.Mappers;

public static class CartMapper
{
    public static CartItemViewModel MapToView(this CartItemDto cartItem)
    {
        return new CartItemViewModel
        {
            Id = cartItem.Id,
            Quantity = cartItem.Quantity,
            Book = cartItem.Book.MapToView(),
        };
    }

    public static CartViewModel MapToView(this IEnumerable<CartItemDto> cart)
    {
        return new CartViewModel { Items = cart.Select(i => i.MapToView()).ToList() };
    }
}
