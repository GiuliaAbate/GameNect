using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int RecipientUserId { get; set; }

    public int? ActorUserId { get; set; }

    public byte Type { get; set; }

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User? ActorUser { get; set; }

    public virtual User RecipientUser { get; set; } = null!;
}
