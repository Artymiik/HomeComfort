using System.Diagnostics;
using HomeComfort.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HomeComfort.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeComfort.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IApplicationRepository _applicationRepository;

    public HomeController(ILogger<HomeController> logger, IApplicationRepository applicationRepository)
    {
        _logger = logger;
        _applicationRepository = applicationRepository;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Applications> applicationsEnumerable = await _applicationRepository.GetAll();
        return View(applicationsEnumerable);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}