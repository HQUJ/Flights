using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flights.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Flight_FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_FlightID",
                table: "Reservation",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Flight_FlightID",
                table: "Reservation",
                column: "FlightID",
                principalTable: "Flight",
                principalColumn: "FlightID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_FlightID",
                table: "Reservation");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_FK_Reservation_Flight_FlightID",
                table: "Reservation",
                column: "FK_Reservation_Flight_FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Flight_FK_Reservation_Flight_FlightID",
                table: "Reservation",
                column: "FK_Reservation_Flight_FlightID",
                principalTable: "Flight",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
