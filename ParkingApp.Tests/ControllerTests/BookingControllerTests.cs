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
        private BookingController _controller;

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

            _controller = new BookingController(_fakeRepository);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void GetAllBookings_ShouldReturn_2()
        {
            var apiCall = _controller.GetAllBookings();
            apiCall.Result.Count.ShouldBe(2);
            apiCall.Result.ShouldNotBeNull();
            apiCall.Result.ShouldNotBeEmpty();
        }
        [Test]
        public void GetBookingById_99_ShouldReturnNull()
        {
            var apiCall = _controller.GetBookingById(99);
            apiCall.Result.ShouldBe(null);
        }
        [Test]
        public void GetBookingById_0_ShouldReturnNull()
        {
            var apiCall = _controller.GetBookingById(0);
            apiCall.Result.ShouldBe(null);
        }
        [Test]
        public void GetBookingById_2_ShouldReturnSecondSpot()
        {
            var apiCall = _controller.GetBookingById(2);
            apiCall.Result.Id.ShouldBe(2);
            apiCall.Result.ShouldNotBeNull();
        }
    }
}