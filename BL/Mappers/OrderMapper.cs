using BL.DTOs.OrderDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto MapToOrderDto(this Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Date = order.Date,
                User = order.User.MapToSummaryDto(),
                Items = order.Items.Select(i => i.MapToOrderItemDto()) ?? [],
                PaymentStatus = order.PaymentStatus,
            };
        }

        public static OrderItemDto MapToOrderItemDto(this OrderItem item)
        {
            return new OrderItemDto()
            {
                Id = item.Id,
                Book = item.Book.MapToSummaryDto(),
                Quantity = item.Quantity,
            };
        }
    }
}
