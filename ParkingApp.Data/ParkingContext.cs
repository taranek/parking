using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ParkingApp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=TOMEK;Database=ParkingAppData;Trusted_Connection=True;")
                .UseLoggerFactory(DbLogger);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //       DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field)
            
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Spot>().HasMany(s => s.SpotBookings).WithOne(b => b.BookedSpot).HasForeignKey(b => b.SpotId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

