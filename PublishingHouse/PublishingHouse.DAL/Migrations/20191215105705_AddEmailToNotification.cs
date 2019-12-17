using Microsoft.EntityFrameworkCore.Migrations;

namespace PublishingHouse.DAL.Migrations
{
    public partial class AddEmailToNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Notifications",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Notifications");
        }
    }
}
