using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class UserFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "users",
                type: "text",
                nullable: true);
        }
    }
}
