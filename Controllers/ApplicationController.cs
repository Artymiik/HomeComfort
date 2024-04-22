using Microsoft.AspNetCore.Mvc;

namespace HomeComfort.Controllers;

public class ApplicationController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
}