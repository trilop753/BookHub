using Business.DTOs.BookDTOs;

namespace Business.Services.Interfaces
{
    public interface IBookService
    {
        public Task<BookDto?> GetBookByIdAsync(int id);
        public Task<IEnumerable<BookDto>> GetAllBooksAsync();
        public Task<BookDto> CreateBookAsync(BookCreateDto dto);
        public Task<bool> UpdateBookAsync(BookUpdateDto dto);
        public Task<bool> DeleteBookAsync(int id);
        public Task<IEnumerable<BookSummaryDto>> GetFiltered(BookSearchCriteriaDto searchCriteria);
    }
}
