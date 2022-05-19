using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightName = table.Column<string>(type: "TEXT", nullable: false),
                    DepartureAirport = table.Column<string>(type: "TEXT", nullable: true),
                    ArrivalAirport = table.Column<string>(type: "TEXT", nullable: true),
                    DepartureDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DepartureTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    DepartureGate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightName);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportName = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    ArrivalAirport = table.Column<string>(type: "TEXT", nullable: true),
                    DepartureAirport = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportName);
                    table.ForeignKey(
                        name: "FK_Airports_Flights_ArrivalAirport",
                        column: x => x.ArrivalAirport,
                        principalTable: "Flights",
                        principalColumn: "FlightName");
                    table.ForeignKey(
                        name: "FK_Airports_Flights_DepartureAirport",
                        column: x => x.DepartureAirport,
                        principalTable: "Flights",
                        principalColumn: "FlightName");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeatRow = table.Column<int>(type: "INTEGER", nullable: false),
                    AisleTaken = table.Column<bool>(type: "INTEGER", nullable: false),
                    CenterTaken = table.Column<bool>(type: "INTEGER", nullable: false),
                    WindowTaken = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlightName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_FlightName",
                        column: x => x.FlightName,
                        principalTable: "Flights",
                        principalColumn: "FlightName");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityName = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityName);
                    table.ForeignKey(
                        name: "FK_Cities_Airports_City",
                        column: x => x.City,
                        principalTable: "Airports",
                        principalColumn: "AirportName");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryName = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryName);
                    table.ForeignKey(
                        name: "FK_Countries_Cities_Country",
                        column: x => x.Country,
                        principalTable: "Cities",
                        principalColumn: "CityName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_ArrivalAirport",
                table: "Airports",
                column: "ArrivalAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_DepartureAirport",
                table: "Airports",
                column: "DepartureAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_City",
                table: "Cities",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Country",
                table: "Countries",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightName",
                table: "Seats",
                column: "FlightName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
