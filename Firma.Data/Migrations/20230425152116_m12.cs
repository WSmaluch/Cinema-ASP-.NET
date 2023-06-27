using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prywatnosc",
                columns: table => new
                {
                    IdPrywatnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naglowek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tresc1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tresc2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tresc3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tresc4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tresc5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prywatnosc", x => x.IdPrywatnosci);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prywatnosc");
        }
    }
}
