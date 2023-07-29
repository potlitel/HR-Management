CREATE TABLE [dbo].[Roles]
(
	[role_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [rol_name] NVARCHAR(50) NOT NULL UNIQUE, 
)
