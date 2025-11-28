using DAL.UtilityModels;

namespace WebMVC.Models.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<OrderItemViewModel> Items { get; set; }

        public decimal? TotalPrice => Items?.Sum(i => i.Quantity * i.Book.Price);

        public PaymentStatus PaymentStatus { get; set; }
    }
}
