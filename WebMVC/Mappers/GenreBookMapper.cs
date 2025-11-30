using BL.DTOs.GenreBookDTOs;
using WebMVC.Models.GenreBook;

namespace WebMVC.Mappers
{
    public static class GenreBookMapper
    {
        public static GenreBookViewModel MapToView(this GenreBookSummaryDto genreBook)
        {
            return new GenreBookViewModel()
            {
                GenreId = genreBook.GenreId,
                GenreName = genreBook.GenreName,
                IsPrimary = genreBook.IsPrimary,
            };
        }
    }
}
