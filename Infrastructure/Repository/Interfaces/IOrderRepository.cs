using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetDetailByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllDetailedAsync();
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    }
}
