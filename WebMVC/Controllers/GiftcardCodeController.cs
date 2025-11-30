using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    public class GiftcardCodeController : Controller
    {
        private readonly IGiftcardFacade _giftcardFacade;

        public GiftcardCodeController(IGiftcardFacade giftcardFacade)
        {
            _giftcardFacade = giftcardFacade;
        }

        public async Task<IActionResult> Index(int giftcardId)
        {
            var res = await _giftcardFacade.GetByIdAsync(giftcardId);

            if (res.IsFailed)
            {
                return NotFound();
            }

            return View(res.Value.MapToCodesView());
        }
    }
}
