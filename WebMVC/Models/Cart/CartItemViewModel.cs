using WebMVC.Models.Book;

namespace WebMVC.Models.Cart;

public class CartItemViewModel
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public BookViewModel Book { get; set; }
}
