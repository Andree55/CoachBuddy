using AutoMapper;
using CoachBuddy.Application;
using CoachBuddy.Application.ClientGroup;
using CoachBuddy.Application.Group;
using CoachBuddy.Application.Group.Commands.AddClientToGroup;
using CoachBuddy.Application.Group.Commands.CreateGroup;
using CoachBuddy.Application.Group.Commands.DeleteGroup;
using CoachBuddy.Application.Group.Commands.EditGroup;
using CoachBuddy.Application.Group.Queries.GetAllGroups;
using CoachBuddy.Application.Group.Queries.GetGroupByEncodedName;
using CoachBuddy.Application.Group.Queries.GetGroupDetails;
using CoachBuddy.Application.Group.Queries.GetGroupsBySearch;
using CoachBuddy.Infrastructure.Persistence;
using CoachBuddy.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoachBuddy.MVC.Controllers
{
    public class GroupController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly CoachBuddyDbContext _context;

        public GroupController(IMediator mediator, IMapper mapper, CoachBuddyDbContext context, ILogger<GroupController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 7)
        {
            var query = new GetAllGroupsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var paginatedResult = await _mediator.Send(query);
            return View(paginatedResult);
        }

        [Route("Group/Details")]
        public IActionResult Details(string encodedName)
        {
            var group = _context.Groups
                .Include(g => g.ClientGroups)
                    .ThenInclude(cg => cg.Client)
                .FirstOrDefault(g => g.EncodedName == encodedName);

            if (group == null)
            {
                return NotFound();
            }

            var assignedClientIds = group.ClientGroups
                .Select(cg => cg.ClientId)
                .ToList();

            var availableClients = _context.Clients
                .Where(c => !assignedClientIds.Contains(c.Id))
                .Select(c => new AvailableClientDto
                {
                    Id = c.Id,
                    FullName = $"{c.Name} {c.LastName}"
                })
                .ToList();

            var groupDto = new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreatedAt = group.CreatedAt,
                ClientGroups = group.ClientGroups.Select(cg => new ClientGroupDto
                {
                    ClientId = cg.ClientId,
                    FullName = $"{cg.Client.Name} {cg.Client.LastName}",
                    AssignedAt = cg.AssignedAt
                }).ToList(),
                AvailableClients = availableClients
            };

            return View(groupDto);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateGroupCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);

            this.SetNotification("success", $"Group '{command.Name}' has been crated.");
            return RedirectToAction(nameof(Index));
        }

        [Route("Group/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetGroupByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditGroupCommand model = _mapper.Map<EditGroupCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("Group/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditGroupCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Group '{command.Name}' has been updated.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var group = await _context.Groups
                .FirstOrDefaultAsync(c => c.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<GroupDto>(group);
            return View(dto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [Route("Group/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(c => c.Id == id);

            if (group == null)
            {
                return NotFound();
            }
            var command = new DeleteGroupCommand { Id = id };

            await _mediator.Send(command);

            this.SetNotification("success", $"Group {group.Name} was successfully deleted.");

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, int pageNumber = 1, int pageSize = 7)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction(nameof(Index));
            }
            var query = new GetGroupsBySearchQuery(searchTerm, pageNumber, pageSize);

            var groups = await _mediator.Send(query);

            return View("Index", groups);
        }
        [HttpPost]
        public async Task<IActionResult> AddClientToGroup(int groupId, int clientId)
        {
            try
            {
                await _mediator.Send(new AddClientToGroupCommand { GroupId = groupId, ClientId = clientId });
                TempData["SuccessMessage"] = "Client added to the group successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Details", new { id = groupId });
        }
        
    }
}