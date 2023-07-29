CREATE TABLE [dbo].[Employees]
(
	[employee_id] INT NOT NULL PRIMARY KEY, 
    [employee_name] NVARCHAR(MAX) NOT NULL, 
    [lastName] NVARCHAR(MAX) NOT NULL, 
    [email] NCHAR(10) NOT NULL, 
    [personalAddress] NCHAR(10) NULL, 
    [phone] CHAR(10) NULL, 
    [workingStartingDate] DATETIME NOT NULL, 
    [startingSalary] MONEY NULL, 
    --CONSTRAINT [CK_Employees_Email] CHECK (email like '%_@__%.__%' AND email NOT LIKE '@%' AND email NOT LIKE '%@%@%'), 
    CONSTRAINT [CK_Employees_Email] CHECK (email LIKE '%_@__%.__%'), 
    CONSTRAINT [CK_Employees_UniqueEmail] UNIQUE (email)
)
