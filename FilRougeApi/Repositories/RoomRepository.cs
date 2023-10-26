using FilRougeApi.Data;
using FilRougeCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilRougeApi.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private ApplicationDbContext _dbContext { get; }
        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Room room)
        {
            var addedObj = await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj is null) return false;
            _dbContext.Rooms.Remove(obj);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Room?> Get(Expression<Func<Room, bool>> predicate)
        {
            return await _dbContext.Rooms.Include(r => r.Schedules).Include(r => r.Activities).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Room>> GetAll()
        {
            
            return await _dbContext.Rooms.Include(r => r.Schedules).Include(r => r.Activities).ToListAsync();
        }

        public async Task<List<Room>> GetAll(Expression<Func<Room, bool>> predicate)
        {
            return await _dbContext.Rooms.Include(r => r.Schedules).Include(r => r.Activities).Where(predicate).ToListAsync();
        }

        public async Task<Room?> GetById(int id)
        {
            return await Get(r => r.Id == id);
        }

        public async Task<bool> Update(Room room)
        {
            var roomFromDb = await GetById(room.Id);

            if (roomFromDb == null)
                return false;

            if (roomFromDb.Name != room.Name)
                roomFromDb.Name = room.Name;
            if (roomFromDb.Location != room.Location)
                roomFromDb.Location = room.Location;
            if (!roomFromDb.Schedules.Equals(room.Schedules))
                roomFromDb.Schedules.AddRange(room.Schedules.FindAll(a => !roomFromDb.Schedules.Contains(a)));
            if (!roomFromDb.Activities.Equals(room.Activities))
                roomFromDb.Activities.AddRange(room.Activities.FindAll(a => !roomFromDb.Activities.Contains(a)));

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
