CREATE TABLE [dbo].[Messages] (
    [MessageId]      INT             IDENTITY (1, 1) NOT NULL,
    [ConversationId] INT             NOT NULL,
    [SenderUserId]   INT             NOT NULL,
    [Content]        NVARCHAR (2000) NOT NULL,
    [SentAt]         DATETIME2 (3)   NOT NULL,
    [DeletedAt]      DATETIME2 (3)   NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([MessageId] ASC),
    CONSTRAINT [FK_Messages_Conversations] FOREIGN KEY ([ConversationId]) REFERENCES [dbo].[Conversations] ([ConversationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_Sender_Users] FOREIGN KEY ([SenderUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_ConversationParticipants] FOREIGN KEY ([ConversationId], [SenderUserId]) REFERENCES [dbo].[ConversationParticipants] ([ConversationId], [UserId]) ON DELETE NO ACTION
);

-- Recuperare i messaggi di una conversazione in ordine cronologico
CREATE NONCLUSTERED INDEX [IX_Messages_ConversationId_SentAt]
    ON [dbo].[Messages]([ConversationId], [SentAt]);
