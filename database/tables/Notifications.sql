CREATE TABLE [dbo].[Notifications] (
    [NotificationId]  INT            IDENTITY (1, 1) NOT NULL,
    [RecipientUserId] INT            NOT NULL,
    [ActorUserId]     INT            NULL,
    [Type]            TINYINT        NOT NULL,
    [Message]         NVARCHAR (500) NOT NULL,
    [IsRead]          BIT            CONSTRAINT [DF_Notifications_IsRead] DEFAULT ((0)) NOT NULL,
    [CreatedAt]       DATETIME2 (3)  NOT NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationId] ASC),
    CONSTRAINT [FK_Notifications_Recipient_Users] FOREIGN KEY ([RecipientUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Notifications_Actor_Users] FOREIGN KEY ([ActorUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Notifications_Type] CHECK ([Type] BETWEEN 1 AND 9)
);

-- Recuperare le notifiche di un utente dal più recente
CREATE NONCLUSTERED INDEX [IX_Notifications_RecipientUserId_CreatedAt]
    ON [dbo].[Notifications]([RecipientUserId], [CreatedAt] DESC);

-- Recuperare rapidamente le notifiche non lette
CREATE NONCLUSTERED INDEX [IX_Notifications_RecipientUserId_Unread]
    ON [dbo].[Notifications]([RecipientUserId], [CreatedAt] DESC) WHERE [IsRead] = 0;
