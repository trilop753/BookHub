using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Giftcard
{
    public class GiftcardCreateViewModel
    {
        [Required]
        [Display(Name = "Gift Card Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 100000, ErrorMessage = "Amount must be greater than 0.")]
        [Display(Name = "Discount Amount (CZK)")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Valid To")]
        public DateTime ValidTo { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Number of codes must be at least 1.")]
        [Display(Name = "Number of Codes to Generate")]
        public int NumberOfCodes { get; set; }
    }
}
