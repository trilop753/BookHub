using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Author;

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

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuthorCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var authRes = await _authorService.CreateAuthorAsync(model.MapToDto());
        if (authRes.IsFailed)
        {
            foreach (var error in authRes.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return View(model);
        }
        _cache.Remove(CacheKeys.AuthorAll());
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int authorId)
    {
        var authRes = await _cache.GetOrCreateAsync(
            CacheKeys.AuthorDetail(authorId),
            () => _authorService.GetAuthorByIdAsync(authorId)
        );
        if (authRes.IsFailed)
        {
            return View("InternalServerError");
        }

        var model = authRes.Value.MapToUpdateView();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AuthorUpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var authRes = await _authorService.UpdateAuthorAsync(model.Id, model.MapToDto());
        if (authRes.IsFailed)
        {
            foreach (var error in authRes.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return View(model);
        }
        _cache.Remove(CacheKeys.AuthorAll());
        _cache.Remove(CacheKeys.AuthorDetail(model.Id));
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int authorId)
    {
        var authRes = await _authorService.DeleteAuthorAsync(authorId);
        if (authRes.IsFailed)
        {
            var errorMessages = string.Join("<br />", authRes.Errors.Select(e => e.Message));
            TempData["ErrorMessage"] = errorMessages;
            return RedirectToAction("Index");
        }

        _cache.Remove(CacheKeys.AuthorAll());
        return RedirectToAction("Index");
    }
}
