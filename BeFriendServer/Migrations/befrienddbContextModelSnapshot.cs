﻿// <auto-generated />
using System;
using BeFriendServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeFriendServer.Migrations
{
    [DbContext(typeof(befrienddbContext))]
    partial class befrienddbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("BeFriendServer.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Chat_Id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("Creation_Date");

                    b.HasKey("ChatId");

                    b.HasIndex(new[] { "ChatId" }, "Chat_Id_UNIQUE")
                        .IsUnique();

                    b.ToTable("chats");
                });

            modelBuilder.Entity("BeFriendServer.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Event_id");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("int")
                        .HasColumnName("Age_limit");

                    b.Property<int>("AgeMin")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("EventDate")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Event_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int")
                        .HasColumnName("People_count");

                    b.Property<string>("Photo")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("SeatsLimit")
                        .HasColumnType("int")
                        .HasColumnName("Seats_limit");

                    b.HasKey("EventId");

                    b.HasIndex(new[] { "EventId" }, "Event_id_UNIQUE")
                        .IsUnique();

                    b.ToTable("events");
                });

            modelBuilder.Entity("BeFriendServer.Models.Friends", b =>
                {
                    b.Property<string>("FirstNumber")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("SecondNumber")
                        .HasColumnType("varchar(12)");

                    b.HasKey("FirstNumber", "SecondNumber")
                        .HasName("PRIMARY");

                    b.HasIndex("SecondNumber");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("BeFriendServer.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Interest_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("InterestId");

                    b.HasIndex(new[] { "InterestId" }, "Interest_id_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "Name_UNIQUE")
                        .IsUnique();

                    b.ToTable("interests");
                });

            modelBuilder.Entity("BeFriendServer.Models.InterestsEvent", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int")
                        .HasColumnName("Interest_id");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("Event_id");

                    b.HasKey("InterestId", "EventId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EventId" }, "FK_IE_EVENT");

                    b.ToTable("interests_event");
                });

            modelBuilder.Entity("BeFriendServer.Models.InterestsUser", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int")
                        .HasColumnName("Interest_id");

                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Telephone_number");

                    b.HasKey("InterestId", "TelephoneNumber")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TelephoneNumber" }, "FK_IU_Users");

                    b.ToTable("interests_user");
                });

            modelBuilder.Entity("BeFriendServer.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Message_Id");

                    b.Property<int>("ChatId")
                        .HasColumnType("int")
                        .HasColumnName("Chat_id");

                    b.Property<string>("Content")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("Creation_Date");

                    b.Property<string>("Messagescol")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("Telephone_number");

                    b.HasKey("MessageId");

                    b.HasIndex(new[] { "ChatId" }, "Chat_id_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "MessageId" }, "Message_Id_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "TelephoneNumber" }, "Telephone_number_UNIQUE")
                        .IsUnique();

                    b.ToTable("messages");
                });

            modelBuilder.Entity("BeFriendServer.Models.Notification", b =>
                {
                    b.Property<int>("NotificationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notifications_Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("Telephone_number");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("NotificationsId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "NotificationsId" }, "Notifications_Id_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "TelephoneNumber" }, "Telephone_number_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("Telephone_number_UNIQUE1");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("BeFriendServer.Models.Organizer", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("Event_Id");

                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Telephone_number");

                    b.HasKey("EventId", "TelephoneNumber")
                        .HasName("PRIMARY");

                    b.HasIndex("TelephoneNumber");

                    b.HasIndex(new[] { "EventId" }, "FK_Org_Event");

                    b.ToTable("organizers");
                });

            modelBuilder.Entity("BeFriendServer.Models.Participant", b =>
                {
                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("Telephone_number");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("Event_Id");

                    b.HasKey("TelephoneNumber", "EventId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EventId" }, "FK_PC_Events");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("BeFriendServer.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Payment_Id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("End_Date");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("Telephone_number");

                    b.HasKey("PaymentId");

                    b.HasIndex(new[] { "PaymentId" }, "Payment_Id_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "TelephoneNumber" }, "Telephone_number(FK)_UNIQUE")
                        .IsUnique();

                    b.ToTable("payments");
                });

            modelBuilder.Entity("BeFriendServer.Models.Socials", b =>
                {
                    b.Property<string>("Social")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Telephone_number")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Social", "Telephone_number")
                        .HasName("PRIMARY");

                    b.HasIndex("Telephone_number");

                    b.ToTable("Socials");
                });

            modelBuilder.Entity("BeFriendServer.Models.User", b =>
                {
                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("Telephone_number");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int?>("CommunicationsCount")
                        .HasColumnType("int")
                        .HasColumnName("Communications_count");

                    b.Property<string>("Country")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<byte>("IsAdmin")
                        .HasColumnType("tinyint")
                        .HasColumnName("Is_Admin");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("TelephoneNumber")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TelephoneNumber" }, "Telephone_number_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("Telephone_number_UNIQUE2");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BeFriendServer.Models.Friends", b =>
                {
                    b.HasOne("BeFriendServer.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("FirstNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeFriendServer.Models.User", "Friend")
                        .WithMany()
                        .HasForeignKey("SecondNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeFriendServer.Models.InterestsEvent", b =>
                {
                    b.HasOne("BeFriendServer.Models.Event", "Event")
                        .WithMany("InterestsEvents")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_IE_EVENT")
                        .IsRequired();

                    b.HasOne("BeFriendServer.Models.Interest", "Interest")
                        .WithMany("InterestsEvents")
                        .HasForeignKey("InterestId")
                        .HasConstraintName("FK_IE_Interests")
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Interest");
                });

            modelBuilder.Entity("BeFriendServer.Models.InterestsUser", b =>
                {
                    b.HasOne("BeFriendServer.Models.Interest", "Interest")
                        .WithMany("InterestsUsers")
                        .HasForeignKey("InterestId")
                        .HasConstraintName("FK_IU_Interests")
                        .IsRequired();

                    b.HasOne("BeFriendServer.Models.User", "TelephoneNumberNavigation")
                        .WithMany("InterestsUsers")
                        .HasForeignKey("TelephoneNumber")
                        .HasConstraintName("FK_IU_Users")
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("TelephoneNumberNavigation");
                });

            modelBuilder.Entity("BeFriendServer.Models.Message", b =>
                {
                    b.HasOne("BeFriendServer.Models.Chat", "Chat")
                        .WithOne("Message")
                        .HasForeignKey("BeFriendServer.Models.Message", "ChatId")
                        .HasConstraintName("FK_Mess_Chats")
                        .IsRequired();

                    b.HasOne("BeFriendServer.Models.User", "TelephoneNumberNavigation")
                        .WithOne("Message")
                        .HasForeignKey("BeFriendServer.Models.Message", "TelephoneNumber")
                        .HasConstraintName("FK_Mess_Users")
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("TelephoneNumberNavigation");
                });

            modelBuilder.Entity("BeFriendServer.Models.Notification", b =>
                {
                    b.HasOne("BeFriendServer.Models.User", "TelephoneNumberNavigation")
                        .WithOne("Notification")
                        .HasForeignKey("BeFriendServer.Models.Notification", "TelephoneNumber")
                        .HasConstraintName("FK_Not_Users")
                        .IsRequired();

                    b.Navigation("TelephoneNumberNavigation");
                });

            modelBuilder.Entity("BeFriendServer.Models.Organizer", b =>
                {
                    b.HasOne("BeFriendServer.Models.Event", "Event")
                        .WithMany("Organizers")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_ORG_EVENT")
                        .IsRequired();

                    b.HasOne("BeFriendServer.Models.User", "TelephoneNumberNavigation")
                        .WithMany("Organizers")
                        .HasForeignKey("TelephoneNumber")
                        .HasConstraintName("FK_ORG_USER")
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("TelephoneNumberNavigation");
                });

            modelBuilder.Entity("BeFriendServer.Models.Participant", b =>
                {
                    b.HasOne("BeFriendServer.Models.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_PC_Events")
                        .IsRequired();

                    b.HasOne("BeFriendServer.Models.User", "TelephoneNumberNavigation")
                        .WithMany("Participants")
                        .HasForeignKey("TelephoneNumber")
                        .HasConstraintName("FK_PC_Users")
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("TelephoneNumberNavigation");
                });

            modelBuilder.Entity("BeFriendServer.Models.Payment", b =>
                {
                    b.HasOne("BeFriendServer.Models.User", "TelephoneNumberNavigation")
                        .WithOne("Payment")
                        .HasForeignKey("BeFriendServer.Models.Payment", "TelephoneNumber")
                        .HasConstraintName("FK_USER_PAYMENTS")
                        .IsRequired();

                    b.Navigation("TelephoneNumberNavigation");
                });

            modelBuilder.Entity("BeFriendServer.Models.Socials", b =>
                {
                    b.HasOne("BeFriendServer.Models.User", "User")
                        .WithMany("Socials")
                        .HasForeignKey("Telephone_number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeFriendServer.Models.Chat", b =>
                {
                    b.Navigation("Message");
                });

            modelBuilder.Entity("BeFriendServer.Models.Event", b =>
                {
                    b.Navigation("InterestsEvents");

                    b.Navigation("Organizers");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("BeFriendServer.Models.Interest", b =>
                {
                    b.Navigation("InterestsEvents");

                    b.Navigation("InterestsUsers");
                });

            modelBuilder.Entity("BeFriendServer.Models.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("InterestsUsers");

                    b.Navigation("Message");

                    b.Navigation("Notification");

                    b.Navigation("Organizers");

                    b.Navigation("Participants");

                    b.Navigation("Payment");

                    b.Navigation("Socials");
                });
#pragma warning restore 612, 618
        }
    }
}
