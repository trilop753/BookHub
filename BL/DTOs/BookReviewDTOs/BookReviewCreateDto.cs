namespace BL.DTOs.BookReviewDTOs
{
    public class BookReviewCreateDto
    {
        public int Stars { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
