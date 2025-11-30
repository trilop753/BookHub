using BL.DTOs.OrderDTOs;
using WebMVC.Models.Order;

namespace WebMVC.Mappers
{
    public static class OrderMapper
    {
        public static IEnumerable<OrderItemViewModel> MapToView(
            this IEnumerable<OrderItemDto> orderItemsDto
        )
        {
            return orderItemsDto.Select(oi => new OrderItemViewModel()
            {
                Id = oi.Id,
                Book = oi.Book.MapToView(),
                Quantity = oi.Quantity,
            });
        }

        public static OrderViewModel MapToView(this OrderDto orderDto)
        {
            return new OrderViewModel()
            {
                Id = orderDto.Id,
                Date = orderDto.Date,
                Items = orderDto.Items.MapToView(),
                PaymentStatus = orderDto.PaymentStatus,
                TotalPrice = orderDto.TotalPrice,
                FinalPrice = orderDto.FinalPrice,
                GiftcardCode = orderDto.GiftcardCode,
            };
        }
    }
}
