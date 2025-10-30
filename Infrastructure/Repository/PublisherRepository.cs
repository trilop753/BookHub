using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<Publisher?> GetByNameAsync(string name)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Publisher>> GetAllWithBooksAsync()
        {
            return await _dbSet
                .Include(p => p.Books)
                .ThenInclude(b => b.Author)
                .Include(p => p.Books)
                .ThenInclude(b => b.Genres)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
