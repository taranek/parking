using System;

namespace ParkingApp.Models
{
    public class BookingDto
    {
        public int? Id { get; set; }
        public int SpotId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Owner { get; set; }
    }
}
