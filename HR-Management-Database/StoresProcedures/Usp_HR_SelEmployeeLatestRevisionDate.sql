--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelEmployeeLatestRevisionDate') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelEmployeeLatestRevisionDate;
--GO
/*
-- ===================================================================================== --
--	Details			: Delete the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_SelEmployeeLatestRevisionDate]
    -- Add the parameters for the stored procedure here
    @employee_id INT,
    @salary_review_proceeds INT OUTPUT,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        SET @salary_review_proceeds = (SELECT DATEDIFF(MONTH,e.workingStartingDate,GETDATE()) AS LatestRevisionDate FROM dbo.Employees e WHERE e.employee_id = @employee_id)
        SET @salary_review_proceeds = (SELECT ABS(@salary_review_proceeds))
        SET @prp_mensaje = 'The latest revision date has been successfully calculated for employee %s!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not get latest revision date for employee %s'		
 		RAISERROR (@prp_mensaje,1,16,@employee_id) 
    END CATCH
	--END
END