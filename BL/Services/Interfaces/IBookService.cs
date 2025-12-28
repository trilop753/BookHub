using BL.DTOs.BookDTOs;
using BL.DTOs.UtilityDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IBookService
    {
        public Task<Result<BookDto>> GetBookByIdAsync(int id);
        public Task<Result<IEnumerable<BookDto>>> GetBooksByIdsAsync(int[] id);
        public Task<PaginatedResult<BookDto>> GetAllBooksAsync(int? page = null, int pageSize = 4);
        public Task<Result<BookDto>> CreateBookAsync(BookCreateDto dto);
        public Task<Result> UpdateBookAsync(int id, BookUpdateDto dto);
        public Task<Result<string>> DeleteBookAsync(int id);
        public Task<IEnumerable<BookSummaryDto>> GetFilteredAsync(
            BookSearchCriteriaDto searchCriteria
        );
    }
}
