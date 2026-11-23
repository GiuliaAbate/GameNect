using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Post
{
    public int PostId { get; set; }

    public int AuthorUserId { get; set; }

    public int? CommunityId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User AuthorUser { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Community? Community { get; set; }

    public virtual ICollection<PostMedia> PostMedia { get; set; } = new List<PostMedia>();

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
}
