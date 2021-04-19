using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BeFriendServer.Models;

#nullable disable

namespace BeFriendServer.Data
{
    public partial class befrienddbContext : DbContext
    {
        public befrienddbContext()
        {
        }

        public befrienddbContext(DbContextOptions<befrienddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<InterestsEvent> InterestsEvents { get; set; }
        public virtual DbSet<InterestsUser> InterestsUsers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3309;Database=befrienddb;uid=root;pwd=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chats");

                entity.HasIndex(e => e.ChatId, "Chat_Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ChatId).HasColumnName("Chat_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_Date");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.HasIndex(e => e.EventId, "Event_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.Property(e => e.AgeLimit).HasColumnName("Age_limit");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Event_date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PeopleCount).HasColumnName("People_count");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.SeatsLimit).HasColumnName("Seats_limit");
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.ToTable("interests");

                entity.HasIndex(e => e.InterestId, "Interest_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.InterestId).HasColumnName("Interest_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<InterestsEvent>(entity =>
            {
                entity.HasKey(e => new { e.InterestId, e.EventId })
                    .HasName("PRIMARY");

                entity.ToTable("interests_event");

                entity.HasIndex(e => e.EventId, "FK_IE_EVENT");

                entity.Property(e => e.InterestId).HasColumnName("Interest_id");

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.InterestsEvents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IE_EVENT");

                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.InterestsEvents)
                    .HasForeignKey(d => d.InterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IE_Interests");
            });

            modelBuilder.Entity<InterestsUser>(entity =>
            {
                entity.HasKey(e => new { e.InterestId, e.TelephoneNumber })
                    .HasName("PRIMARY");

                entity.ToTable("interests_user");

                entity.HasIndex(e => e.TelephoneNumber, "FK_IU_Users");

                entity.Property(e => e.InterestId).HasColumnName("Interest_id");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(45)
                    .HasColumnName("Telephone_number");

                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.InterestsUsers)
                    .HasForeignKey(d => d.InterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IU_Interests");

                entity.HasOne(d => d.TelephoneNumberNavigation)
                    .WithMany(p => p.InterestsUsers)
                    .HasForeignKey(d => d.TelephoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IU_Users");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.HasIndex(e => e.ChatId, "Chat_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MessageId, "Message_Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TelephoneNumber, "Telephone_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.MessageId).HasColumnName("Message_Id");

                entity.Property(e => e.ChatId).HasColumnName("Chat_id");

                entity.Property(e => e.Content).HasMaxLength(45);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_Date");

                entity.Property(e => e.Messagescol).HasMaxLength(500);

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Telephone_number");

                entity.HasOne(d => d.Chat)
                    .WithOne(p => p.Message)
                    .HasForeignKey<Message>(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mess_Chats");

                entity.HasOne(d => d.TelephoneNumberNavigation)
                    .WithOne(p => p.Message)
                    .HasForeignKey<Message>(d => d.TelephoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mess_Users");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationsId)
                    .HasName("PRIMARY");

                entity.ToTable("notifications");

                entity.HasIndex(e => e.NotificationsId, "Notifications_Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TelephoneNumber, "Telephone_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.NotificationsId).HasColumnName("Notifications_Id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Telephone_number");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.TelephoneNumberNavigation)
                    .WithOne(p => p.Notification)
                    .HasForeignKey<Notification>(d => d.TelephoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Not_Users");
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.TelephoneNumber })
                    .HasName("PRIMARY");

                entity.ToTable("organizers");

                entity.HasIndex(e => e.EventId, "Event_Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TelephoneNumber, "Telephone_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.EventId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Event_Id");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(45)
                    .HasColumnName("Telephone_number");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Organizer)
                    .HasForeignKey<Organizer>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORG_EVENT");

                entity.HasOne(d => d.TelephoneNumberNavigation)
                    .WithOne(p => p.Organizer)
                    .HasForeignKey<Organizer>(d => d.TelephoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORG_USER");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => new { e.TelephoneNumber, e.EventId })
                    .HasName("PRIMARY");

                entity.ToTable("participants");

                entity.HasIndex(e => e.EventId, "FK_PC_Events");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(12)
                    .HasColumnName("Telephone_number");

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_Events");

                entity.HasOne(d => d.TelephoneNumberNavigation)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.TelephoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_Users");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.HasIndex(e => e.PaymentId, "Payment_Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TelephoneNumber, "Telephone_number(FK)_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Telephone_number");

                entity.HasOne(d => d.TelephoneNumberNavigation)
                    .WithOne(p => p.Payment)
                    .HasForeignKey<Payment>(d => d.TelephoneNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PAYMENTS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.TelephoneNumber)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.TelephoneNumber, "Telephone_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(12)
                    .HasColumnName("Telephone_number");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.CommunicationsCount).HasColumnName("Communications_count");

                entity.Property(e => e.Country).HasMaxLength(45);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.IsAdmin).HasColumnName("Is_Admin");

                entity.Property(e => e.Location).HasMaxLength(45);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Photo).HasMaxLength(45);

                entity.Property(e => e.Surname).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
