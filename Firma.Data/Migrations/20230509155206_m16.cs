using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DoKiedyGrany",
                table: "Filmy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OdKiedyGrany",
                table: "Filmy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zdjecie",
                table: "Filmy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoKiedyGrany",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "OdKiedyGrany",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "Zdjecie",
                table: "Filmy");
        }
    }
}
