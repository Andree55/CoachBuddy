﻿using CoachBuddy.Domain.Entities;
using CoachBuddy.Domain.Interfaces;
using CoachBuddy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoachBuddy.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CoachBuddyDbContext _dbContext;

        public ClientRepository(CoachBuddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Client client)
        {
            _dbContext.Add(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client client)
        {
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAll()
            => await _dbContext.Clients.ToListAsync();

        public async Task<Client> GetByEncodedName(string encodedName)
            => await _dbContext.Clients.FirstAsync(c => c.EncodedName == encodedName);

        public async Task<Client> GetByIdAsync(int id)
            => await _dbContext.Clients.FirstAsync(c => c.Id == id);

        public Task<Client?> GetByName(string name)
            => _dbContext.Clients.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

        public async Task<int> GetClientCountAsync()
        {
            return await _dbContext.Clients.CountAsync();
        }
    }
}
