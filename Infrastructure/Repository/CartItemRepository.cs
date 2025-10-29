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
            var item = await _dbSet.Where(i => i.Id == id).FirstOrDefaultAsync();

            if (item == null)
            {
                return null;
            }

            item.Quantity = quantity;

            if (quantity == 0)
            {
                Delete(item);
            }

            await SaveChangesAsync();

            return item;
        }
    }
}
