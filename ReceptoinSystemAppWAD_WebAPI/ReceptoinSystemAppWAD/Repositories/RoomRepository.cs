using Microsoft.EntityFrameworkCore;
using ReceptoinSystemAppWAD.Data;
using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ReceptionSystemAppDbContext _dbContext;
        public RoomRepository(ReceptionSystemAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatRoom(Room room)
        {
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            var room = await _dbContext.Rooms.ToListAsync();
            return room;
        }

        public async Task<Room> GetSingleRoom(int id)
        {
            var room = await _dbContext.Rooms.SingleOrDefaultAsync(r => r.RoomId == id);
            return room;
        }

        public async Task UpdateRoom(Room room)
        {
            _dbContext.Entry(room).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
