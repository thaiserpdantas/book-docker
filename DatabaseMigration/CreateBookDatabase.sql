CREATE DATABASE [BookDatabase];
GO

USE [BookDatabase];
GO

CREATE TABLE [Books] (
	[Id] bigint identity primary key not null,
	[Name] nvarchar(max),
	[Author] nvarchar(max),
);
GO

INSERT INTO [Books] ([Name], [Author]) VALUES
('Book 1', 'Author 1'),
('Book 2', 'Author 2')
GO
