using BL.Facades;
using BL.Facades.Interfaces;
using BL.Services;
using BL.Services.Interfaces;
using DAL.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            var connectionString =
                config.GetConnectionString("DefaultConnection")
                ?? throw new Exception("DbString not found in appsettings.");

            connectionString = Environment.ExpandEnvironmentVariables(connectionString);

            services.AddDbContext<BookHubDbContext>(options =>
                options
                    .UseSqlite(connectionString)
                    .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                    .UseLazyLoadingProxies()
            );

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWishlistItemRepository, WishlistItemRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishlistItemService, WishlistItemService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }

        public static IServiceCollection AddFacades(this IServiceCollection services)
        {
            services.AddScoped<IWishlistFacade, WishlistFacade>();
            services.AddScoped<ICartFacade, CartFacade>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowSwaggerUI",
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });
            return services;
        }
    }
}
