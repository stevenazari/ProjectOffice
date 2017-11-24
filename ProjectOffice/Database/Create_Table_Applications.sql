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

/****** Object:  StoredProcedure [dbo].[Create_Table_Applications]    Script Date: 24/11/2017 11:03:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 16/11/17
-- Description:	Create Applications table
-- =============================================
CREATE PROCEDURE [dbo].[Create_Table_Applications]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF OBJECT_ID('dbo.Applications', 'U') IS NOT NULL 
		DROP TABLE dbo.Applications; 

	CREATE TABLE Applications (
		ID INT NOT NULL IDENTITY(1,1),
		Name NVARCHAR(50) NOT NULL UNIQUE,
		Version NVARCHAR(10),
		Package_Type_ID INT,
		Created DATETIME DEFAULT GETDATE(),
		Support_Company_ID INT,
		Last_Used dateTime,
		Status BIT NOT NULL DEFAULT 0,
		Deleted BIT DEFAULT 0,

		PRIMARY KEY (ID),
		FOREIGN KEY (Support_Company_ID) REFERENCES dbo.Support_Companies(ID)
	);

		SELECT 'Created Table "Applications"';
END
GO


