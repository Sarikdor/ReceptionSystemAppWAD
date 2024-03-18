using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceptoinSystemAppWAD.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Guest of reservation is required!")]
        [ForeignKey("GuestId")]
        public int? GuestId { get; set; }
        public Guest? Guest { get; set; }
        [Required(ErrorMessage = "For Reservation room is required!")]
        [ForeignKey("RoomId")]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }


    }
}
