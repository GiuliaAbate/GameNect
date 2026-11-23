CREATE TABLE [dbo].[Games] (
    [GameId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([GameId] ASC),
    CONSTRAINT [UQ_Games_Name] UNIQUE NONCLUSTERED ([Name])
);