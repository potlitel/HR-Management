--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_UpdEmployee') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_UpdEmployee;
--GO
/*
-- ===================================================================================== --
--	Details			: Update the data of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_UpdEmployee]
    -- Add the parameters for the stored procedure here
    @employee_id INT,
	@employee_name varchar(max),
	@lastName varchar(max),
	@email varchar(max),
	@personalAddress varchar(max),
	@phone CHAR(7),
    @workingStartingDate datetime,
    @startingSalary money,
    @roles VARCHAR(MAX), ---roles a asignar a este usuario
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        UPDATE Employees 
		SET employee_name = @employee_name,
            lastName=@lastName,
            email=@email,
            personalAddress=@personalAddress,
            phone=@phone,
            workingStartingDate=@workingStartingDate,
            startingSalary=@startingSalary
		WHERE employee_id=@employee_id

        DECLARE @rol INT
        DECLARE @prp_id INT
        DECLARE perfiles_cursors CURSOR FOR 
		SELECT splitdata FROM dbo.fnSplitString(@roles,',')
        DELETE FROM dbo.User_Roles where employee_id = @employee_id
        OPEN perfiles_cursors
        FETCH NEXT FROM perfiles_cursors INTO @rol
        WHILE @@FETCH_STATUS = 0
	     BEGIN
           SELECT @rol
           EXEC [dbo].[Usp_HR_AddUserRoles] @employee_id, @rol, @prp_id, @prp_mensaje
           FETCH NEXT FROM perfiles_cursors INTO @rol
         END
        CLOSE perfiles_cursors;
        DEALLOCATE perfiles_cursors;

        SET @prp_mensaje = 'The employee has been successfully update!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not update employee %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@employee_name) 
    END CATCH
	--END
END