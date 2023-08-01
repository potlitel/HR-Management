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
        DECLARE @increases_period VARCHAR(MAX)
        DECLARE @increase_date DATE
        DECLARE @with_Role INT
        DECLARE @employee VARCHAR(MAX)
        SET @employee = (SELECT e.employee_name + ' ' + e.lastName FROM dbo.Employees e WHERE e.employee_id = @employee_id)
        --We select the role of the employee, in this case we use MAX, because an employee can have several roles and we want to keep the largest of these
        SET @with_Role = (SELECT MAX(ur.role_id) FROM dbo.User_Roles ur WHERE ur.employee_id = @employee_id)
        -- Get employee current salary
        SET @currentSalary = (SELECT e.startingSalary FROM dbo.Employees e WHERE e.employee_id = @employee_id)
        --We increase the salary by a percentage that depends on the role of the employee
        IF(@with_Role = 1)
        BEGIN
            IF (@pending_months / 3) = 0
                SET @currentSalary = @currentSalary + (@currentSalary * 5/ 100.0)
            ELSE
                SET @pending_months = (SELECT CAST(10 AS INT)/3)
                --SET @currentSalary = (@currentSalary + (@currentSalary * 5.0 / 100.0)) * (@pending_months / 3)
                DECLARE @cnt INT = 0;
                WHILE @cnt < @pending_months
                BEGIN
                   SET @currentSalary = (@currentSalary + (@currentSalary * 5 / 100.0)) * 1
                   UPDATE dbo.Employees SET currentSalary = @currentSalary WHERE employee_id = @employee_id
                   SET @currentSalary = (SELECT e.currentSalary FROM dbo.Employees e WHERE e.employee_id = @employee_id)
                   SET @cnt = @cnt + 1;
                END;
        END
        ELSE
        IF(@with_Role = 2)
        BEGIN
            IF (@pending_months / 3) = 0
                SET @currentSalary = @currentSalary + (@currentSalary * 8 / 100.0)
            ELSE
                SET @pending_months = (SELECT CAST(10 AS INT)/3)
                --SET @currentSalary = (@currentSalary + (@currentSalary * 8.0 / 100.0)) * (@pending_months / 3)
                DECLARE @cnt1 INT = 0;
                WHILE @cnt1 < @pending_months
                BEGIN
                   SET @currentSalary = (@currentSalary + (@currentSalary * 8.0 / 100.0)) * 1
                   UPDATE dbo.Employees SET currentSalary = @currentSalary WHERE employee_id = @employee_id
                   SET @currentSalary = (SELECT e.currentSalary FROM dbo.Employees e WHERE e.employee_id = @employee_id)
                   SET @cnt1 = @cnt1 + 1;
                END;
        END
        ELSE
        BEGIN
            IF (@pending_months / 3) = 0
                SET @currentSalary = @currentSalary + (@currentSalary * 12.0 / 100.0)
            ELSE
                SET @pending_months = (SELECT CAST(10 AS INT)/3)
                --SET @currentSalary = (@currentSalary + (@currentSalary * 12.0 / 100.0)) * (@pending_months / 3)
                DECLARE @cnt2 INT = 0;
                WHILE @cnt2 < @pending_months
                BEGIN
                   --Obtenemos el salario actual
                   SET @currentSalary = (@currentSalary + (@currentSalary * 12.0 / 100.0)) * 1
                   UPDATE dbo.Employees SET currentSalary = @currentSalary WHERE employee_id = @employee_id
                   SET @currentSalary = (SELECT e.currentSalary FROM dbo.Employees e WHERE e.employee_id = @employee_id)
                   SET @cnt2 = @cnt2 + 1;
                END;
        END
        SET @increases_period = (SELECT CAST(year(getdate()) AS char(4)) + '-Q' + CAST(CEILING(CAST(month(getdate()) AS decimal(4,2)) / 3) AS char(1)))
        SET @increase_date = GETDATE()

        INSERT INTO dbo.HistoricalSalaries (employee_id, salaries_increases, increases_period, increases_date, with_role)
        VALUES (@employee_id, @currentSalary, @increases_period, @increase_date, @with_role)
        SET @prp_mensaje = (SELECT CONCAT ( 'The salary increase has been calculated correctly for the employee ', @employee , ' !' ))
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not get latest revision date for employee %s'		
 		RAISERROR (@prp_mensaje,1,16,@employee_id) 
    END CATCH
	--END
END