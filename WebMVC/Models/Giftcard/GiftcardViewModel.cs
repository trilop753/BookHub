using System;

namespace WebMVC.Models.Giftcard
{
    public class GiftcardViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public int TotalCodes { get; set; }

        public int UsedCodes { get; set; }
    }
}
