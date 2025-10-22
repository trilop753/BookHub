using Business.DTOs.BookDTOs;

namespace Business.DTOs
{
    public class PublisherDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<BookSummaryDto> Books { get; set; }
    }
}
