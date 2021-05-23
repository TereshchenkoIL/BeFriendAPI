using Microsoft.EntityFrameworkCore.Migrations;

namespace BeFriendServer.Migrations
{
    public partial class UserOrginizerFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_users_OrganizerEventId_OrganizerTelephoneNumber",
                table: "users",
                columns: new[] { "OrganizerEventId", "OrganizerTelephoneNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_users_organizers_OrganizerEventId_OrganizerTelephoneNumber",
                table: "users",
                columns: new[] { "OrganizerEventId", "OrganizerTelephoneNumber" },
                principalTable: "organizers",
                principalColumns: new[] { "Event_Id", "Telephone_number" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
