
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2017 16:14:24
-- Generated from EDMX file: c:\src\VSTips\API\Models\Tip.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vstips];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tips'
CREATE TABLE [dbo].[Tips] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [ShortcutKey] nvarchar(max)  NULL,
    [GifUri] nvarchar(max)  NULL,
    [VdeoUri] nvarchar(max)  NULL,
    [HelpUri] nvarchar(max)  NULL,
    [Version] int  NULL,
    [ImageUri] nvarchar(max)  NULL,
    [UiTarget] nvarchar(max)  NULL,
    [isActive] bit  NULL,
    [CreatedBy] nvarchar(max)  NULL,
    [CreatedOn] datetime  NULL,
    [LastEditedOn] datetime  NULL,
    [LastEditedBy] nvarchar(max)  NULL,
    [MinVSVersion] nvarchar(max)  NULL,
    [MaxVSVersion] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Tips'
ALTER TABLE [dbo].[Tips]
ADD CONSTRAINT [PK_Tips]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------