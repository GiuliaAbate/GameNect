CREATE TABLE [dbo].[Users] (
    [UserId]       INT             IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (30)   NOT NULL,
    [Email]        NVARCHAR (255)  NOT NULL,
    [PasswordHash] NVARCHAR (255)  NOT NULL,
    [Bio]          NVARCHAR (500)  NULL,
    [AvatarUrl]    NVARCHAR (2048) NULL,
    [CoverUrl]     NVARCHAR (2048) NULL,
    [IsPrivate]    BIT             CONSTRAINT [DF_Users_IsPrivate] DEFAULT (0) NOT NULL,
    [CreatedAt]    DATETIME2 (3)   NOT NULL,
    [UpdatedAt]    DATETIME2 (3)   NULL,
    [DeletedAt]    DATETIME2 (3)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

-- Username univoco tra gli account attivi
CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_Username_Active]
    ON [dbo].[Users]([Username]) WHERE [DeletedAt] IS NULL;

-- Email univoca tra gli account attivi
CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_Email_Active]
    ON [dbo].[Users]([Email]) WHERE [DeletedAt] IS NULL;