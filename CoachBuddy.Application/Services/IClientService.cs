using CoachBuddy.Application.Client;
using CoachBuddy.Domain.Entities;

namespace CoachBuddy.Application.Services
{
    public interface IClientService
    {
        Task Create(ClientDto client);

        Task<IEnumerable<ClientDto>> GetAll();
    }
}