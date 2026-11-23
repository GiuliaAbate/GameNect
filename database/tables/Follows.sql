CREATE TABLE [dbo].[Follows] (
    [FollowerUserId] INT           NOT NULL,
    [FollowedUserId] INT           NOT NULL,
    [Status]         TINYINT       NOT NULL,
    [CreatedAt]      DATETIME2 (3) NOT NULL,
    [UpdatedAt]      DATETIME2 (3) NULL,
    [DeletedAt]      DATETIME2 (3) NULL,
    CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED ([FollowerUserId] ASC, [FollowedUserId] ASC),
    CONSTRAINT [FK_Follows_Follower_Users] FOREIGN KEY ([FollowerUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Follows_Followed_Users] FOREIGN KEY ([FollowedUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Follows_NotSelf] CHECK ([FollowerUserId] <> [FollowedUserId]),
    CONSTRAINT [CK_Follows_Status] CHECK ([Status] IN (1, 2, 3))
);

-- Recuperare follower e richieste ricevute
CREATE NONCLUSTERED INDEX [IX_Follows_FollowedUserId_Status]
    ON [dbo].[Follows]([FollowedUserId], [Status], [FollowerUserId]) WHERE [DeletedAt] IS NULL;
