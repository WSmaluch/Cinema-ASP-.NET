using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ONas",
                columns: table => new
                {
                    IdONas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naglowek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zdjecia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ONas", x => x.IdONas);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ONas");
        }
    }
}
