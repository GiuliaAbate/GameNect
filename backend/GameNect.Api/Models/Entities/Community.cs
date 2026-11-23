using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Community
{
    public int CommunityId { get; set; }

    public int CreatorUserId { get; set; }

    public int CommunityCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? CoverUrl { get; set; }

    public string? Rules { get; set; }

    public bool IsPrivate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CommunityCategory CommunityCategory { get; set; } = null!;

    public virtual ICollection<CommunityMember> CommunityMembers { get; set; } = new List<CommunityMember>();

    public virtual User CreatorUser { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
