using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<Genre?> GetByNameAsync(string name)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Genre>> GetAllWithBooksAsync()
        {
            return await _dbSet
                .Include(g => g.Books)
                .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                .ThenInclude(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
