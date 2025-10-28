using BL.DTOs.GenreDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto MapToDto(this Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Books = genre.Books.Select(b => b.MapToSummaryDto()).ToList(),
            };
        }

        public static GenreSummaryDto MapToSummaryDto(this Genre genre)
        {
            return new GenreSummaryDto { Id = genre.Id, Name = genre.Name };
        }
    }
}
