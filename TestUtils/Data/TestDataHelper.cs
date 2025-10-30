using DAL.Models;

namespace TestUtils.Data
{
    public static class TestDataHelper
    {
        public static IEnumerable<Author> GetFakeAuthors() =>
            new[]
            {
                new Author { Id = 1, Name = "test_author_1" },
                new Author { Id = 2, Name = "test_author_2" },
            };

        public static IEnumerable<Publisher> GetFakePublishers() =>
            new[]
            {
                new Publisher { Id = 1, Name = "test_publisher_1" },
                new Publisher { Id = 2, Name = "test_publisher_2" },
            };

        public static IEnumerable<Genre> GetFakeGenres() =>
            new[]
            {
                new Genre { Id = 1, Name = "test_genre_1" },
                new Genre { Id = 2, Name = "test_genre_2" },
                new Genre { Id = 3, Name = "test_genre_3" },
            };

        public static IEnumerable<Book> GetFakeBooks() =>
            new[]
            {
                new Book
                {
                    Id = 1,
                    Title = "test_book_1",
                    Description = "test_description_1",
                    ISBN = "111-1111111111",
                    Price = 10.0m,
                    AuthorId = 1,
                    PublisherId = 1,
                },
                new Book
                {
                    Id = 2,
                    Title = "test_book_2",
                    Description = "test_description_2",
                    ISBN = "222-2222222222",
                    Price = 20.0m,
                    AuthorId = 2,
                    PublisherId = 2,
                },
            };

        public static IEnumerable<User> GetFakeUsers() =>
            new[]
            {
                new User
                {
                    Id = 1,
                    Username = "test_user_1",
                    Email = "user1@test.com",
                },
                new User
                {
                    Id = 2,
                    Username = "test_user_2",
                    Email = "user2@test.com",
                },
            };

        public static IEnumerable<WishlistItem> GetFakeWishlistItems() =>
            new[]
            {
                new WishlistItem
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                },
                new WishlistItem
                {
                    Id = 2,
                    UserId = 2,
                    BookId = 2,
                },
            };

        public static IEnumerable<CartItem> GetFakeCartItems() =>
            new[]
            {
                new CartItem
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    Quantity = 1,
                },
                new CartItem
                {
                    Id = 2,
                    UserId = 2,
                    BookId = 2,
                    Quantity = 3,
                },
            };

        public static IEnumerable<BookReview> GetFakeReviews() =>
            new[]
            {
                new BookReview
                {
                    Id = 1,
                    BookId = 1,
                    UserId = 1,
                    Body = "test_review_1",
                    Stars = 5,
                },
                new BookReview
                {
                    Id = 2,
                    BookId = 2,
                    UserId = 2,
                    Body = "test_review_2",
                    Stars = 3,
                },
            };
    }
}
