using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParkingApp.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int SpotId { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }
        public Spot BookedSpot { get; set; }
    }
}
