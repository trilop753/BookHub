using Business.DTOs.AuthorDTOs;
using Business.DTOs.BookDTOs;
using Business.DTOs.BookReviewDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class BookMapper
    {

        public static BookDto MapToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ISBN = book.ISBN,
                Price = book.Price,
                Publisher = book.Publisher.MapToSummaryDto(),
                Author = book.Author.MapToSummaryDto(),
                Genres = book.Genres.Select(g => g.MapToSummaryDto()).ToList(),
                Reviews = book.Reviews != null
                    ? book.Reviews.Select(r => r.MapToSummaryDto()).ToList()
                    : new List<BookReviewSummaryDto>()
            };
        }
        public static BookSummaryDto MapToSummaryDto(this Book book)
        {
            return new BookSummaryDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ISBN = book.ISBN,
                Price = book.Price,
                PublisherName = book.Publisher.Name,
                AuthorName = book.Author.Name,
                Genres = book.Genres.Select(g => g.Name).ToList(),
                AverageRating = book.Reviews.Any() ? book.Reviews.Average(r => r.Stars) : 0
            };
        }
    }
}