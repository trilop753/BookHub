using DAL.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGiftcardRepository : IGenericRepository<Giftcard>
    {
        Task<GiftcardCode?> GetCodeByValueAsync(string code);
        Task<GiftcardCode?> GetCodeByIdAsync(int id);
    }
}
