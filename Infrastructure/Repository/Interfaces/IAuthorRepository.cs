using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetByFullNameAsync(string name, string surname);
        Task<IEnumerable<Author>> GetByNameAsync(string query);
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
    }
}
