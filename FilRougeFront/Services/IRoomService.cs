using FilRougeCore.Models;

namespace FilRougeFront.Services
{
    public interface IRoomService
    {
        Task<Room?> Get(int id);
        Task<List<Room>> GetAll();
        Task<bool> Post(Room room);
        Task<bool> Put(Room room);
        Task<bool> Delete(int id);
    }
}
