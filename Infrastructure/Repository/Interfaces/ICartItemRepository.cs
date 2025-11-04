using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId);

        /// <summary>
        /// If quantity == 0, behaves just as like delete.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<CartItem?> UpdateItemQuantityAsync(int id, int quantity);

        Task<CartItem?> GetByUserIdAndBookIdAsync(int userId, int bookId);

        Task<IEnumerable<int>> GetExistingIdsAsync(IEnumerable<int> ids);

        Task DeleteCartItemsAsync(IEnumerable<int> ids);
    }
}
