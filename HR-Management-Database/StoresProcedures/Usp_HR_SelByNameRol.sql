--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelRol') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelRol;
--GO
/*
-- ===================================================================================== --
--	Details			: Select the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 30/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE  PROCEDURE [dbo].[Usp_HR_SelByNameRol]
  @rol_name varchar(250),
  @prp_mensaje varchar(250) output
AS
BEGIN
	BEGIN TRY
		SELECT dbo.Roles.role_id, dbo.Roles.rol_name
		FROM dbo.Roles
		WHERE dbo.Roles.rol_name = @rol_name
	END TRY
	BEGIN CATCH
		set @prp_mensaje ='Could not get list of employees'				 
 		RAISERROR (@prp_mensaje,1,16) 
	END CATCH
END
GO
