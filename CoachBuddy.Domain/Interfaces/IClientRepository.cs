using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task Create(Domain.Entities.Client client);
        Task<Domain.Entities.Client?> GetByName(string name);
    }
}
