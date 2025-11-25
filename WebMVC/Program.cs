using Microsoft.AspNetCore.Identity;
using WebMVC.Extensions;

namespace WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddBusinessServices();
            builder.Services.AddFacades();
            builder.Services.AddCorsPolicy();

            builder.Services.AddLocalIdentityProvider();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.ApplyMigrations();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    roleManager.CreateAsync(new IdentityRole("Admin"));
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
