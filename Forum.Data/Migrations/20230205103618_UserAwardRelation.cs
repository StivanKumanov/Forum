using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class UserAwardRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Awards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Awards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Awards_UserId1",
                table: "Awards",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_AspNetUsers_UserId1",
                table: "Awards",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_AspNetUsers_UserId1",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_UserId1",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Awards");
        }
    }
}
