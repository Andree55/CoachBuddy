namespace CoachBuddy.Domain.Entities
{
    public class ClientGroup
    {
        public int ClientId { get; set; }
        public Client Client { get; set; } = default!;
        public int GroupId { get; set; }
        public int MyProperty { get; set; }
    }
}
