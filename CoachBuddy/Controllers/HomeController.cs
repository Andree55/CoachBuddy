using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoachBuddy.Models;

namespace CoachBuddy.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult NoAccess()
    {
        return View();
    }
    public IActionResult About()
    {
        var model = new About()
        {
            Title = "CoachBuddy application",
            Description = "Some description",
            Tags = new List<string> { "coach", "client", "program" }
        };
        return View(model);
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
