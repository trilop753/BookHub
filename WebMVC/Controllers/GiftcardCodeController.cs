using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    public class GiftcardCodeController : Controller
    {
        private readonly IGiftcardFacade _giftcardFacade;
        private readonly IAppCache _cache;

        public GiftcardCodeController(IGiftcardFacade giftcardFacade, IAppCache cache)
        {
            _giftcardFacade = giftcardFacade;
            _cache = cache;
        }

        public async Task<IActionResult> Index(int giftcardId)
        {
            var res = await _cache.GetOrCreateAsync(
                CacheKeys.GiftcardDetail(giftcardId),
                () => _giftcardFacade.GetByIdAsync(giftcardId)
            );

            if (res.IsFailed)
            {
                return NotFound();
            }

            return View(res.Value.MapToCodesView());
        }
    }
}