using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre?> GetByNameAsync(string name);
        Task<IEnumerable<Genre>> GetManyByNameAsync(string query);
        Task<IEnumerable<Genre>> GetAllWithBooksAsync();
    }
}
