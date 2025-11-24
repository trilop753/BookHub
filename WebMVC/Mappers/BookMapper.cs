using BL.DTOs.BookDTOs;
using WebMVC.Models.Book;

namespace WebMVC.Mappers
{
    public static class BookMapper
    {
        public static BookViewModel MapToView(this BookDto book)
        {
            return new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.Name,
                PublisherName = book.Publisher.Name,
                Genres = book.Genres.Select(g => g.Name),
                Price = book.Price,
                CoverImageUrl = book.CoverImageUrl,
            };
        }

        public static BookViewModel MapToView(this BookSummaryDto book)
        {
            return new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.AuthorName,
                PublisherName = book.PublisherName,
                Genres = book.Genres,
                Price = book.Price,
                CoverImageUrl = book.CoverImageUrl,
            };
        }

        public static BookDetailViewModel MapToDetailView(
            this BookDto book,
            IEnumerable<int> wishlistedBooksIds,
            IEnumerable<int> booksInCart
        )
        {
            return new BookDetailViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ISBN = book.ISBN,
                Price = book.Price,
                Genres = book.Genres.Select(g => g.MapToView()),
                Publisher = book.Publisher.MapToView(),
                Author = book.Author.MapToView(),
                Reviews = book.Reviews.Select(r => r.MapToView()),
                CoverImageUrl = book.CoverImageUrl,
                IsWishlisted = wishlistedBooksIds.Any()
                    ? wishlistedBooksIds.Contains(book.Id)
                    : false,
                IsInCart = booksInCart.Any() ? booksInCart.Contains(book.Id) : false,
            };
        }

        public static BookCreateDto MapToCreateDto(this BookCreateViewModel model)
        {
            return new BookCreateDto()
            {
                Title = model.Title,
                Description = model.Description,
                ISBN = model.ISBN,
                Price = model.Price,
                GenreIds = model.GenreIds,
                PublisherId = model.PublisherId,
                AuthorId = model.AuthorId,
                CoverImageUrl = model.CoverImageUrl,
            };
        }
    }
}
