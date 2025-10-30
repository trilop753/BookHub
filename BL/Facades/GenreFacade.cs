using BL.DTOs.GenreDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using FluentResults;

namespace BL.Facades
{
    public class GenreFacade : IGenreFacade
    {
        private readonly IGenreService _genreService;

        public GenreFacade(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<Result<IEnumerable<GenreDto>>> GetAllAsync()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Result.Ok(genres);
        }

        public async Task<Result<GenreDto>> GetByIdAsync(int id)
        {
            return await _genreService.GetGenreByIdAsync(id);
        }

        public async Task<Result<GenreDto>> CreateAsync(GenreCreateDto dto)
        {
            return await _genreService.CreateGenreAsync(dto);
        }

        public async Task<Result> UpdateAsync(int id, GenreUpdateDto dto)
        {
            return await _genreService.UpdateGenreAsync(id, dto);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _genreService.DeleteGenreAsync(id);
        }
    }
}
