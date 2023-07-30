--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_AddHistoricalSalaries') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_AddHistoricalSalaries;
--GO
/*
-- ===================================================================================== --
--	Details			: Insert historical salaries of a determined employee.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE    PROCEDURE [dbo].[Usp_HR_AddHistoricalSalaries]
    -- Add the parameters for the stored procedure here
	@user_id INT,
    @salaries_increases varchar (250), 
    @increases_period varchar (250),
    @increases_date datetime,
    @prp_id INT output,
    @prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO HistoricalSalaries(employee_id, salaries_increases, increases_period, increases_date)
            VALUES (@user_id, @salaries_increases, @increases_period, @increases_date)
            SET @prp_id = @@IDENTITY
            SET @prp_mensaje = 'The historical salaries has been successfully added!'
    COMMIT
	END TRY
	BEGIN CATCH
    ROLLBACK
        SET @prp_mensaje ='Could not insert historical salaries %s'		
		--SET @nIdLogExcAG = -1
 		RAISERROR (@prp_mensaje,1,16) 
    END CATCH
	--END
END