using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StronaGlowna",
                columns: table => new
                {
                    IdStronyGlownej = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bannery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TekstyBanner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReklamyZdjecia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TekstyReklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerzyZdjecia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StronaGlowna", x => x.IdStronyGlownej);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StronaGlowna");
        }
    }
}
