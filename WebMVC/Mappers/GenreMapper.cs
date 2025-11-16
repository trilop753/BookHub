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
    }
}
