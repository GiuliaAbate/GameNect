CREATE TABLE [dbo].[ArticleMedias] (
    [ArticleMediaId] INT             IDENTITY (1, 1) NOT NULL,
    [ArticleId]      INT             NOT NULL,
    [MediaUrl]       NVARCHAR (2048) NOT NULL,
    [Position]       SMALLINT        NOT NULL,
    CONSTRAINT [PK_ArticleMedias] PRIMARY KEY CLUSTERED ([ArticleMediaId] ASC),
    CONSTRAINT [FK_ArticleMedias_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([ArticleId]) ON DELETE NO ACTION,
    CONSTRAINT [UQ_ArticleMedias_ArticleId_Position] UNIQUE NONCLUSTERED ([ArticleId] ASC, [Position] ASC),
    CONSTRAINT [CK_ArticleMedias_Position] CHECK ([Position] >= 0)
);
