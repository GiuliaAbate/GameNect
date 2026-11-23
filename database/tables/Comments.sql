CREATE TABLE [dbo].[Comments] (
    [CommentId]    INT             IDENTITY (1, 1) NOT NULL,
    [AuthorUserId] INT             NOT NULL,
    [PostId]       INT             NULL,
    [ArticleId]    INT             NULL,
    [Content]      NVARCHAR (2000) NOT NULL,
    [CreatedAt]    DATETIME2 (3)   NOT NULL,
    [UpdatedAt]    DATETIME2 (3)   NULL,
    [DeletedAt]    DATETIME2 (3)   NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_Comments_Users] FOREIGN KEY ([AuthorUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Comments_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([PostId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Comments_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([ArticleId]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Comments_OneTarget] CHECK (([PostId] IS NOT NULL
                                               AND [ArticleId] IS NULL)
                                              OR ([PostId] IS NULL
                                                  AND [ArticleId] IS NOT NULL))
);

-- Recuperare i commenti attivi di un post
CREATE NONCLUSTERED INDEX [IX_Comments_PostId_CreatedAt]
    ON [dbo].[Comments]([PostId], [CreatedAt]) WHERE [PostId] IS NOT NULL
                                                     AND [DeletedAt] IS NULL;

-- Recuperare i commenti attivi di un articolo
CREATE NONCLUSTERED INDEX [IX_Comments_ArticleId_CreatedAt]
    ON [dbo].[Comments]([ArticleId], [CreatedAt]) WHERE [ArticleId] IS NOT NULL
                                                        AND [DeletedAt] IS NULL;