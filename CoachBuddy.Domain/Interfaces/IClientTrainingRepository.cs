using CoachBuddy.Domain.Entities;

namespace CoachBuddy.Domain.Interfaces
{
    public interface IClientTrainingRepository
    {
        Task Create(ClientTraining clientTraining);
        Task<IEnumerable<ClientTraining>> GetAllByEncodedName(string encodedName);
    }
}
