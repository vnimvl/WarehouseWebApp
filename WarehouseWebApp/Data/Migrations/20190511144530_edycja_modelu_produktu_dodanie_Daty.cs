using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class edycja_modelu_produktu_dodanie_Daty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmenDate",
                table: "Produkty",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipmenDate",
                table: "Produkty");
        }
    }
}
