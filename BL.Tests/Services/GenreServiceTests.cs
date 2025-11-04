using BL.DTOs.GenreDTOs;
using BL.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestUtils.MockedObjects;

namespace BL.Tests.Services
{
    public class GenreServiceTests
    {
        private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public GenreServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task GetGenreByIdAsync_ShouldReturnGenre()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var genre = new Genre() { Id = 1, Name = "Fantasy" };
            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Genre?>(genre));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.GetGenreByIdAsync(1);

                Assert.True(result.IsSuccess);
                Assert.Equal(genre.Name, result.Value.Name);
            }
        }

        [Fact]
        public async Task GetGenreByIdAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Genre?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.GetGenreByIdAsync(1);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task CreateGenreAsync_ShouldCreateGenre()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var genreCreate = new GenreCreateDto() { Name = "Drama" };

            repository.GetByNameAsync(Arg.Any<string>()).Returns(Task.FromResult<Genre?>(null));
            repository.AddAsync(Arg.Any<Genre>()).Returns(Task.CompletedTask);
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.CreateGenreAsync(genreCreate);

                Assert.True(result.IsSuccess);
                Assert.Equal(genreCreate.Name, result.Value.Name);
            }
        }

        [Fact]
        public async Task CreateGenreAsync_ShouldFailIfEmptyName()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var genreCreate = new GenreCreateDto() { Name = " " };

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.CreateGenreAsync(genreCreate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task CreateGenreAsync_ShouldFailIfDuplicate()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var genreCreate = new GenreCreateDto() { Name = "Horror" };
            var existing = new Genre() { Id = 1, Name = "Horror" };

            repository.GetByNameAsync(Arg.Any<string>()).Returns(Task.FromResult<Genre?>(existing));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.CreateGenreAsync(genreCreate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateGenreAsync_ShouldUpdate()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var genre = new Genre() { Id = id, Name = "Sci-Fi" };
            var updateDto = new GenreUpdateDto() { Name = "Science Fiction" };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Genre?>(genre));
            repository.GetByNameAsync(Arg.Any<string>()).Returns(Task.FromResult<Genre?>(null));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.UpdateGenreAsync(id, updateDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(updateDto.Name, genre.Name);
            }
        }

        [Fact]
        public async Task UpdateGenreAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Genre?>(null));

            var updateDto = new GenreUpdateDto() { Name = "Fiction" };

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.UpdateGenreAsync(1, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateGenreAsync_ShouldFailIfEmptyName()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var genre = new Genre() { Id = 1, Name = "Adventure" };
            var updateDto = new GenreUpdateDto() { Name = "" };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Genre?>(genre));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.UpdateGenreAsync(1, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateGenreAsync_ShouldFailIfDuplicate()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var genre = new Genre() { Id = id, Name = "Thriller" };
            var duplicate = new Genre() { Id = 2, Name = "Drama" };
            var updateDto = new GenreUpdateDto() { Name = "Drama" };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Genre?>(genre));
            repository.GetByNameAsync(updateDto.Name).Returns(Task.FromResult<Genre?>(duplicate));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.UpdateGenreAsync(id, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeleteGenreAsync_ShouldDelete()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var genre = new Genre()
            {
                Id = id,
                Name = "History",
                Books = new List<Book>(),
            };
            var books = new List<Book>();

            repository.GetByIdAsync(id).Returns(Task.FromResult<Genre?>(genre));
            bookRepository.GetBooksAsync().Returns(Task.FromResult<IEnumerable<Book>>(books));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.DeleteGenreAsync(id);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task DeleteGenreAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Genre?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.DeleteGenreAsync(1);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeleteGenreAsync_ShouldFailIfHasBooks()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var genre = new Genre()
            {
                Id = id,
                Name = "Romance",
                Books = new List<Book>() { new Book() { Title = "Existing Book" } },
            };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Genre?>(genre));
            bookRepository
                .GetBooksAsync()
                .Returns(Task.FromResult<IEnumerable<Book>>(new List<Book>()));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.DeleteGenreAsync(id);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeleteGenreAsync_ShouldFailIfBooksContainGenre()
        {
            var repository = Substitute.For<IGenreRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var genre = new Genre()
            {
                Id = id,
                Name = "Action",
                Books = new List<Book>(),
            };
            var books = new List<Book>
            {
                new Book
                {
                    Title = "Book with genre",
                    Genres = new List<Genre>
                    {
                        new Genre { Id = id, Name = "Action" },
                    },
                },
            };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Genre?>(genre));
            bookRepository.GetBooksAsync().Returns(Task.FromResult<IEnumerable<Book>>(books));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IGenreRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

                var result = await genreService.DeleteGenreAsync(id);

                Assert.True(result.IsFailed);
            }
        }
    }
}
