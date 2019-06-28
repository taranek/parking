using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using ParkingApp.Repositories;

namespace ParkingApp.Controllers
{
    [Route("api/bookings")]
    public class BookingController : Controller
    {
        private IParkingRepository _repository;

        public BookingController(IParkingRepository parkingRepository)
        {
            _repository = parkingRepository;
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var result = _repository.GetAllBookings();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var result = _repository.GetBooking(id);
            return Ok(result);
        }

        [HttpGet("forSpot/{spotId}")]
        public IActionResult GetAllBokingsForSpot(int spotId)
        {
            var result = _repository.GetAllBookingsForSpot(spotId);
            return Ok(result);
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking([FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                return BadRequest();
            }

            var spot = _repository.GetSpot(bookingDto.SpotId);
            if (spot == null)
            {
                return StatusCode(404, $"Couldn't find the spot that has an id: {bookingDto.SpotId}");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingEntity = Mapper.Map<Booking>(bookingDto);
            bookingEntity.BookedSpot = spot;
            bookingEntity.SpotId = spot.Id;

            _repository.AddBooking(bookingEntity);
            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Changes has not been save");
            }

            return Ok(_repository.GetBooking(bookingEntity.Id));
        }
        [HttpPut("EditBooking/{id}")]
        public IActionResult EditBooking([FromBody] BookingDto bookingDto)
        {
            if (bookingDto == null)
            {
                return BadRequest();
            }

            var spot = _repository.GetSpot(bookingDto.SpotId);
            if (spot == null)
            {
                return StatusCode(404, $"Couldn't find the spot that has an id: {bookingDto.SpotId}");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingEntity = Mapper.Map<Booking>(bookingDto);
            bookingEntity.BookedSpot = spot;
            bookingEntity.SpotId = spot.Id;

            _repository.AddBooking(bookingEntity);
            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Changes has not been save");
            }

            return Ok(_repository.GetBooking(bookingEntity.Id));
        }
    }
}
