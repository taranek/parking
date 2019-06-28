using ParkingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Repositories
{
    public interface IParkingRepository
    {
        IEnumerable<Spot> GetAllParkingSpots();
        Spot GetSpot(int id);
        void AddSpot(Spot spot);
        void EditSpot(int id, Spot spot);
        void RemoveSpot(int id);
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetAllBookingsForSpot(int spotId);
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void EditBooking(int id, Booking booking);
        void RemoveBooking(int id);
        bool SaveChanges();
    }
}
