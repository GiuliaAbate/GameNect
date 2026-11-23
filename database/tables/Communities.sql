CREATE TABLE [dbo].[Communities] (
    [CommunityId]         INT             IDENTITY (1, 1) NOT NULL,
    [CreatorUserId]       INT             NOT NULL,
    [CommunityCategoryId] INT             NOT NULL,
    [Name]                NVARCHAR (100)  NOT NULL,
    [Description]         NVARCHAR (500)  NULL,
    [ImageUrl]            NVARCHAR (2048) NULL,
    [CoverUrl]            NVARCHAR (2048) NULL,
    [Rules]               NVARCHAR (MAX)  NULL,
    [IsPrivate]           BIT             CONSTRAINT [DF_Communities_IsPrivate] DEFAULT ((0)) NOT NULL,
    [CreatedAt]           DATETIME2 (3)   NOT NULL,
    [UpdatedAt]           DATETIME2 (3)   NULL,
    [DeletedAt]           DATETIME2 (3)   NULL,
    CONSTRAINT [PK_Communities] PRIMARY KEY CLUSTERED ([CommunityId] ASC),
    CONSTRAINT [FK_Communities_CommunityCategories] FOREIGN KEY ([CommunityCategoryId]) REFERENCES [dbo].[CommunityCategories] ([CommunityCategoryId]),
    CONSTRAINT [FK_Communities_Users] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[Users] ([UserId])
);

-- Recuperare le community create da un utente
CREATE NONCLUSTERED INDEX [IX_Communities_CreatorUserId]
    ON [dbo].[Communities]([CreatorUserId]) WHERE [DeletedAt] IS NULL;

-- Elencare le community per categoria e data
CREATE NONCLUSTERED INDEX [IX_Communities_CategoryId_CreatedAt]
    ON [dbo].[Communities]([CommunityCategoryId], [CreatedAt] DESC) WHERE [DeletedAt] IS NULL;

-- Supportare la ricerca delle community per nome
CREATE NONCLUSTERED INDEX [IX_Communities_Name]
    ON [dbo].[Communities]([Name]) WHERE [DeletedAt] IS NULL;