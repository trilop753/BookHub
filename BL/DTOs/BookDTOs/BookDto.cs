using BL.DTOs.AuthorDTOs;
using BL.DTOs.BookReviewDTOs;
using BL.DTOs.GenreDTOs;
using BL.DTOs.PublisherDTOs;
using BL.DTOs.UserDTOs;

namespace BL.DTOs.BookDTOs
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
        public string CoverImageUrl { get; set; }

        public int EditCount { get; set; }

        public UserSummaryDto LastEditedBy { get; set; }
    }
}
