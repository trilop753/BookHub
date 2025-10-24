using BL.DTOs.BookDTOs;
using BL.DTOs.UserDTOs;

namespace BL.DTOs.WishlistItemDTOs
{
    public class WishlistItemDto
    {
        public int Id { get; set; }
        public UserSummaryDto? User { get; set; }
        public BookSummaryDto? Book { get; set; }
    }
}
