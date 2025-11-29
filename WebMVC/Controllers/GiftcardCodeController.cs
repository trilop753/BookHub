using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Giftcard;

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
                return NotFound();

            var g = res.Value;

            var vm = new GiftcardCodesViewModel
            {
                GiftcardId = g.Id,
                GiftcardName = g.Name,
                Codes = g
                    .Codes.Select(c => new GiftcardCodeItemViewModel
                    {
                        Id = c.Id,
                        Code = c.Code,
                        IsUsed = c.IsUsed,
                        OrderId = c.OrderId,
                    })
                    .ToList(),
            };

            return View(vm);
        }
    }
}
