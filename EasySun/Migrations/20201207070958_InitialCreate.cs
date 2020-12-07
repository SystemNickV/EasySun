using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasySun.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sun");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "sun",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "sun",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(88)", maxLength: 88, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(11,8)", nullable: false),
                    CountryFK = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryFK",
                        column: x => x.CountryFK,
                        principalSchema: "sun",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTimes",
                schema: "sun",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sunrise = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sunset = table.Column<DateTime>(type: "datetime", nullable: false),
                    CityFK = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTimes_Cities_CityFK",
                        column: x => x.CityFK,
                        principalSchema: "sun",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryFK",
                schema: "sun",
                table: "Cities",
                column: "CountryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                schema: "sun",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                schema: "sun",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTimes_CityFK",
                schema: "sun",
                table: "EventTimes",
                column: "CityFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTimes",
                schema: "sun");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "sun");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "sun");
        }
    }
}
