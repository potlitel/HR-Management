--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelByIdEmployeeAllRoles') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelByIdEmployeeAllRoles;
--GO
/*
-- ===================================================================================== --
--	Details			: Select the roles of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE  PROCEDURE [dbo].[Usp_HR_SelByIdEmployeeAllRoles]
  -- Add the parameters for the stored procedure here
  @employee_id INT,
  @prp_mensaje varchar(250) output
AS
BEGIN
	BEGIN TRY
		SELECT dbo.User_Roles.employee_id, dbo.User_Roles.role_id
		FROM dbo.User_Roles
		WHERE dbo.User_Roles.employee_id = @employee_id
	END TRY
	BEGIN CATCH
		set @prp_mensaje ='Could not get list of user roles '				 
 		RAISERROR (@prp_mensaje,1,16) 
	END CATCH
END
GO