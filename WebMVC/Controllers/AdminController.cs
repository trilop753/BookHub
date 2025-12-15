using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Constants;
using WebMVC.Models.Admin;

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

    [HttpGet]
    public async Task<IActionResult> ResetUserPassword(string? query, string? selectedUserId)
    {
        var model = new AdminResetPasswordViewModel
        {
            Query = query,
            SelectedUserId = selectedUserId,
        };

        if (!string.IsNullOrWhiteSpace(query))
        {
            var q = query.Trim();

            model.Results = await _userManager
                .Users.Where(u =>
                    (u.Email != null && u.Email.Contains(q))
                    || (u.UserName != null && u.UserName.Contains(q))
                )
                .OrderBy(u => u.UserName)
                .Take(20)
                .Select(u => new UserOptionViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                })
                .ToListAsync();
        }

        if (!string.IsNullOrWhiteSpace(selectedUserId))
        {
            var user = await _userManager.FindByIdAsync(selectedUserId);
            model.SelectedUserName = user?.UserName;
            model.SelectedEmail = user?.Email;
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetUserPassword(AdminResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            if (!string.IsNullOrWhiteSpace(model.Query))
            {
                var q = model.Query.Trim();

                model.Results = await _userManager
                    .Users.Where(u =>
                        (u.Email != null && u.Email.Contains(q))
                        || (u.UserName != null && u.UserName.Contains(q))
                    )
                    .OrderBy(u => u.UserName)
                    .Take(20)
                    .Select(u => new UserOptionViewModel
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                    })
                    .ToListAsync();
            }

            return View(model);
        }

        var user = await _userManager.FindByIdAsync(model.SelectedUserId!);
        if (user == null)
        {
            ModelState.AddModelError(nameof(model.SelectedUserId), "User not found.");
            return View(model);
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        await _userManager.UpdateSecurityStampAsync(user);

        TempData["Success"] = $"Password reset for {user.UserName} ({user.Email}).";
        return RedirectToAction(nameof(ResetUserPassword));
    }
}
