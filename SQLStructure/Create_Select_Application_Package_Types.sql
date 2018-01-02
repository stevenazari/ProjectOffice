/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Express Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [projectOffice]
GO

/****** Object:  StoredProcedure [dbo].[Create_Select_Application_Package_Types]    Script Date: 02/01/2018 08:41:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 27/12/2017
-- Description:	Creates procedure to select App/package types
-- =============================================
CREATE PROCEDURE [dbo].[Create_Select_Application_Package_Types]
AS
BEGIN
	EXEC ('	
		CREATE PROCEDURE Select_Application_Package_Types
		AS
		BEGIN
			-- SET NOCOUNT ON added to prevent extra result sets from
			-- interfering with SELECT statements.
			SET NOCOUNT ON;

			-- Insert statements for procedure here
			SELECT
				ID,
				Name + '' '' + Version AS Name
			FROM
				Applications_Types
		END
	')
END
GO

