USE [local];

CREATE TABLE [dbo].[Category](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Product](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL,
    [CategoryId] INT NOT NULL,
	CONSTRAINT FK_Product_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]) 
)

INSERT INTO [dbo].[Category]
    ([Name])
VALUES
    ('Name 1'),
    ('Name 2'),
    ('Name 3');

INSERT INTO [dbo].[Product]
    ([Name], [CategoryId])
VALUES
    ('Product 1', (SELECT TOP 1 [Id] FROM [dbo].[Category] WHERE [Name] = 'Name 1')),
    ('Product 3', (SELECT TOP 1 [Id] FROM [dbo].[Category] WHERE [Name] = 'Name 2')),
    ('Product 2', (SELECT TOP 1 [Id] FROM [dbo].[Category] WHERE [Name] = 'Name 3'));
GO