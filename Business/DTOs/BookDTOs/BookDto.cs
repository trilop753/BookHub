using Business.DTOs.AuthorDTOs;
using Business.DTOs.BookReviewDTOs;
using Business.DTOs.GenreDTOs;
using Business.DTOs.PublisherDTOs;

namespace Business.DTOs.BookDTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public PublisherSummaryDto Publisher { get; set; }

        public AuthorSummaryDto Author { get; set; }

        public IEnumerable<GenreSummaryDto> Genres { get; set; }

        public IEnumerable<BookReviewSummaryDto> Reviews { get; set; }
    }
}
