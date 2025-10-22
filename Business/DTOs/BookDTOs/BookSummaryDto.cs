namespace Business.DTOs.BookDTOs
{
    public class BookSummaryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public string PublisherName { get; set; }

        public string AuthorName { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public double AverageRating { get; set; }
    }
}
