using BL.DTOs.BookReviewDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _repository;

        public BookReviewService(IBookReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<BookReviewDto>> CreateBookReviewAsync(
            BookReviewCreateDto bookReview
        )
        {
            var review = bookReview.MapToModel();

            await _repository.AddAsync(review);
            await _repository.SaveChangesAsync();

            return Result.Ok(review.MapToDto());
        }

        public async Task<Result> DeleteBookReviewAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null)
            {
                return Result.Fail($"Review with id {id} not found.");
            }

            _repository.Delete(review);
            await _repository.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result> UpdateBookReviewAsync(int id, BookReviewUpdateDto bookReview)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null)
            {
                return Result.Fail($"Review with id {id} not found.");
            }

            review.Stars = bookReview.Stars;
            review.Body = bookReview.Body;

            await _repository.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<Result<BookReviewDto>> GetByIdAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null)
            {
                return Result.Fail($"Review with id {id} not found.");
            }

            return Result.Ok(review.MapToDto());
        }

        public async Task<IEnumerable<BookReviewDto>> GetAllAsync()
        {
            var reviews = await _repository.GetAllAsync();
            return reviews.Select(r => r.MapToDto());
        }

        public async Task<IEnumerable<BookReviewDto>> GetAllByBookIdAsync(int bookId)
        {
            var reviews = await _repository.GetByBookIdAsync(bookId);
            return reviews.Select(r => r.MapToDto());
        }
    }
}
