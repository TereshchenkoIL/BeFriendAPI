using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class friends2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AlterColumn<string>(
                name: "SecondNumber",
                table: "Friends",
                type: "varchar(12)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "Friends",
                columns: new[] { "FirstNumber", "SecondNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_users_SecondNumber",
                table: "Friends",
                column: "SecondNumber",
                principalTable: "users",
                principalColumn: "Telephone_number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_users_SecondNumber",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "Friends");

            migrationBuilder.AlterColumn<string>(
                name: "SecondNumber",
                table: "Friends",
                type: "varchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "FirstNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_users_SecondNumber",
                table: "Friends",
                column: "SecondNumber",
                principalTable: "users",
                principalColumn: "Telephone_number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
