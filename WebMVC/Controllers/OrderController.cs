using BL.Facades;
using BL.Facades.Interfaces;
using DAL.Models;
using DAL.UtilityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderFacade _orderFacade;
        private readonly IGiftcardFacade _giftcardFacade;
        private readonly ICartFacade _cartFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public OrderController(
            IOrderFacade orderFacade,
            ICartFacade cartFacade,
            UserManager<LocalIdentityUser> userManager,
            IGiftcardFacade giftcardFacade
        )
        {
            _orderFacade = orderFacade;
            _cartFacade = cartFacade;
            _userManager = userManager;
            _giftcardFacade = giftcardFacade;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res = await _orderFacade.GetByIdAsync(id);
            if (res.IsFailed)
            {
                return NotFound();
            }

            return View(res.Value.MapToView());
        }

        public async Task<IActionResult> List()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var ordersRes = await _orderFacade.GetOrdersByUserIdAsync(identityUser.User.Id);
            if (ordersRes.IsFailed)
            {
                return View("InternalServerError");
            }

            return View(ordersRes.Value.Select(o => o.MapToView()));
        }

        public async Task<IActionResult> Purchase()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var orderRes = await _orderFacade.CreateOrderFromUserCartAsync(identityUser.User.Id);
            if (orderRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var cartRes = await _cartFacade.DeleteCartItemsByUserIdAsync(identityUser.User.Id);
            if (cartRes.IsFailed)
            {
                return View("InternalServerError");
            }

            return View("Detail", orderRes.Value.MapToView());
        }

        [HttpPost]
        public async Task<IActionResult> PayOrder(int id)
        {
            var res = await _orderFacade.UpdateOrderPaymentStatusAsync(id, PaymentStatus.Completed);
            if (res.IsFailed)
            {
                return NotFound();
            }

            return View("Detail", res.Value.MapToView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyGiftcard(int orderId, string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                TempData["Error"] = "Please enter a valid giftcard code.";
                return RedirectToAction("Detail", new { id = orderId });
            }

            var orderRes = await _orderFacade.GetByIdAsync(orderId);
            if (orderRes.IsFailed)
            {
                return View("InternalServerError");
            }

            var order = orderRes.Value;

            var giftcardCode = await _giftcardFacade.GetCodeByValueAsync(code);

            if (giftcardCode == null)
            {
                TempData["Error"] = "Giftcard code not found.";
                return RedirectToAction("Detail", new { id = orderId });
            }

            if (giftcardCode.IsUsed)
            {
                TempData["Error"] = "This giftcard has already been used.";
                return RedirectToAction("Detail", new { id = orderId });
            }

            if (
                DateTime.Now < giftcardCode.Giftcard.ValidFrom
                || DateTime.Now > giftcardCode.Giftcard.ValidTo
            )
            {
                TempData["Error"] = "This giftcard has expired or is not active.";
                return RedirectToAction("Detail", new { id = orderId });
            }

            await _orderFacade.AssignGiftcardCodeAsync(orderId, giftcardCode.Id);

            TempData["Success"] = "Giftcard applied successfully.";

            return RedirectToAction("Detail", new { id = orderId });
        }
    }
}
