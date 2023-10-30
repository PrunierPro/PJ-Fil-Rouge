using FilRougeApi.Data;
using FilRougeCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilRougeApi.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private ApplicationDbContext _dbContext { get; }
        public ScheduleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Schedule schedule)
        {
            var addedObj = await _dbContext.Schedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj is null) return false;
            _dbContext.Schedules.Remove(obj);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Schedule?> Get(Expression<Func<Schedule, bool>> predicate)
        {
            return await _dbContext.Schedules.Include(s => s.Room).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Schedule>> GetAll()
        {
            return await _dbContext.Schedules.Include(s => s.Room).ToListAsync();
        }

        public async Task<List<Schedule>> GetAll(Expression<Func<Schedule, bool>> predicate)
        {
            return await _dbContext.Schedules.Include(s => s.Room).Where(predicate).ToListAsync();
        }

        public async Task<Schedule?> GetById(int id)
        {
            return await Get(u => u.Id == id);
        }

        public async Task<bool> Update(Schedule schedule)
        {
            var scheduleFromDb = await GetById(schedule.Id);

            if (scheduleFromDb == null)
                return false;

            //if (scheduleFromDb.Room != schedule.Room)
            //    scheduleFromDb.Room = schedule.Room;
            if (scheduleFromDb.RoomId != schedule.RoomId)
                scheduleFromDb.RoomId = schedule.RoomId;
            if (scheduleFromDb.OpenTime != schedule.OpenTime)
                scheduleFromDb.OpenTime = schedule.OpenTime;
            if (scheduleFromDb.CloseTime != schedule.CloseTime)
                scheduleFromDb.CloseTime = schedule.CloseTime;
            if (scheduleFromDb.Day != schedule.Day)
                scheduleFromDb.Day = schedule.Day;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
