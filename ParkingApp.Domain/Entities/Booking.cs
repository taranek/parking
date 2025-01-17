﻿using System;

namespace ParkingApp.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int SpotId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Owner { get; set; }
        public Spot BookedSpot { get; set; }
    }
}
