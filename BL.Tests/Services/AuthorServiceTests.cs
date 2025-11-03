using BL.DTOs.AuthorDTOs;
using BL.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestUtils.MockedObjects;

namespace BL.Tests.Services
{
    public class AuthorServiceTests
    {
        private MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public AuthorServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task CreateAuthorAsync_ShouldAddAuthorAndReturnDto()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorCreate = new AuthorCreateDto() { Name = "Mocker", Surname = "Mockington" };

            repository
                .GetByFullNameAsync(Arg.Any<string>(), Arg.Any<string>())
                .Returns(Task.FromResult<Author?>(null));

            repository
                .AddAsync(Arg.Any<Author>())
                .Returns(input =>
                {
                    var entity = input.Arg<Author>();
                    entity.Id = authorId;
                    entity.Books = new List<Book>();
                    return Task.CompletedTask;
                });

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.CreateAuthorAsync(authorCreate);

                Assert.True(result.IsSuccess);
                Assert.True(!result.Value.Books.Any());
                Assert.Equal(authorId, result.Value.Id);
            }
        }

        [Fact]
        public async Task CreateAuthorAsync_ShouldFailEmptyName()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorCreate = new AuthorCreateDto() { Name = "", Surname = "Mockington" };

            repository
                .GetByFullNameAsync(Arg.Any<string>(), Arg.Any<string>())
                .Returns(Task.FromResult<Author?>(null));

            repository
                .AddAsync(Arg.Any<Author>())
                .Returns(input =>
                {
                    var entity = input.Arg<Author>();
                    entity.Id = authorId;
                    entity.Books = new List<Book>();
                    return Task.CompletedTask;
                });

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.CreateAuthorAsync(authorCreate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task CreateAuthorAsync_ShouldFailEmptySurname()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorCreate = new AuthorCreateDto() { Name = "Mocker", Surname = " " };

            repository
                .GetByFullNameAsync(Arg.Any<string>(), Arg.Any<string>())
                .Returns(Task.FromResult<Author?>(null));

            repository
                .AddAsync(Arg.Any<Author>())
                .Returns(input =>
                {
                    var entity = input.Arg<Author>();
                    entity.Id = authorId;
                    entity.Books = new List<Book>();
                    return Task.CompletedTask;
                });

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.CreateAuthorAsync(authorCreate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateAuthorAsync_ShouldUpdate()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorUpdate = new AuthorUpdateDto()
            {
                Name = "NameUpdate",
                Surname = "SurnameUpdate",
            };
            var author = new Author()
            {
                Id = authorId,
                Name = "Mocker",
                Surname = "Mockington",
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(author));

            repository
                .GetByFullNameAsync(Arg.Any<string>(), Arg.Any<string>())
                .Returns(Task.FromResult<Author?>(null));

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.UpdateAuthorAsync(authorId, authorUpdate);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task UpdateAuthorAsync_ShouldFailEmptyUpdateName()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorUpdate = new AuthorUpdateDto() { Name = "", Surname = "SurnameUpdate" };
            var author = new Author()
            {
                Id = authorId,
                Name = "Mocker",
                Surname = "Mockington",
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(author));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.UpdateAuthorAsync(authorId, authorUpdate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateAuthorAsync_ShouldFailEmptyUpdateSurname()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorUpdate = new AuthorUpdateDto() { Name = "NameUpdate", Surname = " " };
            var author = new Author()
            {
                Id = authorId,
                Name = "Mocker",
                Surname = "Mockington",
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(author));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.UpdateAuthorAsync(authorId, authorUpdate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateAuthorAsync_ShouldFailDoesNotExist()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorUpdate = new AuthorUpdateDto()
            {
                Name = "NameUpdate",
                Surname = "SurnameUpdate",
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.UpdateAuthorAsync(authorId, authorUpdate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdateAuthorAsync_ShouldFailDuplicate()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var authorUpdate = new AuthorUpdateDto() { Name = "Mocker", Surname = "Mockington" };
            var author = new Author()
            {
                Id = authorId,
                Name = "Mocker",
                Surname = "Mockington",
            };
            var authorDuplicate = new Author()
            {
                Id = authorId + 1,
                Name = "Mocker",
                Surname = "Mockington",
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(author));

            repository
                .GetByFullNameAsync(Arg.Any<string>(), Arg.Any<string>())
                .Returns(Task.FromResult<Author?>(authorDuplicate));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.UpdateAuthorAsync(authorId, authorUpdate);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeleteAuthorAsync_ShouldDelete()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var author = new Author()
            {
                Id = authorId,
                Name = "Mocker",
                Surname = "Mockington",
                Books = new List<Book>(),
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(author));

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.DeleteAuthorAsync(authorId);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task DeleteAuthorAsync_ShouldFailDoesNotExist()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(null));

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.DeleteAuthorAsync(authorId);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeleteAuthorAsync_ShouldFailHasBooks()
        {
            var repository = Substitute.For<IAuthorRepository>();

            var authorId = 1;
            var author = new Author()
            {
                Id = authorId,
                Name = "Mocker",
                Surname = "Mockington",
                Books = new List<Book>() { new Book() { Title = "Existing" } },
            };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Author?>(author));

            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IAuthorRepository>(repository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                var result = await authorService.DeleteAuthorAsync(authorId);

                Assert.True(result.IsFailed);
            }
        }
    }
}
