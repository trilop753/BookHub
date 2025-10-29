using BL.DTOs.CartItemDTOs;

namespace BL.DTOs.UserDTOs
{
    public class UserCartDto
    {
        public int Id { get; set; }

        public IEnumerable<CartItemDto> Cart { get; set; }
    }
}
