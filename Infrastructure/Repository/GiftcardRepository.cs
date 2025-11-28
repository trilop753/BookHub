using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GiftcardRepository : GenericRepository<Giftcard>, IGiftcardRepository
    {
        private readonly DbSet<GiftcardCode> _codes;

        public GiftcardRepository(BookHubDbContext context)
            : base(context)
        {
            _codes = context.Set<GiftcardCode>();
        }

        public async Task<GiftcardCode?> GetCodeByValueAsync(string code)
        {
            return await _codes
                .Include(c => c.Giftcard)
                .FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<IEnumerable<Giftcard>> GetAllAsync()
        {
            return await _dbSet
                .Include(g => g.Codes)
                .ToListAsync();
        }

        public async Task<Giftcard?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(g => g.Codes)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}