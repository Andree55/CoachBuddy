using CoachBuddy.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoachBuddy.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.Client client)
        {
            await _clientService.Create(client);

            return RedirectToAction(nameof(Create)); //TODO: refactor
        }
    }
}
