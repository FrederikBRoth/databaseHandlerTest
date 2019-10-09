using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pleeweasse.Models
{
    public partial class semester3Context : DbContext
    {
        public semester3Context()
        {
        }

        public semester3Context(DbContextOptions<semester3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserChat> UserChat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=federicoshytte.dk;port=42333;user=user;password=pass;database=semester3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chat");

                entity.HasIndex(e => new { e.ChatId, e.UserChatUserId })
                    .HasName("chat_id_idxfk");

                entity.Property(e => e.ChatId)
                    .HasColumnName("chat_id")
                    .HasColumnType("char(32)");

                entity.Property(e => e.ChatPassword)
                    .HasColumnName("chat_password")
                    .HasColumnType("char(64)");

                entity.Property(e => e.ChatTopic)
                    .HasColumnName("chat_topic")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.UserChatUserId)
                    .HasColumnName("user_chat_user_id")
                    .HasColumnType("char(32)");

                entity.HasOne(d => d.UserChat)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => new { d.ChatId, d.UserChatUserId })
                    .HasConstraintName("chat_ibfk_1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.HasIndex(e => e.MessageChatId)
                    .HasName("message_chat_id_idxfk");

                entity.HasIndex(e => e.MessageUserId)
                    .HasName("message_user_id_idxfk");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasColumnType("char(32)");

                entity.Property(e => e.MessageChatId)
                    .HasColumnName("message_chat_id")
                    .HasColumnType("char(32)");

                entity.Property(e => e.MessageDatetime)
                    .HasColumnName("message_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MessageText)
                    .HasColumnName("message_text")
                    .HasColumnType("text");

                entity.Property(e => e.MessageUserId)
                    .HasColumnName("message_user_id")
                    .HasColumnType("char(32)");

                entity.HasOne(d => d.MessageChat)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.MessageChatId)
                    .HasConstraintName("message_ibfk_1");

                entity.HasOne(d => d.MessageUser)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.MessageUserId)
                    .HasConstraintName("message_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("user_login_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("char(32)");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasColumnType("varchar(400)");

                entity.Property(e => e.UserLogin)
                    .HasColumnName("user_login")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("user_password")
                    .HasColumnType("char(64)");
            });

            modelBuilder.Entity<UserChat>(entity =>
            {
                entity.HasKey(e => new { e.UserChatChatId, e.UserChatUserId })
                    .HasName("PRIMARY");

                entity.ToTable("user_chat");

                entity.HasIndex(e => e.UserChatUserId)
                    .HasName("user_chat_user_id_idxfk");

                entity.Property(e => e.UserChatChatId)
                    .HasColumnName("user_chat_chat_id")
                    .HasColumnType("char(32)");

                entity.Property(e => e.UserChatUserId)
                    .HasColumnName("user_chat_user_id")
                    .HasColumnType("char(32)");

                entity.HasOne(d => d.UserChatUser)
                    .WithMany(p => p.UserChat)
                    .HasForeignKey(d => d.UserChatUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_chat_ibfk_1");
            });
        }
    }
}
