using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ParkingApp.Data;
using ParkingApp.Domain.Entities;
using ParkingApp.Models;

namespace ParkingApp.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private ParkingContext _context;
        private Mapper _mapper;
        public ParkingRepository()
        {
            _context = new ParkingContext();
        }
        public ParkingRepository(ParkingContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            var spot = _context.Spots.FirstOrDefault(s => s.Id == booking.SpotId);
            spot.SpotBookings.Add(booking);
            _context.Bookings.Add(booking);
            _context.Update(spot);
        }

        public void AddSpot(Spot spot)
        {
            _context.Spots.Add(spot);
        }

        public void EditBooking(int id, BookingDto bookingDto)
        {
            var updatedBooking = _context.Bookings.FirstOrDefault(s => s.Id == id);
            updatedBooking = Mapper.Map(bookingDto, updatedBooking);
            var spot = _context.Spots.FirstOrDefault(s => s.Id == updatedBooking.SpotId);
            var previousBooking = spot.SpotBookings.FirstOrDefault(b => b.SpotId == bookingDto.SpotId);
            spot.SpotBookings.Remove(previousBooking);
            spot.SpotBookings.Add(updatedBooking);
            _context.Bookings.Update(updatedBooking);

        }

        public void EditSpot(int id,SpotDto spotDto)
        {
            var updatedSpot = _context.Spots.FirstOrDefault(s => s.Id == id);
            updatedSpot = Mapper.Map(spotDto, updatedSpot);
            _context.Spots.Update(updatedSpot);
        }
        
        public ICollection<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public ICollection<Booking> GetAllBookingsForSpot(int spotId)
        {
            return _context.Bookings.Where(b => b.SpotId == spotId).ToList();
        }

        public ICollection<Spot> GetAllParkingSpots()
        {
            return _context.Spots.ToList();
            
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public Spot GetSpot(int id)
        {
            return _context.Spots.FirstOrDefault(s => s.Id == id);
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
                var booking = _context.Bookings.FirstOrDefault(b => b.SpotId == id);
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
