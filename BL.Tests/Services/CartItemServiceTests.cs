using BL.DTOs.CartItemDTOs;
using BL.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestUtils.Data;
using TestUtils.MockedObjects;

namespace BL.Tests.Services
{
    public class CartItemServiceTests
    {
        private MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public CartItemServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task CreateCartItemAsync_ShouldFailForZeroQuantity()
        {
            int userId = 1;
            int bookId = 1;
            int quantity = 0;

            var dto = new CartItemCreateDto
            {
                Quantity = quantity,
                BookId = bookId,
                UserId = userId,
            };

            using (var scope = _serviceProviderBuilder.Create().CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.CreateCartItemAsync(dto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task CreateCartItemAsync_ShouldCreateAndReturnDto()
        {
            var repository_mock = Substitute.For<ICartItemRepository>();

            int userId = 1;
            int bookId = 1;
            int quantity = 1;

            var dto = new CartItemCreateDto
            {
                Quantity = quantity,
                BookId = bookId,
                UserId = userId,
            };

            int id = 1;

            var fakeBook = TestDataHelper.GetFakeBooks().First(book => book.Id == bookId);
            fakeBook.Author = new Author { Id = 1, Name = "test_author_1" };
            fakeBook.Publisher = new Publisher { Id = 1, Name = "test_publisher_1" };
            fakeBook.Genres = new List<Genre>();
            fakeBook.Reviews = new List<BookReview>();

            var fakeUser = TestDataHelper.GetFakeUsers().First(user => user.Id == userId);

            var created = new CartItem
            {
                UserId = userId,
                BookId = bookId,
                Quantity = quantity,
            };

            repository_mock
                .GetByUserIdAndBookIdAsync(Arg.Any<int>(), Arg.Any<int>())
                .Returns(Task.FromResult<CartItem?>(null));

            repository_mock
                .AddAsync(Arg.Any<CartItem>())
                .Returns(input =>
                {
                    var entity = input.Arg<CartItem>();
                    entity.Id = id;
                    entity.Book = fakeBook;
                    entity.User = fakeUser;
                    return Task.CompletedTask;
                });

            repository_mock.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<ICartItemRepository>(repository_mock)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.CreateCartItemAsync(dto);

                Assert.True(result.IsSuccess);
                Assert.NotNull(result.Value);
                Assert.Equal(result.Value.Id, id);
                Assert.Equal(result.Value.User.Id, userId);
                Assert.Equal(result.Value.Book.Id, bookId);
                Assert.Equal(result.Value.Quantity, quantity);
            }
        }

        [Fact]
        public async Task DeleteCartItemAsync_ShouldDeleteExisting()
        {
            var repository_mock = Substitute.For<ICartItemRepository>();

            var idToDelete = 1;
            var toDelete = new CartItem { Id = idToDelete };

            repository_mock
                .GetByIdAsync(Arg.Any<int>())
                .Returns(Task.FromResult<CartItem?>(toDelete));

            repository_mock.When(x => x.Delete(Arg.Any<CartItem>())).Do(_ => { });

            repository_mock.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<ICartItemRepository>(repository_mock)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.DeleteCartItemAsync(idToDelete);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task DeleteCartItemAsync_ShouldFailDoesNotExist()
        {
            var repository_mock = Substitute.For<ICartItemRepository>();

            var idToDelete = 1;
            repository_mock.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<CartItem?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<ICartItemRepository>(repository_mock)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.DeleteCartItemAsync(idToDelete);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeleteCartItemsAsync_ShouldDeleteAllExisting()
        {
            var repositoryMock = Substitute.For<ICartItemRepository>();

            var idsToDelete = new[] { 1, 2, 3 };
            repositoryMock
                .GetExistingIdsAsync(idsToDelete)
                .Returns(Task.FromResult<IEnumerable<int>>(idsToDelete));

            repositoryMock
                .When(x => x.DeleteCartItemsAsync(Arg.Any<IEnumerable<int>>()))
                .Do(_ => { });

            var serviceProvider = _serviceProviderBuilder.AddScoped(repositoryMock).Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.DeleteCartItemsAsync(idsToDelete);

                Assert.True(result.IsSuccess);
                Assert.Empty(result.Errors);
            }
        }

        [Fact]
        public async Task DeleteCartItemsAsync_ShouldFailNotAllExisting()
        {
            var repositoryMock = Substitute.For<ICartItemRepository>();

            var requestedIds = new[] { 1, 2, 3 };
            var existingIds = new[] { 1 };

            repositoryMock
                .GetExistingIdsAsync(requestedIds)
                .Returns(Task.FromResult<IEnumerable<int>>(existingIds));

            var serviceProvider = _serviceProviderBuilder.AddScoped(repositoryMock).Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.DeleteCartItemsAsync(requestedIds);

                Assert.True(result.IsFailed);
                Assert.Equal(2, result.Errors.Count);
            }
        }

        [Fact]
        public async Task GetCartItemsByUserIdAsync_ShouldReturnMappedDtos()
        {
            var repositoryMock = Substitute.For<ICartItemRepository>();

            int userId = 1;

            var fakeBook = TestDataHelper.GetFakeBooks().First(book => book.Id == 1);
            fakeBook.Author = new Author { Id = 1, Name = "test_author_1" };
            fakeBook.Publisher = new Publisher { Id = 1, Name = "test_publisher_1" };
            fakeBook.Genres = new List<Genre>();
            fakeBook.Reviews = new List<BookReview>();

            var fakeUser = TestDataHelper.GetFakeUsers().First(user => user.Id == userId);

            var fakeCartItems = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    UserId = userId,
                    BookId = fakeBook.Id,
                    Quantity = 2,
                    User = fakeUser,
                    Book = fakeBook,
                },
                new CartItem
                {
                    Id = 2,
                    UserId = userId,
                    BookId = fakeBook.Id,
                    Quantity = 1,
                    User = fakeUser,
                    Book = fakeBook,
                },
            };

            repositoryMock
                .GetByUserIdAsync(Arg.Any<int>())
                .Returns(Task.FromResult<IEnumerable<CartItem>>(fakeCartItems));

            var serviceProvider = _serviceProviderBuilder.AddScoped(repositoryMock).Create();

            using var scope = serviceProvider.CreateScope();
            var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

            var result = await cartItemService.GetCartItemsByUserIdAsync(userId);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);

