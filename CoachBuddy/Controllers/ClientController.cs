using AutoMapper;
using CoachBuddy.Application.Client.Commands.CreateClient;
using CoachBuddy.Application.Client.Commands.EditClient;
using CoachBuddy.Application.Client.Queries.GetAllClients;
using CoachBuddy.Application.Client.Queries.GetClientByEncodedName;
using CoachBuddy.Application.ClientTraining.Commands;
using CoachBuddy.MVC.Extensions;
using CoachBuddy.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoachBuddy.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());
            return View(clients);
        }
        
        [Route("Client/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto  = await _mediator.Send(new GetClientByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("Client/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetClientByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditClientCommand model = _mapper.Map<EditClientCommand>(dto);

            return View(model);
        }
        [HttpPost]
        [Route("Client/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName,EditClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

           // await _mediator.Send(command);

            this.SetNotification("success", $"Added new client: {command.Name} {command.LastName}");

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Route("Client/ClientTraining")]
        public async Task<IActionResult> CreateClientTraining(CreateClientTrainingCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             await _mediator.Send(command);

            return Ok();
        }
    }
}
