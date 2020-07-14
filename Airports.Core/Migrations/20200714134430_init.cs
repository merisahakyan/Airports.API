using Microsoft.EntityFrameworkCore.Migrations;

namespace Airports.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ident = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Elevation = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    ScheduledService = table.Column<string>(nullable: true),
                    GPSCode = table.Column<string>(nullable: true),
                    IATACode = table.Column<string>(nullable: true),
                    LocalCode = table.Column<string>(nullable: true),
                    HomeLink = table.Column<string>(nullable: true),
                    Wikipedia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
