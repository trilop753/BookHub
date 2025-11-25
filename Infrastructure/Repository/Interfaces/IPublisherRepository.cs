using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<Publisher?> GetByNameAsync(string name);
        Task<IEnumerable<Publisher>> GetAllWithBooksAsync();
    }
}
