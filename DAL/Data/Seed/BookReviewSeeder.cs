using Bogus;
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
            var faker = new Faker<BookReview>("en")
                .RuleFor(r => r.Id, f => f.IndexFaker + 1)
                .RuleFor(r => r.Stars, f => f.Random.Int(1, 5))
                .RuleFor(r => r.Body, f => f.Lorem.Sentence(8, 2))
                .RuleFor(r => r.UserId, f => f.Random.Int(1, 8))
                .RuleFor(r => r.BookId, f => f.Random.Int(1, 4));

            return faker.Generate(6);
        }
    }
}
