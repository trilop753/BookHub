using BL.DTOs.BookDTOs;
using BL.DTOs.UtilityDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IBookService
    {
        Task<Result<BookDto>> GetBookByIdAsync(int id);
        Task<Result<IEnumerable<BookDto>>> GetBooksByIdsAsync(int[] id);
        Task<PaginatedResult<BookDto>> GetAllBooksAsync(int? page = null, int pageSize = 4);
        Task<PaginatedResult<BookDto>> GetAllBooksAsync(
            string? q,
            int? page = null,
            int pageSize = 4
        );
        Task<Result<BookDto>> CreateBookAsync(BookCreateDto dto);
        Task<Result> UpdateBookAsync(int id, BookUpdateDto dto);
        Task<Result<string>> DeleteBookAsync(int id);
        Task<IEnumerable<BookSummaryDto>> GetFilteredAsync(BookSearchCriteriaDto searchCriteria);
    }
}
