CREATE TABLE [dbo].[CommunityCategories] (
    [CommunityCategoryId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (100) NOT NULL,
    [Description]         NVARCHAR (500) NULL,
    CONSTRAINT [PK_CommunityCategories] PRIMARY KEY CLUSTERED ([CommunityCategoryId] ASC),
    CONSTRAINT [UQ_CommunityCategories_Name] UNIQUE NONCLUSTERED ([Name])
);