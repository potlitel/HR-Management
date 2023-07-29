--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_DelEmployee') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_DelEmployee;
--GO
/*
-- ===================================================================================== --
--	Details			: Delete the data of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_DelEmployee]
    -- Add the parameters for the stored procedure here
    @employee_id INT,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRY
        DELETE FROM dbo.Employees WHERE dbo.Employees.employee_id = @employee_id
            SET @prp_mensaje = 'The employee has been successfully deleted!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not delete employee %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@employee_id) 
    END CATCH
	--END
END