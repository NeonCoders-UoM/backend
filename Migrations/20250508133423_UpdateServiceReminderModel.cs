using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VPassport.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceReminderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MileageInterval",
                table: "ServiceReminders");

            migrationBuilder.DropColumn(
                name: "TimeIntervalInDays",
                table: "ServiceReminders");

            migrationBuilder.DropColumn(
                name: "UseMileageInterval",
                table: "ServiceReminders");

            migrationBuilder.DropColumn(
                name: "UseTimeInterval",
                table: "ServiceReminders");

            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalInMonths",
                table: "ServiceReminders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeIntervalInMonths",
                table: "ServiceReminders");

            migrationBuilder.AddColumn<int>(
                name: "MileageInterval",
                table: "ServiceReminders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalInDays",
                table: "ServiceReminders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseMileageInterval",
                table: "ServiceReminders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseTimeInterval",
                table: "ServiceReminders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
