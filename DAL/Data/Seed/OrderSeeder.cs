using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class OrderSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder, List<User> users, List<Book> books)
        {
            var orders = PrepareOrderModels(users, books);
            var orderItems = PrepareOrderItemsModels(books, orders);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderItem>().HasData(orderItems);
        }

        private static List<Order> PrepareOrderModels(List<User> users, List<Book> books)
        {
            var faker = new Faker<Order>("en")
                .RuleFor(o => o.Id, f => f.IndexFaker + 1)
                .RuleFor(o => o.UserId, f => f.PickRandom(users).Id)
                .RuleFor(
                    o => o.Date,
                    f => f.Date.Between(new DateTime(2015, 1, 1), new DateTime(2025, 12, 31))
                );

            return faker.Generate(4);
        }

        private static List<OrderItem> PrepareOrderItemsModels(List<Book> books, List<Order> orders)
        {
            var faker = new Faker<OrderItem>()
                .RuleFor(o => o.Id, f => f.IndexFaker + 1)
                .RuleFor(i => i.BookId, f => f.PickRandom(books).Id)
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 5));

            List<OrderItem> orderItems = new();

            foreach (var order in orders)
            {
                var itemsForThisOrder = faker.Generate(new Random().Next(1, 4));
                foreach (var item in itemsForThisOrder)
                {
                    item.OrderId = order.Id;
                }
                orderItems.AddRange(itemsForThisOrder);
            }

            return orderItems;
        }
    }
}
