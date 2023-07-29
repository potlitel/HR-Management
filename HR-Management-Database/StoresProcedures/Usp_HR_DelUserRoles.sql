--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_DelUserRoles') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_DelUserRoles;
--GO
/*
-- ===================================================================================== --
--	Details			: Delete the roles of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_DelUserRoles]
    -- Add the parameters for the stored procedure here
    @employee_id INT,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRY
        DELETE FROM dbo.User_Roles WHERE dbo.User_Roles.employee_id = @employee_id
            SET @prp_mensaje = 'User roles were successfully removed!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not delete user roles %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@employee_id) 
    END CATCH
	--END
END