using DAL.Models;
using DAL.UtilityModels;

namespace Infrastructure.Repository.Interfaces
{
	public interface IBookRepository : IGenericRepository<Book>
	{
		public Task<IEnumerable<Book>> GetBooksAsync(
			int[]? bookIds = null,
			bool includeAuthor = true,
			bool includePublisher = true,
			bool includeGenres = true,
			bool includeReviews = true
		);

		public Task<IEnumerable<Book>> GetFiltered(BookSearchCriteria searchCriteria);
	}
}
