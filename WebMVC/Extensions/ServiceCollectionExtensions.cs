using System.Diagnostics;
using BL.Facades;
using BL.Facades.Interfaces;
using BL.Services;
using BL.Services.Interfaces;
using DAL.Data;
using DAL.Models;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebMVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var connectionString =
                config.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Database name not found in appsettings.");
            var path = Path.Combine(Environment.GetFolderPath(folder), connectionString);
            connectionString = $"DataSource={path}";

            var migrationAssembly = config.GetValue<string>("MigrationProject");

            services.AddDbContext<BookHubDbContext>(options =>
                options
                    .UseSqlite(connectionString, x => x.MigrationsAssembly(migrationAssembly))
                    .LogTo(s => Debug.WriteLine(s))
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
            services.AddScoped<IBookReviewRepository, BookReviewRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGiftcardRepository, GiftcardRepository>();
            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishlistItemService, WishlistItemService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IBookReviewService, BookReviewService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICoverImageService, CoverImageService>();
            services.AddScoped<IGiftcardService, GiftcardService>();
            return services;
        }

        public static IServiceCollection AddFacades(this IServiceCollection services)
        {
            services.AddScoped<IWishlistFacade, WishlistFacade>();
            services.AddScoped<IAuthorFacade, AuthorFacade>();
            services.AddScoped<IGenreFacade, GenreFacade>();
            services.AddScoped<IPublisherFacade, PublisherFacade>();
            services.AddScoped<IBookReviewFacade, BookReviewFacade>();
            services.AddScoped<ICartFacade, CartFacade>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddScoped<IGiftcardFacade, GiftcardFacade>();
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

        public static IServiceCollection AddLocalIdentityProvider(this IServiceCollection services)
        {
            services
                .AddIdentity<LocalIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BookHubDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });
            return services;
        }
    }
}
