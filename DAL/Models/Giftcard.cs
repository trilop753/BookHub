namespace DAL.Models
{
    public class Giftcard: BaseEntity
    {
        public string Name { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public IEnumerable<GiftcardCode> Codes { get; set; }
    }
}

