using BL.DTOs.GenreDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<Result<GenreDto>> GetGenreByIdAsync(int id);
        public Task<IEnumerable<GenreDto>> GetGenresByNameAsync(string query);
        public Task<IEnumerable<GenreDto>> GetAllGenresAsync();
        public Task<Result<GenreDto>> CreateGenreAsync(GenreCreateDto dto);
        public Task<Result> UpdateGenreAsync(int id, GenreUpdateDto dto);
        public Task<Result> DeleteGenreAsync(int id);
    }
}
