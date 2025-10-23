using BL.DTOs.BookDTOs;

namespace BL.DTOs.AuthorDTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual IEnumerable<BookSummaryDto> Books { get; set; }
    }
}
