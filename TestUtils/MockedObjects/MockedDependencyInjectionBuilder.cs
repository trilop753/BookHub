using BL.Facades;
using BL.Facades.Interfaces;
using BL.Services;
using BL.Services.Interfaces;
using DAL.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestUtils.MockedObjects
{
    public class MockedDependencyInjectionBuilder
    {
        protected IServiceCollection _serviceCollection = new ServiceCollection();

        public MockedDependencyInjectionBuilder() { }

        public MockedDependencyInjectionBuilder AddMockedDBContext()
        {
            _serviceCollection = _serviceCollection.AddDbContext<BookHubDbContext>(options =>
                options.UseInMemoryDatabase(MockedDBContext.RandomDBName)
            );

            return this;
        }

        public MockedDependencyInjectionBuilder AddScoped<T>(T objectToRegister)
            where T : class
        {
            _serviceCollection = _serviceCollection.AddScoped<T>(_ => objectToRegister);
            return this;
        }

        public MockedDependencyInjectionBuilder AddRepositories()
        {
            _serviceCollection = _serviceCollection
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IPublisherRepository, PublisherRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IWishlistItemRepository, WishlistItemRepository>()
                .AddScoped<ICartItemRepository, CartItemRepository>();

            return this;
        }

        public MockedDependencyInjectionBuilder AddServices()
        {
            _serviceCollection = _serviceCollection
                .AddScoped<IBookService, BookService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IWishlistItemService, WishlistItemService>()
                .AddScoped<ICartItemService, CartItemService>();

            return this;
        }

        public MockedDependencyInjectionBuilder AddFacades()
        {
            _serviceCollection = _serviceCollection
                .AddScoped<IWishlistFacade, WishlistFacade>()
                .AddScoped<ICartFacade, CartFacade>();

            return this;
        }

        public ServiceProvider Create()
        {
            return _serviceCollection.BuildServiceProvider();
        }
    }
}
