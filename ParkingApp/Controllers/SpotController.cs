using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using ParkingApp.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingApp.Controllers
{
    [Route("api/spots")]
    public class SpotController : Controller
    {
        private IParkingRepository _repository;

        public SpotController(IParkingRepository parkingRepository)
        {
            _repository = parkingRepository;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ICollection<Spot>> GetAllSpots()
        {
            var result =_repository.GetAllParkingSpots();
            return result;
        }

        [HttpGet("GetSpotById/{id}")]
        public async Task<Spot> GetSpotById(int id)
        {
            var result = _repository.GetSpot(id);
            return result;
        }
        [HttpPost("AddSpot")]
        public async Task<ActionResult> AddSpot([FromBody] SpotDto spot)
        {
            if (spot == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var finalSpot = Mapper.Map<Spot>(spot);

            _repository.AddSpot(finalSpot);

            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Could not save changes.");
            }
            var addedSpot = Mapper.Map<SpotDto>(finalSpot);
            return Ok(_repository.GetSpot(finalSpot.Id));
        }

        [HttpPut("EditSpot/{id}")]
        public IActionResult EditSpot(int id, [FromBody] SpotUpdateDto spot)
        {
            var spotFromRepo = _repository.GetSpot(id);
            if (spot == null)
            {
                return BadRequest();
            }
            if (spotFromRepo == null)
            {
                return StatusCode(404, "Could not find spot to edit");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mappedSpot = Mapper.Map<SpotDto>(spot);

            _repository.EditSpot(id, mappedSpot);

            if (!_repository.SaveChanges())
            {
                return StatusCode(400, "Probably bad request, but not 500 - server is fine tho");
            }
            return Ok(_repository.GetSpot(id));
        }
        [HttpDelete("RemoveSpot/{id}")]
        public IActionResult RemoveSpot(int id)
        {
            var spotFromRepo = _repository.GetSpot(id);

            if (spotFromRepo == null)
            {
                return StatusCode(404, "Could not find spot to edit");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.RemoveSpot(id);
            if (!_repository.SaveChanges())
            {
                return StatusCode(500, "Error with saving changes");
            }
            return Ok("User removed succesfully.");
        }
    }
}
