using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebMVC.Models.Book;

public class BookUpdateViewModel : BookDropDownViewModel, IValidatableObject
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
    public List<int> GenreIds { get; set; } = new();

    [Required]
    public int PrimaryGenreId { get; set; }

    [Display(Name = "Upload cover image")]
    public IFormFile? NewCoverImageFile { get; set; }

    [ValidateNever]
    public string CoverImageName { get; set; } = "";

    public int LastEditedById { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (GenreIds == null || !GenreIds.Any())
        {
            yield return new ValidationResult(
                "At least one genre must be selected.",
                new[] { nameof(GenreIds) }
            );
        }

        if (PrimaryGenreId == 0 || (GenreIds != null && !GenreIds.Contains(PrimaryGenreId)))
        {
            yield return new ValidationResult(
                "Primary genre must be selected and must be one of the selected genres.",
                new[] { nameof(PrimaryGenreId) }
            );
        }
    }
}
