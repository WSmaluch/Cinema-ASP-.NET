using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    IdBiletu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    NumerSiedzenia = table.Column<int>(type: "int", nullable: false),
                    DataProjekcji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZarezerwowanyPrzez = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.IdBiletu);
                    table.ForeignKey(
                        name: "FK_Bilet_Filmy_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmy",
                        principalColumn: "IdFilmu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_FilmId",
                table: "Bilet",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilet");
        }
    }
}
