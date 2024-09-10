using CoachBuddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Domain.Interfaces
{
    public interface IClientTrainingRepository
    {
        Task Create(ClientTraining clientTraining);
    }
}
