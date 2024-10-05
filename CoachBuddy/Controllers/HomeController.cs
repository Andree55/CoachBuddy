using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoachBuddy.Models;
using MediatR;
using CoachBuddy.Application.Client.Queries.GetClientCount;
using CoachBuddy.MVC.Models;

namespace CoachBuddy.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var clientCount = await _mediator.Send(new GetClientCountQuery());
        var viewModel = new HomeViewModel
        {
            ClientCount = clientCount
        };
        return View(viewModel);
    }
    public IActionResult NoAccess()
    {
        return View();
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
