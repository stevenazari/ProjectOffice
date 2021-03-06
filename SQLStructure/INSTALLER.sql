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

/****** Object:  StoredProcedure [dbo].[_DATABASE_CREATOR]    Script Date: 02/01/2018 08:38:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 16/11/17
-- Description:	Create the sites database.
-- RUN THIS ONCE WHEN CREATING THE SITE, AND NEVER AGAIN OR YOU WILL RISK ERASING ALL DATA!
-- =============================================
CREATE PROCEDURE [dbo].[_DATABASE_CREATOR] 
AS
BEGIN
	-- Create Tables
	EXEC dbo.Create_Table_Support_Companies;
	EXEC dbo.Create_Table_Servers_Types;
	EXEC dbo.Create_Table_Servers;
	EXEC dbo.Create_Table_Applications_Types;
	EXEC dbo.Create_Table_Applications;
	EXEC dbo.Create_Table_Applications_Support_Companies_Servers;
	EXEC dbo.Create_Insert_Support_Companies;

	-- Create SELECT Stored Procedures (These go first because Inserts return SELECTS
	EXEC dbo.Create_Select_Support_Companies;

	-- Create INSERT Stored Procedures
	EXEC dbo.Create_Insert_Support_Companies;
END
GO

