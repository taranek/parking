using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.DataStores
{
    public class BookingDataStore
    {

        public static BookingDataStore Current { get; } = new BookingDataStore();
        public List<BookingDto> Bookings { get; set; }
        public BookingDataStore()
        {
            Bookings = new List<BookingDto>()
            {
                new BookingDto()
                {
                    Id = 1,
                    SpotId = 1,
                    Owner = "Gennaro Gatusso",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(5)
                },
                new BookingDto()
                {
                    Id = 2,
                    SpotId = 2,
                    Owner = "Krzysztof Piatek",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(5)
                },
            };
        }
    }
}
