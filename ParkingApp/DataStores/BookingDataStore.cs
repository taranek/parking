using ParkingApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ParkingApp.DataStores
{
    public class BookingDataStore
    {
        //public static BookingDataStore Current { get; } = new BookingDataStore();
        private List<Booking> _bookings { get; set; }
        public BookingDataStore()
        {
            _bookings = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    SpotId = 1,
                    Owner = "Gennaro Gatusso",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(5)
                },
                new Booking()
                {
                    Id = 2,
                    SpotId = 2,
                    Owner = "Krzysztof Piatek",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddHours(5)
                },
            };
        }
        public List<Booking> GetFakeBookings()
        {
            return _bookings;
        }
    }
}
