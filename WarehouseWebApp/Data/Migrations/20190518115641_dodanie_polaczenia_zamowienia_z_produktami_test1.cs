using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanie_polaczenia_zamowienia_z_produktami_test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZamowienieId",
                table: "Produkty",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FakturaId = table.Column<int>(nullable: true),
                    KlientId = table.Column<int>(nullable: false),
                    DataZamowienia = table.Column<DateTime>(nullable: false),
                    DataWystawieniaFaktury = table.Column<DateTime>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_ZamowienieId",
                table: "Produkty",
                column: "ZamowienieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KlientId",
                table: "Zamowienie",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkty_Zamowienie_ZamowienieId",
                table: "Produkty",
                column: "ZamowienieId",
                principalTable: "Zamowienie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkty_Zamowienie_ZamowienieId",
                table: "Produkty");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropIndex(
                name: "IX_Produkty_ZamowienieId",
                table: "Produkty");

            migrationBuilder.DropColumn(
                name: "ZamowienieId",
                table: "Produkty");
        }
    }
}
