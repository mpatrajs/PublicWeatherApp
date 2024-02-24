using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicWeatherApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTemperatureColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "WeatherData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinTemperature",
                table: "WeatherData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "WeatherData");
        }
    }
}
