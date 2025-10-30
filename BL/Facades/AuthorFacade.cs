using BL.DTOs.AuthorDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using FluentResults;

namespace BL.Facades
{
    public class AuthorFacade : IAuthorFacade
    {
        private readonly IAuthorService _authorService;

        public AuthorFacade(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Result<IEnumerable<AuthorDto>>> GetAllAsync()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Result.Ok(authors);
        }

        public async Task<Result<AuthorDto>> GetByIdAsync(int id)
        {
            return await _authorService.GetAuthorByIdAsync(id);
        }

        public async Task<Result<AuthorDto>> CreateAsync(AuthorCreateDto dto)
        {
            return await _authorService.CreateAuthorAsync(dto);
        }

        public async Task<Result> UpdateAsync(int id, AuthorUpdateDto dto)
        {
            return await _authorService.UpdateAuthorAsync(id, dto);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _authorService.DeleteAuthorAsync(id);
        }
    }
}
