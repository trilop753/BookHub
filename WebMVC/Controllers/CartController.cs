using BL.DTOs.CartItemDTOs;
using BL.Facades.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Caching;
using WebMVC.Constants;
using WebMVC.Mappers;
using WebMVC.Models.Cart;

namespace WebMVC.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly ICartFacade _cartFacade;
    private readonly UserManager<LocalIdentityUser> _userManager;
    private readonly IAppCache _cache;

    public CartController(
        ICartFacade cartFacade,
        UserManager<LocalIdentityUser> userManager,
        IAppCache cache
    )
    {
        _cartFacade = cartFacade;
        _userManager = userManager;
        _cache = cache;
    }

    [HttpPost]
    public async Task<IActionResult> Add(int bookId)
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null || identityUser.User == null)
        {
            return View("InternalServerError");
        }

        var createDto = new CartItemCreateDto
        {
            BookId = bookId,
            UserId = identityUser.User.Id,
            Quantity = 1,
        };
        var res = await _cartFacade.AddToCartAsync(createDto);
        if (res.IsFailed)
        {
            return View("InternalServerError");
        }

        _cache.Remove(CacheKeys.UserCartAll(identityUser.User.Id));
        return RedirectToAction("Detail", "Book", new { id = bookId });
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int bookId)
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null || identityUser.User == null)
        {
            return View("InternalServerError");
        }

        var res = await _cartFacade.RemoveFromCartAsync(identityUser.User.Id, bookId);
        if (res.IsFailed)
        {
            return View("InternalServerError");
        }

        _cache.Remove(CacheKeys.UserCartAll(identityUser.User.Id));
        return RedirectToAction("Detail", "Book", new { id = bookId });
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null || identityUser.User == null)
        {
            return View("InternalServerError");
        }

        var cartRes = await _cache.GetOrCreateAsync(
            CacheKeys.UserCartAll(identityUser.User.Id),
            () => _cartFacade.GetCartItemsByUserIdAsync(identityUser.User.Id)
        );
        if (cartRes.IsFailed)
        {
            return View("InternalServerError");
        }
        return View(cartRes.Value.MapToView());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CartViewModel model, int? removeId, string? action)
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null || identityUser.User == null)
        {
            return View("InternalServerError");
        }

        if (removeId.HasValue)
        {
            await _cartFacade.DeleteCartItemByIdAsync(removeId.Value);
            _cache.Remove(CacheKeys.UserCartAll(identityUser.User.Id));
            return RedirectToAction(nameof(Index));
        }

        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index));
        }

        foreach (var item in model.Items)
        {
            if (item.Quantity == 0)
            {
                await _cartFacade.DeleteCartItemByIdAsync(item.Id);
            }
            else
            {
                await _cartFacade.UpdateItemQuantityAsync(item.Id, item.Quantity);
            }
        }

        _cache.Remove(CacheKeys.UserCartAll(identityUser.User.Id));

        if (string.Equals(action, "purchase", StringComparison.OrdinalIgnoreCase))
        {
            return RedirectToAction("Purchase", "Order");
        }

        return RedirectToAction(nameof(Index));
    }
}
