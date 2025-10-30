using BL.DTOs.BookDTOs;

namespace BL.DTOs.OrderDTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public BookSummaryDto Book { get; set; }
    }
}
