using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VPassport.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelEntries",
                columns: table => new
                {
                    FuelEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RefuelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Litres = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelEntries", x => x.FuelEntryId);
                    table.ForeignKey(
                        name: "FK_FuelEntries_CustomerVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Vehicle_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuelEntries_VehicleId",
                table: "FuelEntries",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelEntries");
        }
    }
}
