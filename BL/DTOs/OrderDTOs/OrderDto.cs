using BL.DTOs.UserDTOs;
using DAL.UtilityModels;

namespace BL.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserSummaryDto User { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
