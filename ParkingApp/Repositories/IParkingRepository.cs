using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using System.Collections.Generic;

namespace ParkingApp.Repositories
{
    public interface IParkingRepository
    {
        IEnumerable<Spot> GetAllParkingSpots();
        Spot GetSpot(int id);
        void AddSpot(Spot spot);
        void EditSpot(int id, SpotDto spot);
        void RemoveSpot(int id);
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetAllBookingsForSpot(int spotId);
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void EditBooking(int id, BookingDto booking);
        void RemoveBooking(int id);
        bool SaveChanges();
    }
}
