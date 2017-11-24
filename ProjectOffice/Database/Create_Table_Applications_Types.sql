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

/****** Object:  StoredProcedure [dbo].[Create_Table_Applications_Types]    Script Date: 24/11/2017 11:04:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Create_Table_Applications_Types] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF OBJECT_ID('dbo.Applications_Types', 'U') IS NOT NULL 
		DROP TABLE dbo.Applications_Types; 

	CREATE TABLE Applications_Types (
		ID INT NOT NULL IDENTITY(1,1),
		Name NVARCHAR(50) NOT NULL,
		Version NVARCHAR(10),
		Created DATETIME DEFAULT GETDATE(),
		Deleted BIT DEFAULT 0,

		PRIMARY KEY (ID),
	);

		SELECT 'Created Table "Applications"';
END
GO


