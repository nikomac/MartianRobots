using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartianRobots.Repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Scent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grids",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    MaxX = table.Column<int>(type: "int", nullable: false),
                    MaxY = table.Column<int>(type: "int", nullable: false),
                    MissionID = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grids_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    InitialCoordinate = table.Column<string>(type: "text", nullable: true),
                    LastKnownCoordinate = table.Column<string>(type: "text", nullable: true),
                    CurrentCoordinate = table.Column<string>(type: "text", nullable: true),
                    Instructions = table.Column<string>(type: "text", nullable: true),
                    IsLost = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MissionID = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Robots_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grids_MissionID",
                table: "Grids",
                column: "MissionID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Robots_MissionID",
                table: "Robots",
                column: "MissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grids");

            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
