CREATE TABLE [dbo].[Collectible]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR NOT NULL,
	[Quantity] INT,
	[PlayerId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[AspNetUsers]([Id])
)
