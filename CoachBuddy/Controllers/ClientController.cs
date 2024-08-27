using CoachBuddy.Application.Client;
using CoachBuddy.Application.Client.Commands.CreateClient;
using CoachBuddy.Application.Client.Queries.GetAllClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoachBuddy.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());
            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    }
}
