
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/30/2018 11:23:40
-- Generated from EDMX file: D:\_Study\labs\ITManagment\X\X\X\X\Models\XModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [X.Models.XModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DrugDealersDrugSuplies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugSuplySet] DROP CONSTRAINT [FK_DrugDealersDrugSuplies];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugSuplyDrug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugSuplySet] DROP CONSTRAINT [FK_DrugSuplyDrug];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitsOfMeasurementDrugSuply]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugSuplySet] DROP CONSTRAINT [FK_UnitsOfMeasurementDrugSuply];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugDistributorBoughtDrugSuply]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugSuplySet_BoughtDrugSuply] DROP CONSTRAINT [FK_DrugDistributorBoughtDrugSuply];
GO
IF OBJECT_ID(N'[dbo].[FK_BoughtDrugSuplyDrugPack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugPackSet] DROP CONSTRAINT [FK_BoughtDrugSuplyDrugPack];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugUnitsOfMeasurement_Drug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugUnitsOfMeasurement] DROP CONSTRAINT [FK_DrugUnitsOfMeasurement_Drug];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugUnitsOfMeasurement_UnitsOfMeasurement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugUnitsOfMeasurement] DROP CONSTRAINT [FK_DrugUnitsOfMeasurement_UnitsOfMeasurement];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugSuplier_inherits_SystemUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemUserSet_DrugSuplier] DROP CONSTRAINT [FK_DrugSuplier_inherits_SystemUser];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugDistributor_inherits_SystemUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SystemUserSet_DrugDistributor] DROP CONSTRAINT [FK_DrugDistributor_inherits_SystemUser];
GO
IF OBJECT_ID(N'[dbo].[FK_BoughtDrugSuply_inherits_DrugSuply]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugSuplySet_BoughtDrugSuply] DROP CONSTRAINT [FK_BoughtDrugSuply_inherits_DrugSuply];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DrugSuplySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugSuplySet];
GO
IF OBJECT_ID(N'[dbo].[SystemUserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemUserSet];
GO
IF OBJECT_ID(N'[dbo].[DrugSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugSet];
GO
IF OBJECT_ID(N'[dbo].[UnitsOfMeasurementSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnitsOfMeasurementSet];
GO
IF OBJECT_ID(N'[dbo].[DrugPackSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugPackSet];
GO
IF OBJECT_ID(N'[dbo].[SystemUserSet_DrugSuplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemUserSet_DrugSuplier];
GO
IF OBJECT_ID(N'[dbo].[SystemUserSet_DrugDistributor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemUserSet_DrugDistributor];
GO
IF OBJECT_ID(N'[dbo].[DrugSuplySet_BoughtDrugSuply]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugSuplySet_BoughtDrugSuply];
GO
IF OBJECT_ID(N'[dbo].[DrugUnitsOfMeasurement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugUnitsOfMeasurement];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DrugSuplySet'
CREATE TABLE [dbo].[DrugSuplySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugSuplierId] int  NOT NULL,
    [Price] bigint  NOT NULL,
    [DeliveryTime] datetime  NOT NULL,
    [DrugId] int  NOT NULL,
    [Count] int  NOT NULL,
    [UnitsOfMeasurementId] int  NOT NULL
);
GO

-- Creating table 'SystemUserSet'
CREATE TABLE [dbo].[SystemUserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NULL,
    [Balance] bigint  NOT NULL,
    [SessionKey] nvarchar(max)  NULL
);
GO

-- Creating table 'DrugSet'
CREATE TABLE [dbo].[DrugSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UnitsOfMeasurementSet'
CREATE TABLE [dbo].[UnitsOfMeasurementSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ShortName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DrugPackSet'
CREATE TABLE [dbo].[DrugPackSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BoughtDrugSuplyId] int  NOT NULL,
    [CoordX] nvarchar(max)  NOT NULL,
    [CoordY] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [Price] int  NOT NULL
);
GO

-- Creating table 'SystemUserSet_DrugSuplier'
CREATE TABLE [dbo].[SystemUserSet_DrugSuplier] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'SystemUserSet_DrugDistributor'
CREATE TABLE [dbo].[SystemUserSet_DrugDistributor] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'DrugSuplySet_BoughtDrugSuply'
CREATE TABLE [dbo].[DrugSuplySet_BoughtDrugSuply] (
    [DrugDistributorId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'DrugSuplySet_DrugSuplyOffer'
CREATE TABLE [dbo].[DrugSuplySet_DrugSuplyOffer] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'DrugUnitsOfMeasurement'
CREATE TABLE [dbo].[DrugUnitsOfMeasurement] (
    [DrugUnitsOfMeasurement_UnitsOfMeasurement_Id] int  NOT NULL,
    [UnitsOfMeasurement_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DrugSuplySet'
ALTER TABLE [dbo].[DrugSuplySet]
ADD CONSTRAINT [PK_DrugSuplySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SystemUserSet'
ALTER TABLE [dbo].[SystemUserSet]
ADD CONSTRAINT [PK_SystemUserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugSet'
ALTER TABLE [dbo].[DrugSet]
ADD CONSTRAINT [PK_DrugSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UnitsOfMeasurementSet'
ALTER TABLE [dbo].[UnitsOfMeasurementSet]
ADD CONSTRAINT [PK_UnitsOfMeasurementSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugPackSet'
ALTER TABLE [dbo].[DrugPackSet]
ADD CONSTRAINT [PK_DrugPackSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SystemUserSet_DrugSuplier'
ALTER TABLE [dbo].[SystemUserSet_DrugSuplier]
ADD CONSTRAINT [PK_SystemUserSet_DrugSuplier]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SystemUserSet_DrugDistributor'
ALTER TABLE [dbo].[SystemUserSet_DrugDistributor]
ADD CONSTRAINT [PK_SystemUserSet_DrugDistributor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugSuplySet_BoughtDrugSuply'
ALTER TABLE [dbo].[DrugSuplySet_BoughtDrugSuply]
ADD CONSTRAINT [PK_DrugSuplySet_BoughtDrugSuply]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugSuplySet_DrugSuplyOffer'
ALTER TABLE [dbo].[DrugSuplySet_DrugSuplyOffer]
ADD CONSTRAINT [PK_DrugSuplySet_DrugSuplyOffer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [DrugUnitsOfMeasurement_UnitsOfMeasurement_Id], [UnitsOfMeasurement_Id] in table 'DrugUnitsOfMeasurement'
ALTER TABLE [dbo].[DrugUnitsOfMeasurement]
ADD CONSTRAINT [PK_DrugUnitsOfMeasurement]
    PRIMARY KEY CLUSTERED ([DrugUnitsOfMeasurement_UnitsOfMeasurement_Id], [UnitsOfMeasurement_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DrugSuplierId] in table 'DrugSuplySet'
ALTER TABLE [dbo].[DrugSuplySet]
ADD CONSTRAINT [FK_DrugDealersDrugSuplies]
    FOREIGN KEY ([DrugSuplierId])
    REFERENCES [dbo].[SystemUserSet_DrugSuplier]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugDealersDrugSuplies'
CREATE INDEX [IX_FK_DrugDealersDrugSuplies]
ON [dbo].[DrugSuplySet]
    ([DrugSuplierId]);
GO

-- Creating foreign key on [DrugId] in table 'DrugSuplySet'
ALTER TABLE [dbo].[DrugSuplySet]
ADD CONSTRAINT [FK_DrugSuplyDrug]
    FOREIGN KEY ([DrugId])
    REFERENCES [dbo].[DrugSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugSuplyDrug'
CREATE INDEX [IX_FK_DrugSuplyDrug]
ON [dbo].[DrugSuplySet]
    ([DrugId]);
GO

-- Creating foreign key on [UnitsOfMeasurementId] in table 'DrugSuplySet'
ALTER TABLE [dbo].[DrugSuplySet]
ADD CONSTRAINT [FK_UnitsOfMeasurementDrugSuply]
    FOREIGN KEY ([UnitsOfMeasurementId])
    REFERENCES [dbo].[UnitsOfMeasurementSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitsOfMeasurementDrugSuply'
CREATE INDEX [IX_FK_UnitsOfMeasurementDrugSuply]
ON [dbo].[DrugSuplySet]
    ([UnitsOfMeasurementId]);
GO

-- Creating foreign key on [DrugDistributorId] in table 'DrugSuplySet_BoughtDrugSuply'
ALTER TABLE [dbo].[DrugSuplySet_BoughtDrugSuply]
ADD CONSTRAINT [FK_DrugDistributorBoughtDrugSuply]
    FOREIGN KEY ([DrugDistributorId])
    REFERENCES [dbo].[SystemUserSet_DrugDistributor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugDistributorBoughtDrugSuply'
CREATE INDEX [IX_FK_DrugDistributorBoughtDrugSuply]
ON [dbo].[DrugSuplySet_BoughtDrugSuply]
    ([DrugDistributorId]);
GO

-- Creating foreign key on [BoughtDrugSuplyId] in table 'DrugPackSet'
ALTER TABLE [dbo].[DrugPackSet]
ADD CONSTRAINT [FK_BoughtDrugSuplyDrugPack]
    FOREIGN KEY ([BoughtDrugSuplyId])
    REFERENCES [dbo].[DrugSuplySet_BoughtDrugSuply]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoughtDrugSuplyDrugPack'
CREATE INDEX [IX_FK_BoughtDrugSuplyDrugPack]
ON [dbo].[DrugPackSet]
    ([BoughtDrugSuplyId]);
GO

-- Creating foreign key on [DrugUnitsOfMeasurement_UnitsOfMeasurement_Id] in table 'DrugUnitsOfMeasurement'
ALTER TABLE [dbo].[DrugUnitsOfMeasurement]
ADD CONSTRAINT [FK_DrugUnitsOfMeasurement_Drug]
    FOREIGN KEY ([DrugUnitsOfMeasurement_UnitsOfMeasurement_Id])
    REFERENCES [dbo].[DrugSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UnitsOfMeasurement_Id] in table 'DrugUnitsOfMeasurement'
ALTER TABLE [dbo].[DrugUnitsOfMeasurement]
ADD CONSTRAINT [FK_DrugUnitsOfMeasurement_UnitsOfMeasurement]
    FOREIGN KEY ([UnitsOfMeasurement_Id])
    REFERENCES [dbo].[UnitsOfMeasurementSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugUnitsOfMeasurement_UnitsOfMeasurement'
CREATE INDEX [IX_FK_DrugUnitsOfMeasurement_UnitsOfMeasurement]
ON [dbo].[DrugUnitsOfMeasurement]
    ([UnitsOfMeasurement_Id]);
GO

-- Creating foreign key on [Id] in table 'SystemUserSet_DrugSuplier'
ALTER TABLE [dbo].[SystemUserSet_DrugSuplier]
ADD CONSTRAINT [FK_DrugSuplier_inherits_SystemUser]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[SystemUserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'SystemUserSet_DrugDistributor'
ALTER TABLE [dbo].[SystemUserSet_DrugDistributor]
ADD CONSTRAINT [FK_DrugDistributor_inherits_SystemUser]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[SystemUserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'DrugSuplySet_BoughtDrugSuply'
ALTER TABLE [dbo].[DrugSuplySet_BoughtDrugSuply]
ADD CONSTRAINT [FK_BoughtDrugSuply_inherits_DrugSuply]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DrugSuplySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'DrugSuplySet_DrugSuplyOffer'
ALTER TABLE [dbo].[DrugSuplySet_DrugSuplyOffer]
ADD CONSTRAINT [FK_DrugSuplyOffer_inherits_DrugSuply]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DrugSuplySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------