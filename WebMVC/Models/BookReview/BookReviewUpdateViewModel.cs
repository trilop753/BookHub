namespace WebMVC.Models.Book
{
    public class BookReviewUpdateViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public int Stars { get; set; }
        public string Body { get; set; } = string.Empty;
    }
}