using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
	public static class BookReviewSeeder
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var reviews = PrepareBookReviewModels();

			modelBuilder.Entity<BookReview>().HasData(reviews);
		}

		private static List<BookReview> PrepareBookReviewModels()
		{
			return new List<BookReview>
			{
				new BookReview
				{
					Id = 1,
					Stars = 5,
					Body = "Absolutely loved it! A masterpiece of fantasy.",
					UserId = 1,
					BookId = 1,
				},
				new BookReview
				{
					Id = 2,
					Stars = 4,
					Body = "Creepy, atmospheric, and unique.",
					UserId = 2,
					BookId = 2,
				},
				new BookReview
				{
					Id = 3,
					Stars = 5,
					Body = "Classic romance with wit and heart.",
					UserId = 3,
					BookId = 3,
				},
			};
		}
	}
}
