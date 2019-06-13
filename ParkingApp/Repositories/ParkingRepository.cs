using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingApp.Data;
using ParkingApp.Domain.Entities;

namespace ParkingApp.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private ParkingContext _context;
        public ParkingRepository()
        {
            _context = new ParkingContext();
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
        }

        public void AddSpot(Spot spot)
        {
            _context.Spots.Add(spot);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public IEnumerable<Booking> GetAllBookingsForSpot(int spotId)
        {
            return _context.Bookings.Where(b => b.SpotId == spotId).ToList();
        }

        public IEnumerable<Spot> GetAllParkingSpots()
        {
            return _context.Spots.ToList();
            
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings.Where(b => b.Id == id).FirstOrDefault();
        }

        public Spot GetParkingSpot(int id)
        {
            return _context.Spots.Where(s => s.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
