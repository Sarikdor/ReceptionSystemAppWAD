using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetSingleReservation(int id);
        Task CreateReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int id);
    }
}
