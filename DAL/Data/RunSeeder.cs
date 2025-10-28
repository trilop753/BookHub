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
            UserSeeder.Seed(modelBuilder);
            BookSeeder.Seed(modelBuilder);
            BookReviewSeeder.Seed(modelBuilder);
        }
    }
}
