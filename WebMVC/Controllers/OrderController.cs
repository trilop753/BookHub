using BL.DTOs.OrderDTOs;
using BL.Facades.Interfaces;
using DAL.Models;
using DAL.UtilityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebMVC.Constants;
using WebMVC.Mappers;

namespace WebMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderFacade _orderFacade;
        private readonly ICartFacade _cartFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IMemoryCache _cache;

        public OrderController(
            IOrderFacade orderFacade,
            ICartFacade cartFacade,
            UserManager<LocalIdentityUser> userManager,
            IMemoryCache cache
        )
        {
            _orderFacade = orderFacade;
            _cartFacade = cartFacade;
            _userManager = userManager;
            _cache = cache;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var cacheKey = CacheKeys.OrderDetail(id);
            if (!_cache.TryGetValue(cacheKey, out OrderDto? order))
            {
                var res = await _orderFacade.GetByIdAsync(id);
                if (res.IsFailed)
                {
                    return View("NotFound");
                }

                order = res.Value;
                _cache.Set(
                    cacheKey,
                    order,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                );
            }
            return View(order!.MapToView());
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
    }
}
