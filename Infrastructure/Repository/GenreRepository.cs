using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly BookHubDbContext _context;

        public GenreRepository(BookHubDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Genre?> GetByNameAsync(string name)
        {
            return await _context
                .Genres.AsNoTracking()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Genre>> GetAllWithBooksAsync()
        {
            return await _context
                .Genres.Include(g => g.Books)
                .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                .ThenInclude(b => b.Publisher)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
