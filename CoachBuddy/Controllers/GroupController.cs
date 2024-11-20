using CoachBuddy.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoachBuddy.MVC.Controllers
{
    public class GroupController:Controller
    {
        private readonly CoachBuddyDbContext _context;
        public GroupController(CoachBuddyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var groups = await _context.Groups.ToListAsync();
            return View(groups);
        }
    }
}
