--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_AddUserRoles') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_AddUserRoles;
--GO
/*
-- ===================================================================================== --
--	Details			: Assign roles to a certain employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_AddUserRoles]
    -- Add the parameters for the stored procedure here
	@employee_id INT,
    @role_id INT,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRY
        INSERT INTO User_Roles(employee_id, role_id)
            VALUES (@employee_id, @role_id)
            SET @prp_mensaje = 'Roles successfully assigned to the employee!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not assign roles to employee %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16) 
    END CATCH
	--END
END