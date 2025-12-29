using BL.DTOs.AuthorDTOs;
using BL.DTOs.BookDTOs;
using BL.DTOs.GenreDTOs;
using BL.DTOs.PublisherDTOs;

namespace BL.DTOs.UtilityDTOs
{
    public class SearchResultDto
    {
        public IEnumerable<BookSummaryDto> Books { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public IEnumerable<PublisherDto> Publishers { get; set; }
    }
}
