using BL.DTOs.BookDTOs;
using DAL.Models;
using DAL.UtilityModels;

namespace BL.Mappers
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
                Genres = book.Genres.Select(gb => gb.MapToSummaryDto()).ToList(),
                Reviews = book.Reviews?.Select(r => r.MapToNoBookDto()).ToList() ?? [],
                CoverImageName = book.CoverImageName,
                EditCount = book.EditCount,
                LastEditedBy = book.LastEditedBy?.MapToSummaryDto(),
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
                AuthorName = $"{book.Author?.Name} {book.Author?.Surname}".Trim(),
                Genres = book.Genres.Select(gb => gb.MapToSummaryDto()).ToList(),
                AverageRating = book.Reviews.Any() ? book.Reviews.Average(r => r.Stars) : null,
                CoverImageName = book.CoverImageName,
            };
        }

        public static BookSearchCriteria MapToBookSearchCriteria(this BookSearchCriteriaDto model)
        {
            model ??= new BookSearchCriteriaDto();

            return new BookSearchCriteria
            {
                Title = model.Title,
                Description = model.Description,
                LowPrice = model.LowPrice,
                HighPrice = model.HighPrice,
                GenreIds = model.GenreIds,
                AuthorId = model.AuthorId,
                PublisherId = model.PublisherId,
                SearchMode = model.SearchMode,
                Query = model.Query,
            };
        }
    }
}
