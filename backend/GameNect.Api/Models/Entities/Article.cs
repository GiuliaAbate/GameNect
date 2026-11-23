using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Article
{
    public int ArticleId { get; set; }

    public int AuthorUserId { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ArticleMedia> ArticleMedia { get; set; } = new List<ArticleMedia>();

    public virtual User AuthorUser { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
