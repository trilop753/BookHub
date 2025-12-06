using BL.DTOs.GenreDTOs;
using WebMVC.Models.Genre;

namespace WebMVC.Mappers
{
    public static class GenreMapper
    {
        public static GenreViewModel MapToView(this GenreSummaryDto genre)
        {
            return new GenreViewModel() { Id = genre.Id, Name = genre.Name };
        }

        public static GenreViewModel MapToView(this GenreDto genre)
        {
            return new GenreViewModel() { Id = genre.Id, Name = genre.Name };
        }

        public static GenreUpdateViewModel MapToUpdateView(this GenreDto genre)
        {
            return new GenreUpdateViewModel() { Id = genre.Id, Name = genre.Name };
        }

        public static GenreUpdateDto MapToDto(this GenreUpdateViewModel genre)
        {
            return new GenreUpdateDto() { Name = genre.Name };
        }

        public static GenreCreateDto MapToDto(this GenreCreateViewModel genre)
        {
            return new GenreCreateDto() { Name = genre.Name };
        }
    }
}
