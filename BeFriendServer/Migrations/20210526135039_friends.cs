using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class friends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    FirstNumber = table.Column<string>(type: "varchar(12)", nullable: false),
                    SecondNumber = table.Column<string>(type: "varchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.FirstNumber);
                    table.ForeignKey(
                        name: "FK_Friends_users_FirstNumber",
                        column: x => x.FirstNumber,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_users_SecondNumber",
                        column: x => x.SecondNumber,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_SecondNumber",
                table: "Friends",
                column: "SecondNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
