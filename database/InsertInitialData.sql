-- Popolamento tabella Categories
INSERT INTO [dbo].[Categories] (
    [Name],
    [Description]
)
SELECT seed.[Name],
       seed.[Description]
FROM   (VALUES (N'Guide', N'Guide, tutorial e approfondimenti sui videogiochi.'), (N'Recensioni', N'Analisi e recensioni di videogiochi.'), (N'News', N'Notizie e aggiornamenti dal mondo videoludico.')) AS seed([Name], [Description])
WHERE  NOT EXISTS (SELECT 1
                   FROM   [dbo].[Categories] AS existing
                   WHERE  existing.[Name] = seed.[Name]);

-- Popolamento tabella CommunityCategories
INSERT INTO [dbo].[CommunityCategories] (
    [Name],
    [Description]
)
SELECT seed.[Name],
       seed.[Description]
FROM   (VALUES (N'Generale', N'Community di discussione generale sul gaming.')) AS seed([Name], [Description])
WHERE  NOT EXISTS (SELECT 1
                   FROM   [dbo].[CommunityCategories] AS existing
                   WHERE  existing.[Name] = seed.[Name]);

-- Popolamento tabella Platforms
INSERT INTO [dbo].[Platforms] (
    [Name]
)
SELECT seed.[Name]
FROM   (VALUES (N'PC'), (N'PlayStation 5'), (N'PlayStation 4'), (N'Xbox Series X|S'), (N'Xbox One'), (N'Nintendo Switch'), (N'Nintendo Switch 2'), (N'Mobile')) AS seed([Name])
WHERE  NOT EXISTS (SELECT 1
                   FROM   [dbo].[Platforms] AS existing
                   WHERE  existing.[Name] = seed.[Name]);

-- Popolamento tabella Games
INSERT INTO [dbo].[Games] (
    [Name]
)
SELECT seed.[Name]
FROM   (VALUES (N'Elden Ring'), (N'Minecraft'), (N'The Legend of Zelda: Breath Of The Wild'), (N'Cyberpunk 2077'), (N'Fortnite'), (N'Grand Theft Auto VI'), (N'EA Sports FC 27'), (N'League of Legends'), (N'Valorant')) AS seed([Name])
WHERE  NOT EXISTS (SELECT 1
                   FROM   [dbo].[Games] AS existing
                   WHERE  existing.[Name] = seed.[Name]);

-- Popolamento tabella Tags
INSERT INTO [dbo].[Tags] (
    [Name]
)
SELECT seed.[Name]
FROM   (VALUES (N'azione'), (N'avventura'), (N'GDR'), (N'indie'), (N'FPS'), (N'multiplayer'), (N'open-world'), (N'strategia'), (N'simulazione'), (N'horror'), (N'retro'), (N'notizie')) AS seed([Name])
WHERE  NOT EXISTS (SELECT 1
                   FROM   [dbo].[Tags] AS existing
                   WHERE  existing.[Name] = seed.[Name]);