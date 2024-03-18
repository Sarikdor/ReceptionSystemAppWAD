using Microsoft.EntityFrameworkCore;
using ReceptoinSystemAppWAD.Model;

namespace ReceptoinSystemAppWAD.Data
{
    public class ReceptionSystemAppDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
       

        public ReceptionSystemAppDbContext(DbContextOptions<ReceptionSystemAppDbContext> options) : base(options) { }
        

        }
}
