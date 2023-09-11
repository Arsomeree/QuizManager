using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Data.Migrations
{
    public partial class _12many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quiz2s_CurrentQuizId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CurrentQuizId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CurrentQuizId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "Quiz2Id",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Quiz2Id",
                table: "Questions",
                column: "Quiz2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quiz2s_Quiz2Id",
                table: "Questions",
                column: "Quiz2Id",
                principalTable: "Quiz2s",
                principalColumn: "Quiz2Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quiz2s_Quiz2Id",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Quiz2Id",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Quiz2Id",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CurrentQuizId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CurrentQuizId",
                table: "Questions",
                column: "CurrentQuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quiz2s_CurrentQuizId",
                table: "Questions",
                column: "CurrentQuizId",
                principalTable: "Quiz2s",
                principalColumn: "Quiz2Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
