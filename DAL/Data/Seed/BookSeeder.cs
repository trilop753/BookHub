using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class BookSeeder
    {
        public static List<Book> Seed(this ModelBuilder modelBuilder)
        {
            var books = PrepareBookModels().AddCoverImageUrls();
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

        // Temporary solution. In Milestone3, creating books in book controller will be responsible for adding urls.
        private static List<Book> AddCoverImageUrls(this List<Book> books)
        {
            string[] coverImageUrls =
            {
                "https://www.epubbooks.com/images/covers/th/the-king-in-yellow-8d4d06.jpg", // The King in yellow
                "https://images2.patro.cz/550x600/000/000/081/000000081441_0.jpg", // Harry Potter and the Philosopher's Stone
                "https://www.slovart.cz/buxus/images/image_25007_19_v1.jpeg", // Little Prince
                "https://cdn.knihcentrum.cz/98535435_metro-2033-4.jpg", // Metro 2033
            };
            for (int i = 0; i < coverImageUrls.Length; i++)
            {
                books[i].CoverImageUrl = coverImageUrls[i];
            }
            return books;
        }
    }
}
