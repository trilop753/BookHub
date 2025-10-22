using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
	public static class PublisherSeeder
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var publishers = PreparePublisherModels();

			modelBuilder.Entity<Publisher>().HasData(publishers);
		}

		private static List<Publisher> PreparePublisherModels()
		{
			return new List<Publisher>
			{
				new Publisher { Id = 1, Name = "Penguin Books" },
				new Publisher { Id = 2, Name = "HarperCollins" },
				new Publisher { Id = 3, Name = "Bloomsbury" },
				new Publisher { Id = 4, Name = "Vintage" },
			};
		}
	}
}
