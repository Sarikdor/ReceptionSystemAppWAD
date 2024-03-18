using Microsoft.EntityFrameworkCore;
using ReceptoinSystemAppWAD.Data;
using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly ReceptionSystemAppDbContext _dbContext;

        public GuestRepository(ReceptionSystemAppDbContext dbContext)
        {
           _dbContext = dbContext;
        }


        public async Task CreateGuest(Guest guest)
        {
            await _dbContext.Guests.AddAsync(guest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGuest(int id)
        {
            var guest = await _dbContext.Guests.FirstOrDefaultAsync(g => g.GuestId == id);
            if (guest != null)
            {
                _dbContext.Guests.Remove(guest);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            var guest =  await _dbContext.Guests.ToListAsync();
            return guest;
        }

        public async Task<Guest> GetSingleGuest(int id)
        {
            var guest = await _dbContext.Guests.SingleOrDefaultAsync(g => g.GuestId == id);
            return guest;
        }

        public async Task UpdateGuest(Guest guest)
        {
            _dbContext.Entry(guest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
