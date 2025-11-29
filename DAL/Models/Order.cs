using System.ComponentModel.DataAnnotations.Schema;
using DAL.UtilityModels;

namespace DAL.Models
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int? GiftcardCodeId { get; set; }

        [ForeignKey(nameof(GiftcardCodeId))]
        public virtual GiftcardCode? GiftcardCode { get; set; }

        public virtual IEnumerable<OrderItem> Items { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.InProgress;

        public decimal TotalPrice => Items?.Sum(i => i.Quantity * i.Book.Price) ?? 0;

        public decimal FinalPrice
        {
            get
            {
                decimal discount = GiftcardCode?.Giftcard?.Amount ?? 0;
                decimal result = TotalPrice - discount;
                return result < 0 ? 0 : result;
            }
        }
    }
}
