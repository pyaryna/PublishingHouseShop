using Microsoft.EntityFrameworkCore.Migrations;

namespace PublishingHouse.DAL.Migrations
{
    public partial class UpdateCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId1",
                table: "Comments",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CustomerId1",
                table: "Comments",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CustomerId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CustomerId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Comments");
        }
    }
}
