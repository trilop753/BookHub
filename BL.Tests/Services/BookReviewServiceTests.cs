using BL.DTOs.BookReviewDTOs;
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
        private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public BookReviewServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task CreateBookReviewAsync_ShouldCreate()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            var createDto = new BookReviewCreateDto()
            {
                Stars = 5,
                Body = "Great book!",
                BookId = 1,
                UserId = 1,
            };

            repository
                .AddAsync(Arg.Any<BookReview>())
                .Returns(call =>
                {
                    var entity = call.Arg<BookReview>();
                    entity.Id = 1;
                    entity.User = new User
                    {
                        Id = 1,
                        Username = "John",
                        Cart = new List<CartItem>(),
                    };
                    entity.Book = new Book
                    {
                        Id = 1,
                        Title = "ExampleBook",
                        Description = "Example description",
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
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.CreateBookReviewAsync(createDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(createDto.Body, result.Value.Body);
                Assert.Equal(createDto.Stars, result.Value.Stars);
            }
        }

        [Fact]
        public async Task DeleteBookReviewAsync_ShouldDelete()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            var review = new BookReview()
            {
                Id = 1,
                Stars = 4,
                Body = "Nice book",
            };

            repository.GetByIdAsync(1).Returns(Task.FromResult<BookReview?>(review));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.DeleteBookReviewAsync(1);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task DeleteBookReviewAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<BookReview?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.DeleteBookReviewAsync(1);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateBookReviewAsync_ShouldUpdate()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            var review = new BookReview()
            {
                Id = 1,
                Stars = 3,
                Body = "Okay",
            };
            var updateDto = new BookReviewUpdateDto() { Stars = 5, Body = "Excellent!" };

            repository.GetByIdAsync(1).Returns(Task.FromResult<BookReview?>(review));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.UpdateBookReviewAsync(1, updateDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(updateDto.Body, review.Body);
                Assert.Equal(updateDto.Stars, review.Stars);
            }
        }

        [Fact]
        public async Task UpdateBookReviewAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<BookReview?>(null));

            var updateDto = new BookReviewUpdateDto() { Stars = 4, Body = "Nice" };

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.UpdateBookReviewAsync(1, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnReview()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            var review = new BookReview()
            {
                Id = 1,
                Stars = 5,
                Body = "Amazing read!",
                User = new User
                {
                    Id = 1,
                    Username = "Alice",
                    Cart = new List<CartItem>(),
                },
                Book = new Book
                {
                    Id = 1,
                    Title = "Book One",
                    Description = "Description",
                    ISBN = "1234567890",
                    Price = 10,
                    Genres = new List<Genre>(),
                    Publisher = new Publisher { Id = 1, Name = "Publisher" },
                    Author = new Author
                    {
                        Id = 1,
                        Name = "Jane",
                        Surname = "Doe",
                    },
                    Reviews = new List<BookReview>(),
                },
            };

            repository.GetByIdAsync(1).Returns(Task.FromResult<BookReview?>(review));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.GetByIdAsync(1);

                Assert.True(result.IsSuccess);
                Assert.Equal(review.Body, result.Value.Body);
            }
        }

        [Fact]
        public async Task GetByIdAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<BookReview?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.GetByIdAsync(1);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnList()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            var reviews = new List<BookReview>()
            {
                new BookReview
                {
                    Id = 1,
                    Stars = 5,
                    Body = "Great!",
                    User = new User
                    {
                        Id = 1,
                        Username = "Anna",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 1,
                        Title = "Book 1",
                        Description = "Description 1",
                        ISBN = "1111111111",
                        Price = 10,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Publisher" },
                        Author = new Author
                        {
                            Id = 1,
                            Name = "Anna",
                            Surname = "Doe",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
                new BookReview
                {
                    Id = 2,
                    Stars = 3,
                    Body = "Average",
                    User = new User
                    {
                        Id = 2,
                        Username = "Bob",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 2,
                        Title = "Book 2",
                        Description = "Description 2",
                        ISBN = "2222222222",
                        Price = 15,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 2, Name = "Publisher 2" },
                        Author = new Author
                        {
                            Id = 2,
                            Name = "Bob",
                            Surname = "Smith",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
            };

            repository.GetAllAsync().Returns(Task.FromResult<IEnumerable<BookReview>>(reviews));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.GetAllAsync();

                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task GetAllByBookIdAsync_ShouldReturnList()
        {
            var repository = Substitute.For<IBookReviewRepository>();
            var reviews = new List<BookReview>()
            {
                new BookReview
                {
                    Id = 1,
                    Stars = 5,
                    Body = "Nice",
                    BookId = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "Tom",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 1,
                        Title = "Book 1",
                        Description = "Description 1",
                        ISBN = "1111111111",
                        Price = 10,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Publisher" },
                        Author = new Author
                        {
                            Id = 1,
                            Name = "Tom",
                            Surname = "Tester",
                        },
                        Reviews = new List<BookReview>(),
                    },
                },
                new BookReview
                {
                    Id = 2,
                    Stars = 4,
                    Body = "Good",
                    BookId = 1,
                    User = new User
                    {
                        Id = 2,
                        Username = "Jerry",
                        Cart = new List<CartItem>(),
                    },
                    Book = new Book
                    {
                        Id = 1,
                        Title = "Book 1",
                        Description = "Description 1",
                        ISBN = "1111111111",
                        Price = 10,
                        Genres = new List<Genre>(),
                        Publisher = new Publisher { Id = 1, Name = "Publisher" },
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
                .GetByBookIdAsync(1)
                .Returns(Task.FromResult<IEnumerable<BookReview>>(reviews));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IBookReviewRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var reviewService = scope.ServiceProvider.GetRequiredService<IBookReviewService>();

                var result = await reviewService.GetAllByBookIdAsync(1);

                Assert.Equal(2, result.Count());
                Assert.All(result, r => Assert.Equal(1, r.Book.Id));
            }
        }
    }
}
