CREATE TABLE [dbo].[ArticleTags] (
    [ArticleId] INT NOT NULL,
    [TagId]     INT NOT NULL,
    CONSTRAINT [PK_ArticleTags] PRIMARY KEY CLUSTERED ([ArticleId] ASC, [TagId] ASC),
    CONSTRAINT [FK_ArticleTags_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([ArticleId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ArticleTags_Tags] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([TagId]) ON DELETE NO ACTION
);

-- Trovare gli articoli associati a un tag
CREATE NONCLUSTERED INDEX [IX_ArticleTags_TagId_ArticleId]
    ON [dbo].[ArticleTags]([TagId], [ArticleId]);
