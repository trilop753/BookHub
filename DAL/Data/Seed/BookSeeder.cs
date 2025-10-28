using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class BookSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var books = PrepareBookModels();

            modelBuilder.Entity<Book>().HasData(books);

            modelBuilder
                .Entity("BookGenre")
                .HasData(
                    new { BooksId = 1, GenresId = 1 },
                    new { BooksId = 2, GenresId = 2 },
                    new { BooksId = 2, GenresId = 3 },
                    new { BooksId = 3, GenresId = 4 },
                    new { BooksId = 4, GenresId = 5 }
                );
        }

        private static List<Book> PrepareBookModels()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Description = "Classic high fantasy adventure.",
                    ISBN = "9780547928210",
                    Price = 10.99m,
                    AuthorId = 1,
                    PublisherId = 1,
                },
                new Book
                {
                    Id = 2,
                    Title = "The King in Yellow",
                    Description = "A collection of weird horror stories.",
                    ISBN = "9780486226886",
                    Price = 6.99m,
                    AuthorId = 2,
                    PublisherId = 2,
                },
                new Book
                {
                    Id = 3,
                    Title = "Pride and Prejudice",
                    Description = "A romantic novel of manners.",
                    ISBN = "9780141439518",
                    Price = 8.49m,
                    AuthorId = 4,
                    PublisherId = 3,
                },
                new Book
                {
                    Id = 4,
                    Title = "Foundation",
                    Description = "Science fiction classic about the fall of the Galactic Empire.",
                    ISBN = "9780553293357",
                    Price = 9.99m,
                    AuthorId = 5,
                    PublisherId = 4,
                },
            };
        }
    }
}
