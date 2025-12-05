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
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 5))
                .RuleFor(i => i.BookAuthor, f => f.Name.FirstName() + f.Name.LastName())
                .RuleFor(i => i.BookPublisher, f => f.Company.CompanyName())
                .FinishWith(
                    (f, item) =>
                    {
                        var book = f.PickRandom(books);

                        item.BookTitle = book.Title;
                        item.BookISBN = book.ISBN;
                        item.BookPrice = book.Price;
                    }
                );

            List<OrderItem> orderItems = new();

            foreach (var order in orders)
            {
                int count = new Random().Next(1, 4);
                var items = faker.Generate(count);

                foreach (var item in items)
                {
                    item.OrderId = order.Id;
                }

                orderItems.AddRange(items);
            }

            return orderItems;
        }
    }
}
