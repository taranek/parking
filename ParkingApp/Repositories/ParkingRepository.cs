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

        public void EditBooking(int id, Booking booking)
        {
            var updatedBooking = _context.Bookings.Where(s => s.Id == id).FirstOrDefault();

            // dont like that sutff below:
            updatedBooking.Owner = booking.Owner;
            updatedBooking.Date = booking.Date;
            updatedBooking.SpotId = booking.SpotId;
            updatedBooking.BookedSpot = booking.BookedSpot;
            
            _context.Bookings.Update(updatedBooking);
        }

        public void EditSpot(int id,Spot spot)
        {
            var updatedSpot = _context.Spots.Where(s => s.Id == id).FirstOrDefault();

            // dont like that sutff below:
            updatedSpot.Level = spot.Level;
            updatedSpot.ParkingLot = spot.ParkingLot;
            updatedSpot.PrimaryOwner = spot.PrimaryOwner;
            updatedSpot.Code = spot.Code;
            updatedSpot.Company = spot.Company;

            _context.Spots.Update(updatedSpot);
          
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

        public Spot GetSpot(int id)
        {
            return _context.Spots.Where(s => s.Id == id).FirstOrDefault();
        }

        public void RemoveBooking(int id)
        {
            var booking = GetBooking(id);
            _context.Bookings.Remove(booking);
        }

        public void RemoveSpot(int id)
        {
            var spot = GetSpot(id);
            while (spot.SpotBookings.Count > 0)
            {
                var booking = _context.Bookings.Where(b => b.SpotId == id).FirstOrDefault();
                _context.Bookings.Remove(booking);
            }
            _context.Spots.Remove(spot);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
