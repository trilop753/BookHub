using Business.DTOs.BookDTOs;
using Business.Mappers;
using Business.Services.Interfaces;
using Infrastructure.Repository.Interfaces;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
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

    //public async Task<BookDto> CreateBookAsync(BookDto dto)
    //{
    //    var entity = dto.MapToEntity();
    //    await _bookRepository.AddAsync(entity);
    //    await _bookRepository.SaveChangesAsync();

    //    return entity.MapToDto();
    //}

    public async Task<bool> UpdateBookAsync(BookDto dto)
    {
        var existing = await _bookRepository.GetByIdAsync(dto.Id);
        if (existing == null)
            return false;

        existing.Title = dto.Title;
        existing.Description = dto.Description;
        existing.Price = dto.Price;
        // TODO update genres,author,publisher ?

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
