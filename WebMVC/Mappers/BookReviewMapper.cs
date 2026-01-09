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

        public static BookReviewCreateDto MapToCreateDto(this BookReviewCreateViewModel review)
        {
            return new BookReviewCreateDto()
            {
                Body = review.Body,
                Stars = review.Stars,
                BookId = review.BookId,
                UserId = review.UserId,
            };
        }

        public static BookReviewUpdateDto MapToUpdateDto(this BookReviewUpdateViewModel review)
        {
            return new BookReviewUpdateDto { Body = review.Body, Stars = review.Stars };
        }
    }
}
