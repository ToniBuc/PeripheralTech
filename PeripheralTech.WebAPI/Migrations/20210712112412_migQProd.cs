using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migQProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ProductID",
                table: "Question",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Product_ProductID",
                table: "Question",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Product_ProductID",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ProductID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Question");
        }
    }
}
