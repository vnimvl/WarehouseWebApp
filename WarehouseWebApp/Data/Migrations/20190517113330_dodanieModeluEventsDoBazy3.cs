using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseWebApp.Data.Migrations
{
    public partial class dodanieModeluEventsDoBazy3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Events",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "Subject");
        }
    }
}
