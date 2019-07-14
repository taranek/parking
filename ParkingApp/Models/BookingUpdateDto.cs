using System;

namespace ParkingApp.Models
{
    public class BookingUpdateDto
    {
        public int SpotId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Owner { get; set; }
    }
}
