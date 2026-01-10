using BL.DTOs.PublisherDTOs;
using BL.Services.Interfaces;
using DAL.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestUtils.MockedObjects;

namespace BL.Tests.Services
{
    public class PublisherServiceTests
    {
        private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

        public PublisherServiceTests()
        {
            _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddRepositories()
                .AddServices()
                .AddMockedDBContext();
        }

        [Fact]
        public async Task GetPublisherByIdAsync_ShouldReturnPublisher()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var publisher = new Publisher() { Id = 1, Name = "HarperCollins" };
            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Publisher?>(publisher));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.GetPublisherByIdAsync(1);

                Assert.True(result.IsSuccess);
                Assert.Equal(publisher.Name, result.Value.Name);
            }
        }

        [Fact]
        public async Task GetPublisherByIdAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Publisher?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.GetPublisherByIdAsync(1);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task CreatePublisherAsync_ShouldCreatePublisher()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var createDto = new PublisherCreateDto() { Name = "Penguin Books" };

            repository.GetByNameAsync(Arg.Any<string>()).Returns(Task.FromResult<Publisher?>(null));
            repository.AddAsync(Arg.Any<Publisher>()).Returns(Task.CompletedTask);
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.CreatePublisherAsync(createDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(createDto.Name, result.Value.Name);
            }
        }

        [Fact]
        public async Task CreatePublisherAsync_ShouldFailIfEmptyName()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var createDto = new PublisherCreateDto() { Name = " " };

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.CreatePublisherAsync(createDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task CreatePublisherAsync_ShouldFailIfDuplicate()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var existing = new Publisher() { Id = 1, Name = "Penguin Books" };
            var createDto = new PublisherCreateDto() { Name = "Penguin Books" };

            repository
                .GetByNameAsync(Arg.Any<string>())
                .Returns(Task.FromResult<Publisher?>(existing));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.CreatePublisherAsync(createDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdatePublisherAsync_ShouldUpdate()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var publisher = new Publisher() { Id = id, Name = "Old Name" };
            var updateDto = new PublisherUpdateDto() { Name = "New Name" };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Publisher?>(publisher));
            repository.GetByNameAsync(updateDto.Name).Returns(Task.FromResult<Publisher?>(null));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.UpdatePublisherAsync(id, updateDto);

                Assert.True(result.IsSuccess);
                Assert.Equal(updateDto.Name, publisher.Name);
            }
        }

        [Fact]
        public async Task UpdatePublisherAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Publisher?>(null));

            var updateDto = new PublisherUpdateDto() { Name = "New Name" };

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.UpdatePublisherAsync(1, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdatePublisherAsync_ShouldFailIfEmptyName()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var publisher = new Publisher() { Id = 1, Name = "Old Name" };
            var updateDto = new PublisherUpdateDto() { Name = "" };

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Publisher?>(publisher));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.UpdatePublisherAsync(1, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task UpdatePublisherAsync_ShouldFailIfDuplicate()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var publisher = new Publisher() { Id = id, Name = "Old Name" };
            var duplicate = new Publisher() { Id = 2, Name = "Duplicate" };
            var updateDto = new PublisherUpdateDto() { Name = "Duplicate" };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Publisher?>(publisher));
            repository
                .GetByNameAsync(updateDto.Name)
                .Returns(Task.FromResult<Publisher?>(duplicate));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.UpdatePublisherAsync(id, updateDto);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeletePublisherAsync_ShouldDelete()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var publisher = new Publisher()
            {
                Id = id,
                Name = "ToDelete",
                Books = new List<Book>(),
            };
            var books = new List<Book>();

            repository.GetByIdAsync(id).Returns(Task.FromResult<Publisher?>(publisher));
            bookRepository.GetAllAsync().Returns(Task.FromResult<IEnumerable<Book>>(books));
            repository.SaveChangesAsync().Returns(Task.CompletedTask);

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.DeletePublisherAsync(id);

                Assert.True(result.IsSuccess);
            }
        }

        [Fact]
        public async Task DeletePublisherAsync_ShouldFailIfNotExist()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Publisher?>(null));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.DeletePublisherAsync(1);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeletePublisherAsync_ShouldFailIfHasBooks()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var publisher = new Publisher()
            {
                Id = id,
                Name = "HasBooks",
                Books = new List<Book>() { new Book() { Title = "LinkedBook" } },
            };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Publisher?>(publisher));
            bookRepository
                .GetAllAsync()
                .Returns(Task.FromResult<IEnumerable<Book>>(new List<Book>()));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.DeletePublisherAsync(id);

                Assert.True(result.IsFailed);
            }
        }

        [Fact]
        public async Task DeletePublisherAsync_ShouldFailIfBooksReferencePublisher()
        {
            var repository = Substitute.For<IPublisherRepository>();
            var bookRepository = Substitute.For<IBookRepository>();

            var id = 1;
            var publisher = new Publisher()
            {
                Id = id,
                Name = "ToDelete",
                Books = new List<Book>(),
            };
            var books = new List<Book>()
            {
                new Book() { Title = "Ref", PublisherId = id },
            };

            repository.GetByIdAsync(id).Returns(Task.FromResult<Publisher?>(publisher));
            bookRepository.GetAllAsync().Returns(Task.FromResult<IEnumerable<Book>>(books));

            var serviceProvider = _serviceProviderBuilder
                .AddScoped<IPublisherRepository>(repository)
                .AddScoped<IBookRepository>(bookRepository)
                .Create();

            using (var scope = serviceProvider.CreateScope())
            {
                var publisherService =
                    scope.ServiceProvider.GetRequiredService<IPublisherService>();

                var result = await publisherService.DeletePublisherAsync(id);

                Assert.True(result.IsFailed);
            }
        }
    }
}
