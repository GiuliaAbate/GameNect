using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int AuthorUserId { get; set; }

    public int? PostId { get; set; }

    public int? ArticleId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Article? Article { get; set; }

    public virtual User AuthorUser { get; set; } = null!;

    public virtual Post? Post { get; set; }
}
