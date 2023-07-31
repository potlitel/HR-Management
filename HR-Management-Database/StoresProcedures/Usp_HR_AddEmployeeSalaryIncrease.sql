--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_AddEmployeeSalaryIncrease') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_AddEmployeeSalaryIncrease;
--GO
/*
-- ===================================================================================== --
--	Details			: Delete the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_AddEmployeeSalaryIncrease]
    -- Add the parameters for the stored procedure here
    @employee_id INT,
    @pending_months INT,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DECLARE @salaries_increase MONEY
        DECLARE @currentSalary MONEY
        DECLARE @increases_period DATE
        DECLARE @increase_date DATE
        DECLARE @with_Role INT
        --We select the role of the employee, in this case we use MAX, because an employee can have several roles and we want to keep the largest of these
        SET @with_Role = (SELECT MAX(ur.role_id) FROM dbo.User_Roles ur WHERE ur.employee_id = @employee_id)
        -- Get employee current salary
        SET @currentSalary = (SELECT e.startingSalary FROM dbo.Employees e WHERE e.employee_id = @employee_id)
        --We increase the salary by a percentage that depends on the role of the employee
        IF(@with_Role = 1)
        BEGIN
            IF (@pending_months / 3) != 0
                set @currentSalary = @currentSalary + (@currentSalary * 5.0 / 100.0)
            ELSE
                set @currentSalary = (@currentSalary + (@currentSalary * 5.0 / 100.0)) * (@pending_months / 3)
        END
        ELSE
        IF(@with_Role = 2)
        BEGIN
            IF (@pending_months / 3) != 0
                set @currentSalary = @currentSalary + (@currentSalary * 8.0 / 100.0)
            ELSE
                set @currentSalary = (@currentSalary + (@currentSalary * 8.0 / 100.0)) * (@pending_months / 3)
        END
        ELSE
        BEGIN
            IF (@pending_months / 3) != 0
                set @currentSalary = @currentSalary + (@currentSalary * 12.0 / 100.0)
            ELSE
                set @currentSalary = (@currentSalary + (@currentSalary * 12.0 / 100.0)) * (@pending_months / 3)
        END
        SET @increases_period = GETDATE()
        SET @increase_date = GETDATE()

        INSERT INTO dbo.HistoricalSalaries (employee_id, salaries_increases, increases_period, increases_date, with_role)
        VALUES (@employee_id, @currentSalary, @increases_period, @increase_date, @with_role)
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