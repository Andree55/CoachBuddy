namespace CoachBuddy.Application.ClientGroup
{
    public class ClientGroupDto
    {
        public int ClientId { get; set; }
        public int GroupId { get; set; }
        public string? FullName { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
