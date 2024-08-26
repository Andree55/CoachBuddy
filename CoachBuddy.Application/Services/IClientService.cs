using CoachBuddy.Domain.Entities;

namespace CoachBuddy.Application.Services
{
    public interface IClientService
    {
        Task Create(Client client);
    }
}