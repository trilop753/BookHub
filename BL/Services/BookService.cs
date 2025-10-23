using BL.DTOs.BookDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IPublisherRepository _publisherRepository;

    public BookService(
        IBookRepository bookRepository,
        IGenreRepository genreRepository,
        IAuthorRepository authorRepository,
        IPublisherRepository publisherRepository
    )
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
        _publisherRepository = publisherRepository;
    }

    #region Get

    public async Task<Result<BookDto>> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            return Result.Fail($"Book with id {id} does not exist.");
        }
        return Result.Ok(book.MapToDto());
    }

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetBooksAsync();
        return books.Select(b => b.MapToDto());
    }

    public async Task<IEnumerable<BookSummaryDto>> GetFiltered(BookSearchCriteriaDto searchCriteria)
    {
        var books = await _bookRepository.GetFiltered(searchCriteria.MapToBookSearchCriteria());

        return books.Select(b => b.MapToSummaryDto());
    }

    #endregion

    public async Task<Result<BookDto>> CreateBookAsync(BookCreateDto dto)
    {
        var author = await _authorRepository.GetByIdAsync(dto.AuthorId);
        if (author == null)
        {
            return Result.Fail($"Author with id {dto.AuthorId} does not exist.");
        }

        var publisher = await _publisherRepository.GetByIdAsync(dto.PublisherId);
        if (publisher == null)
        {
            return Result.Fail($"Publisher with id {dto.PublisherId} does not exist.");
        }

        var genres = await _genreRepository.GetAllByIdsAsync(dto.GenreIds.ToArray());
        if (genres.Count() != dto.GenreIds.Count())
        {
            return Result.Fail(
                $"Genres with ids {string.Join(", ", dto.GenreIds.Except(genres.Select(g => g.Id)))} do not exist."
            );
        }

        var newBook = new Book
        {
            Title = dto.Title,
            Description = dto.Description,
            ISBN = dto.ISBN,
            Price = dto.Price,
            Author = author,
            Publisher = publisher,
            Genres = genres.ToList(),
        };

        await _bookRepository.AddAsync(newBook);
        await _bookRepository.SaveChangesAsync();

        return Result.Ok(newBook.MapToDto());
    }

    public async Task<Result> UpdateBookAsync(int bookId, BookUpdateDto dto)
    {
        if (await _publisherRepository.GetByIdAsync(dto.PublisherId) == null)
        {
            return Result.Fail($"Publisher with id: {dto.PublisherId} does not exist");
        }
        if (await _authorRepository.GetByIdAsync(dto.AuthorId) == null)
        {
            return Result.Fail($"Author with id: {dto.AuthorId} does not exist");
        }

        var book = await _bookRepository.GetBookByIdWithGenresIncluded(bookId);
        if (book == null)
        {
            return Result.Fail($"Book with id: {bookId} does not exist");
        }

        var allGenres = (await _genreRepository.GetAllAsync()).ToList();

        var allGenresIds = allGenres.Select(genre => genre.Id).ToHashSet();
        if (!dto.GenreIds.All(allGenresIds.Contains))
        {
            return Result.Fail(
                $"Genres with ids: {string.Join(", ", dto.GenreIds.Except(allGenresIds))} do not exist"
            );
        }

        var wantedGenres = dto.GenreIds.Distinct().ToHashSet();
        var wantedExistingGenres = allGenres
            .Where(genre => wantedGenres.Contains(genre.Id))
            .ToList();

        book.Title = dto.Title;
        book.Description = dto.Description;
        book.ISBN = dto.ISBN;
        book.Price = dto.Price;
        book.AuthorId = dto.AuthorId;
        book.PublisherId = dto.PublisherId;
        book.Genres = wantedExistingGenres; // this may be a bug

        await _bookRepository.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteBookAsync(int id)
    {
        var existing = await _bookRepository.GetByIdAsync(id);
        if (existing == null)
        {
            return Result.Fail($"Book with id {id} does not exist.");
        }

        _bookRepository.Delete(existing);
        await _bookRepository.SaveChangesAsync();
        return Result.Ok();
    }
}
