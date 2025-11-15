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
            };
        }
    }
}
