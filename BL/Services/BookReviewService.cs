using BL.DTOs.BookReviewDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using DAL.Models;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _reviewRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookReviewService(
            IBookReviewRepository reviewRepository,
            IBookRepository bookRepository,
            IUserRepository userRepository
        )
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<BookReviewDto>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.Select(r => r.MapToDto());
        }

        public async Task<Result<BookReviewDto>> GetByIdAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                return Result.Fail($"Review with id {id} not found.");
            }

            return Result.Ok(review.MapToDto());
        }

        public async Task<IEnumerable<BookReviewDto>> GetByBookAsync(int bookId)
        {
            var reviews = await _reviewRepository.GetByBookIdAsync(bookId);
            return reviews.Select(r => r.MapToDto());
        }

        public async Task<Result<BookReviewDto>> CreateAsync(BookReviewCreateDto dto)
        {
            var result = new Result();

            if (await _bookRepository.GetByIdAsync(dto.BookId) == null)
            {
                result.WithError($"Book with id {dto.BookId} not found.");
            }

            if (await _userRepository.GetByIdAsync(dto.UserId) == null)
            {
                result.WithError($"User with id {dto.UserId} not found.");
            }
            if (dto.Stars < 1 || dto.Stars > 5)
            {
                result.WithError("Stars must be between 1 and 5.");
            }

            if (result.IsFailed)
            {
                return result;
            }

            var review = new BookReview
            {
                Stars = dto.Stars,
                Body = dto.Body,
                BookId = dto.BookId,
                UserId = dto.UserId,
            };

            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();

            return Result.Ok(review.MapToDto());
        }

        public async Task<Result> UpdateAsync(int id, BookReviewUpdateDto dto)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                return Result.Fail($"Review with id {id} not found.");
            }

            review.Stars = dto.Stars;
            review.Body = dto.Body;

            await _reviewRepository.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                return Result.Fail($"Review with id {id} not found.");
            }

            _reviewRepository.Delete(review);
            await _reviewRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
