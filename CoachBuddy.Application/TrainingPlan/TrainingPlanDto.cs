using CoachBuddy.Domain.Entities.TrainingPlan;

namespace CoachBuddy.Application.TrainingPlan
{
    public class TrainingPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsEditable { get; set; }
        public string? EncodedName { get; set; }
        public List<TrainingPlanExerciseDto>? Exercises { get; set; } = new List<TrainingPlanExerciseDto>();
        public List<Domain.Entities.Group.Group>? Groups { get; set; } = new List<Domain.Entities.Group.Group>();

    }
}
