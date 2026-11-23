CREATE TABLE [dbo].[ConversationParticipants] (
    [ConversationId] INT           NOT NULL,
    [UserId]         INT           NOT NULL,
    [JoinedAt]       DATETIME2 (3) NOT NULL,
    CONSTRAINT [PK_ConversationParticipants] PRIMARY KEY CLUSTERED ([ConversationId] ASC, [UserId] ASC),
    CONSTRAINT [FK_ConversationParticipants_Conversations] FOREIGN KEY ([ConversationId]) REFERENCES [dbo].[Conversations] ([ConversationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ConversationParticipants_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION
);

-- Recuperare le conversazioni di un utente
CREATE NONCLUSTERED INDEX [IX_ConversationParticipants_UserId_ConversationId]
    ON [dbo].[ConversationParticipants]([UserId], [ConversationId]);
