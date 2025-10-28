using DAL.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public static class RunSeeder
    {
        public static void SeedAll(this ModelBuilder modelBuilder)
        {
            AuthorSeeder.Seed(modelBuilder);
            PublisherSeeder.Seed(modelBuilder);
            GenreSeeder.Seed(modelBuilder);
            var users = UserSeeder.Seed(modelBuilder);
            var books = BookSeeder.Seed(modelBuilder);
            BookReviewSeeder.Seed(modelBuilder);
            CartItemsSeeder.Seed(modelBuilder, users, books);
        }
    }
}
