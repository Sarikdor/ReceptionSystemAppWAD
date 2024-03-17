using System.ComponentModel.DataAnnotations.Schema;

namespace ReceptoinSystemAppWAD.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public int GuestId { get; set; }
        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }


    }
}
