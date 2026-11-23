CREATE TABLE [dbo].[UserFavoriteGames] (
    [UserId] INT NOT NULL,
    [GameId] INT NOT NULL,
    CONSTRAINT [PK_UserFavoriteGames] PRIMARY KEY CLUSTERED ([UserId] ASC, [GameId] ASC),
    CONSTRAINT [FK_UserFavoriteGames_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserFavoriteGames_Games] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([GameId]) ON DELETE NO ACTION
);

-- Trovare gli utenti che hanno indicato un determinato gioco
CREATE NONCLUSTERED INDEX [IX_UserFavoriteGames_GameId_UserId]
    ON [dbo].[UserFavoriteGames]([GameId], [UserId]);
