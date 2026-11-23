using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class ArticleMedia
{
    public int ArticleMediaId { get; set; }

    public int ArticleId { get; set; }

    public string MediaUrl { get; set; } = null!;

    public short Position { get; set; }

    public virtual Article Article { get; set; } = null!;
}
