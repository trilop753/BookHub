using System.Collections.Generic;

namespace WebMVC.Models.Giftcard
{
    public class GiftcardCodesViewModel
    {
        public int GiftcardId { get; set; }

        public string GiftcardName { get; set; } = null!;

        public List<GiftcardCodeItemViewModel> Codes { get; set; } = new();
    }

    public class GiftcardCodeItemViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public bool IsUsed { get; set; }

        public int? OrderId { get; set; }
    }
}
