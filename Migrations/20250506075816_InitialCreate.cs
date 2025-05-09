using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VPassport.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerVehicles",
                columns: table => new
                {
                    Vehicle_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassiNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVehicles", x => x.Vehicle_ID);
                    table.ForeignKey(
                        name: "FK_CustomerVehicles_Customers_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Document_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehicle_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Document_ID);
                    table.ForeignKey(
                        name: "FK_Documents_CustomerVehicles_Vehicle_ID",
                        column: x => x.Vehicle_ID,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Vehicle_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerVehicles_Customer_ID",
                table: "CustomerVehicles",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Vehicle_ID",
                table: "Documents",
                column: "Vehicle_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "CustomerVehicles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
