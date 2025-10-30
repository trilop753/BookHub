using BL.DTOs.UserDTOs;

namespace BL.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserSummaryDto User { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}
