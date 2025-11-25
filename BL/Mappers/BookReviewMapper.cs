using BL.DTOs.BookReviewDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class BookReviewMapper
    {
        public static BookReviewDto MapToDto(this BookReview review)
        {
            return new BookReviewDto
            {
                Id = review.Id,
                Stars = review.Stars,
                Body = review.Body,
                User = review.User.MapToSummaryDto(),
                Book = review.Book.MapToSummaryDto(),
            };
        }

        public static BookReviewNoBookDto MapToNoBookDto(this BookReview review)
        {
            return new BookReviewNoBookDto
            {
                Id = review.Id,
                Stars = review.Stars,
                Body = review.Body,
                User = review.User.MapToSummaryDto(),
            };
        }

        public static BookReviewSummaryDto MapToSummaryDto(this BookReview review)
        {
            return new BookReviewSummaryDto
            {
                Id = review.Id,
                Stars = review.Stars,
                Body = review.Body,
            };
        }

        public static BookReview MapToModel(this BookReviewCreateDto bookReview)
        {
            return new BookReview()
            {
                Body = bookReview.Body,
                Stars = bookReview.Stars,
                BookId = bookReview.BookId,
                UserId = bookReview.UserId,
            };
        }
    }
}
