using CoachBuddy.Domain.Entities;
using CoachBuddy.Domain.Interfaces;
using CoachBuddy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Infrastructure.Repositories
{
    public class ClientTrainingRepository : IClientTrainingRepository
    {
        private readonly CoachBuddyDbContext _dbContext;

        public ClientTrainingRepository(CoachBuddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(ClientTraining clientTraining)
        {
            _dbContext.Trainings.Add(clientTraining);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientTraining>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Trainings
            .Where(s => s.Client.EncodedName == encodedName)
            .ToListAsync();
    }
}
