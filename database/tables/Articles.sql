CREATE TABLE [dbo].[Articles] (
    [ArticleId]    INT            IDENTITY (1, 1) NOT NULL,
    [AuthorUserId] INT            NOT NULL,
    [CategoryId]   INT            NOT NULL,
    [Title]        NVARCHAR (100) NOT NULL,
    [Content]      NVARCHAR (MAX) NOT NULL,
    [Status]       TINYINT        NOT NULL,
    [CreatedAt]    DATETIME2 (3)  NOT NULL,
    [UpdatedAt]    DATETIME2 (3)  NULL,
    [PublishedAt]  DATETIME2 (3)  NULL,
    [DeletedAt]    DATETIME2 (3)  NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([ArticleId] ASC),
    CONSTRAINT [FK_Articles_Users] FOREIGN KEY ([AuthorUserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Articles_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Articles_Status] CHECK ([Status] IN (1, 2))
);

-- Recuperare gli articoli di un autore ordinati per pubblicazione
CREATE NONCLUSTERED INDEX [IX_Articles_AuthorUserId_PublishedAt]
    ON [dbo].[Articles]([AuthorUserId], [PublishedAt] DESC) WHERE [DeletedAt] IS NULL;

-- Recuperare gli articoli di una categoria
CREATE NONCLUSTERED INDEX [IX_Articles_CategoryId_PublishedAt]
    ON [dbo].[Articles]([CategoryId], [PublishedAt] DESC) WHERE [DeletedAt] IS NULL;

-- Recuperare gli articoli in base allo stato e alla data
CREATE NONCLUSTERED INDEX [IX_Articles_Status_PublishedAt]
    ON [dbo].[Articles]([Status], [PublishedAt] DESC) WHERE [DeletedAt] IS NULL;