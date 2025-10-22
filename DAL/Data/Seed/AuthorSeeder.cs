using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
	public static class AuthorSeeder
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var authors = PrepareAuthorModels();

			modelBuilder.Entity<Author>().HasData(authors);
		}

		private static List<Author> PrepareAuthorModels()
		{
			return new List<Author>
			{
				new Author
				{
					Id = 1,
					Name = "J.R.R.",
					Surname = "Tolkien",
				},
				new Author
				{
					Id = 2,
					Name = "Robert W.",
					Surname = "Chambers",
				},
				new Author
				{
					Id = 3,
					Name = "Stephen",
					Surname = "King",
				},
				new Author
				{
					Id = 4,
					Name = "Jane",
					Surname = "Austen",
				},
				new Author
				{
					Id = 5,
					Name = "Isaac",
					Surname = "Asimov",
				},
			};
		}
	}
}
