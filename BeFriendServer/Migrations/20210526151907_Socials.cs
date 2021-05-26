using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class Socials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Social = table.Column<string>(type: "varchar(35)", nullable: false),
                    Telephone_number = table.Column<string>(type: "varchar(12)", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Social, x.Telephone_number });
                    table.ForeignKey(
                        name: "FK_Socials_users_Telephone_number",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Socials_Telephone_number",
                table: "Socials",
                column: "Telephone_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Socials");
        }
    }
}
