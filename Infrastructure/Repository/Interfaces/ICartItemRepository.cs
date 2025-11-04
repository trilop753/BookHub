using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Updates quantity of a CartItem.
        /// Must be called with quantity > 0.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<CartItem?> UpdateItemQuantityAsync(int id, int quantity);

        Task<CartItem?> GetByUserIdAndBookId(int userId, int bookId);

        Task<IEnumerable<int>> GetExistingIds(IEnumerable<int> ids);

        Task DeleteCartItemsAsync(IEnumerable<int> ids);
    }
}
