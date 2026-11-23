using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Message
{
    public int MessageId { get; set; }

    public int ConversationId { get; set; }

    public int SenderUserId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual ConversationParticipant ConversationParticipant { get; set; } = null!;

    public virtual User SenderUser { get; set; } = null!;
}
