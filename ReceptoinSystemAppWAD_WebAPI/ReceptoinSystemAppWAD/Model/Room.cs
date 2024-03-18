using System.ComponentModel.DataAnnotations;

namespace ReceptoinSystemAppWAD.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        //[Required(ErrorMessage = "Type of room is required!")]
        public string RoomType { get; set; }
       // [Required(ErrorMessage = "Number of room is required!")]
        public string RoomNum { get; set;}
    }
}
