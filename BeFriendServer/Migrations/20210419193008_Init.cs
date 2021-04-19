using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace BeFriendServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    Chat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Creation_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.Chat_Id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Age_limit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Location = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Seats_limit = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Event_date = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    People_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Event_id);
                });

            migrationBuilder.CreateTable(
                name: "interests",
                columns: table => new
                {
                    Interest_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interests", x => x.Interest_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Telephone_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Login = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Password = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Photo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    Surname = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<byte>(type: "tinyint", nullable: false),
                    Country = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    Location = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    Email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Communications_count = table.Column<int>(type: "int", nullable: true),
                    Is_Admin = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Telephone_number);
                });

            migrationBuilder.CreateTable(
                name: "interests_event",
                columns: table => new
                {
                    Interest_id = table.Column<int>(type: "int", nullable: false),
                    Event_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Interest_id, x.Event_id });
                    table.ForeignKey(
                        name: "FK_IE_EVENT",
                        column: x => x.Event_id,
                        principalTable: "events",
                        principalColumn: "Event_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IE_Interests",
                        column: x => x.Interest_id,
                        principalTable: "interests",
                        principalColumn: "Interest_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "interests_user",
                columns: table => new
                {
                    Interest_id = table.Column<int>(type: "int", nullable: false),
                    Telephone_number = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Interest_id, x.Telephone_number });
                    table.ForeignKey(
                        name: "FK_IU_Interests",
                        column: x => x.Interest_id,
                        principalTable: "interests",
                        principalColumn: "Interest_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IU_Users",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Message_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Chat_id = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Content = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    Messagescol = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Telephone_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Message_Id);
                    table.ForeignKey(
                        name: "FK_Mess_Chats",
                        column: x => x.Chat_id,
                        principalTable: "chats",
                        principalColumn: "Chat_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mess_Users",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Notifications_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Telephone_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Image = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Notifications_Id);
                    table.ForeignKey(
                        name: "FK_Not_Users",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "organizers",
                columns: table => new
                {
                    Event_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Telephone_number = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Event_Id, x.Telephone_number });
                    table.ForeignKey(
                        name: "FK_ORG_EVENT",
                        column: x => x.Event_Id,
                        principalTable: "events",
                        principalColumn: "Event_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORG_USER",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    Telephone_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Event_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Telephone_number, x.Event_Id });
                    table.ForeignKey(
                        name: "FK_PC_Events",
                        column: x => x.Event_Id,
                        principalTable: "events",
                        principalColumn: "Event_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PC_Users",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Telephone_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    End_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_USER_PAYMENTS",
                        column: x => x.Telephone_number,
                        principalTable: "users",
                        principalColumn: "Telephone_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Chat_Id_UNIQUE",
                table: "chats",
                column: "Chat_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Event_id_UNIQUE",
                table: "events",
                column: "Event_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Interest_id_UNIQUE",
                table: "interests",
                column: "Interest_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name_UNIQUE",
                table: "interests",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_IE_EVENT",
                table: "interests_event",
                column: "Event_id");

            migrationBuilder.CreateIndex(
                name: "FK_IU_Users",
                table: "interests_user",
                column: "Telephone_number");

            migrationBuilder.CreateIndex(
                name: "Chat_id_UNIQUE",
                table: "messages",
                column: "Chat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Message_Id_UNIQUE",
                table: "messages",
                column: "Message_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Telephone_number_UNIQUE",
                table: "messages",
                column: "Telephone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Notifications_Id_UNIQUE",
                table: "notifications",
                column: "Notifications_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Telephone_number_UNIQUE1",
                table: "notifications",
                column: "Telephone_number",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "FK_PC_Events",
                table: "participants",
                column: "Event_Id");

            migrationBuilder.CreateIndex(
                name: "Payment_Id_UNIQUE",
                table: "payments",
                column: "Payment_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Telephone_number(FK)_UNIQUE",
                table: "payments",
                column: "Telephone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Telephone_number_UNIQUE3",
                table: "users",
                column: "Telephone_number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interests_event");

            migrationBuilder.DropTable(
                name: "interests_user");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "organizers");

            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "interests");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
