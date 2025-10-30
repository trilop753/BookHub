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

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _dbSet.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
