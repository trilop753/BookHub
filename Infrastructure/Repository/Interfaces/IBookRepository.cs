using DAL.Models;
using DAL.UtilityModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<PaginatedResult<Book>> GetBooksAsync(
            int[]? bookIds = null,
            string? q = null,
            int? page = null,
            int pageSize = 4
        );


        public Task<IEnumerable<Book>> GetFilteredAsync(BookSearchCriteria searchCriteria);

        public Task<Book?> GetBookByIdWithGenresIncludedAsync(int bookId);
    }
}
