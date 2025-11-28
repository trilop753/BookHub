namespace BL.DTOs.GiftcardDTOs
{
    public class GiftcardSummaryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public decimal Amount { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public IEnumerable<GiftcardCodeDto> Codes { get; set; }
            = new List<GiftcardCodeDto>();
    } 
}