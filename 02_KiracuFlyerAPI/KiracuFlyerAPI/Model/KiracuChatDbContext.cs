using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.Model;

public partial class KiracuChatDbContext : DbContext
{
    public KiracuChatDbContext()
    {
    }

    public KiracuChatDbContext(DbContextOptions<KiracuChatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Channel> Channels { get; set; }

    public virtual DbSet<ChannelIconMaster> ChannelIconMasters { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupAdmin> GroupAdmins { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserIcon> UserIcons { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserStatus> UserStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.40.125,1433\\\\\\\\SQLEXPRESS;Database=kiracu_chat_db;User Id=kiracu_db_admin;Password=kiracu_db_admin;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Channel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__channel__3213E83F49025B23");

            entity.ToTable("channel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_day");
            entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");
            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Level)
                .HasDefaultValue(1)
                .HasColumnName("level");
            entity.Property(e => e.ModifiedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_day");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.Channels)
                .HasForeignKey(d => d.CreatedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__channel__created__7E02B4CC");

            entity.HasOne(d => d.Group).WithMany(p => p.Channels)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__channel__group_i__7D0E9093");
        });

        modelBuilder.Entity<ChannelIconMaster>(entity =>
        {
            entity.HasKey(e => e.Level).HasName("PK__channel___C03A140BD14DB10C");

            entity.ToTable("channel_icon_master");

            entity.Property(e => e.Level)
                .ValueGeneratedNever()
                .HasColumnName("level");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group__3213E83F1BA064EE");

            entity.ToTable("group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_day");
            entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_day");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.Groups)
                .HasForeignKey(d => d.CreatedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__group__created_u__72910220");
        });

        modelBuilder.Entity<GroupAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group_ad__3213E83F5D5CD488");

            entity.ToTable("group_admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("assigned_day");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupAdmins)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__group_adm__group__76619304");

            entity.HasOne(d => d.User).WithMany(p => p.GroupAdmins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__group_adm__user___7755B73D");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__message__3213E83FA21AEAF3");

            entity.ToTable("message");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HandleName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("handle_name");
            entity.Property(e => e.MediaUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("media_url");
            entity.Property(e => e.MessageNo).HasColumnName("message_no");
            entity.Property(e => e.ModifiedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_day");
            entity.Property(e => e.PostDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("post_date");
            entity.Property(e => e.Text)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__user_id__02C769E9");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__refresh___3213E83F62815583");

            entity.ToTable("refresh_token");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("expiry_date");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__refresh_t__user___6DCC4D03");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__status__3213E83F6514F706");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FA9DF56A7");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue((byte)1)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue((byte)0)
                .HasColumnName("is_deleted");
            entity.Property(e => e.LoginId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("login_id");
            entity.Property(e => e.ModifiedDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_day");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserIconId).HasColumnName("user_icon_id");
            entity.Property(e => e.UserLevel).HasColumnName("user_level");

            entity.HasOne(d => d.UserIcon).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserIconId)
                .HasConstraintName("FK__user__user_icon___625A9A57");
        });

        modelBuilder.Entity<UserIcon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_ico__3213E83F869BFE14");

            entity.ToTable("user_icon");

            entity.HasIndex(e => e.IconLevel, "UQ__user_ico__EE7EB918595A2E04").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BatchImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("batch_image_url");
            entity.Property(e => e.IconLevel).HasColumnName("icon_level");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_pro__3213E83FBE1F0DB0");

            entity.ToTable("user_profile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bio");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_prof__user___69FBBC1F");
        });

        modelBuilder.Entity<UserStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_sta__3213E83F7A96E71C");

            entity.ToTable("user_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("custom_message");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Status).WithMany(p => p.UserStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_stat__statu__671F4F74");

            entity.HasOne(d => d.User).WithMany(p => p.UserStatuses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_stat__user___662B2B3B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
