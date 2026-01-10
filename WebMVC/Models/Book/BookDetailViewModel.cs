using WebMVC.Models.Author;
using WebMVC.Models.GenreBook;
using WebMVC.Models.Publisher;

namespace WebMVC.Models.Book
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<GenreBookViewModel> Genres { get; set; }

        public PublisherViewModel Publisher { get; set; }

        public AuthorViewModel Author { get; set; }

        public virtual IEnumerable<BookReviewViewModel> Reviews { get; set; }

        public string? CoverImageName { get; set; }

        public bool IsWishlisted { get; set; }

        public bool IsInCart { get; set; }
    }
}
