using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miejsce",
                columns: table => new
                {
                    IdMiejsca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerMiejsca = table.Column<int>(type: "int", nullable: false),
                    Zarezerwowane = table.Column<bool>(type: "bit", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilmyIdFilmu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsce", x => x.IdMiejsca);
                    table.ForeignKey(
                        name: "FK_Miejsce_Filmy_FilmyIdFilmu",
                        column: x => x.FilmyIdFilmu,
                        principalTable: "Filmy",
                        principalColumn: "IdFilmu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miejsce_FilmyIdFilmu",
                table: "Miejsce",
                column: "FilmyIdFilmu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miejsce");
        }
    }
}
