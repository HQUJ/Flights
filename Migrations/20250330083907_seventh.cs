using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flights.Migrations
{
    /// <inheritdoc />
    public partial class seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaneID",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaneID",
                table: "Flight",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PlaneID",
                table: "Reservation",
                column: "PlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PlaneID",
                table: "Flight",
                column: "PlaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Plane_PlaneID",
                table: "Flight",
                column: "PlaneID",
                principalTable: "Plane",
                principalColumn: "PlaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Plane_PlaneID",
                table: "Reservation",
                column: "PlaneID",
                principalTable: "Plane",
                principalColumn: "PlaneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Plane_PlaneID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Plane_PlaneID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_PlaneID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Flight_PlaneID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "PlaneID",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "PlaneID",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
