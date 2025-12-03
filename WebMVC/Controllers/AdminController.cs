using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Constants;

namespace WebMVC.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly UserManager<LocalIdentityUser> _userManager;
    private readonly SignInManager<LocalIdentityUser> _signInManager;

    public AdminController(
        UserManager<LocalIdentityUser> userManager,
        SignInManager<LocalIdentityUser> signInManager
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddAdminRole()
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null)
        {
            return View("InternalServerError");
        }

        if (!await _userManager.IsInRoleAsync(identityUser, Roles.Admin))
        {
            var result = await _userManager.AddToRoleAsync(identityUser, Roles.Admin);

            if (!result.Succeeded)
            {
                return View("InternalServerError");
            }
            await _signInManager.RefreshSignInAsync(identityUser);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveAdminRole()
    {
        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null)
        {
            return View("InternalServerError");
        }

        if (await _userManager.IsInRoleAsync(identityUser, Roles.Admin))
        {
            var result = await _userManager.RemoveFromRoleAsync(identityUser, Roles.Admin);

            if (!result.Succeeded)
            {
                return View("InternalServerError");
            }
            await _signInManager.RefreshSignInAsync(identityUser);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Dashboard()
    {
        return View();
    }
}
