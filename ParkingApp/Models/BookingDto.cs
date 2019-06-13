using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int SpotId { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }
    }
}
