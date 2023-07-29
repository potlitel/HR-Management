--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_AddRol') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_AddRol;
--GO
/*
-- ===================================================================================== --
--	Details			: Insert the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_AddRol]
    -- Add the parameters for the stored procedure here
	@rol_name varchar(max),
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRY
        INSERT INTO Roles(rol_name)
            VALUES (@rol_name)
            SET @prp_mensaje = 'The role has been successfully added!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not insert role %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@rol_name) 
    END CATCH
	--END
END