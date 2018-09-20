using Microsoft.EntityFrameworkCore.Migrations;

namespace IndoorTracker.API.Migrations
{
    public partial class fixing_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_SensorDatas_WifisId",
                table: "Wifis");

            migrationBuilder.RenameColumn(
                name: "WifisId",
                table: "Wifis",
                newName: "SendorDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Wifis_WifisId",
                table: "Wifis",
                newName: "IX_Wifis_SendorDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_SensorDatas_SendorDataId",
                table: "Wifis",
                column: "SendorDataId",
                principalTable: "SensorDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_SensorDatas_SendorDataId",
                table: "Wifis");

            migrationBuilder.RenameColumn(
                name: "SendorDataId",
                table: "Wifis",
                newName: "WifisId");

            migrationBuilder.RenameIndex(
                name: "IX_Wifis_SendorDataId",
                table: "Wifis",
                newName: "IX_Wifis_WifisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_SensorDatas_WifisId",
                table: "Wifis",
                column: "WifisId",
                principalTable: "SensorDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
