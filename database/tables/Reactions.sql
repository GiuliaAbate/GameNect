CREATE TABLE [dbo].[Reactions] (
    [ReactionId] INT           IDENTITY (1, 1) NOT NULL,
    [UserId]     INT           NOT NULL,
    [PostId]     INT           NULL,
    [ArticleId]  INT           NULL,
    [Emoji]      NVARCHAR (32) NOT NULL,
    [CreatedAt]  DATETIME2 (3) NOT NULL,
    [UpdatedAt]  DATETIME2 (3) NULL,
    [DeletedAt]  DATETIME2 (3) NULL,
    CONSTRAINT [PK_Reactions] PRIMARY KEY CLUSTERED ([ReactionId] ASC),
    CONSTRAINT [FK_Reactions_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reactions_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([PostId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reactions_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([ArticleId]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Reactions_OneTarget] CHECK (([PostId] IS NOT NULL
                                                AND [ArticleId] IS NULL)
                                               OR ([PostId] IS NULL
                                                   AND [ArticleId] IS NOT NULL))
);

-- Associare la reazione a un solo contenuto
CREATE UNIQUE NONCLUSTERED INDEX [UX_Reactions_UserId_PostId_Active]
    ON [dbo].[Reactions]([UserId], [PostId]) WHERE [PostId] IS NOT NULL
                                                   AND [DeletedAt] IS NULL;

-- Associare la reazione a un solo contenuto
CREATE UNIQUE NONCLUSTERED INDEX [UX_Reactions_UserId_ArticleId_Active]
    ON [dbo].[Reactions]([UserId], [ArticleId]) WHERE [ArticleId] IS NOT NULL
                                                      AND [DeletedAt] IS NULL;

-- Recuperare le reazioni attive di un post
CREATE NONCLUSTERED INDEX [IX_Reactions_PostId_UserId]
    ON [dbo].[Reactions]([PostId], [UserId]) WHERE [PostId] IS NOT NULL
                                                   AND [DeletedAt] IS NULL;

-- Recuperare le reazioni attive di un articolo
CREATE NONCLUSTERED INDEX [IX_Reactions_ArticleId_UserId]
    ON [dbo].[Reactions]([ArticleId], [UserId]) WHERE [ArticleId] IS NOT NULL
                                                      AND [DeletedAt] IS NULL;