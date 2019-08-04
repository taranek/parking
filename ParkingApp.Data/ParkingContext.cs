using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ParkingApp.Domain.Entities;

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
                .UseSqlServer("Server=TOMEK;Database=ParkingAppData;Trusted_Connection=True;")
                .UseLoggerFactory(DbLogger);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spot>().HasMany(s => s.SpotBookings).WithOne(b => b.BookedSpot).HasForeignKey(b => b.SpotId);
        }
    }
}

