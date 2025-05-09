using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VPassport.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceReminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseMileageInterval = table.Column<bool>(type: "bit", nullable: false),
                    MileageInterval = table.Column<int>(type: "int", nullable: true),
                    UseTimeInterval = table.Column<bool>(type: "bit", nullable: false),
                    TimeIntervalInDays = table.Column<int>(type: "int", nullable: true),
                    NotifyPeriodInDays = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTriggered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReminders_CustomerVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Vehicle_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReminders_VehicleId",
                table: "ServiceReminders",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceReminders");
        }
    }
}
