namespace CoachBuddy.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<ClientGroup> ClientGroups { get; set; } = new();
    }
}
