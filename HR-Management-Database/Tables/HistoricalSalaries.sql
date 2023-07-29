CREATE TABLE [dbo].[HistoricalSalaries]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [employee_id] INT NOT NULL FOREIGN KEY REFERENCES Employees(employee_id) ON DELETE CASCADE ON UPDATE CASCADE, 
    [salaries_increases] INT NOT NULL, 
    [increases_period] NVARCHAR(150) NOT NULL, 
    [increases_date] DATETIME NOT NULL
)
