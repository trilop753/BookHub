using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IWishlistItemRepository : IGenericRepository<WishlistItem>
    {
        Task<IEnumerable<WishlistItem>> GetAllWithBookIdAsync(int id);

        Task<IEnumerable<WishlistItem>> GetAllByUserIdAsync(int id);

        Task<WishlistItem?> GetByUserIdAndBookId(int userId, int bookId);
    }
}
