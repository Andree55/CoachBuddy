using AutoMapper;
using CoachBuddy.Domain.Interfaces.TrainingPlan;
using MediatR;

namespace CoachBuddy.Application.TrainingPlan.Queries.GetTrainingPlanById
{
    public class GetTrainingPlanByIdQueryHandler : IRequestHandler<GetTrainingPlanByIdQuery, TrainingPlanDto>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IMapper _mapper;
        public GetTrainingPlanByIdQueryHandler(ITrainingPlanRepository trainingPlanRepository, IMapper mapper)
        {
            _trainingPlanRepository = trainingPlanRepository;
            _mapper = mapper;
        }
        public Task<TrainingPlanDto> Handle(GetTrainingPlanByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
