/*9
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

DELETE FROM dbo.Employees
GO

DELETE FROM dbo.User_Roles
GO

DELETE FROM dbo.HistoricalSalaries
GO

--﻿PRINT 'Inserting Application.People'
--GO

INSERT INTO dbo.Roles(rol_name) 
    VALUES 
     ('Worker')
    ,('Specialist')
    ,('Manager')

DECLARE @workingStartingDate datetime2(7) = '20130101'
INSERT INTO dbo.Employees(employee_name, lastName, email, personalAddress, phone, workingStartingDate, startingSalary) 
    VALUES 
     ('Jeanette', 'M. Greenlaw', 'JeanetteMGreenlaw@armyspy.com', '832 Joseph Street Sheboygan Falls, WI 53085', '262-795-1956', @workingStartingDate, '875.25')
    ,('Preston', 'M. Hammonds', 'PrestonMHammonds@jourrapide.com', '1552 Westfall Avenue Santa Fe, NM 87501', '505-986-8109', @workingStartingDate, '589.25')
    ,('Kathleen', 'C. Christensen', 'KathleenCChristensen@rhyta.com', '3225 Saints Alley Tampa, FL 33602', '813-778-7519', @workingStartingDate, '275.25')
    ,('Jose', 'T. Wagner', 'JoseTWagner@teleworm.us', '2293 Aviation Way Mira Loma, CA 91752', '213-923-5048', @workingStartingDate, '875.25')
    ,('Frances', 'J. Jones', 'FrancesJJones@teleworm.us', '2835 Rebecca Street Lombard, IL 60148', '847-791-5934', @workingStartingDate, '289.25')
    ,('Anne', 'L. Dougherty', 'AnneLDougherty@dayrep.com', '1927 Cerullo Road Louisville, KY 40202', '502-391-8057', @workingStartingDate, '2875.25')
    ,('Travis', 'M. Harward', 'TravisMHarward@jourrapide.com', '249 Shearwood Forest Drive Bedford, NH 01730', '603-318-0878', @workingStartingDate, '693.25')
    ,('Earl', 'P. Maxwell', 'EarlPMaxwell@dayrep.com', '610 Camden Place Summerville, SC 29483', '843-875-1554', @workingStartingDate, '975.25')
    ,('Lula', 'B. Findlay', 'LulaBFindlay@armyspy.com', '12 Broadcast Drive Herndon, VA 22090', '703-975-8280', @workingStartingDate, '1875.25')
    ,('Gilbert', 'L. Crouch', 'GilbertLCrouch@dayrep.com', '594 Sycamore Road The Dalles, OR 97958', '541-399-7296', @workingStartingDate, '875.25')

