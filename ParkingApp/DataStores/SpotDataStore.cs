using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.DataStores
{
    public class SpotDataStore
    {
        public static SpotDataStore Current { get; } = new SpotDataStore();
        public List<SpotDto> Spots { get; set; }
        public SpotDataStore()
        {
            Spots = new List<SpotDto>()
            {
                new SpotDto()
                {
                    Id=1,
                    Code="1A",
                    Company="Aon",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Novak Djokovic",
                },
                new SpotDto()
                {
                    Id=2,
                    Code="1B",
                    Company="Cisco",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Andy Murray",
                },
                new SpotDto()
                {
                    Id=3,
                    Code="2A",
                    Company="Aon",
                    Level=1,
                    ParkingLot="EP-1",
                    PrimaryOwner="Roger Federer",
                },
                new SpotDto()
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
    }
}
