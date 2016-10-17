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