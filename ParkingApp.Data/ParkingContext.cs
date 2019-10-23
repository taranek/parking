using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ParkingApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ParkingApp.Data
{
    public class ParkingContext : DbContext
    {
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public static readonly LoggerFactory DbLogger = new LoggerFactory(new[]
            {
            new ConsoleLoggerProvider((category,level)=>
            category == DbLoggerCategory.Database.Command.Name
            && level ==LogLevel.Information,true)
        });

        public ParkingContext()
        {
            //this.Database.EnsureCreated();
        }
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Server=EPLLH5CG6480NHG\\SQLEXPRESS;Database=ParkingDBMain;Trusted_Connection=True")
                .UseLoggerFactory(DbLogger);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spot>().HasMany(s => s.SpotBookings).WithOne(b => b.BookedSpot).HasForeignKey(b => b.SpotId);
            modelBuilder.Seed();
        }
        
    }
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spot>().HasData(
                new Spot
                {
                    Id = 1,
                    Code = "XX",
                    Company = "Company",
                    Level = -1,
                    ParkingLot = "EP1",
                    PrimaryOwner = "Jan Kowalski",
                    SpotBookings = new List<Booking>(),
                },
                new Spot
                {
                    Id = 2,
                    Code = "XY",
                    Company = "Company2",
                    Level = -1,
                    ParkingLot = "EP2",
                    PrimaryOwner = "Jose Alcara",
                    SpotBookings = new List<Booking>(),
                },
                new Spot
                {
                    Id = 3,
                    Code = "ABC",
                    Company = "Company1",
                    Level = 1,
                    ParkingLot = "EP1",
                    PrimaryOwner = "Jan Nowak",
                    SpotBookings = new List<Booking>(),
                });
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    SpotId = 3,
                    DateStart = DateTime.Now.AddDays(-1),
                    DateEnd = DateTime.Now.AddDays(1),
                    Owner = "Deborah Kurata",
                },
                 new Booking
                 {
                     Id = 2,
                     SpotId = 2,
                     DateStart = DateTime.Now.AddDays(1),
                     DateEnd = DateTime.Now.AddDays(3),
                     Owner = "Kyle SImpson",
                 },
                 new Booking
                 {
                     Id = 3,
                     SpotId = 1,
                     DateStart = DateTime.Now.AddDays(-4),
                     DateEnd = DateTime.Now.AddDays(-2),
                     Owner = "Julie Lerman",
                 },
                 new Booking
                 {
                     Id = 4,
                     SpotId = 1,
                     DateStart = DateTime.Now.AddDays(2),
                     DateEnd = DateTime.Now.AddDays(4),
                     Owner = "Julie Lerman",
                 }
            );
        }
    }
    }

