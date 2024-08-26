﻿using CoachBuddy.Application.Client;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDto client)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _clientService.Create(client);

            return RedirectToAction(nameof(Create)); //TODO: refactor
        }
    }
}
