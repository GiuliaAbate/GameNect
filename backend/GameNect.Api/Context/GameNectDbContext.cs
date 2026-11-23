using System;
using System.Collections.Generic;
using GameNect.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameNect.Api.Context;

public partial class GameNectDbContext : DbContext
{
    public GameNectDbContext()
    {
    }

    public GameNectDbContext(DbContextOptions<GameNectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleMedia> ArticleMedias { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<CommunityCategory> CommunityCategories { get; set; }

    public virtual DbSet<CommunityMember> CommunityMembers { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<ConversationParticipant> ConversationParticipants { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostMedia> PostMedias { get; set; }

    public virtual DbSet<Reaction> Reactions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasIndex(e => new { e.AuthorUserId, e.PublishedAt }, "IX_Articles_AuthorUserId_PublishedAt")
                .IsDescending(false, true)
                .HasFilter("([DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.CategoryId, e.PublishedAt }, "IX_Articles_CategoryId_PublishedAt")
                .IsDescending(false, true)
                .HasFilter("([DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.Status, e.PublishedAt }, "IX_Articles_Status_PublishedAt")
                .IsDescending(false, true)
                .HasFilter("([DeletedAt] IS NULL)");

            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.PublishedAt).HasPrecision(3);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.AuthorUser).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articles_Users");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articles_Categories");

            entity.HasMany(d => d.Tags).WithMany(p => p.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ArticleTags_Tags"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ArticleTags_Articles"),
                    j =>
                    {
                        j.HasKey("ArticleId", "TagId");
                        j.ToTable("ArticleTags");
                        j.HasIndex(new[] { "TagId", "ArticleId" }, "IX_ArticleTags_TagId_ArticleId");
                        j.IndexerProperty<int>("ArticleId");
                        j.IndexerProperty<int>("TagId");
                    });
        });

        modelBuilder.Entity<ArticleMedia>(entity =>
        {
            entity.HasIndex(e => new { e.ArticleId, e.Position }, "UQ_ArticleMedias_ArticleId_Position").IsUnique();

            entity.Property(e => e.MediaUrl).HasMaxLength(2048);

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleMedia)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticleMedias_Articles");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_Categories_Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => new { e.ArticleId, e.CreatedAt }, "IX_Comments_ArticleId_CreatedAt").HasFilter("([ArticleId] IS NOT NULL AND [DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.PostId, e.CreatedAt }, "IX_Comments_PostId_CreatedAt").HasFilter("([PostId] IS NOT NULL AND [DeletedAt] IS NULL)");

            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.Article).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_Comments_Articles");

