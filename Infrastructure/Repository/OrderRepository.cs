using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<Order?> GetDetailByIdAsync(int id)
        {
            return await _dbSet
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .Include(o => o.GiftcardCode)
                .ThenInclude(gc => gc.Giftcard)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAllDetailedAsync()
        {
            return await _dbSet
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .Include(o => o.GiftcardCode)
                .ThenInclude(gc => gc.Giftcard)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .Include(o => o.GiftcardCode)
                .ThenInclude(gc => gc.Giftcard)
                .ToListAsync();
        }
    }
}
