--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelEmployee') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelEmployee;
--GO
/*
-- ===================================================================================== --
--	Details			: Select the historical salaries of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE  PROCEDURE [dbo].[Usp_HR_SelHistoricalSalaries.sql]
	@prp_mensaje varchar(250) output
AS
BEGIN
	BEGIN TRY
		SELECT HistoricalSalaries.employee_id, HistoricalSalaries.salaries_increases, HistoricalSalaries.increases_period, 
		HistoricalSalaries.increases_date
		FROM dbo.HistoricalSalaries
	END TRY
	BEGIN CATCH
		set @prp_mensaje ='Could not get list of employees'				 
 		RAISERROR (@prp_mensaje,1,16) 
	END CATCH
END
GO