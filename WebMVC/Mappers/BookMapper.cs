using BL.DTOs.BookDTOs;
using BL.DTOs.GenreBookDTOs;
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
                Genres = book.Genres.Select(g => g.MapToView()),
                Price = book.Price,
                CoverImageName = book.CoverImageName,
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
                Genres = book.Genres.Select(g => g.MapToView()),
                Price = book.Price,
                CoverImageName = book.CoverImageName,
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
                Genres = book.Genres.Select(gb => gb.MapToView()),
                Publisher = book.Publisher.MapToView(),
                Author = book.Author.MapToView(),
                Reviews = book.Reviews.Select(r => r.MapToView()),
                CoverImageName = book.CoverImageName,
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
                Genres = model.GenreIds.Select(gId => new GenreBookCreateDto()
                {
                    GenreId = gId,
                    IsPrimary = gId == model.GenreIds.First(),
                    /*
                     * Set the first Genre in the list as primary.
                     * Reason is that selecting genres when creating a book
                     * is kinda wonky even without primary genre.
                     * Otherwise, the entire genre selection for
                     * book creation would need to be revised.
                     */
                }),
                PublisherId = model.PublisherId,
                AuthorId = model.AuthorId,
                CoverImageName = model.CoverImageName,
            };
        }
    }
}
