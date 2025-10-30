using BL.DTOs.GenreDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IBookRepository _bookRepository;

    public GenreService(IGenreRepository genreRepository, IBookRepository bookRepository)
    {
        _genreRepository = genreRepository;
        _bookRepository = bookRepository;
    }

    #region Get

    public async Task<Result<GenreDto>> GetGenreByIdAsync(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre == null)
        {
            return Result.Fail($"Genre with id {id} does not exist.");
        }

        return Result.Ok(genre.MapToDto());
    }

    public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
    {
        var genres = await _genreRepository.GetAllAsync();
        return genres.Select(g => g.MapToDto());
    }

    #endregion

    public async Task<Result<GenreDto>> CreateGenreAsync(GenreCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return Result.Fail("Genre name cannot be empty.");
        }

        var existing = await _genreRepository.GetByNameAsync(dto.Name);
        if (existing != null)
        {
            return Result.Fail($"Genre with name '{dto.Name}' already exists.");
        }

        var newGenre = new Genre { Name = dto.Name };

        await _genreRepository.AddAsync(newGenre);
        await _genreRepository.SaveChangesAsync();

        return Result.Ok(newGenre.MapToDto());
    }

    public async Task<Result> UpdateGenreAsync(int id, GenreUpdateDto dto)
    {
        var existingGenre = await _genreRepository.GetByIdAsync(id);
        if (existingGenre == null)
        {
            return Result.Fail($"Genre with id {id} does not exist.");
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return Result.Fail("Genre name cannot be empty.");
        }

        var duplicate = await _genreRepository.GetByNameAsync(dto.Name);
        if (duplicate != null && duplicate.Id != id)
        {
            return Result.Fail($"Genre with name '{dto.Name}' already exists.");
        }

        existingGenre.Name = dto.Name;
        await _genreRepository.SaveChangesAsync();

        return Result.Ok();
    }

    public async Task<Result> DeleteGenreAsync(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre == null)
        {
            return Result.Fail($"Genre with id {id} does not exist.");
        }

        var books = await _bookRepository.GetBooksAsync();
        var hasBooks =
            (genre.Books != null && genre.Books.Any())
            || books.Any(b => b.Genres.Any(g => g.Id == id));

        if (hasBooks)
        {
            return Result.Fail($"Cannot delete genre with id {id} because it has assigned books.");
        }

        _genreRepository.Delete(genre);
        await _genreRepository.SaveChangesAsync();

        return Result.Ok();
    }
}
