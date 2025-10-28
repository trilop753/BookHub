using Bogus;
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
            var faker = new Faker<Author>("en")
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Name, f => f.Name.FirstName())
                .RuleFor(a => a.Surname, f => f.Name.LastName());

            return faker.Generate(5);
        }
    }
}
