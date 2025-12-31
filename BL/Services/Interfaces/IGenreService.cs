using BL.DTOs.GenreDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IGenreService
    {
        Task<Result<GenreDto>> GetGenreByIdAsync(int id);
        Task<IEnumerable<GenreDto>> GetGenresByNameAsync(string query);
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();
        Task<Result<GenreDto>> CreateGenreAsync(GenreCreateDto dto);
        Task<Result> UpdateGenreAsync(int id, GenreUpdateDto dto);
        Task<Result> DeleteGenreAsync(int id);
    }
}
