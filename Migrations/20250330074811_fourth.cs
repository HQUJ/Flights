using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flights.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_FlightID",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "FlightID",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FK_Reservation_Flight_FlightID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Flight_FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "FK_Reservation_Flight_FlightID",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "FlightID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_FlightID",
                table: "Reservation",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Flight_FlightID",
                table: "Reservation",
                column: "FlightID",
                principalTable: "Flight",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
