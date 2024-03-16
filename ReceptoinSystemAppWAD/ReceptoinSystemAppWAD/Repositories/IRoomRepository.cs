using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoom();
        Task<Room> GetSingleRoom(int id);
        Task CreatRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
    }
}
