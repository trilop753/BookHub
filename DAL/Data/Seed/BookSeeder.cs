using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class BookSeeder
    {
        public static List<Book> Seed(this ModelBuilder modelBuilder)
        {
            var books = PrepareBookModels();
            modelBuilder.Entity<Book>().HasData(books);

            modelBuilder
                .Entity("BookGenre")
                .HasData(
                    new { BooksId = 1, GenresId = 1 },
                    new { BooksId = 1, GenresId = 4 },
                    new { BooksId = 2, GenresId = 2 },
                    new { BooksId = 3, GenresId = 3 },
                    new { BooksId = 4, GenresId = 5 }
                );

            return books;
        }

        private static List<Book> PrepareBookModels()
        {
            var faker = new Faker<Book>("en")
                .RuleFor(b => b.Id, f => f.IndexFaker + 1)
                .RuleFor(b => b.Title, f => f.Lorem.Sentence(4, 2))
                .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                .RuleFor(b => b.ISBN, f => f.Commerce.Ean13())
                .RuleFor(b => b.Price, f => decimal.Parse(f.Commerce.Price(5, 20)))
                .RuleFor(b => b.AuthorId, f => f.Random.Int(1, 5))
                .RuleFor(b => b.PublisherId, f => f.Random.Int(1, 4))
                .RuleFor(b => b.EditCount, f => f.Random.Int(0, 10))
                .RuleFor(b => b.LastEditedById, f => f.Random.Int(1, 5));

            return faker.Generate(4);
        }
    }
}
