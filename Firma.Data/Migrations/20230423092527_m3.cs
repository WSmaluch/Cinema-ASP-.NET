using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmy_Gatunek_GatunekId",
                table: "Filmy");

            migrationBuilder.DropIndex(
                name: "IX_Filmy_GatunekId",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "GatunekId",
                table: "Filmy");

            migrationBuilder.AddColumn<string>(
                name: "Gatunek",
                table: "Filmy",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GatunekIdGatunku",
                table: "Filmy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_GatunekIdGatunku",
                table: "Filmy",
                column: "GatunekIdGatunku");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmy_Gatunek_GatunekIdGatunku",
                table: "Filmy",
                column: "GatunekIdGatunku",
                principalTable: "Gatunek",
                principalColumn: "IdGatunku");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmy_Gatunek_GatunekIdGatunku",
                table: "Filmy");

            migrationBuilder.DropIndex(
                name: "IX_Filmy_GatunekIdGatunku",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "Gatunek",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "GatunekIdGatunku",
                table: "Filmy");

            migrationBuilder.AddColumn<int>(
                name: "GatunekId",
                table: "Filmy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_GatunekId",
                table: "Filmy",
                column: "GatunekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmy_Gatunek_GatunekId",
                table: "Filmy",
                column: "GatunekId",
                principalTable: "Gatunek",
                principalColumn: "IdGatunku",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
