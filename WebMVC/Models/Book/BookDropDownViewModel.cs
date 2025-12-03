using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC.Models.Book;

public class BookDropDownViewModel
{
    public IEnumerable<SelectListItem> Authors { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> Publishers { get; set; } =
        Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> Genres { get; set; } = Enumerable.Empty<SelectListItem>();
}
