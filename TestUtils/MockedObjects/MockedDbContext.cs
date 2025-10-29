using DAL.Data;
using EntityFrameworkCore.Testing.NSubstitute.Helpers;
using Microsoft.EntityFrameworkCore;
using TestUtils.Data;

namespace TestUtils.MockedObjects
{
    public static class MockedDBContext
    {
        public static string RandomDBName => Guid.NewGuid().ToString();

        public static DbContextOptions<BookHubDbContext> GenerateNewInMemoryDBContextOptions()
        {
            var options = new DbContextOptionsBuilder<BookHubDbContext>()
                .UseInMemoryDatabase(RandomDBName)
                .Options;

            return options;
        }

        public static BookHubDbContext CreateFromOptions(DbContextOptions<BookHubDbContext> options)
        {
            var dbContextToMock = new BookHubDbContext(options);

            var dbContext = new MockedDbContextBuilder<BookHubDbContext>()
                .UseDbContext(dbContextToMock)
                .UseConstructorWithParameters(options)
                .MockedDbContext;

            PrepareData(dbContext);

            return dbContext;
        }

        public static void PrepareData(BookHubDbContext dbContext)
        {
            dbContext.Author.AddRange(TestDataHelper.GetFakeAuthors());
            dbContext.Publisher.AddRange(TestDataHelper.GetFakePublishers());
            dbContext.Genre.AddRange(TestDataHelper.GetFakeGenres());
            dbContext.Book.AddRange(TestDataHelper.GetFakeBooks());
            dbContext.User.AddRange(TestDataHelper.GetFakeUsers());
            dbContext.WishlistItem.AddRange(TestDataHelper.GetFakeWishlistItems());
            dbContext.CartItem.AddRange(TestDataHelper.GetFakeCartItems());

            dbContext.SaveChanges();
        }

        public static async Task PrepareDataAsync(BookHubDbContext dbContext)
        {
            dbContext.Author.AddRange(TestDataHelper.GetFakeAuthors());
            dbContext.Publisher.AddRange(TestDataHelper.GetFakePublishers());
            dbContext.Genre.AddRange(TestDataHelper.GetFakeGenres());
            dbContext.Book.AddRange(TestDataHelper.GetFakeBooks());
            dbContext.User.AddRange(TestDataHelper.GetFakeUsers());
            dbContext.WishlistItem.AddRange(TestDataHelper.GetFakeWishlistItems());
            dbContext.CartItem.AddRange(TestDataHelper.GetFakeCartItems());

            await dbContext.SaveChangesAsync();
        }
    }
}