            var dtos = result.Value.ToList();
            Assert.Equal(fakeCartItems.Count, dtos.Count);

            for (int i = 0; i < dtos.Count; i++)
            {
                Assert.Equal(fakeCartItems[i].Id, dtos[i].Id);
                Assert.Equal(fakeCartItems[i].Quantity, dtos[i].Quantity);
                Assert.Equal(fakeCartItems[i].Book.Id, dtos[i].Book.Id);
                Assert.Equal(fakeCartItems[i].User.Id, dtos[i].User.Id);
            }
        }

        [Fact]
        public async Task UpdateItemQuantityAsync_ShouldUpdateAndReturnDto()
        {
            var repositoryMock = Substitute.For<ICartItemRepository>();

            int id = 1;
            int newQuantity = 5;

            var fakeBook = TestDataHelper.GetFakeBooks().First();
            fakeBook.Author = new Author { Id = 1, Name = "test_author_1" };
            fakeBook.Publisher = new Publisher { Id = 1, Name = "test_publisher_1" };
            fakeBook.Genres = new List<Genre>();
            fakeBook.Reviews = new List<BookReview>();

            var fakeUser = TestDataHelper.GetFakeUsers().First();

            var updated = new CartItem
            {
                Id = id,
                Quantity = newQuantity,
                UserId = fakeUser.Id,
                BookId = fakeBook.Id,
                User = fakeUser,
                Book = fakeBook,
            };

            repositoryMock
                .UpdateItemQuantityAsync(Arg.Any<int>(), Arg.Any<int>())
                .Returns(Task.FromResult<CartItem?>(updated));

            var serviceProvider = _serviceProviderBuilder.AddScoped(repositoryMock).Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.UpdateItemQuantityAsync(id, newQuantity);

                Assert.True(result.IsSuccess);
                Assert.NotNull(result.Value);
                Assert.Equal(id, result.Value.Id);
                Assert.Equal(newQuantity, result.Value.Quantity);
            }
        }

        [Fact]
        public async Task UpdateItemQuantityAsync_ShouldFailForZeroQuantity()
        {
            int id = 1;
            int negativeQuantity = 0;

            using (var scope = _serviceProviderBuilder.Create().CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await service.UpdateItemQuantityAsync(id, negativeQuantity);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateItemQuantityAsync_ShouldFailDoesNotExist()
        {
            var repositoryMock = Substitute.For<ICartItemRepository>();

            int id = 1;
            int newQuantity = 5;

            repositoryMock
                .UpdateItemQuantityAsync(Arg.Any<int>(), Arg.Any<int>())
                .Returns(Task.FromResult<CartItem?>(null));

            var serviceProvider = _serviceProviderBuilder.AddScoped(repositoryMock).Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var cartItemService = scope.ServiceProvider.GetRequiredService<ICartItemService>();

                var result = await cartItemService.UpdateItemQuantityAsync(id, newQuantity);

                Assert.True(result.IsFailed);
            }
        }
    }
}
