using Microsoft.AspNetCore.Mvc;

namespace CoachBuddy.MVC.Controllers
{
    public class ClientController:Controller
    {
        [HttpPost]
        public IActionResult Create(Domain.Entities.Client client)
        {

        }
    }
}
