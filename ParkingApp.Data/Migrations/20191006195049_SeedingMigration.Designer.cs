﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingApp.Data;

namespace ParkingApp.Data.Migrations
{
    [DbContext(typeof(ParkingContext))]
    [Migration("20191006195049_SeedingMigration")]
    partial class SeedingMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingApp.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Owner");

                    b.Property<int>("SpotId");

                    b.HasKey("Id");

                    b.HasIndex("SpotId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateEnd = new DateTime(2019, 10, 7, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(7017),
                            DateStart = new DateTime(2019, 10, 5, 21, 50, 48, 827, DateTimeKind.Local).AddTicks(4402),
                            Owner = "Deborah Kurata",
                            SpotId = 3
                        },
                        new
                        {
                            Id = 2,
                            DateEnd = new DateTime(2019, 10, 9, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8261),
                            DateStart = new DateTime(2019, 10, 7, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8245),
                            Owner = "Kyle SImpson",
                            SpotId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateEnd = new DateTime(2019, 10, 4, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8272),
                            DateStart = new DateTime(2019, 10, 2, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8268),
                            Owner = "Julie Lerman",
                            SpotId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateEnd = new DateTime(2019, 10, 10, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8280),
                            DateStart = new DateTime(2019, 10, 8, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8276),
                            Owner = "Julie Lerman",
                            SpotId = 1
                        });
                });

            modelBuilder.Entity("ParkingApp.Domain.Entities.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Company");

                    b.Property<int>("Level");

                    b.Property<string>("ParkingLot");

                    b.Property<string>("PrimaryOwner");

                    b.HasKey("Id");

                    b.ToTable("Spots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "XX",
                            Company = "Company",
                            Level = -1,
                            ParkingLot = "EP1",
                            PrimaryOwner = "Jan Kowalski"
                        },
                        new
                        {
                            Id = 2,
                            Code = "XY",
                            Company = "Company2",
                            Level = -1,
                            ParkingLot = "EP2",
                            PrimaryOwner = "Jose Alcara"
                        },
                        new
                        {
                            Id = 3,
                            Code = "ABC",
                            Company = "Company1",
                            Level = 1,
                            ParkingLot = "EP1",
                            PrimaryOwner = "Jan Nowak"
                        });
                });

            modelBuilder.Entity("ParkingApp.Domain.Entities.Booking", b =>
                {
                    b.HasOne("ParkingApp.Domain.Entities.Spot", "BookedSpot")
                        .WithMany("SpotBookings")
                        .HasForeignKey("SpotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
