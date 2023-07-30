--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_UpdRol') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_UpdRol;
--GO
/*
-- ===================================================================================== --
--	Details			: Update the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_UpdRol]
    -- Add the parameters for the stored procedure here
    @role_id INT,
	@rol_name varchar(max),
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        UPDATE Roles 
		SET rol_name = @rol_name
		WHERE role_id=@role_id
            SET @prp_mensaje = 'The role has been successfully update!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not update role %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@rol_name) 
    END CATCH
	--END
END