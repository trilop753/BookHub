using Bogus;
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
            var faker = new Faker<User>("en")
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.IsBanned, f => f.Random.Bool(0.1f));

            return faker.Generate(8);
        }
    }
}
