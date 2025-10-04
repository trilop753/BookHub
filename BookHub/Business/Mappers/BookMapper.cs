using Business.DTOs.AuthorDTOs;
using Business.DTOs.BookDTOs;
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
            BookDto dto = new BookDto();
            dto.Id = book.Id;
            dto.Title = book.Title;
            dto.Description = book.Description;
            dto.ISBN = book.ISBN;
            dto.Price = book.Price;
            dto.Publisher = book.Publisher.MapToSummaryDto();
            dto.Author = book.Author.MapToSummaryDto();
            dto.Genres = book.Genres.Select(g => g.MapToSummaryDto()).ToList();
            dto.Reviews = book.Reviews.Select(r => r.MapToSummaryDto()).ToList(); ;
            return dto;
        }
        public static BookSummaryDto MapToSummaryDto(this Book book)
        {
            BookSummaryDto dtoSummary = new BookSummaryDto();
            dtoSummary.Id = book.Id;
            dtoSummary.Title = book.Title;
            dtoSummary.Description = book.Description;
            dtoSummary.ISBN = book.ISBN;
            dtoSummary.Price = book.Price;
            dtoSummary.PublisherName = book.Publisher.Name;
            dtoSummary.AuthorName = book.Author.Name;
            dtoSummary.Genres = book.Genres.Select(g => g.Name).ToList();
            dtoSummary.AverageRating = book.Reviews.Average(r => r.Stars);
            return dtoSummary;
        }
    }
}