using Bogus;
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
            var faker = new Faker<Publisher>("en")
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Company.CompanyName());

            return faker.Generate(4);
        }
    }
}
