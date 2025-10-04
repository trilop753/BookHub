using Business.DTOs.BookReviewDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class BookReviewMapper
    {
        public static BookReviewDto mapToDto(this BookReview review)
        {
            BookReviewDto dto = new BookReviewDto();
            dto.Id = review.Id;
            dto.Stars = review.Stars;
            dto.Body = review.Body;
            dto.User = review.User.mapToSummaryDto();
            dto.Book = review.Book.mapToSummaryDto();
            return dto;
        }

        public static BookReviewSummaryDto mapToSummaryDto(this BookReview review)
        {
            BookReviewSummaryDto dtoSummary = new BookReviewSummaryDto();
            dtoSummary.Id = review.Id;
            dtoSummary.Stars = review.Stars;
            dtoSummary.Body = review.Body;
            return dtoSummary;
        }
    }
}
