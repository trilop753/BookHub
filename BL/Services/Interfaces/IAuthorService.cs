using BL.DTOs.AuthorDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Result<AuthorDto>> GetAuthorByIdAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<Result<AuthorDto>> CreateAuthorAsync(AuthorCreateDto dto);
        Task<Result> UpdateAuthorAsync(int id, AuthorUpdateDto dto);
        Task<Result> DeleteAuthorAsync(int id);
    }
}
