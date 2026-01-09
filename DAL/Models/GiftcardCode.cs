using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class GiftcardCode : BaseEntity
    {
        public int GiftcardId { get; set; }

        [ForeignKey(nameof(GiftcardId))]
        public virtual Giftcard? Giftcard { get; set; }

        public string Code { get; set; } = null!;

        public bool IsUsed { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }
    }
}
