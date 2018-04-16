
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/16/2018 22:56:53
-- Generated from EDMX file: J:\X\X\X\X\Models\XModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DrugSuplySet'
CREATE TABLE [dbo].[DrugSuplySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugSuplierId] int  NOT NULL,
    [DrugDistributorsId] int  NOT NULL,
    [Price] bigint  NOT NULL,
    [DeliveryTime] datetime  NOT NULL,
    [DrugId] int  NOT NULL
);
GO

-- Creating table 'SystemUserSet'
CREATE TABLE [dbo].[SystemUserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL
);
GO

-- Creating table 'RegionSet'
CREATE TABLE [dbo].[RegionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DrugSet'
CREATE TABLE [dbo].[DrugSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UnitsIOfMeasurementSet'
CREATE TABLE [dbo].[UnitsIOfMeasurementSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ShortName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RegionDrugPriceSet'
CREATE TABLE [dbo].[RegionDrugPriceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegionId] int  NOT NULL,
    [DrugId] int  NOT NULL,
    [CostForUnit] bigint  NOT NULL,
    [UnitsOfMeasurementId] int  NOT NULL
);
GO

-- Creating table 'RegionDrugNeedSet'
CREATE TABLE [dbo].[RegionDrugNeedSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugId] int  NOT NULL,
    [RegionId] int  NOT NULL,
    [Count] int  NOT NULL,
    [UnitsOfMeasurementId] int  NOT NULL
);
GO

-- Creating table 'SystemUserSet_DrugSuplier'
CREATE TABLE [dbo].[SystemUserSet_DrugSuplier] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'SystemUserSet_DrugDistributor'
CREATE TABLE [dbo].[SystemUserSet_DrugDistributor] (
    [RegionId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'RegionDrugDistributor'
CREATE TABLE [dbo].[RegionDrugDistributor] (
    [Region_Id] int  NOT NULL,
    [DrugDistributor_Id] int  NOT NULL
);
GO

-- Creating table 'DrugUnitsIOfMeasurement'
CREATE TABLE [dbo].[DrugUnitsIOfMeasurement] (
    [Drugs_Id] int  NOT NULL,
    [UnitsIOfMeasurement_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'RegionSet'
ALTER TABLE [dbo].[RegionSet]
ADD CONSTRAINT [PK_RegionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugSet'
ALTER TABLE [dbo].[DrugSet]
ADD CONSTRAINT [PK_DrugSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UnitsIOfMeasurementSet'
ALTER TABLE [dbo].[UnitsIOfMeasurementSet]
ADD CONSTRAINT [PK_UnitsIOfMeasurementSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegionDrugPriceSet'
ALTER TABLE [dbo].[RegionDrugPriceSet]
ADD CONSTRAINT [PK_RegionDrugPriceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegionDrugNeedSet'
ALTER TABLE [dbo].[RegionDrugNeedSet]
ADD CONSTRAINT [PK_RegionDrugNeedSet]
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

-- Creating primary key on [Region_Id], [DrugDistributor_Id] in table 'RegionDrugDistributor'
ALTER TABLE [dbo].[RegionDrugDistributor]
ADD CONSTRAINT [PK_RegionDrugDistributor]
    PRIMARY KEY CLUSTERED ([Region_Id], [DrugDistributor_Id] ASC);
GO

-- Creating primary key on [Drugs_Id], [UnitsIOfMeasurement_Id] in table 'DrugUnitsIOfMeasurement'
ALTER TABLE [dbo].[DrugUnitsIOfMeasurement]
ADD CONSTRAINT [PK_DrugUnitsIOfMeasurement]
    PRIMARY KEY CLUSTERED ([Drugs_Id], [UnitsIOfMeasurement_Id] ASC);
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

-- Creating foreign key on [DrugDistributorsId] in table 'DrugSuplySet'
ALTER TABLE [dbo].[DrugSuplySet]
ADD CONSTRAINT [FK_DrugDistributorsDrugSuplies]
    FOREIGN KEY ([DrugDistributorsId])
    REFERENCES [dbo].[SystemUserSet_DrugDistributor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugDistributorsDrugSuplies'
CREATE INDEX [IX_FK_DrugDistributorsDrugSuplies]
ON [dbo].[DrugSuplySet]
    ([DrugDistributorsId]);
GO

-- Creating foreign key on [Region_Id] in table 'RegionDrugDistributor'
ALTER TABLE [dbo].[RegionDrugDistributor]
ADD CONSTRAINT [FK_RegionDrugDistributor_Region]
    FOREIGN KEY ([Region_Id])
    REFERENCES [dbo].[RegionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DrugDistributor_Id] in table 'RegionDrugDistributor'
ALTER TABLE [dbo].[RegionDrugDistributor]
ADD CONSTRAINT [FK_RegionDrugDistributor_DrugDistributor]
    FOREIGN KEY ([DrugDistributor_Id])
    REFERENCES [dbo].[SystemUserSet_DrugDistributor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugDistributor_DrugDistributor'
CREATE INDEX [IX_FK_RegionDrugDistributor_DrugDistributor]
ON [dbo].[RegionDrugDistributor]
    ([DrugDistributor_Id]);
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

-- Creating foreign key on [Drugs_Id] in table 'DrugUnitsIOfMeasurement'
ALTER TABLE [dbo].[DrugUnitsIOfMeasurement]
ADD CONSTRAINT [FK_DrugUnitsIOfMeasurement_Drug]
    FOREIGN KEY ([Drugs_Id])
    REFERENCES [dbo].[DrugSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UnitsIOfMeasurement_Id] in table 'DrugUnitsIOfMeasurement'
ALTER TABLE [dbo].[DrugUnitsIOfMeasurement]
ADD CONSTRAINT [FK_DrugUnitsIOfMeasurement_UnitsIOfMeasurement]
    FOREIGN KEY ([UnitsIOfMeasurement_Id])
    REFERENCES [dbo].[UnitsIOfMeasurementSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugUnitsIOfMeasurement_UnitsIOfMeasurement'
CREATE INDEX [IX_FK_DrugUnitsIOfMeasurement_UnitsIOfMeasurement]
ON [dbo].[DrugUnitsIOfMeasurement]
    ([UnitsIOfMeasurement_Id]);
GO

-- Creating foreign key on [DrugId] in table 'RegionDrugPriceSet'
ALTER TABLE [dbo].[RegionDrugPriceSet]
ADD CONSTRAINT [FK_RegionDrugPriceDrug]
    FOREIGN KEY ([DrugId])
    REFERENCES [dbo].[DrugSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugPriceDrug'
CREATE INDEX [IX_FK_RegionDrugPriceDrug]
ON [dbo].[RegionDrugPriceSet]
    ([DrugId]);
GO

-- Creating foreign key on [UnitsOfMeasurementId] in table 'RegionDrugPriceSet'
ALTER TABLE [dbo].[RegionDrugPriceSet]
ADD CONSTRAINT [FK_RegionDrugPriceUnitsIOfMeasurement]
    FOREIGN KEY ([UnitsOfMeasurementId])
    REFERENCES [dbo].[UnitsIOfMeasurementSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugPriceUnitsIOfMeasurement'
CREATE INDEX [IX_FK_RegionDrugPriceUnitsIOfMeasurement]
ON [dbo].[RegionDrugPriceSet]
    ([UnitsOfMeasurementId]);
GO

-- Creating foreign key on [RegionId] in table 'RegionDrugPriceSet'
ALTER TABLE [dbo].[RegionDrugPriceSet]
ADD CONSTRAINT [FK_RegionDrugPriceRegion]
    FOREIGN KEY ([RegionId])
    REFERENCES [dbo].[RegionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugPriceRegion'
CREATE INDEX [IX_FK_RegionDrugPriceRegion]
ON [dbo].[RegionDrugPriceSet]
    ([RegionId]);
GO

-- Creating foreign key on [RegionId] in table 'RegionDrugNeedSet'
ALTER TABLE [dbo].[RegionDrugNeedSet]
ADD CONSTRAINT [FK_RegionDrugNeedRegion]
    FOREIGN KEY ([RegionId])
    REFERENCES [dbo].[RegionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugNeedRegion'
CREATE INDEX [IX_FK_RegionDrugNeedRegion]
ON [dbo].[RegionDrugNeedSet]
    ([RegionId]);
GO

-- Creating foreign key on [DrugId] in table 'RegionDrugNeedSet'
ALTER TABLE [dbo].[RegionDrugNeedSet]
ADD CONSTRAINT [FK_RegionDrugNeedDrug]
    FOREIGN KEY ([DrugId])
    REFERENCES [dbo].[DrugSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugNeedDrug'
CREATE INDEX [IX_FK_RegionDrugNeedDrug]
ON [dbo].[RegionDrugNeedSet]
    ([DrugId]);
GO

-- Creating foreign key on [UnitsOfMeasurementId] in table 'RegionDrugNeedSet'
ALTER TABLE [dbo].[RegionDrugNeedSet]
ADD CONSTRAINT [FK_RegionDrugNeedUnitsIOfMeasurement]
    FOREIGN KEY ([UnitsOfMeasurementId])
    REFERENCES [dbo].[UnitsIOfMeasurementSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionDrugNeedUnitsIOfMeasurement'
CREATE INDEX [IX_FK_RegionDrugNeedUnitsIOfMeasurement]
ON [dbo].[RegionDrugNeedSet]
    ([UnitsOfMeasurementId]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------