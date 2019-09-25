using ParkingApp.Repositories;
using System;

namespace ParkingApp.Domain.Validators
{
    public class BookingValidator : IValidator
    {
        private ParkingRepository _parkingRepository;
        public BookingValidator(ParkingRepository repository)
        {
            _parkingRepository = repository;
        }
        public bool ValidateBeforeCreate(int id)
        {
            return true;
        }

        public bool ValidateBeforeDelete(int bookingId)
        {
            return true;
        }

        public bool ValidateBeforeEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
