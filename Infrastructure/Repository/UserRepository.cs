using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<User?> GetUserWithCartAsync(int id)
        {
            return await _dbSet
                .Where(u => u.Id == id)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Book)
                .FirstOrDefaultAsync();
        }
    }
}
