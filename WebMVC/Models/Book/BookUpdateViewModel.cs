using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Book;

public class BookUpdateViewModel : BookDropDownViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Book Title")]
    [MaxLength(50)]
    public string Title { get; set; }

    [Display(Name = "Description")]
    [MaxLength(500)]
    public string Description { get; set; }

    [Display(Name = "ISBN")]
    [MinLength(10)]
    [MaxLength(13)]
    public string ISBN { get; set; }

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
    public List<int> GenreIds { get; set; }

    [Display(Name = "Upload cover image")]
    public IFormFile? CoverImageFile { get; set; }

    public string CoverImageName { get; set; }
}
