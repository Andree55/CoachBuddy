using AutoMapper;
using CoachBuddy.Domain.Interfaces.Exercise;
using MediatR;
using System.ComponentModel;

namespace CoachBuddy.Application.Exercise.Commands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<Domain.Entities.Exercise.Exercise>(request);

            await _exerciseRepository.Create(exercise);
            return Unit.Value;
        }
    }
}
