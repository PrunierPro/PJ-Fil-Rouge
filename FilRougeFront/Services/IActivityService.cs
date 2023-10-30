using FilRougeCore.Models;

namespace FilRougeFront.Services
{
    public interface IActivityService
    {
        public Task<Activity?> Get(int id);
        public Task<List<Activity>> GetAll();
        public Task<bool> Post(Activity activity);
        public Task<bool> Put(Activity activity);
        public Task<bool> Delete(int id);
    }
}
