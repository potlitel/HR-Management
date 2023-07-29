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
    @prp_mensaje varchar(250) output
AS
BEGIN
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