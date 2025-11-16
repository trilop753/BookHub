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

        public static BookDetailViewModel MapToDetailView(this BookDto book)
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
            };
        }
    }
}
