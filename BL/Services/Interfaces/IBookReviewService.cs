using BL.DTOs.BookReviewDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IBookReviewService
    {
        Task<IEnumerable<BookReviewDto>> GetAllAsync();
        Task<Result<BookReviewDto>> GetByIdAsync(int id);
        Task<IEnumerable<BookReviewDto>> GetByBookAsync(int bookId);
        Task<Result<BookReviewDto>> CreateAsync(BookReviewCreateDto dto);
        Task<Result> UpdateAsync(int id, BookReviewUpdateDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
