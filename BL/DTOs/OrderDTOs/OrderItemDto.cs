namespace BL.DTOs.OrderDTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string BookTitle { get; set; }

        public string BookISBN { get; set; }

        public decimal BookPrice { get; set; }

        public string BookPublisher { get; set; }

        public string BookAuthor { get; set; }
    }
}
