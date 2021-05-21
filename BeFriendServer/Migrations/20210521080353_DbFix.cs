using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace BeFriendServer.Migrations
{
    public partial class DbFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

          

            migrationBuilder.RenameIndex(
                name: "Telephone_number_UNIQUE3",
                table: "users",
                newName: "Telephone_number_UNIQUE2");

            migrationBuilder.AddColumn<int>(
                name: "OrganizerEventId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizerTelephoneNumber",
                table: "users",
                type: "varchar(45)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Event_Id",
                table: "organizers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_users_OrganizerEventId_OrganizerTelephoneNumber",
                table: "users",
                columns: new[] { "OrganizerEventId", "OrganizerTelephoneNumber" });

            migrationBuilder.CreateIndex(
                name: "FK_Org_Event",
                table: "organizers",
                column: "Event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_organizers_Telephone_number",
                table: "organizers",
                column: "Telephone_number");

            migrationBuilder.AddForeignKey(
                name: "FK_users_organizers_OrganizerEventId_OrganizerTelephoneNumber",
                table: "users",
                columns: new[] { "OrganizerEventId", "OrganizerTelephoneNumber" },
                principalTable: "organizers",
                principalColumns: new[] { "Event_Id", "Telephone_number" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_organizers_OrganizerEventId_OrganizerTelephoneNumber",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_OrganizerEventId_OrganizerTelephoneNumber",
                table: "users");

            migrationBuilder.DropIndex(
                name: "FK_Org_Event",
                table: "organizers");

            migrationBuilder.DropIndex(
                name: "IX_organizers_Telephone_number",
                table: "organizers");

            migrationBuilder.DropColumn(
                name: "OrganizerEventId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "OrganizerTelephoneNumber",
                table: "users");

            migrationBuilder.RenameIndex(
                name: "Telephone_number_UNIQUE2",
                table: "users",
                newName: "Telephone_number_UNIQUE3");

            migrationBuilder.AlterColumn<int>(
                name: "Event_Id",
                table: "organizers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "Event_Id_UNIQUE",
                table: "organizers",
                column: "Event_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Telephone_number_UNIQUE2",
                table: "organizers",
                column: "Telephone_number",
                unique: true);
        }
    }
}
