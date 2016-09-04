
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/04/2016 17:36:02
-- Generated from EDMX file: C:\Users\nemesis\Desktop\test\Stan\Stan\SQLData\SQLModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StanoviDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Stans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stans];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Stans'
CREATE TABLE [dbo].[Stans] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GazdaId] nvarchar(max)  NOT NULL,
    [Kvadratura] smallint  NOT NULL,
    [BrojNaSobi] smallint  NOT NULL,
    [NaKojSprat] smallint  NOT NULL,
    [ImaLift] bit  NOT NULL,
    [ImaKujna] bit  NOT NULL,
    [ImaToalet] bit  NOT NULL,
    [ImaTerasa] bit  NOT NULL,
    [Namesten] bit  NOT NULL,
    [DatumObjaven] datetime  NOT NULL,
    [KontaktIme] nvarchar(max)  NOT NULL,
    [KontaktBroj] nvarchar(max)  NOT NULL,
    [Lokacija] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Cena] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Stans'
ALTER TABLE [dbo].[Stans]
ADD CONSTRAINT [PK_Stans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------