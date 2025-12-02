using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Book
{
    public class BookCreateViewModel : BookDropDownViewModel
    {
        [Required]
        [Display(Name = "Book Title")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "ISBN")]
        [MinLength(10)]
        [MaxLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Display(Name = "Price")]
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Author")]
        [Required]
        public int AuthorId { get; set; }

        [Display(Name = "Publisher")]
        [Required]
        public int PublisherId { get; set; }

        [Display(Name = "Genres")]
        [Required]
        public List<int> GenreIds { get; set; } = new();

        [Display(Name = "Upload cover image")]
        [Required]
        public IFormFile? CoverImageFile { get; set; }

        public string CoverImageName { get; set; } = "";
    }
}
