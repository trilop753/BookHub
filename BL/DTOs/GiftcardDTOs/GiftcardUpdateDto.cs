namespace BL.DTOs.GiftcardDTOs
{
    public class GiftcardUpdateDto
    {
        public string Name { get; set; } = null!;
        public decimal Amount { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}