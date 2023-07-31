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
    @role_id INT,
	@rol_name varchar(max),
    @prp_id INT output,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY
            INSERT INTO Roles(role_id, rol_name)
                    VALUES (@role_id, @rol_name)
            --SET @prp_id = @@IDENTITY
            SET @prp_id = @role_id
            SET @prp_mensaje = 'The role has been successfully added!'
            COMMIT TRANSACTION
	    END TRY
	    BEGIN CATCH
            ROLLBACK TRANSACTION
            SET @prp_mensaje ='Could not insert role %s'		
		    --SET @nIdLogExcAG = -1
 		    RAISERROR (@prp_mensaje,1,16,@rol_name) 
        END CATCH
	--END
END