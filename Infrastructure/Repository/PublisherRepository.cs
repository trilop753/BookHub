using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        private readonly BookHubDbContext _context;

        public PublisherRepository(BookHubDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Publisher?> GetByNameAsync(string name)
        {
            return await _context
                .Publishers.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Publisher>> GetAllWithBooksAsync()
        {
            return await _context
                .Publishers.Include(p => p.Books)
                .ThenInclude(b => b.Author)
                .Include(p => p.Books)
                .ThenInclude(b => b.Genres)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
