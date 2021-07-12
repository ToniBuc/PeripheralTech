using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migFixMistakeQProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Product_ProductID",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Question",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_ProductID",
                table: "Question",
                newName: "IX_Question_OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Order_OrderID",
                table: "Question",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Order_OrderID",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Question",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_OrderID",
                table: "Question",
                newName: "IX_Question_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Product_ProductID",
                table: "Question",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
