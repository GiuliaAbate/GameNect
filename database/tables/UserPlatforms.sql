CREATE TABLE [dbo].[UserPlatforms] (
    [UserId]     INT NOT NULL,
    [PlatformId] INT NOT NULL,
    CONSTRAINT [PK_UserPlatforms] PRIMARY KEY CLUSTERED ([UserId] ASC, [PlatformId] ASC),
    CONSTRAINT [FK_UserPlatforms_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserPlatforms_Platforms] FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[Platforms] ([PlatformId]) ON DELETE NO ACTION
);

-- Trovare gli utenti associati a una piattaforma
CREATE NONCLUSTERED INDEX [IX_UserPlatforms_PlatformId_UserId]
    ON [dbo].[UserPlatforms]([PlatformId], [UserId]);
