IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'RectangleDB')
BEGIN
    CREATE DATABASE RectangleDB;
END
GO

USE [RectangleDB]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rectangles]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Rectangles](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [X] [int] NOT NULL,
        [Y] [int] NOT NULL,
        [Width] [int] NOT NULL,
        [Height] [int] NOT NULL,
        CONSTRAINT [PK_Rectangles] PRIMARY KEY CLUSTERED 
        (
            [Id] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO
