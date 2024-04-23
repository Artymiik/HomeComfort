using HomeComfort.Interfaces;
using HomeComfort.Models;
using HomeComfort.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeComfort.Controllers;

public class ApplicationController : Controller
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly UserManager<AppUser> _userManager;

    public ApplicationController(IApplicationRepository applicationRepository, UserManager<AppUser> userManager)
    {
        _applicationRepository = applicationRepository;
        _userManager = userManager;
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CApplicationViewModel applicationViewModel)
    {
        if (!ModelState.IsValid) return View(applicationViewModel);

        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        if (currentUser == null) return RedirectToAction("Login", "Account");

        var application = new Applications()
        {
            Title = applicationViewModel.Title,
            Description = applicationViewModel.Description,
            Priority = applicationViewModel.Priority,
            Address = applicationViewModel.Address,
            Category = applicationViewModel.Category,
            AppUserId = currentUser.Id.ToString()
        };

        _applicationRepository.Add(application);
        return RedirectToAction("Index", "Home");
    }
}