using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public static class DataInitializer
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var books = PrepairBookModels();
            var authors = PrepairAuthorModels();
            var publishers = PrepairPublisherModels();
            var genres = PrepairGenreModels();
            var users = PrepairUserModels();
            var bookReviews = PrepairBookReviewModels();



            modelBuilder.Entity<Book>()
                .HasData(books);

            modelBuilder.Entity<Author>()
                .HasData(authors);

            modelBuilder.Entity<Publisher>()
                .HasData(publishers);

            modelBuilder.Entity<Genre>()
                .HasData(genres);

            modelBuilder.Entity<User>()
                .HasData(users);

            modelBuilder.Entity<BookReview>()
                .HasData(bookReviews);

            modelBuilder.Entity("BookGenre").HasData(
                new { BooksId = 1, GenresId = 1 },
                new { BooksId = 2, GenresId = 2 }
                );
        }



        private static List<Book> PrepairBookModels()
        {
            return new List<Book>()
                {
                    new Book
                    {
                        Id = 1,
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        Description = "you dont know lotr?",
                        ISBN = "1231231231231",
                        Price = 10,
                        PublisherId = 1,
                        AuthorId = 1,
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "The King in Yellow",
                        Description = "test description",
                        ISBN = "1231231231232",
                        Price = 5,
                        PublisherId = 1,
                        AuthorId = 2,
                    },
                };
        }

        private static List<Author> PrepairAuthorModels()
        {
            return new List<Author>()
                {
                    new Author()
                    {
                        Id = 1,
                        Name = "J.R.R.",
                        Surname = "Tolkien",
                    },

                    new Author()
                    {
                        Id = 2,
                        Name = "Robert W.",
                        Surname = "Chambers",
                    },
                };
        }

        private static List<Publisher> PrepairPublisherModels()
        {
            return new List<Publisher>()
                {
                    new Publisher()
                    {
                        Id = 1,
                        Name = "publisher1",
                    },

                    new Publisher()
                    {
                        Id = 2,
                        Name = "publisher2",
                    },
                };
        }
        private static List<BookReview> PrepairBookReviewModels()
        {
            return new List<BookReview>()
                {
                    new BookReview()
                    {
                        Id = 1,
                        Stars = 5,
                        Body = "best book!",
                        UserId = 1,
                        BookId = 1,
                    },

                    new BookReview()
                    {
                        Id = 2,
                        Stars = 4,
                        Body = "nice",
                        UserId = 1,
                        BookId = 2,
                    },
                };
        }

        private static List<User> PrepairUserModels()
        {
            return new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Username = "trilop",
                        Email = "example@gmail.com",
                        //PasswordHash = "hash",
                        //PasswordSalt = "salt",
                        IsBanned = false,
                    },

                    new User()
                    {
                        Id = 2,
                        Username = "username123",
                        Email = "example2@gmail.com",
                        //PasswordHash = "hash2",
                        //PasswordSalt = "salt2",
                        IsBanned = true,
                    },
                };
        }

        private static List<Genre> PrepairGenreModels()
        {
            return new List<Genre>()
                {
                    new Genre()
                    {
                        Id = 1,
                        Name = "Fantasy",
                    },

                    new Genre()
                    {
                        Id = 2,
                        Name = "Horror",
                    },
                };
        }
    }

}
