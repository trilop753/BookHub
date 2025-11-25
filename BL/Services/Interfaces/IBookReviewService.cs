using BL.DTOs.BookReviewDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IBookReviewService
    {
        Task<Result<BookReviewDto>> CreateBookReviewAsync(BookReviewCreateDto bookReview);
        Task<Result> DeleteBookReviewAsync(int id);
        Task<Result> UpdateBookReviewAsync(int id, BookReviewUpdateDto bookReview);
        Task<Result<BookReviewDto>> GetByIdAsync(int id);
        Task<IEnumerable<BookReviewDto>> GetAllAsync();
        Task<IEnumerable<BookReviewDto>> GetAllByBookIdAsync(int bookId);
    }
}
