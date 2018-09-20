using Microsoft.EntityFrameworkCore.Migrations;

namespace IndoorTracker.API.Migrations
{
    public partial class fixing_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorsData_Gps_GPSId",
                schema: "tracking",
                table: "SensorsData");

            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_SensorsData_SensorDataId",
                schema: "tracking",
                table: "Wifis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorsData",
                schema: "tracking",
                table: "SensorsData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gps",
                schema: "tracking",
                table: "Gps");

            migrationBuilder.RenameTable(
                name: "SensorsData",
                schema: "tracking",
                newName: "sensorsData",
                newSchema: "tracking");

            migrationBuilder.RenameTable(
                name: "Gps",
                schema: "tracking",
                newName: "gps",
                newSchema: "tracking");

            migrationBuilder.RenameIndex(
                name: "IX_SensorsData_GPSId",
                schema: "tracking",
                table: "sensorsData",
                newName: "IX_sensorsData_GPSId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sensorsData",
                schema: "tracking",
                table: "sensorsData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gps",
                schema: "tracking",
                table: "gps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sensorsData_gps_GPSId",
                schema: "tracking",
                table: "sensorsData",
                column: "GPSId",
                principalSchema: "tracking",
                principalTable: "gps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_sensorsData_SensorDataId",
                schema: "tracking",
                table: "Wifis",
                column: "SensorDataId",
                principalSchema: "tracking",
                principalTable: "sensorsData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sensorsData_gps_GPSId",
                schema: "tracking",
                table: "sensorsData");

            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_sensorsData_SensorDataId",
                schema: "tracking",
                table: "Wifis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sensorsData",
                schema: "tracking",
                table: "sensorsData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gps",
                schema: "tracking",
                table: "gps");

            migrationBuilder.RenameTable(
                name: "sensorsData",
                schema: "tracking",
                newName: "SensorsData",
                newSchema: "tracking");

            migrationBuilder.RenameTable(
                name: "gps",
                schema: "tracking",
                newName: "Gps",
                newSchema: "tracking");

            migrationBuilder.RenameIndex(
                name: "IX_sensorsData_GPSId",
                schema: "tracking",
                table: "SensorsData",
                newName: "IX_SensorsData_GPSId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorsData",
                schema: "tracking",
                table: "SensorsData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gps",
                schema: "tracking",
                table: "Gps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorsData_Gps_GPSId",
                schema: "tracking",
                table: "SensorsData",
                column: "GPSId",
                principalSchema: "tracking",
                principalTable: "Gps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_SensorsData_SensorDataId",
                schema: "tracking",
                table: "Wifis",
                column: "SensorDataId",
                principalSchema: "tracking",
                principalTable: "SensorsData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
