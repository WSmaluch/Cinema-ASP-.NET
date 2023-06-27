using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyAktywny",
                table: "StronaGlowna",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "KiedyDodal",
                table: "StronaGlowna",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KiedyWykasowal",
                table: "StronaGlowna",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KiedyZmodyfikowal",
                table: "StronaGlowna",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KtoDodal",
                table: "StronaGlowna",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KtoWykasowal",
                table: "StronaGlowna",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KtoZmodyfikowal",
                table: "StronaGlowna",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyAktywny",
                table: "StronaGlowna");

            migrationBuilder.DropColumn(
                name: "KiedyDodal",
                table: "StronaGlowna");

            migrationBuilder.DropColumn(
                name: "KiedyWykasowal",
                table: "StronaGlowna");

            migrationBuilder.DropColumn(
                name: "KiedyZmodyfikowal",
                table: "StronaGlowna");

            migrationBuilder.DropColumn(
                name: "KtoDodal",
                table: "StronaGlowna");

            migrationBuilder.DropColumn(
                name: "KtoWykasowal",
                table: "StronaGlowna");

            migrationBuilder.DropColumn(
                name: "KtoZmodyfikowal",
                table: "StronaGlowna");
        }
    }
}
