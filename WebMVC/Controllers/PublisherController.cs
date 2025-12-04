using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Publisher;

namespace WebMVC.Controllers;

[Authorize(Roles = "Admin")]
public class PublisherController : Controller
{
    private readonly IPublisherService _publisherService;
    private readonly IAppCache _cache;

    public PublisherController(IPublisherService publisherService, IAppCache cache)
    {
        _publisherService = publisherService;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var pubRes = await _cache.GetOrCreateAsync(
            CacheKeys.PublisherAll(),
            () => _publisherService.GetAllPublishersAsync()
        );
        if (pubRes.IsFailed)
        {
            return View("InternalServerError");
        }
        return View(pubRes.Value.Select(a => a.MapToView()));
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PublisherCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var pubRes = await _publisherService.CreatePublisherAsync(model.MapToDto());
        if (pubRes.IsFailed)
        {
            foreach (var error in pubRes.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return View(model);
        }
        _cache.Remove(CacheKeys.PublisherAll());
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int publisherId)
    {
        var pubRes = await _cache.GetOrCreateAsync(
            CacheKeys.PublisherDetail(publisherId),
            () => _publisherService.GetPublisherByIdAsync(publisherId)
        );
        if (pubRes.IsFailed)
        {
            return View("InternalServerError");
        }

        var model = pubRes.Value.MapToUpdateView();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PublisherUpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var pubRes = await _publisherService.UpdatePublisherAsync(model.Id, model.MapToDto());
        if (pubRes.IsFailed)
        {
            foreach (var error in pubRes.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
            return View(model);
        }
        _cache.Remove(CacheKeys.PublisherAll());
        _cache.Remove(CacheKeys.PublisherDetail(model.Id));
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int publisherId)
    {
        var pubRes = await _publisherService.DeletePublisherAsync(publisherId);
        if (pubRes.IsFailed)
        {
            var errorMessages = string.Join("<br />", pubRes.Errors.Select(e => e.Message));
            TempData["ErrorMessage"] = errorMessages;
            return RedirectToAction("Index");
        }

        TempData["SuccessMessage"] = "Publisher was deleted.";
        _cache.Remove(CacheKeys.PublisherAll());
        return RedirectToAction("Index");
    }
}
