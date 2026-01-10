using BL.DTOs.GenreBookDTOs;

namespace BL.DTOs.BookDTOs
{
    public class BookCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public int PublisherId { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<GenreBookCreateDto> Genres { get; set; }

        public string CoverImageName { get; set; }
    }
}
