using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class CommunityMember
{
    public int UserId { get; set; }

    public int CommunityId { get; set; }

    public byte Role { get; set; }

    public byte Status { get; set; }

    public DateTime RequestedAt { get; set; }

    public DateTime? JoinedAt { get; set; }

    public DateTime? LeftAt { get; set; }

    public virtual Community Community { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
