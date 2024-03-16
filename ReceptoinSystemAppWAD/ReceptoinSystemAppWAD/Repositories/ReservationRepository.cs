using Microsoft.EntityFrameworkCore;
using ReceptoinSystemAppWAD.Data;
using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReceptionSystemAppDbContext _dbContext;
        public ReservationRepository(ReceptionSystemAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReservation(int id)
        {
            var reservation = await _dbContext.Reservations.FirstOrDefaultAsync(b => b.ReservationId == id);
            if (reservation != null)
            {
                _dbContext.Reservations.Remove(reservation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            var reservation = await _dbContext.Reservations.ToListAsync();
            return reservation;
        }

        public async Task<Reservation> GetSingleReservation(int id)
        {
            var reservation = await _dbContext.Reservations.SingleOrDefaultAsync(b => b.GuestId == id);
            return reservation;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            _dbContext.Entry(reservation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }  
}
