using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Domain.Interfaces.TrainingPlan;
using MediatR;

namespace CoachBuddy.Application.TrainingPlan.Commands.CreateTrainingPlan
{
    public class CreateTrainingPlanCommandHandler : IRequestHandler<CreateTrainingPlanCommand>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public CreateTrainingPlanCommandHandler()
        {
            
        }


        public Task<Unit> Handle(CreateTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
