using BL.DTOs.WishlistItemDTOs;
using BL.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestUtils.MockedObjects;

namespace BL.Tests.Services
{
    public class WishlistItemServiceTests
    {
        private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public WishlistItemServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task CreateWishlistItemAsync_ShouldCreate()
        {
            var repository = Substitute.For<IWishlistItemRepository>();

            var createDto = new WishlistItemCreateDto { UserId = 1, BookId = 2 };

            repository
                .AddAsync(Arg.Any<WishlistItem>())
                .Returns(call =>
                {
                    var entity = call.Arg<WishlistItem>();
                    entity.Id = 1;
                    entity.User = new User
                    {
                        Id = 1,
                        Username = "John",
                        Cart = new List<CartItem>(),
                    };
                    entity.Book = new Book
                    {
                        Id = 2,
                        Title = "Mocked Book",
                        Description = "Test desc",
                        ISBN = "1234567890",
                        Price = 10,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Test Publisher" },
                        Author = new Author
                        {
                            Id = 1,
                            Name = "John",
                            Surname = "Doe",
                        },
                        Reviews = new List<BookReview>(),
                    };
                    return Task.CompletedTask;
                });

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.CreateWishlistItemAsync(createDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(createDto.UserId, result.Value.User.Id);
                Assert.Equal(createDto.BookId, result.Value.Book.Id);
            }
        }

        [Fact]
        public async Task CreateWishlistItemAsync_ShouldFailIfUserOrBookNotProvided()
        {
            var repository = Substitute.For<IWishlistItemRepository>();

            var createDto = new WishlistItemCreateDto { UserId = 0, BookId = 0 };

            repository
                .AddAsync(Arg.Any<WishlistItem>())
                .Returns(call =>
                {
                    var entity = call.Arg<WishlistItem>();
                    entity.Id = 1;
                    entity.User = new User
                    {
                        Id = 0,
                        Username = "Unknown",
                        Cart = new List<CartItem>(),
                    };
                    entity.Book = new Book
                    {
                        Id = 0,
                        Title = "Unknown",
                        Description = "",
                        ISBN = "",
                        Price = 0,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Placeholder" },
                        Author = new Author
                        {
                            Id = 1,
                            Name = "N/A",
                            Surname = "",
                        },
                        Reviews = new List<BookReview>(),
                    };
                    return Task.CompletedTask;
                });

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.CreateWishlistItemAsync(createDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(0, result.Value.User.Id);
                Assert.Equal(0, result.Value.Book.Id);
            }
        }

        [Fact]
        public async Task DeleteWishlistItemAsync_ShouldDelete()
        {
            var repository = Substitute.For<IWishlistItemRepository>();

            var wishlistItem = new WishlistItem
            {
                Id = 1,
                UserId = 1,
                BookId = 2,
                User = new User
                {
                    Id = 1,
                    Username = "TestUser",
                    Cart = new List<CartItem>(),
                },
                Book = new Book
                {
                    Id = 2,
                    Title = "TestBook",
                    Description = "Desc",
                    ISBN = "1234567890",
                    Price = 10,
                    Genres = new List<Genre>(),
                    Publisher = new Publisher { Id = 1, Name = "Pub" },
                    Author = new Author
                    {
                        Id = 1,
                        Name = "John",
                        Surname = "Doe",
                    },
                    Reviews = new List<BookReview>(),
                },
            };

            repository
                .GetByUserIdAndBookIdAsync(1, 2)
                .Returns(Task.FromResult<WishlistItem?>(wishlistItem));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.DeleteWishlistItemAsync(1, 2);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task DeleteWishlistItemAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IWishlistItemRepository>();

            repository
                .GetByUserIdAndBookIdAsync(Arg.Any<int>(), Arg.Any<int>())
                .Returns(Task.FromResult<WishlistItem?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.DeleteWishlistItemAsync(1, 2);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task GetAllBookWishlistItemsAsync_ShouldReturnList()
        {
            var repository = Substitute.For<IWishlistItemRepository>();

            var items = new List<WishlistItem>
            {
                new WishlistItem
                {
                    Id = 1,
                    BookId = 2,
                    UserId = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "Tom",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 2,
                        Title = "Book A",
                        Description = "Desc",
                        ISBN = "1111111111",
                        Price = 10,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Pub" },
                        Author = new Author
                        {
                            Id = 1,
                            Name = "Tom",
                            Surname = "Tester",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
                new WishlistItem
                {
                    Id = 2,
                    BookId = 2,
                    UserId = 2,
                    User = new User
                    {
                        Id = 2,
                        Username = "Jerry",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 2,
                        Title = "Book A",
                        Description = "Desc",
                        ISBN = "1111111111",
                        Price = 10,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Pub" },
                        Author = new Author
                        {
                            Id = 2,
                            Name = "Jerry",
                            Surname = "Mouse",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
            };

            repository
                .GetAllWithBookIdAsync(2)
                .Returns(Task.FromResult<IEnumerable<WishlistItem>>(items));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.GetAllBookWishlistItemsAsync(2);

                Assert.Equal(2, result.Count());
                Assert.All(result, x => Assert.Equal(2, x.Book.Id));
            }
        }

        [Fact]
        public async Task GetAllBookWishlistItemsAsync_ShouldReturnEmptyIfNoItems()
        {
            var repository = Substitute.For<IWishlistItemRepository>();
            repository
                .GetAllWithBookIdAsync(2)
                .Returns(Task.FromResult<IEnumerable<WishlistItem>>(new List<WishlistItem>()));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.GetAllBookWishlistItemsAsync(2);

                Assert.Empty(result);
            }
        }

        [Fact]
        public async Task GetAllUserWishlistItemsAsync_ShouldReturnList()
        {
            var repository = Substitute.For<IWishlistItemRepository>();

            var items = new List<WishlistItem>
            {
                new WishlistItem
                {
                    Id = 1,
                    BookId = 3,
                    UserId = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "Anna",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 3,
                        Title = "Book 1",
                        Description = "Desc 1",
                        ISBN = "1111111111",
                        Price = 12,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Pub1" },
                        Author = new Author
                        {
                            Id = 1,
                            Name = "Anna",
                            Surname = "Reader",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
                new WishlistItem
                {
                    Id = 2,
                    BookId = 4,
                    UserId = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "Anna",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 4,
                        Title = "Book 2",
                        Description = "Desc 2",
                        ISBN = "2222222222",
                        Price = 20,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 2, Name = "Pub2" },
                        Author = new Author
                        {
                            Id = 2,
                            Name = "Bob",
                            Surname = "Writer",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
            };

            repository
                .GetAllByUserIdAsync(1)
                .Returns(Task.FromResult<IEnumerable<WishlistItem>>(items));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.GetAllUserWishlistItemsAsync(1);

                Assert.Equal(2, result.Count());
                Assert.All(result, x => Assert.Equal(1, x.User.Id));
            }
        }

        [Fact]
        public async Task GetAllUserWishlistItemsAsync_ShouldReturnEmptyIfNoItems()
        {
            var repository = Substitute.For<IWishlistItemRepository>();
            repository
                .GetAllByUserIdAsync(1)
                .Returns(Task.FromResult<IEnumerable<WishlistItem>>(new List<WishlistItem>()));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IWishlistItemRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var wishlistService =
                    scope.ServiceProvider.GetRequiredService<IWishlistItemService>();

                var result = await wishlistService.GetAllUserWishlistItemsAsync(1);

                Assert.Empty(result);
            }
        }
    }
}
