using BL.DTOs.BookDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IBookService
    {
        Task<Result<BookDto>> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<Result<BookDto>> CreateBookAsync(BookCreateDto dto);
        Task<Result> UpdateBookAsync(int id, BookUpdateDto dto);
        Task<Result> DeleteBookAsync(int id);
        Task<IEnumerable<BookSummaryDto>> GetFilteredAsync(BookSearchCriteriaDto searchCriteria);
    }
}
