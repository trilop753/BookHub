using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserWithCartAsync(int id);
    }
}
