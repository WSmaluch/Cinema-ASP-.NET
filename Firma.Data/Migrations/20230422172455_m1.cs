
#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gatunek",
                columns: table => new
                {
                    IdGatunku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunek", x => x.IdGatunku);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.IdKategorii);
                });

            migrationBuilder.CreateTable(
                name: "Komentarz",
                columns: table => new
                {
                    IdKomentarza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentarz", x => x.IdKomentarza);
                });

            migrationBuilder.CreateTable(
                name: "Posty",
                columns: table => new
                {
                    IdPostu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPublikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObrazekUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posty", x => x.IdPostu);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "Szczegoly",
                columns: table => new
                {
                    IdSzczegolu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szczegoly", x => x.IdSzczegolu);
                });

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    IdFilmu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytuł = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    DataPremiery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rezyser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dlugosc = table.Column<int>(type: "int", nullable: false),
                    GatunekId = table.Column<int>(type: "int", nullable: false),
                    LinkDoZwiastunu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    KtoDodal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyDodal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmodyfikowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyZmodyfikowal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KtoWykasowal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KiedyWykasowal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.IdFilmu);
                    table.ForeignKey(
                        name: "FK_Filmy_Gatunek_GatunekId",
                        column: x => x.GatunekId,
                        principalTable: "Gatunek",
                        principalColumn: "IdGatunku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_GatunekId",
                table: "Filmy",
                column: "GatunekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Komentarz");

            migrationBuilder.DropTable(
                name: "Posty");

            migrationBuilder.DropTable(
                name: "Strona");

            migrationBuilder.DropTable(
                name: "Szczegoly");

            migrationBuilder.DropTable(
                name: "Gatunek");
        }
    }
}
