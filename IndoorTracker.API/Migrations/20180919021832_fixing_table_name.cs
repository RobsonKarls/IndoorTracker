using Microsoft.EntityFrameworkCore.Migrations;

namespace IndoorTracker.API.Migrations
{
    public partial class fixing_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorDatas_Gps_GPSId",
                schema: "tracking",
                table: "SensorDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_SensorDatas_SensorDataId",
                schema: "tracking",
                table: "Wifis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorDatas",
                schema: "tracking",
                table: "SensorDatas");

            migrationBuilder.RenameTable(
                name: "SensorDatas",
                schema: "tracking",
                newName: "SensorsData",
                newSchema: "tracking");

            migrationBuilder.RenameIndex(
                name: "IX_SensorDatas_GPSId",
                schema: "tracking",
                table: "SensorsData",
                newName: "IX_SensorsData_GPSId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorsData",
                schema: "tracking",
                table: "SensorsData",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "SensorsData",
                schema: "tracking",
                newName: "SensorDatas",
                newSchema: "tracking");

            migrationBuilder.RenameIndex(
                name: "IX_SensorsData_GPSId",
                schema: "tracking",
                table: "SensorDatas",
                newName: "IX_SensorDatas_GPSId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorDatas",
                schema: "tracking",
                table: "SensorDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorDatas_Gps_GPSId",
                schema: "tracking",
                table: "SensorDatas",
                column: "GPSId",
                principalSchema: "tracking",
                principalTable: "Gps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_SensorDatas_SensorDataId",
                schema: "tracking",
                table: "Wifis",
                column: "SensorDataId",
                principalSchema: "tracking",
                principalTable: "SensorDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
