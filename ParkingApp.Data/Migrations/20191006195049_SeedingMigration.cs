using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class SeedingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "Code", "Company", "Level", "ParkingLot", "PrimaryOwner" },
                values: new object[] { 1, "XX", "Company", -1, "EP1", "Jan Kowalski" });

            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "Code", "Company", "Level", "ParkingLot", "PrimaryOwner" },
                values: new object[] { 2, "XY", "Company2", -1, "EP2", "Jose Alcara" });

            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "Code", "Company", "Level", "ParkingLot", "PrimaryOwner" },
                values: new object[] { 3, "ABC", "Company1", 1, "EP1", "Jan Nowak" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "DateEnd", "DateStart", "Owner", "SpotId" },
                values: new object[,]
                {
                    { 3, new DateTime(2019, 10, 4, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8272), new DateTime(2019, 10, 2, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8268), "Julie Lerman", 1 },
                    { 4, new DateTime(2019, 10, 10, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8280), new DateTime(2019, 10, 8, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8276), "Julie Lerman", 1 },
                    { 2, new DateTime(2019, 10, 9, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8261), new DateTime(2019, 10, 7, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(8245), "Kyle SImpson", 2 },
                    { 1, new DateTime(2019, 10, 7, 21, 50, 48, 829, DateTimeKind.Local).AddTicks(7017), new DateTime(2019, 10, 5, 21, 50, 48, 827, DateTimeKind.Local).AddTicks(4402), "Deborah Kurata", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
