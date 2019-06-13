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
        Spot GetParkingSpot(int id);
        void AddSpot(Spot spot);
        
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetAllBookingsForSpot(int spotId);
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        bool SaveChanges();
    }
}
