using Microsoft.EntityFrameworkCore;

namespace WebMVC.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations<TContext>(this IApplicationBuilder app)
            where TContext : DbContext
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TContext>();
            db.Database.Migrate();
        }
    }
}
