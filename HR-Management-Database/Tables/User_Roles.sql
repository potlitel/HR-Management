﻿CREATE TABLE [dbo].[User_Roles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [employee_id] INT NOT NULL FOREIGN KEY REFERENCES Employees(employee_id) ON DELETE CASCADE ON UPDATE CASCADE, 
    [role_id] INT NOT NULL FOREIGN KEY REFERENCES Roles(role_id) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [CK_User_Roles_UNIQUE] UNIQUE (employee_id, role_id) 
)
