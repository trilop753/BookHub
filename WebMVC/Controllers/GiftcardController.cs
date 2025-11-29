using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;
using WebMVC.Models.Giftcard;

namespace WebMVC.Controllers
{
    public class GiftcardController : Controller
    {
        private readonly IGiftcardFacade _giftcardFacade;

        public GiftcardController(IGiftcardFacade giftcardFacade)
        {
            _giftcardFacade = giftcardFacade;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _giftcardFacade.GetAllAsync();

            if (res.IsFailed)
                return BadRequest(res.Errors);

            var vm = res.Value.Select(g => new GiftcardViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Amount = g.Amount,
                ValidFrom = g.ValidFrom,
                ValidTo = g.ValidTo,
                TotalCodes = g.Codes.Count(),
                UsedCodes = g.Codes.Count(c => c.IsUsed),
            });

            return View(vm);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res = await _giftcardFacade.GetByIdAsync(id);

            if (res.IsFailed)
                return NotFound();

            var g = res.Value;

            var vm = new GiftcardDetailViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Amount = g.Amount,
                ValidFrom = g.ValidFrom,
                ValidTo = g.ValidTo,
                TotalCodes = g.Codes.Count(),
                UsedCodes = g.Codes.Count(c => c.IsUsed),
                Codes = g
                    .Codes.Select(c => new GiftcardCodeSummaryViewModel
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiftcardCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = model.MapToCreateDto();
            var res = await _giftcardFacade.CreateAsync(dto);

            if (res.IsFailed)
            {
                ModelState.AddModelError("", res.Errors.First().Message);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _giftcardFacade.DeleteAsync(id);

            if (res.IsFailed)
                return BadRequest(res.Errors);

            return RedirectToAction(nameof(Index));
        }
    }
}
