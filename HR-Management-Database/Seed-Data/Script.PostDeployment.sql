/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--﻿PRINT 'We delete previously existing data'
--GO

DELETE FROM dbo.Roles
GO

--﻿PRINT 'Inserting Application.People'
--GO

INSERT INTO Roles(rol_name) VALUES ('Worker')
INSERT INTO Roles(rol_name) VALUES ('Specialist')
INSERT INTO Roles(rol_name) VALUES ('Manager')
