using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class CartItemsSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder, List<User> users, List<Book> books)
        {
            var cartItems = PrepareCartItemModels(users, books);
            modelBuilder.Entity<CartItem>().HasData(cartItems);
        }

        private static List<CartItem> PrepareCartItemModels(List<User> users, List<Book> books)
        {
            var faker = new Faker<CartItem>("en")
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.UserId, f => f.PickRandom(users).Id)
                .RuleFor(c => c.BookId, f => f.PickRandom(books).Id)
                .RuleFor(c => c.Quantity, f => f.Random.Int(1, 5));

            return faker.Generate(4);
        }
    }
}
