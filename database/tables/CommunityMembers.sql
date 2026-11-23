CREATE TABLE [dbo].[CommunityMembers] (
    [UserId]      INT           NOT NULL,
    [CommunityId] INT           NOT NULL,
    [Role]        TINYINT       NOT NULL,
    [Status]      TINYINT       NOT NULL,
    [RequestedAt] DATETIME2 (3) NOT NULL,
    [JoinedAt]    DATETIME2 (3) NULL,
    [LeftAt]      DATETIME2 (3) NULL,
    CONSTRAINT [PK_CommunityMembers] PRIMARY KEY CLUSTERED ([UserId] ASC, [CommunityId] ASC),
    CONSTRAINT [FK_CommunityMembers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CommunityMembers_Communities] FOREIGN KEY ([CommunityId]) REFERENCES [dbo].[Communities] ([CommunityId]) ON DELETE NO ACTION,
    CONSTRAINT [CK_CommunityMembers_Role] CHECK ([Role] IN (1, 2, 3)),
    CONSTRAINT [CK_CommunityMembers_Status] CHECK ([Status] IN (1, 2, 3, 4))
);

-- Recuperare membri e richieste di una community per stato
CREATE NONCLUSTERED INDEX [IX_CommunityMembers_CommunityId_Status]
    ON [dbo].[CommunityMembers]([CommunityId], [Status], [UserId]);
