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

        public virtual IEnumerable<OrderItem> Items { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.InProgress;
    }
}
