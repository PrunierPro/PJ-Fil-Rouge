using FilRougeApi.Data;
using FilRougeCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilRougeApi.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private ApplicationDbContext _dbContext { get; }
        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Comment comment)
        {
            var addedObj = await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj is null) return false;
            _dbContext.Comments.Remove(obj);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Comment?> Get(Expression<Func<Comment, bool>> predicate)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetAll(Expression<Func<Comment, bool>> predicate)
        {
            return await _dbContext.Comments.Where(predicate).ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await Get(u => u.Id == id);
        }

        public async Task<bool> Update(Comment comment)
        {
            var commentFromDb = await GetById(comment.Id);

            if (commentFromDb == null)
                return false;

            //if (commentFromDb.User != comment.User)
            //    commentFromDb.User = comment.User;
            if (commentFromDb.UserId != comment.UserId)
                commentFromDb.UserId = comment.UserId;            
            //if (commentFromDb.Session != comment.Session)
            //    commentFromDb.Session = comment.Session;
            if (commentFromDb.SessionId != comment.SessionId)
                commentFromDb.SessionId = comment.SessionId;
            if (commentFromDb.Message != comment.Message)
                commentFromDb.Message = comment.Message;
            if (commentFromDb.Rating != comment.Rating)
                commentFromDb.Rating = comment.Rating;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
