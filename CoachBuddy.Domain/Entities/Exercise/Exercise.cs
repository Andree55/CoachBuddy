namespace CoachBuddy.Domain.Entities.Exercise
{
    public class Exercise
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? MuscleGroup { get; set; }
        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = $"{Name.ToLower().Replace(" ", "-")}";
    }
}
