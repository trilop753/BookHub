using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IBookReviewRepository : IGenericRepository<BookReview>
    {
        Task<IEnumerable<BookReview>> GetByBookIdAsync(int bookId);
        Task<IEnumerable<BookReview>> GetByUserIdAsync(int userId);
    }
}
