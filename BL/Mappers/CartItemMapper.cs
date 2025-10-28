using BL.DTOs.CartItemDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class CartItemMapper
    {
        public static CartItemDto MapToDto(this CartItem item)
        {
            return new CartItemDto()
            {
                Id = item.Id,
                User = item.User.MapToSummaryDto(),
                Book = item.Book.MapToSummaryDto(),
                Quantity = item.Quantity,
            };
        }
    }
}
