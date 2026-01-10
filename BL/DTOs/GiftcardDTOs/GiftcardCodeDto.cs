namespace BL.DTOs.GiftcardDTOs
{
    public class GiftcardCodeDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public bool IsUsed { get; set; }
        public int? OrderId { get; set; }
    }
}
