using Microsoft.EntityFrameworkCore.Migrations;

namespace IndoorTracker.API.Migrations
{
    public partial class fixing_fk_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_SensorDatas_SendorDataId",
                schema: "tracking",
                table: "Wifis");

            migrationBuilder.RenameColumn(
                name: "SendorDataId",
                schema: "tracking",
                table: "Wifis",
                newName: "SensorDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Wifis_SendorDataId",
                schema: "tracking",
                table: "Wifis",
                newName: "IX_Wifis_SensorDataId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_SensorDatas_SensorDataId",
                schema: "tracking",
                table: "Wifis");

            migrationBuilder.RenameColumn(
                name: "SensorDataId",
                schema: "tracking",
                table: "Wifis",
                newName: "SendorDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Wifis_SensorDataId",
                schema: "tracking",
                table: "Wifis",
                newName: "IX_Wifis_SendorDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_SensorDatas_SendorDataId",
                schema: "tracking",
                table: "Wifis",
                column: "SendorDataId",
                principalSchema: "tracking",
                principalTable: "SensorDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
