using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BookHubDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(BookHubDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); // automatically selects correct DbSet based on T
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        async public Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync<T>();
        }

        async public Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }



        async public Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
