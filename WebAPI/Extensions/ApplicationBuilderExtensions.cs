using DAL.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middlewares;

namespace WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var mainDb = scope.ServiceProvider.GetRequiredService<BookHubDbContext>();
            mainDb.Database.Migrate();

            var logDb = scope.ServiceProvider.GetRequiredService<LogDbContext>();
            logDb.Database.Migrate();
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            return app.UseCors("AllowSwaggerUI");
        }

        public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            return app;
        }
    }
}
