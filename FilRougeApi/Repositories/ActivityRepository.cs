using FilRougeApi.Data;
using FilRougeCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilRougeApi.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {
        private ApplicationDbContext _dbContext { get; }
        public ActivityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Activity activity)
        {
            var addedObj = await _dbContext.Activities.AddAsync(activity);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj is null) return false;
            _dbContext.Activities.Remove(obj);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Activity?> Get(Expression<Func<Activity, bool>> predicate)
        {
            return await _dbContext.Activities.Include(a => a.Rooms).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Activity>> GetAll()
        {
            return await _dbContext.Activities.Include(a => a.Rooms).ToListAsync();
        }

        public async Task<List<Activity>> GetAll(Expression<Func<Activity, bool>> predicate)
        {
            return await _dbContext.Activities.Include(a => a.Rooms).Where(predicate).ToListAsync();
        }

        public async Task<Activity?> GetById(int id)
        {
            return await Get(u => u.Id == id);
        }

        public async Task<bool> Update(Activity activity)
        {
            var activityFromDb = await GetById(activity.Id);

            if (activityFromDb == null)
                return false;

            if (activityFromDb.Name != activity.Name)
                activityFromDb.Name = activity.Name;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
