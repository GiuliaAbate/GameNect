CREATE TABLE [dbo].[Conversations] (
    [ConversationId] INT           IDENTITY (1, 1) NOT NULL,
    [CreatedAt]      DATETIME2 (3) NOT NULL,
    [UpdatedAt]      DATETIME2 (3) NOT NULL,
    CONSTRAINT [PK_Conversations] PRIMARY KEY CLUSTERED ([ConversationId] ASC)
);
