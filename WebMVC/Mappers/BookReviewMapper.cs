using BL.DTOs.BookReviewDTOs;
using WebMVC.Models.Book;

namespace WebMVC.Mappers
{
    public static class BookReviewMapper
    {
        public static BookReviewViewModel MapToView(this BookReviewNoBookDto review)
        {
            return new BookReviewViewModel()
            {
                Id = review.Id,
                Body = review.Body,
                Stars = review.Stars,
                User = review.User.MapToUsernameView(),
            };
        }
    }
}
