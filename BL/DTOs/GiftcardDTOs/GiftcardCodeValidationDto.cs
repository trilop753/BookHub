namespace BL.DTOs.GiftcardDTOs
{
    public class GiftcardCodeValidationDto
    {
        public string Code { get; set; } = null!;
        public decimal Amount { get; set; }

        public int GiftcardId { get; set; }

        // For message if the validation did not go through
        public string? Message { get; set; }
    }
}