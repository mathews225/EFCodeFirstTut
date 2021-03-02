using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCodeFirstTut.Migrations
{
    public partial class fixedOrdertotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total",
                table: "Orders",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Orders",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "id");
        }
    }
}
