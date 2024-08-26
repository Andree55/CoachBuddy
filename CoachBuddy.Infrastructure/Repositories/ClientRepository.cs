using CoachBuddy.Domain.Entities;
using CoachBuddy.Domain.Interfaces;
using CoachBuddy.Infrastructure.Persistence;

namespace CoachBuddy.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CoachBuddyDbContext _dbContext;

        public ClientRepository(CoachBuddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.Client client)
        {
            _dbContext.Add(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}
