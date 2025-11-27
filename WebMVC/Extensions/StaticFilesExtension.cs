using Microsoft.Extensions.FileProviders;

namespace WebMVC.Extensions;

public static class StaticFilesExtension
{
    public static WebApplication ApplyStaticFilesManagement(this WebApplication app)
    {
        app.UseStaticFiles();

        var config = app.Configuration;
        var storageFolderName = config["CoverImageStorage"] ?? "dev-bookhub-cover-image-storage";

        var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var imageStoragePath = Path.Combine(appdata, storageFolderName);

        Directory.CreateDirectory(imageStoragePath);

        app.UseStaticFiles(
            new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(imageStoragePath),
                RequestPath = "/cover-images",
            }
        );
        return app;
    }
}
