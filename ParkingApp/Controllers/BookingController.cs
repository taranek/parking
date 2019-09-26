using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using ParkingApp.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ICollection <Booking>> GetAllBookings()
        {
            var result = _repository.GetAllBookings();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Booking> GetBookingById(int id)
        {
            var result = _repository.GetBooking(id);
            return result;
        }

        [HttpGet("forSpot/{spotId}")]
        public async Task<ICollection<Booking>> GetAllBokingsForSpot(int spotId)
        {
            var result = _repository.GetAllBookingsForSpot(spotId);
            return result;
        }

        [HttpPost("Add")]
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
            
            _repository.AddBooking(bookingEntity);
            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Changes has not been saved");
            }

            return Ok(_repository.GetBooking(bookingEntity.Id));
        }
        [HttpPut("Edit/{id}")]
        public IActionResult EditBooking([FromBody] BookingUpdateDto bookingUpdateDto, int id)
        {
            if (bookingUpdateDto == null)
            {
                return BadRequest();
            }

            var spot = _repository.GetSpot(bookingUpdateDto.SpotId);
            if (spot == null)
            {
                return StatusCode(404, $"Couldn't find the spot that has an id: {bookingUpdateDto.SpotId} associated with booking of id: {id}");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingDto = Mapper.Map<BookingDto>(bookingUpdateDto);
            _repository.EditBooking(id,bookingDto);
            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Changes has not been saved.");
            }
            return Ok(_repository.GetBooking(id));
        }
        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveBooking(int id)
        {
            var booking = _repository.GetBooking(id);

            if (booking == null)
            {
                return StatusCode(404, "Could not find booking to edit");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.RemoveBooking(id);
            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Error with saving changes");
            }
            return Ok("Booking removed succesfully.");
        }
    }
}
