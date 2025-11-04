using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId)
        {
            return await _dbSet.Where(i => i.UserId == userId).ToListAsync();
        }

        public async Task<CartItem?> GetByUserIdAndBookId(int userId, int bookId)
        {
            return await _dbSet
                .Where(i => i.UserId == userId && i.BookId == bookId)
                .FirstOrDefaultAsync();
        }

        public async Task<CartItem?> UpdateItemQuantityAsync(int id, int quantity)
        {
            if (quantity <= 0)
            {
                return null;
            }

            var item = await _dbSet.Where(i => i.Id == id).FirstOrDefaultAsync();

            if (item == null)
            {
                return null;
            }

            item.Quantity = quantity;

            await SaveChangesAsync();

            return item;
        }

        public async Task DeleteCartItemsAsync(IEnumerable<int> ids)
        {
            var cartItems = await _dbSet.Where(i => ids.Contains(i.Id)).ToListAsync();

            _dbSet.RemoveRange(cartItems);

            await SaveChangesAsync();
        }

        public async Task<IEnumerable<int>> GetExistingIds(IEnumerable<int> ids)
        {
            return await _dbSet.Where(i => ids.Contains(i.Id)).Select(i => i.Id).ToListAsync();
        }
    }
}
