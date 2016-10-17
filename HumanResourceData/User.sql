CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Username] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(200) NOT NULL, 
    [Pass] NVARCHAR(MAX) NOT NULL, 
    [TwoStepActive] BIT NOT NULL DEFAULT 0, 
    [NumLoginAttempts] INT NOT NULL DEFAULT 0, 
    [Salt] NVARCHAR(MAX) NULL,
	CONSTRAINT AK_Username UNIQUE(Username),
	CONSTRAINT AK_Email UNIQUE(Email)
)
