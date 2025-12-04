using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Giftcard;

namespace WebMVC.Controllers
{
    public class GiftcardController : Controller
    {
        private readonly IGiftcardFacade _giftcardFacade;
        private readonly IAppCache _cache;

        public GiftcardController(IGiftcardFacade giftcardFacade, IAppCache cache)
        {
            _giftcardFacade = giftcardFacade;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _cache.GetOrCreateAsync(
                CacheKeys.GiftcardAll(),
                () => _giftcardFacade.GetAllAsync()
            );

            if (res.IsFailed)
            {
                return BadRequest(res.Errors);
            }

            return View(res.Value.Select(g => g.MapToView()));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res = await _cache.GetOrCreateAsync(
                CacheKeys.GiftcardDetail(id),
                () => _giftcardFacade.GetByIdAsync(id)
            );

            if (res.IsFailed)
            {
                return NotFound();
            }

            return View(res.Value.ToDetail());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiftcardCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = model.MapToCreateDto();
            var res = await _giftcardFacade.CreateAsync(dto);

            if (res.IsFailed)
            {
                ModelState.AddModelError("", res.Errors.First().Message);
                return View(model);
            }

            _cache.Remove(CacheKeys.GiftcardAll());

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _giftcardFacade.DeleteAsync(id);

            if (res.IsFailed)
            {
                return BadRequest(res.Errors);
            }

            _cache.Remove(CacheKeys.GiftcardAll());
            _cache.Remove(CacheKeys.GiftcardDetail(id));

            return RedirectToAction(nameof(Index));
        }
    }
}
