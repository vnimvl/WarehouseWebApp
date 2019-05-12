using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanie_tabeli_klientow_w_bazie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazwaKrotka = table.Column<string>(nullable: true),
                    NazwaDluga = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Numer = table.Column<int>(nullable: false),
                    KodPocztowy = table.Column<string>(nullable: true),
                    Miasto = table.Column<string>(nullable: true),
                    NIP = table.Column<long>(nullable: false),
                    Emial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klienci");
        }
    }
}
