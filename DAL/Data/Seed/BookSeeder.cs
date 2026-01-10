using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class BookSeeder
    {
        public static List<Book> Seed(this ModelBuilder modelBuilder, List<Genre> genres)
        {
            var books = PrepareBookModels();

            modelBuilder.Entity<Book>().HasData(books);

            var rand = new Random();
            var genreBooks = new List<GenreBook>();
            var idGen = 1;

            foreach (var book in books)
            {
                int count = rand.Next(1, 4);
                var selectedGenres = genres.OrderBy(g => rand.Next()).Take(count).ToList();
                int primaryIndex = rand.Next(selectedGenres.Count);

                for (int i = 0; i < selectedGenres.Count; i++)
                {
                    genreBooks.Add(
                        new GenreBook
                        {
                            Id = idGen++,
                            BookId = book.Id,
                            GenreId = selectedGenres[i].Id,
                            IsPrimary = i == primaryIndex,
                        }
                    );
                }
            }

            modelBuilder.Entity<GenreBook>().HasData(genreBooks);

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

            return faker.Generate(32);
        }
    }
}
