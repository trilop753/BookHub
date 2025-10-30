using BL.DTOs.AuthorDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;

    public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
    }

    #region Get

    public async Task<Result<AuthorDto>> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
        {
            return Result.Fail($"Author with id {id} does not exist.");
        }

        return Result.Ok(author.MapToDto());
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllWithBooksAsync();
        return authors.Select(a => a.MapToDto());
    }

    #endregion

    public async Task<Result<AuthorDto>> CreateAuthorAsync(AuthorCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Surname))
        {
            return Result.Fail("Author name and surname cannot be empty.");
        }

        var existing = await _authorRepository.GetByFullNameAsync(dto.Name, dto.Surname);
        if (existing != null)
        {
            return Result.Fail($"Author '{dto.Name} {dto.Surname}' already exists.");
        }

        var author = new Author { Name = dto.Name, Surname = dto.Surname };

        await _authorRepository.AddAsync(author);
        await _authorRepository.SaveChangesAsync();

        return Result.Ok(author.MapToDto());
    }

    public async Task<Result> UpdateAuthorAsync(int id, AuthorUpdateDto dto)
    {
        var existing = await _authorRepository.GetByIdAsync(id);
        if (existing == null)
        {
            return Result.Fail($"Author with id {id} does not exist.");
        }

        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Surname))
        {
            return Result.Fail("Author name and surname cannot be empty.");
        }

        var duplicate = await _authorRepository.GetByFullNameAsync(dto.Name, dto.Surname);
        if (duplicate != null && duplicate.Id != id)
        {
            return Result.Fail($"Author '{dto.Name} {dto.Surname}' already exists.");
        }

        existing.Name = dto.Name;
        existing.Surname = dto.Surname;

        await _authorRepository.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteAuthorAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
        {
            return Result.Fail($"Author with id {id} does not exist.");
        }

        var books = await _bookRepository.GetBooksAsync();
        var hasBooks =
            (author.Books != null && author.Books.Any()) || books.Any(b => b.AuthorId == id);

        if (hasBooks)
        {
            return Result.Fail(
                $"Cannot delete author with id {id} because they have assigned books."
            );
        }

        _authorRepository.Delete(author);
        await _authorRepository.SaveChangesAsync();

        return Result.Ok();
    }
}
