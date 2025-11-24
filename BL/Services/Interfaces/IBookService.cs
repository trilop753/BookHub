using BL.DTOs.BookDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IBookService
    {
        public Task<Result<BookDto>> GetBookByIdAsync(int id);
        public Task<Result<IEnumerable<BookDto>>> GetBooksByIdsAsync(int[] id);
        public Task<IEnumerable<BookDto>> GetAllBooksAsync();
        public Task<Result<BookDto>> CreateBookAsync(BookCreateDto dto);
        public Task<Result> UpdateBookAsync(int id, BookUpdateDto dto);
        public Task<Result> DeleteBookAsync(int id);
        public Task<IEnumerable<BookSummaryDto>> GetFilteredAsync(
            BookSearchCriteriaDto searchCriteria
        );
    }
}
