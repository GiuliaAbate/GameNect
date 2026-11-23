using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Bio { get; set; }

    public string? AvatarUrl { get; set; }

    public string? CoverUrl { get; set; }

    public bool IsPrivate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Community> Communities { get; set; } = new List<Community>();

    public virtual ICollection<CommunityMember> CommunityMembers { get; set; } = new List<CommunityMember>();

    public virtual ICollection<ConversationParticipant> ConversationParticipants { get; set; } = new List<ConversationParticipant>();

    public virtual ICollection<Follow> FollowFollowedUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowerUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Notification> NotificationActorUsers { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationRecipientUsers { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Platform> Platforms { get; set; } = new List<Platform>();
}
