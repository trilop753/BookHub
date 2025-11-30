using DAL.UtilityModels;

namespace WebMVC.Models.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<OrderItemViewModel> Items { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string? GiftcardCode { get; set; }
    }
}
