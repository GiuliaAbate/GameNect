using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Reaction
{
    public int ReactionId { get; set; }

    public int UserId { get; set; }

    public int? PostId { get; set; }

    public int? ArticleId { get; set; }

    public string Emoji { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User User { get; set; } = null!;
}
