using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace ParkingApp.Domain.Entities
{
    public class Spot 
    {
        public Spot()
        {
            SpotBookings = new List<Booking>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public string PrimaryOwner { get; set; }
        public string ParkingLot { get; set; }
        public string Company { get; set; }
        public List<Booking> SpotBookings { get; set; }
    }
}
