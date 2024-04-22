using System.ComponentModel.DataAnnotations;
using HomeComfort.Models;
using HomeComfort.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeComfort.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel LoginVM)
    {
        if (!ModelState.IsValid) return View(LoginVM);

        var user = await _userManager.FindByEmailAsync(LoginVM.Email);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, LoginVM.Password, true, false);
            if (result.Succeeded) return RedirectToAction("Index", "Home");
            
            TempData["Error"] = "We have not found a user with this email address";
            return View(LoginVM);
        }
        
        TempData["Error"] = "We have not found a user with this email address";
        return View(LoginVM);
    }

    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel RegisterVM)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                Name = RegisterVM.Name,
                Fname = RegisterVM.Fname,
                UserName = RegisterVM.Name + RegisterVM.Fname,
                Email = RegisterVM.Email
            };
            
            var emailFind = await _userManager.FindByEmailAsync(RegisterVM.Email);
            if (emailFind != null)
            {
                TempData["Error"] = "An account with this email already exists";
                return View(RegisterVM);
            }

            var result = await _userManager.CreateAsync(user, RegisterVM.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Wrong credentials. Please, try again";
        }

        return View(RegisterVM);
    }
}