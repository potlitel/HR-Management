--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelHistoricalSalaries.sql') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelHistoricalSalaries.sql;
--GO
/*
-- ===================================================================================== --
--	Details			: Select the historical salaries of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE  PROCEDURE [dbo].[Usp_HR_SelHistoricalSalaries]
	@employee_id INT,
	@prp_mensaje varchar(250) output
AS
BEGIN
	BEGIN TRY
		SELECT	e.employee_id, e.employee_name + ' ' + e.lastName as fullName, e.startingSalary, 
				hist.salaries_increases, hist.increases_date, hist.increases_period, r.rol_name as with_rol
		FROM dbo.Employees e 
		INNER JOIN dbo.HistoricalSalaries hist
		ON e.employee_id = hist.employee_id
		INNER JOIN dbo.Roles r
		ON hist.with_role = r.role_id
		WHERE e.employee_id = @employee_id
	END TRY
	BEGIN CATCH
		set @prp_mensaje ='Could not get list of employees'				 
 		RAISERROR (@prp_mensaje,1,16) 
	END CATCH
END
GO