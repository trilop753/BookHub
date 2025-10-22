using Business.DTOs.BookDTOs;
using Business.UtilClasses;

namespace Business.Services.Interfaces
{
    public interface IBookService
    {
        public Task<BookDto?> GetBookByIdAsync(int id);
        public Task<IEnumerable<BookDto>> GetAllBooksAsync();
        public Task<BookDto> CreateBookAsync(BookCreateDto dto);
        public Task<Result<bool>> UpdateBookAsync(int bookId, BookUpdateDto dto);
        public Task<bool> DeleteBookAsync(int id);
        public Task<IEnumerable<BookSummaryDto>> GetFiltered(BookSearchCriteriaDto searchCriteria);
    }
}
