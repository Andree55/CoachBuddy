using AutoMapper;
using CoachBuddy.Domain.Interfaces.Exercise;
using MediatR;

namespace CoachBuddy.Application.Exercise.Commands.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;
        public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);

            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {request.Id} not found.");
            }

            await _exerciseRepository.DeleteAsync(exercise);
            return Unit.Value;
        }
    }
}
