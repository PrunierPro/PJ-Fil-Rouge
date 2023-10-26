using FilRougeCore.Models;
using FilRougeFront.DTOs;

namespace FilRougeFront.Services
{
    public interface IRoomService
    {
        public Task<Room?> Get(int id);
        public Task<List<Room>> GetAll();
        public Task<bool> Post(Room room);
        public Task<bool> Put(Room room);
        public Task<bool> Delete(int id);
        Task Put(RoomEditDTO? roomToEdit);
        Task Post(RoomEditDTO? roomToEdit);
    }
}
