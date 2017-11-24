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

/****** Object:  StoredProcedure [dbo].[Create_Table_Servers_Types]    Script Date: 24/11/2017 11:05:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 16/11/17
-- Description:	Create server table
-- =============================================
CREATE PROCEDURE [dbo].[Create_Table_Servers_Types]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF OBJECT_ID('dbo.Servers_Types', 'U') IS NOT NULL 
		DROP TABLE dbo.Servers_Types; 

	CREATE TABLE Servers_Types (
		ID INT NOT NULL IDENTITY(1,1),
		Type NVARCHAR(50) NOT NULL,
		Deleted BIT DEFAULT 0

		PRIMARY KEY (ID),
	);

	SELECT 'Created Table "Server_Types"';
END
GO


