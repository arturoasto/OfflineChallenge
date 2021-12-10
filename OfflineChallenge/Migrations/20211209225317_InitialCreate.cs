using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfflineChallenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryCovidInfo",
                columns: table => new
                {
                    CountryCovidInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TotalCases = table.Column<string>(type: "TEXT", nullable: true),
                    TotalTests = table.Column<string>(type: "TEXT", nullable: true),
                    ActiveCases = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCovidInfo", x => x.CountryCovidInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCovidInfo");
        }
    }
}
