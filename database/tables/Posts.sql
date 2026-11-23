CREATE TABLE [dbo].[Posts] (
    [PostId]       INT             IDENTITY (1, 1) NOT NULL,
    [AuthorUserId] INT             NOT NULL,
    [CommunityId]  INT             NULL,
    [Content]      NVARCHAR (2000) NOT NULL,
    [CreatedAt]    DATETIME2 (3)   NOT NULL,
    [UpdatedAt]    DATETIME2 (3)   NULL,
    [DeletedAt]    DATETIME2 (3)   NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_Posts_Users] FOREIGN KEY ([AuthorUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Posts_Communities] FOREIGN KEY ([CommunityId]) REFERENCES [dbo].[Communities] ([CommunityId])
);

-- Recuperare i post personali di un utente dal più recente
CREATE NONCLUSTERED INDEX [IX_Posts_AuthorUserId_CreatedAt]
    ON [dbo].[Posts]([AuthorUserId], [CreatedAt] DESC) WHERE [CommunityId] IS NULL
                                                             AND [DeletedAt] IS NULL;

-- Recuperare i post di una community dal più recente
CREATE NONCLUSTERED INDEX [IX_Posts_CommunityId_CreatedAt]
    ON [dbo].[Posts]([CommunityId], [CreatedAt] DESC) WHERE [DeletedAt] IS NULL;