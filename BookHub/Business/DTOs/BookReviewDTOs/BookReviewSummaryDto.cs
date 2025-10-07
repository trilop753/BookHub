using Business.DTOs.BookDTOs;
using Business.DTOs.UserDTOs;

namespace Business.DTOs.BookReviewDTOs
{
    public class BookReviewSummaryDto
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Body { get; set; }
    }
}