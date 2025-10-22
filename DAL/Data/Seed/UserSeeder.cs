using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
	public static class UserSeeder
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var users = PrepareUserModels();

			modelBuilder.Entity<User>().HasData(users);
		}

		private static List<User> PrepareUserModels()
		{
			return new List<User>
			{
				new User
				{
					Id = 1,
					Username = "admin",
					Email = "admin@bookhub.com",
					IsBanned = false,
				},
				new User
				{
					Id = 2,
					Username = "john",
					Email = "john.doe@gmail.com",
					IsBanned = false,
				},
				new User
				{
					Id = 3,
					Username = "emma",
					Email = "emma.reader@gmail.com",
					IsBanned = false,
				},
				new User
				{
					Id = 4,
					Username = "mike",
					Email = "mike.writer@gmail.com",
					IsBanned = false,
				},
			};
		}
	}
}
