--IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Usp_HR_SelRol') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
--    DROP PROCEDURE Usp_HR_SelRol;
--GO
/*
-- ===================================================================================== --
--	Details			: Select the data of a determined role.
--	Author.....		: Alain Jorge Acuña
--	Created at		: 29/07/2023
--	Modified by  	: ...
-- ===================================================================================== --
*/
CREATE  PROCEDURE [dbo].[Usp_HR_SelRol]
	@prp_mensaje varchar(250) output
AS
BEGIN
    BEGIN TRANSACTION
	BEGIN TRY
		SELECT Roles.role_id, Roles.rol_name
		FROM dbo.Roles
	END TRY
	BEGIN CATCH
		set @prp_mensaje ='Could not get list of roles'				 
 		RAISERROR (@prp_mensaje,1,16) 
	END CATCH
END
GO