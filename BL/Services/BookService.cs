using BL.DTOs.BookDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using BL.UtilClasses;
using DAL.Models;
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

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return book?.MapToDto();
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

    public async Task<BookDto> CreateBookAsync(BookCreateDto dto)
    {
        var author = await _authorRepository.GetByIdAsync(dto.AuthorId);
        var publisher = await _publisherRepository.GetByIdAsync(dto.PublisherId);
        var genres = await _genreRepository.GetAllByIdsAsync(dto.GenreIds.ToArray());

        //TODO check null? (ids will be picked from a list?)
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

        return newBook.MapToDto();
    }

    public async Task<Result> UpdateBookAsync(int bookId, BookUpdateDto dto)
    {
        if (await _publisherRepository.GetByIdAsync(dto.PublisherId) == null)
        {
            return new Result()
            {
                Success = false,
                Error = $"Publisher with id: {dto.PublisherId} does not exist",
            };
        }
        if (await _authorRepository.GetByIdAsync(dto.AuthorId) == null)
        {
            return new Result()
            {
                Success = false,
                Error = $"Author with id: {dto.AuthorId} does not exist",
            };
        }

        var book = await _bookRepository.GetBookByIdWithGenresIncluded(bookId);
        if (book == null)
        {
            return new Result()
            {
                Success = false,
                Error = $"Book with id: {bookId} does not exist",
            };
            ;
        }

        var allGenres = (await _genreRepository.GetAllAsync()).ToList();

        var allGenresIds = allGenres.Select(genre => genre.Id).ToHashSet();
        if (!dto.GenreIds.All(allGenresIds.Contains))
        {
            return new Result()
            {
                Success = false,
                Error =
                    $"Genres with ids: {string.Join(", ", dto.GenreIds.Except(allGenresIds))} do not exist",
            };
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
        return new Result() { Success = true };
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var existing = await _bookRepository.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }

        _bookRepository.Delete(existing);
        await _bookRepository.SaveChangesAsync();
        return true;
    }
}
