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

/****** Object:  StoredProcedure [dbo].[Create_Table_Support_Companies]    Script Date: 24/11/2017 11:06:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 16/11/17
-- Description:	Create support companies table
-- =============================================
CREATE PROCEDURE [dbo].[Create_Table_Support_Companies]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF OBJECT_ID('dbo.Support_Companies', 'U') IS NOT NULL 
		DROP TABLE dbo.Support_Companies; 

	CREATE TABLE Support_Companies (
		ID INT NOT NULL IDENTITY(1,1),
		Name NVARCHAR(50) NOT NULL UNIQUE,
		Address_1 NVARCHAR(200),
		Address_2 NVARCHAR(200),
		Post_code NVARCHAR(10),
		Tel int,
		Email NVARCHAR(200),
		Created DATETIME DEFAULT GETDATE(),
		Out_Of_Hours BIT NOT NULL DEFAULT 0,
		Status BIT NOT NULL DEFAULT 1,
		Deleted BIT DEFAULT 0

		PRIMARY KEY (ID)
	);

	SELECT 'Created Table "Support_Companies"';

END
GO


