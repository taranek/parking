﻿using ParkingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class SpotDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public string PrimaryOwner { get; set; }
        public string ParkingLot { get; set; }
        public string Company { get; set; }
        public List<Booking> SpotBookings { get; set; }
    }
}