
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/10/2017 21:27:03
-- Generated from EDMX file: C:\Data\ABEL\Projects\GitHubApps\TravelPackage\TravelPackage\TravelPackage\Models\TravelDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-TravelPackage-20170726021530];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tpAreastpProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProducts] DROP CONSTRAINT [FK_tpAreastpProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_tpProductstpProductImages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProductImages] DROP CONSTRAINT [FK_tpProductstpProductImages];
GO
IF OBJECT_ID(N'[dbo].[FK_tpCategorytpProdCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProdCats] DROP CONSTRAINT [FK_tpCategorytpProdCat];
GO
IF OBJECT_ID(N'[dbo].[FK_tpProductstpProdCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProdCats] DROP CONSTRAINT [FK_tpProductstpProdCat];
GO
IF OBJECT_ID(N'[dbo].[FK_tpProductstpInqServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpInqServices] DROP CONSTRAINT [FK_tpProductstpInqServices];
GO
IF OBJECT_ID(N'[dbo].[FK_tpInquirytpInqServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpInqServices] DROP CONSTRAINT [FK_tpInquirytpInqServices];
GO
IF OBJECT_ID(N'[dbo].[FK_tpProductstpProdRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProdRates] DROP CONSTRAINT [FK_tpProductstpProdRate];
GO
IF OBJECT_ID(N'[dbo].[FK_tpUomtpProdRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProdRates] DROP CONSTRAINT [FK_tpUomtpProdRate];
GO
IF OBJECT_ID(N'[dbo].[FK_tpProductstpProductDesc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpProductDescs] DROP CONSTRAINT [FK_tpProductstpProductDesc];
GO
IF OBJECT_ID(N'[dbo].[FK_tpProductstpKeyword]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tpKeywords] DROP CONSTRAINT [FK_tpProductstpKeyword];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tpAreas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpAreas];
GO
IF OBJECT_ID(N'[dbo].[tpProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpProducts];
GO
IF OBJECT_ID(N'[dbo].[tpProductImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpProductImages];
GO
IF OBJECT_ID(N'[dbo].[tpInquiries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpInquiries];
GO
IF OBJECT_ID(N'[dbo].[tpProdCats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpProdCats];
GO
IF OBJECT_ID(N'[dbo].[tpCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpCategories];
GO
IF OBJECT_ID(N'[dbo].[tpInqServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpInqServices];
GO
IF OBJECT_ID(N'[dbo].[tpProdRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpProdRates];
GO
IF OBJECT_ID(N'[dbo].[tpUoms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpUoms];
GO
IF OBJECT_ID(N'[dbo].[tpProductDescs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpProductDescs];
GO
IF OBJECT_ID(N'[dbo].[tpKeywords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpKeywords];
GO
IF OBJECT_ID(N'[dbo].[tpBacklinks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tpBacklinks];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tpAreas'
CREATE TABLE [dbo].[tpAreas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [PageRemarks] nvarchar(255)  NULL,
    [PageView] nvarchar(30)  NULL,
    [PgFeatureImg] nvarchar(150)  NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'tpProducts'
CREATE TABLE [dbo].[tpProducts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [ShortRemarks] nvarchar(250)  NULL,
    [PageView] nvarchar(50)  NULL,
    [PgFeatureImg] nvarchar(150)  NULL,
    [Sort] int  NOT NULL,
    [tpAreasId] int  NOT NULL
);
GO

-- Creating table 'tpProductImages'
CREATE TABLE [dbo].[tpProductImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tpProductsId] int  NOT NULL,
    [ImgPath] nvarchar(250)  NOT NULL,
    [Desc] nvarchar(150)  NULL,
    [AltName] nvarchar(80)  NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'tpInquiries'
CREATE TABLE [dbo].[tpInquiries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtInquiry] datetime  NOT NULL,
    [LeadGuest] nvarchar(250)  NOT NULL,
    [ContactNo] nvarchar(50)  NULL,
    [Email] nvarchar(120)  NULL,
    [NoOfChild] int  NOT NULL,
    [NoOfAdult] int  NOT NULL,
    [Status] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'tpProdCats'
CREATE TABLE [dbo].[tpProdCats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tpCategoryId] int  NOT NULL,
    [tpProductsId] int  NOT NULL
);
GO

-- Creating table 'tpCategories'
CREATE TABLE [dbo].[tpCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(80)  NOT NULL,
    [SysCode] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'tpInqServices'
CREATE TABLE [dbo].[tpInqServices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tpInquiryId] int  NOT NULL,
    [tpProductsId] int  NOT NULL,
    [dtSvcStart] datetime  NOT NULL,
    [Message] nvarchar(250)  NULL
);
GO

-- Creating table 'tpProdRates'
CREATE TABLE [dbo].[tpProdRates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tpProductsId] int  NOT NULL,
    [tpUomId] int  NOT NULL,
    [GroupOf] int  NOT NULL,
    [Rate] decimal(18,0)  NOT NULL,
    [Remarks] nvarchar(80)  NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'tpUoms'
CREATE TABLE [dbo].[tpUoms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Measure] nvarchar(30)  NOT NULL,
    [Remarks] nvarchar(180)  NULL
);
GO

-- Creating table 'tpProductDescs'
CREATE TABLE [dbo].[tpProductDescs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tpProductsId] int  NOT NULL,
    [tpDescH1] nvarchar(30)  NULL,
    [tpDescH2] nvarchar(50)  NULL,
    [tpDesc] nvarchar(250)  NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'tpKeywords'
CREATE TABLE [dbo].[tpKeywords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Keyword] nvarchar(150)  NOT NULL,
    [tpProductsId] int  NOT NULL
);
GO

-- Creating table 'tpBacklinks'
CREATE TABLE [dbo].[tpBacklinks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LinkType] nvarchar(10)  NOT NULL,
    [LinkUrl] nvarchar(250)  NOT NULL,
    [Description] nvarchar(250)  NOT NULL,
    [LinkExpiry] datetime  NOT NULL,
    [Status] nvarchar(3)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'tpAreas'
ALTER TABLE [dbo].[tpAreas]
ADD CONSTRAINT [PK_tpAreas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpProducts'
ALTER TABLE [dbo].[tpProducts]
ADD CONSTRAINT [PK_tpProducts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpProductImages'
ALTER TABLE [dbo].[tpProductImages]
ADD CONSTRAINT [PK_tpProductImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpInquiries'
ALTER TABLE [dbo].[tpInquiries]
ADD CONSTRAINT [PK_tpInquiries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpProdCats'
ALTER TABLE [dbo].[tpProdCats]
ADD CONSTRAINT [PK_tpProdCats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpCategories'
ALTER TABLE [dbo].[tpCategories]
ADD CONSTRAINT [PK_tpCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpInqServices'
ALTER TABLE [dbo].[tpInqServices]
ADD CONSTRAINT [PK_tpInqServices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpProdRates'
ALTER TABLE [dbo].[tpProdRates]
ADD CONSTRAINT [PK_tpProdRates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpUoms'
ALTER TABLE [dbo].[tpUoms]
ADD CONSTRAINT [PK_tpUoms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpProductDescs'
ALTER TABLE [dbo].[tpProductDescs]
ADD CONSTRAINT [PK_tpProductDescs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpKeywords'
ALTER TABLE [dbo].[tpKeywords]
ADD CONSTRAINT [PK_tpKeywords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tpBacklinks'
ALTER TABLE [dbo].[tpBacklinks]
ADD CONSTRAINT [PK_tpBacklinks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [tpAreasId] in table 'tpProducts'
ALTER TABLE [dbo].[tpProducts]
ADD CONSTRAINT [FK_tpAreastpProducts]
    FOREIGN KEY ([tpAreasId])
    REFERENCES [dbo].[tpAreas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpAreastpProducts'
CREATE INDEX [IX_FK_tpAreastpProducts]
ON [dbo].[tpProducts]
    ([tpAreasId]);
GO

-- Creating foreign key on [tpProductsId] in table 'tpProductImages'
ALTER TABLE [dbo].[tpProductImages]
ADD CONSTRAINT [FK_tpProductstpProductImages]
    FOREIGN KEY ([tpProductsId])
    REFERENCES [dbo].[tpProducts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpProductstpProductImages'
CREATE INDEX [IX_FK_tpProductstpProductImages]
ON [dbo].[tpProductImages]
    ([tpProductsId]);
GO

-- Creating foreign key on [tpCategoryId] in table 'tpProdCats'
ALTER TABLE [dbo].[tpProdCats]
ADD CONSTRAINT [FK_tpCategorytpProdCat]
    FOREIGN KEY ([tpCategoryId])
    REFERENCES [dbo].[tpCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpCategorytpProdCat'
CREATE INDEX [IX_FK_tpCategorytpProdCat]
ON [dbo].[tpProdCats]
    ([tpCategoryId]);
GO

-- Creating foreign key on [tpProductsId] in table 'tpProdCats'
ALTER TABLE [dbo].[tpProdCats]
ADD CONSTRAINT [FK_tpProductstpProdCat]
    FOREIGN KEY ([tpProductsId])
    REFERENCES [dbo].[tpProducts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpProductstpProdCat'
CREATE INDEX [IX_FK_tpProductstpProdCat]
ON [dbo].[tpProdCats]
    ([tpProductsId]);
GO

-- Creating foreign key on [tpProductsId] in table 'tpInqServices'
ALTER TABLE [dbo].[tpInqServices]
ADD CONSTRAINT [FK_tpProductstpInqServices]
    FOREIGN KEY ([tpProductsId])
    REFERENCES [dbo].[tpProducts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpProductstpInqServices'
CREATE INDEX [IX_FK_tpProductstpInqServices]
ON [dbo].[tpInqServices]
    ([tpProductsId]);
GO

-- Creating foreign key on [tpInquiryId] in table 'tpInqServices'
ALTER TABLE [dbo].[tpInqServices]
ADD CONSTRAINT [FK_tpInquirytpInqServices]
    FOREIGN KEY ([tpInquiryId])
    REFERENCES [dbo].[tpInquiries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpInquirytpInqServices'
CREATE INDEX [IX_FK_tpInquirytpInqServices]
ON [dbo].[tpInqServices]
    ([tpInquiryId]);
GO

-- Creating foreign key on [tpProductsId] in table 'tpProdRates'
ALTER TABLE [dbo].[tpProdRates]
ADD CONSTRAINT [FK_tpProductstpProdRate]
    FOREIGN KEY ([tpProductsId])
    REFERENCES [dbo].[tpProducts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpProductstpProdRate'
CREATE INDEX [IX_FK_tpProductstpProdRate]
ON [dbo].[tpProdRates]
    ([tpProductsId]);
GO

-- Creating foreign key on [tpUomId] in table 'tpProdRates'
ALTER TABLE [dbo].[tpProdRates]
ADD CONSTRAINT [FK_tpUomtpProdRate]
    FOREIGN KEY ([tpUomId])
    REFERENCES [dbo].[tpUoms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpUomtpProdRate'
CREATE INDEX [IX_FK_tpUomtpProdRate]
ON [dbo].[tpProdRates]
    ([tpUomId]);
GO

-- Creating foreign key on [tpProductsId] in table 'tpProductDescs'
ALTER TABLE [dbo].[tpProductDescs]
ADD CONSTRAINT [FK_tpProductstpProductDesc]
    FOREIGN KEY ([tpProductsId])
    REFERENCES [dbo].[tpProducts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpProductstpProductDesc'
CREATE INDEX [IX_FK_tpProductstpProductDesc]
ON [dbo].[tpProductDescs]
    ([tpProductsId]);
GO

-- Creating foreign key on [tpProductsId] in table 'tpKeywords'
ALTER TABLE [dbo].[tpKeywords]
ADD CONSTRAINT [FK_tpProductstpKeyword]
    FOREIGN KEY ([tpProductsId])
    REFERENCES [dbo].[tpProducts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tpProductstpKeyword'
CREATE INDEX [IX_FK_tpProductstpKeyword]
ON [dbo].[tpKeywords]
    ([tpProductsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------