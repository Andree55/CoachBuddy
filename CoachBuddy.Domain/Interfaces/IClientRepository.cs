using CoachBuddy.Domain.Entities;

namespace CoachBuddy.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task Create(Domain.Entities.Client client);
        Task<Domain.Entities.Client?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Client>> GetAll();
        Task<Domain.Entities.Client> GetByEncodedName(string encodedName);
        Task Commit();
        Task<Client> GetByIdAsync(int Id);
        Task DeleteAsync(Client client);
        Task<int> GetClientCountAsync();
    }
}
