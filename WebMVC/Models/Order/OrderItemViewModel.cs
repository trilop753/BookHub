using WebMVC.Models.Book;

namespace WebMVC.Models.Order
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public BookViewModel Book { get; set; }
    }
}
