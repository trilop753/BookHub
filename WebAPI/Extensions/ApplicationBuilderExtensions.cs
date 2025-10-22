using DAL.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middlewares;

namespace WebAPI.Extensions
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
