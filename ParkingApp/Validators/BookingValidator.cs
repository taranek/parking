using ParkingApp.Domain.Entities;
using ParkingApp.Repositories;
using System;

namespace ParkingApp.Domain.Validators
{
    public class BookingValidator : IValidator<Booking>
    {
        private ParkingRepository _parkingRepository;
        public BookingValidator(ParkingRepository repository)
        {
            _parkingRepository = repository;
        }
        public bool ValidateBeforeCreate(Booking id)
        {
            return true;
        }

        public bool ValidateBeforeDelete(Booking bookingId)
        {
            return true;
        }

        public bool ValidateBeforeEdit(Booking b)
        {
            throw new NotImplementedException();
        }
    }
}
