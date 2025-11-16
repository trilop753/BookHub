using WebMVC.Models.User;

namespace WebMVC.Models.Book
{
    public class BookReviewViewModel
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Body { get; set; }

        public UserUsernameViewModel User { get; set; }
    }
}
