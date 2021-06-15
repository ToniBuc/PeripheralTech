using Microsoft.EntityFrameworkCore.Migrations;

namespace PeripheralTech.WebAPI.Migrations
{
    public partial class migQuestionTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "QuestionComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionComment_QuestionID",
                table: "QuestionComment",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionComment_Question_QuestionID",
                table: "QuestionComment",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionComment_Question_QuestionID",
                table: "QuestionComment");

            migrationBuilder.DropIndex(
                name: "IX_QuestionComment_QuestionID",
                table: "QuestionComment");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "QuestionComment");
        }
    }
}
