using FluentResults;
using Microsoft.AspNetCore.Http;

namespace BL.Services.Interfaces;

public interface ICoverImageService
{
    Task<Result<string>> AddCoverImageAsync(IFormFile? file);
    void DeleteCoverImage(string path);
    Task<Result<byte[]>> GetCoverImageAsync(string path);
}
