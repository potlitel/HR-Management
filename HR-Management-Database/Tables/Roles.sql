CREATE TABLE [dbo].[Roles]
(
	[role_id] INT NOT NULL PRIMARY KEY, 
    [rol_name] NVARCHAR(50) NOT NULL UNIQUE, 
)
