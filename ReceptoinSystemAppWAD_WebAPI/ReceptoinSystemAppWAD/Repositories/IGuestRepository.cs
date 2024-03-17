using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAllGuests();
        Task<Guest> GetSingleGuest(int id);
        Task CreateGuest(Guest guest);
        Task UpdateGuest(Guest guest);
        Task DeleteGuest(int id);

    }
}
