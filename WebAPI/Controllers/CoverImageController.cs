using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoverImageController : ControllerBase
{
    private readonly ICoverImageService _coverImageService;

    public CoverImageController(ICoverImageService coverImageService)
    {
        this._coverImageService = coverImageService;
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadCoverImage(IFormFile file)
    {
        var res = await _coverImageService.AddCoverImageAsync(file);
        if (res.IsFailed)
        {
            return BadRequest(res.Errors.Select(e => e.Message));
        }
        return Ok(res.Value);
    }

    [HttpDelete("{path}")]
    public IActionResult DeleteCoverImage(string path)
    {
        _coverImageService.DeleteCoverImage(path);
        return NoContent();
    }

    [HttpGet("{path}")]
    [Produces("image/jpeg", "image/png")]
    public async Task<IActionResult> GetCoverImage(string path)
    {
        var res = await _coverImageService.GetCoverImageAsync(path);
        if (res.IsFailed)
        {
            return BadRequest(res.Errors.Select(e => e.Message));
        }

        var bytes = res.Value;
        var contentType = GetContentTypeFromExtension(Path.GetExtension(path));
        return File(bytes, contentType);
    }

    private static string GetContentTypeFromExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return "application/octet-stream";
        }

        switch (extension.ToLowerInvariant())
        {
            case ".jpg":
            case ".jpeg":
            {
                return "image/jpeg";
            }
            case ".png":
            {
                return "image/png";
            }
            default:
            {
                return "application/octet-stream";
            }
        }
    }
}
