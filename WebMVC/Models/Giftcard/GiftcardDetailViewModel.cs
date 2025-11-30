using System;
using System.Collections.Generic;

namespace WebMVC.Models.Giftcard
{
    public class GiftcardDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public int TotalCodes { get; set; }

        public int UsedCodes { get; set; }

        public List<GiftcardCodeSummaryViewModel> Codes { get; set; } = new();
    }

    public class GiftcardCodeSummaryViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public bool IsUsed { get; set; }

        public int? OrderId { get; set; }
    }
}
