using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class WishlistItemRepository : GenericRepository<WishlistItem>, IWishlistItemRepository
    {
        public WishlistItemRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<IEnumerable<WishlistItem>> GetAllWithBookIdAsync(int id)
        {
            return await _dbSet.Include(wishlistItem => wishlistItem.BookId == id).ToListAsync();
        }

        public async Task<IEnumerable<WishlistItem>> GetAllByUserIdAsync(int id)
        {
            return await _dbSet.Include(wishlistItem => wishlistItem.UserId == id).ToListAsync();
        }
    }
}
