CREATE TABLE [dbo].[PostMedias] (
    [PostMediaId] INT             IDENTITY (1, 1) NOT NULL,
    [PostId]      INT             NOT NULL,
    [MediaUrl]    NVARCHAR (2048) NOT NULL,
    [Position]    SMALLINT        NOT NULL,
    CONSTRAINT [PK_PostMedias] PRIMARY KEY CLUSTERED ([PostMediaId] ASC),
    CONSTRAINT [FK_PostMedias_Posts] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([PostId]) ON DELETE NO ACTION,
    CONSTRAINT [UQ_PostMedias_PostId_Position] UNIQUE NONCLUSTERED ([PostId] ASC, [Position] ASC),
    CONSTRAINT [CK_PostMedias_Position] CHECK ([Position] >= 0)
);