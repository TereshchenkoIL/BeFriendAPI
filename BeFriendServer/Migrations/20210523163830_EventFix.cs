using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class EventFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "events");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "events",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "events",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "events");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "users",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "events",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
