using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class PostMedia
{
    public int PostMediaId { get; set; }

    public int PostId { get; set; }

    public string MediaUrl { get; set; } = null!;

    public short Position { get; set; }

    public virtual Post Post { get; set; } = null!;
}
