using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.DataStores;
using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using ParkingApp.Repositories;

namespace ParkingApp.Controllers
{
    [Route("api/spots")]
    public class SpotController : Controller
    {
        private IParkingRepository _repository;
        private Mapper _mapper;

        public SpotController(IParkingRepository parkingRepository)
        {
            _repository = parkingRepository;

        }

        [HttpGet]
        public IActionResult GetAllSpots()
        {
            var result = _repository.GetAllParkingSpots();
            return Ok(result);
        }

        [HttpGet("GetSpotById/{id}")]
        public IActionResult GetSpotById(int id)
        {
            var result = _repository.GetSpot(id);
            return Ok(result);
        }
        [HttpPost("AddSpot")]
        public IActionResult AddSpot([FromBody] SpotDto spot)
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
                return StatusCode(400, "Probably bad request, but not 500 - server is fine tho");
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
            var mappedSpot = Mapper.Map<Spot>(spot);

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
