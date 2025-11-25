using BL.DTOs.UserDTOs;

namespace BL.DTOs.BookReviewDTOs
{
    public class BookReviewNoBookDto
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Body { get; set; }

        public UserSummaryDto User { get; set; }
    }
}
