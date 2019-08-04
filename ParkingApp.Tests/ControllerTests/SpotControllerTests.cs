using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ParkingApp.Data;
using ParkingApp;
using ParkingApp.DataStores;
using ParkingApp.Controllers;
using ParkingApp.Repositories;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Domain.Entities;
using System.Collections.Generic;
using System.Collections;
using ParkingApp.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Tests.ControllerTests
{
    [TestFixture]
    public class SpotControllerTests
    {
        private ParkingRepository _fakeRepository;
        private ParkingContext _context;
        private SpotController _service;

        private static List<Booking> _bookings;
        private static List<Spot> _spots;
        public class MyDataClass
        {
            public static IEnumerable AddSpot_TestCases
            {
                get
                {
                    yield return new TestCaseData(null).Returns(StatusCodes.Status400BadRequest);
                    yield return new TestCaseData(new SpotDto() {
                        Code = "XY",
                        Company = "Test Company",
                        Level = '1',
                        ParkingLot = "TestParkingLot",
                        PrimaryOwner = "TestOwner",
                        SpotBookings = null,
                    }).Returns(StatusCodes.Status200OK);
                    yield return new TestCaseData(new SpotDto()
                    {
                        Id = 1,
                        PrimaryOwner = "TestOwner",
                        SpotBookings = null,
                    }).Returns(StatusCodes.Status500InternalServerError);
                }
            }
        }
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ParkingContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;
            _bookings = new BookingDataStore().GetFakeBookings();
            _spots = new SpotDataStore().GetFakeSpots();
            _context = new ParkingContext(options);
            _fakeRepository = new ParkingRepository(_context);
            _context.Bookings.AddRange(_bookings);
            _context.Spots.AddRange(_spots);
            _context.SaveChanges();
        }
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void GetSpotById_0_ShouldReturnNull()
        {
            _service = new SpotController(_fakeRepository);
            var serviceCall = _service.GetSpotById(0);
            serviceCall.Result.ShouldBe(null);
        }
        [Test]
        public void GetSpotById_99_ShouldReturnNull()
        {
            _service = new SpotController(_fakeRepository);
            var serviceCall = _service.GetSpotById(99);
            serviceCall.Result.ShouldBe(null);
        }
        [Test]
        public void GetSpotById_2_ShouldReturnSecondSpot()
        {
            _service = new SpotController(_fakeRepository);
            var serviceCall = _service.GetSpotById(2);
            serviceCall.Result.Id.ShouldBe(2);
            serviceCall.Result.ShouldNotBeNull();
        }
        [Test]
        public void GetAllSpots_ShouldReturnFourSpots()
        {
            _service = new SpotController(_fakeRepository);
            var serviceCall = _service.GetAllSpots();
            serviceCall.Result.Count.ShouldBe(4);
            serviceCall.Result.ShouldNotBeNull();
            serviceCall.Result.ShouldNotBeEmpty();
        }
        [TestCaseSource(typeof(MyDataClass), "AddSpot_TestCases")]
        [Test]
        public async Task<ActionResult> AddSpot_ShouldReturnCorrectStatusCode(SpotDto dto)
        {
            _service = new SpotController(_fakeRepository);
            var serviceCall = _service.AddSpot(dto);
            return await serviceCall as ObjectResult;
        }
    }
}