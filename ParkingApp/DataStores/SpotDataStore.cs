using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.DataStores
{
    public class SpotDataStore
    {
        //public static SpotDataStore Current { get; } = new SpotDataStore();
        private List<Spot> _spots { get; set; }
        public SpotDataStore()
        {
            _spots = new List<Spot>()
            {
                new Spot()
                {
                    Id=1,
                    Code="1A",
                    Company="Aon",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Novak Djokovic",
                },
                new Spot()
                {
                    Id=2,
                    Code="1B",
                    Company="Cisco",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Andy Murray",
                },
                new Spot()
                {
                    Id=3,
                    Code="2A",
                    Company="Aon",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Roger Federer",
                },
                new Spot()
                {
                    Id=4,
                    Code="2B",
                    Company="Aptiv",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Rafael Nadal",
                },
            };
        }
        public List<Spot> GetFakeSpots()
        {
            return _spots;
        }
    }
}
