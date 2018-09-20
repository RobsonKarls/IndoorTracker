using Microsoft.EntityFrameworkCore.Migrations;

namespace IndoorTracker.API.Migrations
{
    public partial class adding_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Wifis",
                newName: "Wifis",
                newSchema: "tracking");

            migrationBuilder.RenameTable(
                name: "SensorDatas",
                newName: "SensorDatas",
                newSchema: "tracking");

            migrationBuilder.RenameTable(
                name: "Gps",
                newName: "Gps",
                newSchema: "tracking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Wifis",
                schema: "tracking",
                newName: "Wifis");

            migrationBuilder.RenameTable(
                name: "SensorDatas",
                schema: "tracking",
                newName: "SensorDatas");

            migrationBuilder.RenameTable(
                name: "Gps",
                schema: "tracking",
                newName: "Gps");
        }
    }
}
