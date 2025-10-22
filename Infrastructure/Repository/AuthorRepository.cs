using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository
{
	public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
	{
		public AuthorRepository(BookHubDbContext context)
			: base(context) { }
	}
}
