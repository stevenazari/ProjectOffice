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

/****** Object:  StoredProcedure [dbo].[Select_Application_Package_Types]    Script Date: 02/01/2018 08:53:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 27/12/2017
-- Description:	Select list of application / package types
-- =============================================
CREATE PROCEDURE [dbo].[Select_Application_Package_Types]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		ID,
		Name + ' ' + ISNULL(Version, '') AS Name
	FROM
		Applications_Types
END
GO

