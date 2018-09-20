using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndoorTracker.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tracking");

            migrationBuilder.CreateSequence(
                name: "sensorDataseq",
                schema: "tracking",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Gps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Altitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Device = table.Column<string>(nullable: false),
                    Family = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    GPSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorDatas_Gps_GPSId",
                        column: x => x.GPSId,
                        principalTable: "Gps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wifis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MacAddress = table.Column<string>(nullable: false),
                    RSSI = table.Column<int>(nullable: false),
                    WifisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wifis_SensorDatas_WifisId",
                        column: x => x.WifisId,
                        principalTable: "SensorDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorDatas_GPSId",
                table: "SensorDatas",
                column: "GPSId");

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_WifisId",
                table: "Wifis",
                column: "WifisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wifis");

            migrationBuilder.DropTable(
                name: "SensorDatas");

            migrationBuilder.DropTable(
                name: "Gps");

            migrationBuilder.DropSequence(
                name: "sensorDataseq",
                schema: "tracking");
        }
    }
}
