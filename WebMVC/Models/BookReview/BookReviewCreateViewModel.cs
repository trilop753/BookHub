namespace WebMVC.Models.Book
{
    public class BookReviewCreateViewModel
    {
        public int Stars { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }
    }
}
