using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migBillfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Bill",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Bill");
        }
    }
}
