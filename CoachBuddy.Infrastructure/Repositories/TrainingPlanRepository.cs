using CoachBuddy.Domain.Entities.TrainingPlan;
using CoachBuddy.Domain.Interfaces.TrainingPlan;
using CoachBuddy.Infrastructure.Persistence;

namespace CoachBuddy.Infrastructure.Repositories
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly CoachBuddyDbContext _dbContext;
        public TrainingPlanRepository(CoachBuddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TrainingPlan trainingPlan)
        {
            await _dbContext.TrainingPlans.AddAsync(trainingPlan);
            await _dbContext.SaveChangesAsync();
        }

        public Task Commit()
            =>_dbContext.SaveChangesAsync();

        public async Task Create(TrainingPlan trainingPlan)
        {
            _dbContext.Add(trainingPlan);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TrainingPlan id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrainingPlan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TrainingPlan> GetByEncodedName(string encodedName)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingPlan> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetExerciseCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TrainingPlan exercise)
        {
            throw new NotImplementedException();
        }
    }
}
