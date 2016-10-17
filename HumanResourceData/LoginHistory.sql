CREATE TABLE [dbo].[LoginHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[Username] NVARCHAR(50) NOT NULL,
    [LoginAttemptTime] DATETIME NOT NULL, 
    [Successful] BIT NOT NULL
)
