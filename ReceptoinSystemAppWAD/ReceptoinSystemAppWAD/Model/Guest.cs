﻿using ReceptoinSystemAppWAD.Data;
namespace ReceptoinSystemAppWAD.Model
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
    }

}

