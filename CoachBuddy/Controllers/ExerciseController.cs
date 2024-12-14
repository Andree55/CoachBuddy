using AutoMapper;
using CoachBuddy.Application.Exercise;
using CoachBuddy.Application.Exercise.Commands.CreateExercise;
using CoachBuddy.Application.Exercise.Commands.DeleteExercise;
using CoachBuddy.Application.Exercise.Commands.EditExercise;
using CoachBuddy.Application.Exercise.Queries.GetAllExercises;
using CoachBuddy.Application.Exercise.Queries.GetExerciseById;
using CoachBuddy.Application.Exercise.Queries.GetExercisesBySearch;
using CoachBuddy.Infrastructure.Persistence;
using CoachBuddy.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoachBuddy.MVC.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly CoachBuddyDbContext _context;

        public ExerciseController(IMediator mediator, IMapper mapper, CoachBuddyDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetAllExercisesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var exercises = await _mediator.Send(query);
            return View(exercises);
        }

        [Route("Exercise/{id}/Details")]
        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetExerciseByIdQuery(id);
            var exercise = await _mediator.Send(query);
            return View(exercise);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateExerciseCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Exercise '{command.Name}' has been created successfully.");
            return RedirectToAction(nameof(Index));
        }

        [Route("Exercise/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetExerciseByIdQuery(id);
            var exerciseDto = await _mediator.Send(query);
            if (exerciseDto == null)
            {
                return NotFound();
            }

            var command = _mapper.Map<EditExerciseCommand>(exerciseDto);
            return View(command);
        }

        [HttpPost]
        [Route("Exercise/{id}/Edit")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, EditExerciseCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Exercise '{command.Name}' has been updated successfully.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Exercise/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ExerciseDto>(exercise);
            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            var command = new DeleteExerciseCommand { Id = id };
            await _mediator.Send(command);

            this.SetNotification("success", $"Exercise '{exercise.Name}' has been deleted.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction(nameof(Index));
            }

            var query = new GetExercisesBySearchQuery(searchTerm, pageNumber, pageSize);
            var exercises = await _mediator.Send(query);

            return View("Index", exercises);
        }
    }
}
