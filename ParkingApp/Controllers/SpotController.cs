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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllSpots()
        {
            var result = _repository.GetAllParkingSpots();
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("GetSpotById/{id}")]
        public IActionResult GetSpotById(int id)
        {
            var result = _repository.GetParkingSpot(id);
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
            return Ok(_repository.GetParkingSpot(finalSpot.Id));
        }

    }
}
