using BL.DTOs.AuthorDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IAuthorFacade
    {
        Task<Result<IEnumerable<AuthorDto>>> GetAllAsync();
        Task<Result<AuthorDto>> GetByIdAsync(int id);
        Task<Result<AuthorDto>> CreateAsync(AuthorCreateDto dto);
        Task<Result> UpdateAsync(int id, AuthorUpdateDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
