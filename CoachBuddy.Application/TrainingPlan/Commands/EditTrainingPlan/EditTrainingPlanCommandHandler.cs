using MediatR;

namespace CoachBuddy.Application.TrainingPlan.Commands.EditTrainingPlan
{
    public class EditTrainingPlanCommandHandler : IRequestHandler<EditTrainingPlanCommand>
    {
        public Task<Unit> Handle(EditTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
