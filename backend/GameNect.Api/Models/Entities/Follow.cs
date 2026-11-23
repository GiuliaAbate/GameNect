using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Follow
{
    public int FollowerUserId { get; set; }

    public int FollowedUserId { get; set; }

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User FollowedUser { get; set; } = null!;

    public virtual User FollowerUser { get; set; } = null!;
}
