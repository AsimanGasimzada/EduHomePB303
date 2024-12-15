using EduHome.Business.Dtos;
using EduHome.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Presentation.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            ModelState.AddModelError("", "Password ve ya email yanlisdir");
            return View(dto);
        }


        var result = await _signInManager.PasswordSignInAsync(user, dto.Password, true, true);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Password ve ya email yanlisdir");
            return View(dto);
        }

        return RedirectToAction("Index", "Home");

    }


    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        AppUser user = new()
        {
            Email = dto.Email,
            UserName = dto.Username,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return View(dto);
        }

        await _signInManager.SignInAsync(user, true);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
