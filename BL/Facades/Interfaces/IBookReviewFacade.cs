using BL.DTOs.BookReviewDTOs;
using FluentResults;

namespace BL.Facades.Interfaces
{
    public interface IBookReviewFacade
    {
        Task<Result<IEnumerable<BookReviewDto>>> GetAllAsync();
        Task<Result<BookReviewDto>> GetByIdAsync(int id);
        Task<Result<IEnumerable<BookReviewDto>>> GetByBookAsync(int bookId);
        Task<Result<BookReviewDto>> CreateAsync(BookReviewCreateDto dto);
        Task<Result> UpdateAsync(int id, int userId, BookReviewUpdateDto dto);
        Task<Result> DeleteAsync(int id);
    }
}
