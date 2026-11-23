CREATE TABLE [dbo].[Platforms] (
    [PlatformId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED ([PlatformId] ASC),
    CONSTRAINT [UQ_Platforms_Name] UNIQUE NONCLUSTERED ([Name])
);
