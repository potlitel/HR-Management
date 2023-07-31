--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_AddEmployee') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_AddEmployee;
--GO
/*
-- ===================================================================================== --
--	Details			: Insert the data of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_AddEmployee]
    -- Add the parameters for the stored procedure here
    @employee_id int,
	@employee_name varchar(max),
	@lastName varchar(max),
	@email varchar(max),
	@personalAddress varchar(max),
	@phone CHAR(7),
    @workingStartingDate datetime,
    @startingSalary money,
    @prp_id INT output,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO Employees(employee_id,employee_name, lastName, email, personalAddress, phone, workingStartingDate, startingSalary)
            VALUES (@employee_id,@employee_name, @lastName, @email,@personalAddress, @phone, @workingStartingDate, @startingSalary)
            --SET @prp_id = @@IDENTITY
            SET @prp_id = @employee_id
            SET @prp_mensaje = 'The employee has been successfully added!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not insert employee %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16,@employee_name) 
    END CATCH
	--END
END