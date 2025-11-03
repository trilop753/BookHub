using BL.DTOs.BookReviewDTOs;
using BL.Facades.Interfaces;
using BL.Services.Interfaces;
using FluentResults;

namespace BL.Facades
{
    public class BookReviewFacade : IBookReviewFacade
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IBookReviewService _bookReviewService;

        public BookReviewFacade(
            IBookService bookService,
            IUserService userService,
            IBookReviewService bookReviewService
        )
        {
            _bookService = bookService;
            _userService = userService;
            _bookReviewService = bookReviewService;
        }

        public async Task<Result<BookReviewDto>> CreateAsync(BookReviewCreateDto dto)
        {
            var check = await CheckUserAndBookExistAsync(dto.UserId, dto.BookId);
            if (check.IsFailed)
            {
                return Result.Fail(check.Errors);
            }

            if (dto.Stars < 1 || dto.Stars > 5)
            {
                return Result.Fail("Stars must be between 1 and 5.");
            }

            return await _bookReviewService.CreateBookReviewAsync(dto);
        }

        public async Task<Result> UpdateAsync(int id, BookReviewUpdateDto dto)
        {
            var review = await _bookReviewService.GetByIdAsync(id);
            if (review.IsFailed)
            {
                return Result.Fail(review.Errors);
            }

            if (dto.Stars < 1 || dto.Stars > 5)
            {
                return Result.Fail("Stars must be between 1 and 5.");
            }

            return await _bookReviewService.UpdateBookReviewAsync(id, dto.Stars, dto.Body);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _bookReviewService.DeleteBookReviewAsync(id);
        }

        public async Task<Result<IEnumerable<BookReviewDto>>> GetAllAsync()
        {
            var reviews = await _bookReviewService.GetAllAsync();
            return Result.Ok(reviews);
        }

        public async Task<Result<BookReviewDto>> GetByIdAsync(int id)
        {
            return await _bookReviewService.GetByIdAsync(id);
        }

        public async Task<Result<IEnumerable<BookReviewDto>>> GetByBookAsync(int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);
            if (book.IsFailed)
            {
                return Result.Fail(book.Errors);
            }

            var reviews = await _bookReviewService.GetAllByBookIdAsync(bookId);
            return Result.Ok(reviews);
        }

        private async Task<Result> CheckUserAndBookExistAsync(int userId, int bookId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var book = await _bookService.GetBookByIdAsync(bookId);

            var result = Result.Ok();

            if (user.IsFailed)
            {
                result.WithErrors(user.Errors);
            }

            if (book.IsFailed)
            {
                result.WithErrors(book.Errors);
            }

            if (result.IsFailed)
            {
                return Result.Fail(result.Errors);
            }

            return result;
        }
    }
}
