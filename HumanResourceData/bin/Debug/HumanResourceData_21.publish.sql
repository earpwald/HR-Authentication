﻿/*
Deployment script for HumanResourceData

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "HumanResourceData"
:setvar DefaultFilePrefix "HumanResourceData"
:setvar DefaultDataPath "C:\Users\earpwald\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\Projects\"
:setvar DefaultLogPath "C:\Users\earpwald\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\Projects\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[User]...';


GO
ALTER TABLE [dbo].[User] ALTER COLUMN [FirstName] NVARCHAR (50) NULL;

ALTER TABLE [dbo].[User] ALTER COLUMN [LastName] NVARCHAR (50) NULL;


GO
ALTER TABLE [dbo].[User]
    ADD [Salt] NVARCHAR (MAX) NULL;


GO
PRINT N'Creating AK_Email...';


GO
ALTER TABLE [dbo].[User]
    ADD CONSTRAINT [AK_Email] UNIQUE NONCLUSTERED ([Email] ASC);


GO
PRINT N'Creating AK_Username...';


GO
ALTER TABLE [dbo].[User]
    ADD CONSTRAINT [AK_Username] UNIQUE NONCLUSTERED ([Username] ASC);


GO
PRINT N'Creating Default Constraint on [dbo].[User]....';


GO
ALTER TABLE [dbo].[User]
    ADD DEFAULT 0 FOR [TwoStepActive];


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]		
			   (localdb)\Projects			
--------------------------------------------------------------------------------------
*/

MERGE INTO [User] AS Target 
USING (VALUES 
        ('janderson','James','Anderson', 'janderson20@hotmail.co.uk', '$2a$10$qjW9TQXKpyZasQYVmwljR.EsRYX2TUrSql1MaGMofOCZY3QNIhL7S', 0, 0), 
        ('jsmith','James','Smith', 'j.smith@hotmail.co.uk', '$2a$10$qjW9TQXKpyZasQYVmwljR.EsRYX2TUrSql1MaGMofOCZY3QNIhL7S', 0, 0)
) 
AS Source (Username, FirstName, LastName, Email, Pass, TwoStepActive, NumLoginAttempts) 
ON Target.Username = Source.Username 
WHEN NOT MATCHED BY TARGET THEN
INSERT (Username, FirstName, LastName, Email, Pass, TwoStepActive, NumLoginAttempts) 
VALUES (Username, FirstName, LastName, Email, Pass, TwoStepActive, NumLoginAttempts);
GO

GO
PRINT N'Update complete.'
GO