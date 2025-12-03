using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;

namespace WebMVC.Controllers;

[Authorize(Roles = "Admin")]
public class AuthorController : Controller
{
    private readonly IAuthorService _authorService;
    private readonly UserManager<LocalIdentityUser> _userManager;
    private readonly IAppCache _cache;

    public AuthorController(
        IAuthorService authorService,
        UserManager<LocalIdentityUser> userManager,
        IAppCache cache
    )
    {
        _authorService = authorService;
        _userManager = userManager;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var authRes = await _cache.GetOrCreateAsync(
            CacheKeys.AuthorAll(),
            () => _authorService.GetAllAuthorsAsync()
        );
        if (authRes.IsFailed)
        {
            return View("InternalServerError");
        }
        return View(authRes.Value.Select(a => a.MapToView()));
    }
}
