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

        public IEnumerable<int> GenreIds { get; set; }
    }
}
