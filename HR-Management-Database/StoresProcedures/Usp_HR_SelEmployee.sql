--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelEmployee') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelEmployee;
--GO
/*
-- ===================================================================================== --
--	Details			: Select the data of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE  PROCEDURE [dbo].[Usp_HR_SelEmployee]
	@prp_mensaje varchar(250) output
AS
BEGIN
	BEGIN TRY
		SELECT e.employee_id, e.employee_name, e.lastName, 
		RTRIM(e.email) as email, RTRIM(e.personalAddress) as personalAddress, e.phone, 
		e.workingStartingDate, e.startingSalary, e.currentSalary,
		LTRIM(RTRIM(STUFF((SELECT ', ' + r.rol_name 
          FROM dbo.Roles r
		  INNER JOIN dbo.User_Roles ur
          on r.role_id = ur.role_id
		  WHERE ur.employee_id = e.employee_id
          ORDER BY r.rol_name 
          FOR XML PATH('')), 1, 1, ''))) [Roles]
		FROM dbo.Employees e
	END TRY
	BEGIN CATCH
		set @prp_mensaje ='Could not get list of employees'				 
 		RAISERROR (@prp_mensaje,1,16) 
	END CATCH
END
GO