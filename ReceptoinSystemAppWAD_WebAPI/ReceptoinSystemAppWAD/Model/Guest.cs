using ReceptoinSystemAppWAD.Data;
using System.ComponentModel.DataAnnotations;

namespace ReceptoinSystemAppWAD.Model
{
    public class Guest
    {
        public int GuestId { get; set; }

        //[Required(ErrorMessage ="Name of guest is required!")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "PhoneNumber of guest is required!")]
        public string PhoneNumber { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
    }

}

