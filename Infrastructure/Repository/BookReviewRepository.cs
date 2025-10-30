using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BookReviewRepository : GenericRepository<BookReview>, IBookReviewRepository
    {
        public BookReviewRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<IEnumerable<BookReview>> GetByBookIdAsync(int bookId)
        {
            IQueryable<BookReview> query = _dbSet
                .Include(r => r.User)
                .Include(r => r.Book)
                .Where(r => r.BookId == bookId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<BookReview>> GetByUserIdAsync(int userId)
        {
            IQueryable<BookReview> query = _dbSet
                .Include(r => r.User)
                .Include(r => r.Book)
                .Where(r => r.UserId == userId);

            return await query.ToListAsync();
        }

        public async Task<BookReview?> GetByIdWithIncludesAsync(int id)
        {
            IQueryable<BookReview> query = _dbSet
                .Include(r => r.User)
                .Include(r => r.Book)
                .Where(r => r.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
