using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VPassport.Migrations
{
    /// <inheritdoc />
    public partial class AddPartWarranty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartWarranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartWarranties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartWarranties_CustomerVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Vehicle_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartWarranties_VehicleId",
                table: "PartWarranties",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartWarranties");
        }
    }
}
