using BL.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BL.Services;

public class CoverImageService : ICoverImageService
{
    private readonly ISet<string> _acceptableExtensions = new HashSet<string>
    {
        ".jpg",
        ".jpeg",
        ".png",
    };
    private readonly string _coverImageStoragePath;

    public CoverImageService(IConfiguration configuration)
    {
        var appdata = Environment.SpecialFolder.LocalApplicationData;
        var config = configuration["CoverImageStorage"];
        _coverImageStoragePath = Path.Combine(Environment.GetFolderPath(appdata), config);
        Directory.CreateDirectory(_coverImageStoragePath);
    }

    public async Task<Result<string>> AddCoverImageAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0)
        {
            return Result.Fail("Cover image file is empty or not provided.");
        }

        var extension = Path.GetExtension(file.FileName);
        if (!_acceptableExtensions.Contains(extension))
        {
            return Result.Fail(
                "Cover image extension is not supported. Supported extensions: .jpg, .jpeg, .png"
            );
        }

        var fileName = $"{Guid.NewGuid()}{extension}";
        var fullPath = Path.Combine(_coverImageStoragePath, fileName);

        await using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return Result.Ok(fileName);
    }

    public void DeleteCoverImage(string name)
    {
        var path = Path.Combine(_coverImageStoragePath, name);
        if (string.IsNullOrWhiteSpace(path))
        {
            return;
        }

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public async Task<Result<byte[]>> GetCoverImageAsync(string name)
    {
        var path = Path.Combine(_coverImageStoragePath, name);
        if (string.IsNullOrWhiteSpace(path))
        {
            return Result.Fail("Cover image path is null or empty.");
        }

        if (!File.Exists(path))
        {
            return Result.Fail($"Cover image file does not exist at path '{path}'.");
        }

        var bytes = await File.ReadAllBytesAsync(path);
        return Result.Ok(bytes);
    }
}
