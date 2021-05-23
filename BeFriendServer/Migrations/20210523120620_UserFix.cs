using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "users",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true);
        }
    }
}
