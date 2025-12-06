using BL.Facades.Interfaces;
using DAL.Models;
using DAL.UtilityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
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
        private readonly IAppCache _cache;

        public OrderController(
            IOrderFacade orderFacade,
            ICartFacade cartFacade,
            UserManager<LocalIdentityUser> userManager,
            IAppCache cache,
            IGiftcardFacade giftcardFacade
        )
        {
            _orderFacade = orderFacade;
            _cartFacade = cartFacade;
            _userManager = userManager;
            _cache = cache;
            _giftcardFacade = giftcardFacade;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var orderRes = await _cache.GetOrCreateAsync(
                CacheKeys.OrderDetail(id),
                () => _orderFacade.GetByIdAsync(id)
            );
            if (orderRes.IsFailed)
            {
                return View("NotFound");
            }
            return View(orderRes.Value.MapToView());
        }

        public async Task<IActionResult> List()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var ordersRes = await _cache.GetOrCreateAsync(
                CacheKeys.OrderAll(identityUser.User.Id),
                () => _orderFacade.GetOrdersByUserIdAsync(identityUser.User.Id)
            );
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
            _cache.Remove(CacheKeys.UserCartAll(identityUser.User.Id));
            _cache.Remove(CacheKeys.OrderAll(identityUser.User.Id));
            return View("Detail", orderRes.Value.MapToView());
        }

        [HttpPost]
        public async Task<IActionResult> PayOrder(int id)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null || identityUser.User == null)
            {
                return View("InternalServerError");
            }

            var res = await _orderFacade.UpdateOrderPaymentStatusAsync(id, PaymentStatus.Completed);
            if (res.IsFailed)
            {
                return NotFound();
            }

            _cache.Remove(CacheKeys.OrderAll(identityUser.User.Id));
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

            var codeRes = await _giftcardFacade.GetCodeByValueAsync(code);

            if (codeRes.IsFailed)
            {
                TempData["Error"] = codeRes.Errors.First().Message;
                return RedirectToAction("Detail", new { id = orderId });
            }

            var assignRes = await _orderFacade.AssignGiftcardCodeAsync(orderId, codeRes.Value.Id);

            if (assignRes.IsFailed)
            {
                TempData["Error"] = assignRes.Errors.First().Message;
                return RedirectToAction("Detail", new { id = orderId });
            }

            TempData["Success"] = "Giftcard applied successfully.";
            return RedirectToAction("Detail", new { id = orderId });
        }
    }
}
