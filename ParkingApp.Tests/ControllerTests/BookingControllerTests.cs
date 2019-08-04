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

namespace Tests.ControllerTests
{
    [TestFixture]
    public class BookingControllerTests
    {
        private ParkingRepository _fakeRepository;
        private ParkingContext _context;
        private BookingController _service;

        private static List<Booking> _bookings;
        private static List<Spot> _spots;

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

            _service = new BookingController(_fakeRepository);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void GetAllBookings_ShouldReturn_2()
        {
            var serviceCall = _service.GetAllBookings();
            serviceCall.Result.Count.ShouldBe(2);
            serviceCall.Result.ShouldNotBeNull();
            serviceCall.Result.ShouldNotBeEmpty();
        }
        [Test]
        public void GetBookingById_99_ShouldReturnNull()
        {
            var serviceCall = _service.GetBookingById(99);
            serviceCall.Result.ShouldBe(null);
        }
        [Test]
        public void GetBookingById_0_ShouldReturnNull()
        {
            var serviceCall = _service.GetBookingById(0);
            serviceCall.Result.ShouldBe(null);
        }
        [Test]
        public void GetBookingById_2_ShouldReturnSecondSpot()
        {
            var serviceCall = _service.GetBookingById(2);
            serviceCall.Result.Id.ShouldBe(2);
            serviceCall.Result.ShouldNotBeNull();
        }
    }
}