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
