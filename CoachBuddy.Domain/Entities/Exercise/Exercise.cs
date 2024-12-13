namespace CoachBuddy.Domain.Entities.Exercise
{
    public class Exercise
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MuscleGroup { get; set; }
    }
}
