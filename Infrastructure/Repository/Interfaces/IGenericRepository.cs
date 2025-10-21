using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByIdsAsync(int[] ids);
        Task SaveChangesAsync();
    }
}
