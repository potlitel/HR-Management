CREATE TABLE [dbo].[Employees]
(
	[employee_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [employee_name] NVARCHAR(MAX) NOT NULL, 
    [lastName] NVARCHAR(MAX) NOT NULL, 
    [email] NCHAR(75) NOT NULL, 
    [personalAddress] NCHAR(250) NULL, 
    [phone] CHAR(12) NULL, 
    [workingStartingDate] DATETIME NOT NULL, 
    [startingSalary] MONEY NULL, 
    --CONSTRAINT [CK_Employees_Email] CHECK (email like '%_@__%.__%' AND email NOT LIKE '@%' AND email NOT LIKE '%@%@%'), 
    CONSTRAINT [CK_Employees_Email] CHECK (email LIKE '%_@__%.__%'), 
    CONSTRAINT [CK_Employees_UniqueEmail] UNIQUE (email)
)
