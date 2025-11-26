using BL.Services.Interfaces;
using DAL;
using FluentResults;
using Microsoft.AspNetCore.Http;

namespace BL.Services;

public class CoverImageService : ICoverImageService
{
    private readonly ISet<string> _acceptableExtensions = new HashSet<string>
    {
        ".jpg",
        ".jpeg",
        ".png",
    };

    public CoverImageService() { }

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

        var res = GetCoverImageStoragePath();
        if (res.IsFailed)
        {
            return Result.Fail(res.Errors);
        }

        var storagePath = res.Value;
        var fileName = $"{Guid.NewGuid()}{extension}";
        var fullPath = Path.Combine(storagePath, fileName);

        await using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return Result.Ok(fullPath);
    }

    public void DeleteCoverImage(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return;
        }

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public async Task<Result<byte[]>> GetCoverImageAsync(string path)
    {
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

    private Result<string> GetCoverImageStoragePath()
    {
        var dalAssembly = typeof(AssemblyMarker).Assembly;
        var dalDir = Path.GetDirectoryName(dalAssembly.Location);
        if (string.IsNullOrEmpty(dalDir))
        {
            return Result.Fail(
                "Cover image storage path could not be created or found. Something went wrong."
            );
        }
        var coverImageStoragePath = Path.Combine(dalDir, "CoverImageStorage");
        Directory.CreateDirectory(coverImageStoragePath);
        return Result.Ok(coverImageStoragePath);
    }
}
