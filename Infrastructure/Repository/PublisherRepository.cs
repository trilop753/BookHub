using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository
{
	public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
	{
		public PublisherRepository(BookHubDbContext context)
			: base(context) { }
	}
}
