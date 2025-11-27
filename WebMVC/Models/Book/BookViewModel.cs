namespace WebMVC.Models.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public string PublisherName { get; set; }

        public string AuthorName { get; set; }

        public string CoverImageName { get; set; }
    }
}
