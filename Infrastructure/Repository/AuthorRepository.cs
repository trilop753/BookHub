using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookHubDbContext context)
            : base(context) { }

        public async Task<Author?> GetByFullNameAsync(string name, string surname)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(a =>
                    a.Name.ToLower() == name.ToLower() && a.Surname.ToLower() == surname.ToLower()
                );
        }

        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await _dbSet
                .Include(a => a.Books)
                .ThenInclude(b => b.Publisher)
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
