using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly BookHubDbContext _context;

        public AuthorRepository(BookHubDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Author?> GetByFullNameAsync(string name, string surname)
        {
            return await _context
                .Authors.AsNoTracking()
                .FirstOrDefaultAsync(a =>
                    a.Name.ToLower() == name.ToLower() && a.Surname.ToLower() == surname.ToLower()
                );
        }

        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await _context
                .Authors.Include(a => a.Books)
                .ThenInclude(b => b.Publisher)
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
