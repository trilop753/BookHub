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
            {
                return BadRequest(res.Errors);
            }

            return View(res.Value.Select(g => g.MapToView()));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res = await _giftcardFacade.GetByIdAsync(id);

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

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _giftcardFacade.DeleteAsync(id);

            if (res.IsFailed)
            {
                var errorMessages = string.Join("<br />", res.Errors.Select(e => e.Message));
                TempData["ErrorMessage"] = errorMessages;
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Giftcard was deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