            entity.HasOne(d => d.AuthorUser).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Comments_Posts");
        });

        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasIndex(e => new { e.CommunityCategoryId, e.CreatedAt }, "IX_Communities_CategoryId_CreatedAt")
                .IsDescending(false, true)
                .HasFilter("([DeletedAt] IS NULL)");

            entity.HasIndex(e => e.CreatorUserId, "IX_Communities_CreatorUserId").HasFilter("([DeletedAt] IS NULL)");

            entity.HasIndex(e => e.Name, "IX_Communities_Name").HasFilter("([DeletedAt] IS NULL)");

            entity.Property(e => e.CoverUrl).HasMaxLength(2048);
            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ImageUrl).HasMaxLength(2048);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.CommunityCategory).WithMany(p => p.Communities)
                .HasForeignKey(d => d.CommunityCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Communities_CommunityCategories");

            entity.HasOne(d => d.CreatorUser).WithMany(p => p.Communities)
                .HasForeignKey(d => d.CreatorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Communities_Users");
        });

        modelBuilder.Entity<CommunityCategory>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_CommunityCategories_Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CommunityMember>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CommunityId });

            entity.Property(e => e.JoinedAt).HasPrecision(3);
            entity.Property(e => e.LeftAt).HasPrecision(3);
            entity.Property(e => e.RequestedAt).HasPrecision(3);

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityMembers)
                .HasForeignKey(d => d.CommunityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunityMembers_Communities");

            entity.HasOne(d => d.User).WithMany(p => p.CommunityMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunityMembers_Users");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<ConversationParticipant>(entity =>
        {
            entity.HasKey(e => new { e.ConversationId, e.UserId });

            entity.HasIndex(e => new { e.UserId, e.ConversationId }, "IX_ConversationParticipants_UserId_ConversationId");

            entity.Property(e => e.JoinedAt).HasPrecision(3);

            entity.HasOne(d => d.Conversation).WithMany(p => p.ConversationParticipants)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConversationParticipants_Conversations");

            entity.HasOne(d => d.User).WithMany(p => p.ConversationParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConversationParticipants_Users");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => new { e.FollowerUserId, e.FollowedUserId });

            entity.HasIndex(e => new { e.FollowedUserId, e.Status, e.FollowerUserId }, "IX_Follows_FollowedUserId_Status").HasFilter("([DeletedAt] IS NULL)");

            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.FollowedUser).WithMany(p => p.FollowFollowedUsers)
                .HasForeignKey(d => d.FollowedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Follows_Followed_Users");

            entity.HasOne(d => d.FollowerUser).WithMany(p => p.FollowFollowerUsers)
                .HasForeignKey(d => d.FollowerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Follows_Follower_Users");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_Games_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasIndex(e => new { e.ConversationId, e.SentAt }, "IX_Messages_ConversationId_SentAt");

            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.SentAt).HasPrecision(3);

            entity.HasOne(d => d.Conversation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Conversations");

            entity.HasOne(d => d.SenderUser).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Sender_Users");

            entity.HasOne(d => d.ConversationParticipant).WithMany(p => p.Messages)
                .HasForeignKey(d => new { d.ConversationId, d.SenderUserId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_ConversationParticipants");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => new { e.RecipientUserId, e.CreatedAt }, "IX_Notifications_RecipientUserId_CreatedAt").IsDescending(false, true);

            entity.HasIndex(e => new { e.RecipientUserId, e.CreatedAt }, "IX_Notifications_RecipientUserId_Unread")
                .IsDescending(false, true)
                .HasFilter("([IsRead]=(0))");

            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.Message).HasMaxLength(500);

            entity.HasOne(d => d.ActorUser).WithMany(p => p.NotificationActorUsers)
                .HasForeignKey(d => d.ActorUserId)
                .HasConstraintName("FK_Notifications_Actor_Users");

            entity.HasOne(d => d.RecipientUser).WithMany(p => p.NotificationRecipientUsers)
                .HasForeignKey(d => d.RecipientUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_Recipient_Users");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_Platforms_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasIndex(e => new { e.AuthorUserId, e.CreatedAt }, "IX_Posts_AuthorUserId_CreatedAt")
                .IsDescending(false, true)
                .HasFilter("([CommunityId] IS NULL AND [DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.CommunityId, e.CreatedAt }, "IX_Posts_CommunityId_CreatedAt")
                .IsDescending(false, true)
                .HasFilter("([DeletedAt] IS NULL)");

            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.AuthorUser).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AuthorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Posts_Users");

            entity.HasOne(d => d.Community).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FK_Posts_Communities");
        });

        modelBuilder.Entity<PostMedia>(entity =>
        {
            entity.HasIndex(e => new { e.PostId, e.Position }, "UQ_PostMedias_PostId_Position").IsUnique();

            entity.Property(e => e.MediaUrl).HasMaxLength(2048);

            entity.HasOne(d => d.Post).WithMany(p => p.PostMedia)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostMedias_Posts");
        });

        modelBuilder.Entity<Reaction>(entity =>
        {
            entity.HasIndex(e => new { e.ArticleId, e.UserId }, "IX_Reactions_ArticleId_UserId").HasFilter("([ArticleId] IS NOT NULL AND [DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.PostId, e.UserId }, "IX_Reactions_PostId_UserId").HasFilter("([PostId] IS NOT NULL AND [DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.UserId, e.ArticleId }, "UX_Reactions_UserId_ArticleId_Active")
                .IsUnique()
                .HasFilter("([ArticleId] IS NOT NULL AND [DeletedAt] IS NULL)");

            entity.HasIndex(e => new { e.UserId, e.PostId }, "UX_Reactions_UserId_PostId_Active")
                .IsUnique()
                .HasFilter("([PostId] IS NOT NULL AND [DeletedAt] IS NULL)");

            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.Emoji).HasMaxLength(32);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.Article).WithMany(p => p.Reactions)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_Reactions_Articles");

            entity.HasOne(d => d.Post).WithMany(p => p.Reactions)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Reactions_Posts");

            entity.HasOne(d => d.User).WithMany(p => p.Reactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reactions_Users");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_Tags_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UX_Users_Email_Active")
                .IsUnique()
                .HasFilter("([DeletedAt] IS NULL)");

            entity.HasIndex(e => e.Username, "UX_Users_Username_Active")
                .IsUnique()
                .HasFilter("([DeletedAt] IS NULL)");

            entity.Property(e => e.AvatarUrl).HasMaxLength(2048);
            entity.Property(e => e.Bio).HasMaxLength(500);
            entity.Property(e => e.CoverUrl).HasMaxLength(2048);
            entity.Property(e => e.CreatedAt).HasPrecision(3);
            entity.Property(e => e.DeletedAt).HasPrecision(3);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
            entity.Property(e => e.Username).HasMaxLength(30);

            entity.HasMany(d => d.Games).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserFavoriteGame",
                    r => r.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserFavoriteGames_Games"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserFavoriteGames_Users"),
                    j =>
                    {
                        j.HasKey("UserId", "GameId");
                        j.ToTable("UserFavoriteGames");
                        j.HasIndex(new[] { "GameId", "UserId" }, "IX_UserFavoriteGames_GameId_UserId");
                        j.IndexerProperty<int>("UserId");
                        j.IndexerProperty<int>("GameId");
                    });

            entity.HasMany(d => d.Platforms).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserPlatform",
                    r => r.HasOne<Platform>().WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserPlatforms_Platforms"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserPlatforms_Users"),
                    j =>
                    {
                        j.HasKey("UserId", "PlatformId");
                        j.ToTable("UserPlatforms");
                        j.HasIndex(new[] { "PlatformId", "UserId" }, "IX_UserPlatforms_PlatformId_UserId");
                        j.IndexerProperty<int>("UserId");
                        j.IndexerProperty<int>("PlatformId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
