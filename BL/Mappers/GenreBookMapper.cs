using BL.DTOs.GenreBookDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class GenreBookMapper
    {
        public static GenreBookSummaryDto MapToSummaryDto(this GenreBook genreBook)
        {
            return new GenreBookSummaryDto()
            {
                GenreId = genreBook.GenreId,
                IsPrimary = genreBook.IsPrimary,
                GenreName = genreBook.Genre.Name,
            };
        }
    }
}
