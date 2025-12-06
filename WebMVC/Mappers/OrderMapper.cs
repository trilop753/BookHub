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
                Quantity = oi.Quantity,
                BookTitle = oi.BookTitle,
                BookISBN = oi.BookISBN,
                BookPrice = oi.BookPrice,
                BookAuthor = oi.BookAuthor,
                BookPublisher = oi.BookPublisher,
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
