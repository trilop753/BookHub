using BL.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestUtils.MockedObjects;

namespace BL.Tests.Services
{
    public class BookReviewServiceTests
    {
        private MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public BookReviewServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task CreateBookReviewAsync_ShouldAddReviewAndReturnDto()
        {
            var bookReviewRepositoryMock = Substitute.For<IBookReviewRepository>();

            int userId = 1;
            int bookId = 101;
            int stars = 5;
            string body = "Amazing book!";

            bookReviewRepositoryMock.AddAsync(Arg.Any<BookReview>()).Returns(Task.CompletedTask);

            bookReviewRepositoryMock.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(bookReviewRepositoryMock)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var bookReviewService =
                    scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                // Act
                var result = await bookReviewService.CreateBookReviewAsync(
                    userId,
                    bookId,
                    stars,
                    body
                );

                // Assert
                Assert.NotNull(result);
                Assert.True(result.IsSuccess);
                Assert.Equal(userId, result.Value.User.Id);
                Assert.Equal(bookId, result.Value.Book.Id);
                Assert.Equal(stars, result.Value.Stars);
                Assert.Equal(body, result.Value.Body);
            }
        }
    }
}
