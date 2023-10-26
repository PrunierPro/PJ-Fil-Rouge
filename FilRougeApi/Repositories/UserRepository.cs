using FilRougeApi.Data;
using FilRougeCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilRougeApi.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext _dbContext { get; }
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(User user)
        {
            var addedObj = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj is null) return false;
            _dbContext.Users.Remove(obj);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await _dbContext.Users.Include(u => u.Sessions).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.Include(u => u.Sessions).ToListAsync();
        }

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return await _dbContext.Users.Include(u => u.Sessions).Where(predicate).ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await Get(u => u.Id == id);
        }

        public async Task<bool> Update(User user)
        {
            var userFromDb = await GetById(user.Id);

            if (userFromDb == null)
                return false;

            if (userFromDb.FirstName != user.FirstName)
                userFromDb.FirstName = user.FirstName;
            if (userFromDb.LastName != user.LastName)
                userFromDb.LastName = user.LastName;
            if (userFromDb.PhoneNumber != user.PhoneNumber)
                userFromDb.PhoneNumber = user.PhoneNumber;
            if (userFromDb.Address != user.Address)
                userFromDb.Address = user.Address;
            if (userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;
            if (userFromDb.PassWord != user.PassWord)
                userFromDb.PassWord = user.PassWord;
            if (userFromDb.IsAdmin != user.IsAdmin)
                userFromDb.IsAdmin = user.IsAdmin;
            if (!userFromDb.Sessions.Equals(user.Sessions))
                userFromDb.Sessions.AddRange(user.Sessions.FindAll(s => !userFromDb.Sessions.Contains(s)));

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
