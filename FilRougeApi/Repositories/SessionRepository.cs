using FilRougeApi.Data;
using FilRougeCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilRougeApi.Repositories
{
    public class SessionRepository : IRepository<Session>
    {
        private ApplicationDbContext _dbContext { get; }
        public SessionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Session session)
        {
            var addedObj = await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj is null) return false;
            _dbContext.Sessions.Remove(obj);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Session?> Get(Expression<Func<Session, bool>> predicate)
        {
            return await _dbContext.Sessions.Include(s => s.Room).Include(s => s.Users).Include(s => s.Comments).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Session>> GetAll()
        {
            return await _dbContext.Sessions.Include(s => s.Room).Include(s => s.Users).Include(s => s.Comments).ToListAsync();
        }

        public async Task<List<Session>> GetAll(Expression<Func<Session, bool>> predicate)
        {
            return await _dbContext.Sessions.Include(s => s.Room).Include(s => s.Users).Include(s => s.Comments).Where(predicate).ToListAsync();
        }

        public async Task<Session?> GetById(int id)
        {
            return await Get(u => u.Id == id);
        }

        public async Task<bool> Update(Session session)
        {
            var sessionFromDb = await GetById(session.Id);

            if (sessionFromDb == null)
                return false;

            //if (sessionFromDb.Room != session.Room)
            //    sessionFromDb.Room = session.Room;
            if (sessionFromDb.RoomId != session.RoomId)
                sessionFromDb.RoomId = session.RoomId;
            if (sessionFromDb.StartTime != session.StartTime)
                sessionFromDb.StartTime = session.StartTime;
            if (sessionFromDb.EndTime != session.EndTime)
                sessionFromDb.EndTime = session.EndTime;
            if (!sessionFromDb.Comments.Equals(session.Comments))
                sessionFromDb.Comments.AddRange(session.Comments.FindAll(s => !sessionFromDb.Comments.Contains(s)));

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
