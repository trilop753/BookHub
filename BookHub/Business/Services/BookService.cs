using Business.DTOs.BookDTOs;
using Business.Mappers;
using Business.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;

public class BookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IPublisherRepository _publisherRepository;


    public BookService(IBookRepository bookRepository, IGenreRepository genreRepository,
        IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
        _publisherRepository = publisherRepository;
    }

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
            Price = dto.Price,
            Author = author,
            Publisher = publisher,
            Genres = genres.ToList()
        };

        await _bookRepository.AddAsync(newBook);
        await _bookRepository.SaveChangesAsync();

        return newBook.MapToDto();
    }

    public async Task<bool> UpdateBookAsync(BookUpdateDto dto)
    {
        var existing = await _bookRepository.GetByIdAsync(dto.Id);
        if (existing == null)
            return false;

        existing.Title = dto.Title;
        existing.Description = dto.Description;
        existing.Price = dto.Price;

        existing.AuthorId = dto.AuthorId;
        existing.PublisherId = dto.PublisherId;

        var genres = await _genreRepository.GetAllByIdsAsync(dto.GenreIds.ToArray());
        //TODO check empty?
        existing.Genres = genres.ToList();
        // TODO update reviews - in ReviewService?

        await _bookRepository.SaveChangesAsync();
        return true;
    }

    // DELETE
    public async Task<bool> DeleteBookAsync(int id)
    {
        var existing = await _bookRepository.GetByIdAsync(id);
        if (existing == null)
            return false;

        _bookRepository.Delete(existing);
        await _bookRepository.SaveChangesAsync();
        return true;
    }
}
