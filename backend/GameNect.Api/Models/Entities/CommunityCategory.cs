using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class CommunityCategory
{
    public int CommunityCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Community> Communities { get; set; } = new List<Community>();
}
