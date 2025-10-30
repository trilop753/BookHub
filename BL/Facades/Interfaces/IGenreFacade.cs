using BL.DTOs.GenreDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IGenreFacade
    {
        Task<Result<IEnumerable<GenreDto>>> GetAllAsync();
        Task<Result<GenreDto>> GetByIdAsync(int id);
        Task<Result<GenreDto>> CreateAsync(GenreCreateDto dto);
        Task<Result> UpdateAsync(int id, GenreUpdateDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
