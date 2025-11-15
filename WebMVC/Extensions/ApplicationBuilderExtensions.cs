using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace WebMVC.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var mainDb = scope.ServiceProvider.GetRequiredService<BookHubDbContext>();
            mainDb.Database.Migrate();
        }
    }
}
