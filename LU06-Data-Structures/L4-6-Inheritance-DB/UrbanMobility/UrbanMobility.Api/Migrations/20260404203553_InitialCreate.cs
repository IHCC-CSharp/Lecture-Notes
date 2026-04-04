using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanMobility.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vin = table.Column<string>(type: "TEXT", nullable: false),
                    ModelName = table.Column<string>(type: "TEXT", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    BatteryCapacityKwh = table.Column<double>(type: "REAL", nullable: true),
                    CurrentChargeLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    FuelTankSizeLiters = table.Column<double>(type: "REAL", nullable: true),
                    Engine = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
