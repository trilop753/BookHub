namespace BL.DTOs.CartItemDTOs
{
    public class CartItemCreateDto
    {
        public int Quantity { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }
    }
}
