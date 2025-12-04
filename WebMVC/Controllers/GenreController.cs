using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Genre;

namespace WebMVC.Controllers;

[Authorize(Roles = "Admin")]
public class GenreController : Controller
{
    private readonly IGenreService _genreService;
    private readonly IAppCache _cache;

    public GenreController(IGenreService genreService, IAppCache cache)
    {
        _genreService = genreService;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var genreRes = await _cache.GetOrCreateAsync(
            CacheKeys.GenreAll(),
            () => _genreService.GetAllGenresAsync()
        );
        if (genreRes.IsFailed)
        {
            return View("InternalServerError");
        }
        return View(genreRes.Value.Select(a => a.MapToView()));
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(GenreCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var genreRes = await _genreService.CreateGenreAsync(model.MapToDto());
        if (genreRes.IsFailed)
        {
            foreach (var error in genreRes.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return View(model);
        }
        _cache.Remove(CacheKeys.GenreAll());
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int genreId)
    {
        var genreRes = await _cache.GetOrCreateAsync(
            CacheKeys.GenreDetail(genreId),
            () => _genreService.GetGenreByIdAsync(genreId)
        );
        if (genreRes.IsFailed)
        {
            return View("InternalServerError");
        }

        var model = genreRes.Value.MapToUpdateView();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(GenreUpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var genreRes = await _genreService.UpdateGenreAsync(model.Id, model.MapToDto());
        if (genreRes.IsFailed)
        {
            foreach (var error in genreRes.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return View(model);
        }
        _cache.Remove(CacheKeys.GenreAll());
        _cache.Remove(CacheKeys.GenreDetail(model.Id));
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int genreId)
    {
        var genreRes = await _genreService.DeleteGenreAsync(genreId);
        if (genreRes.IsFailed)
        {
            var errorMessages = string.Join("<br />", genreRes.Errors.Select(e => e.Message));
            TempData["ErrorMessage"] = errorMessages;
            return RedirectToAction("Index");
        }

        TempData["SuccessMessage"] = "Genre was deleted.";
        _cache.Remove(CacheKeys.GenreAll());
        return RedirectToAction("Index");
    }
}
