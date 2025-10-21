using Business.DTOs.BookReviewDTOs;
using DAL.Models;

namespace Business.Mappers
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

        public static BookReviewSummaryDto MapToSummaryDto(this BookReview review)
        {
            return new BookReviewSummaryDto
            {
                Id = review.Id,
                Stars = review.Stars,
                Body = review.Body,
            };
        }
    }
}
