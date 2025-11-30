using BL.DTOs.GenreBookDTOs;

namespace BL.DTOs.BookDTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public int PublisherId { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<GenreBookUpdateDto> Genres { get; set; }

        public string CoverImageName { get; set; }

        public int LastEditedById { get; set; }
    }
}
