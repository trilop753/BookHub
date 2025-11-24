using BL.DTOs.CartItemDTOs;
using BL.Facades.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Mappers;
using WebMVC.Models.Cart;

namespace WebMVC.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly ICartFacade _cartFacade;
    private readonly UserManager<LocalIdentityUser> _userManager;

    public CartController(ICartFacade cartFacade, UserManager<LocalIdentityUser> userManager)
    {
        _cartFacade = cartFacade;
        _userManager = userManager;
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

        var res = await _cartFacade.GetCartItemsByUserIdAsync(identityUser.User.Id);
        if (res.IsFailed)
        {
            return View("InternalServerError");
        }
        return View(res.Value.MapToView());
    }

    [HttpGet]
    public async Task<IActionResult> RemoveInCart(int cartItemId)
    {
        var res = await _cartFacade.DeleteCartItemByIdAsync(cartItemId);
        if (res.IsFailed)
        {
            return View("InternalServerError");
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(CartViewModel model)
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null || identityUser.User == null)
        {
            return View("InternalServerError");
        }
        if (!ModelState.IsValid)
        {
            var res = await _cartFacade.GetCartItemsByUserIdAsync(identityUser.User.Id);
            if (res.IsFailed)
            {
                return View("InternalServerError");
            }
            return View("Index", res.Value.MapToView());
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

        return RedirectToAction(nameof(Index));
    }
}
