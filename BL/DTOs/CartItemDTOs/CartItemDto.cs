using BL.DTOs.BookDTOs;
using BL.DTOs.UserDTOs;

namespace BL.DTOs.CartItemDTOs
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public virtual UserSummaryDto User { get; set; }

        public virtual BookSummaryDto Book { get; set; }
    }
}
