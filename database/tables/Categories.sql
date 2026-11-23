CREATE TABLE [dbo].[Categories] (
    [CategoryId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [UQ_Categories_Name] UNIQUE NONCLUSTERED ([Name])
);
