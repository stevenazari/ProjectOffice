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

/****** Object:  StoredProcedure [dbo].[Create_Table_Applications_Support_Companies_Servers]    Script Date: 24/11/2017 11:03:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 16/11/17
-- Description:	Create Applications_Support_Companies_Servers table, used to link support companies to the applications and servers.

--	Note that: 
--		Applications can have many support companies and many servers
--		Support Companies can have many applications and many servers
--		Servers can have many support companies and many applications
-- =============================================
CREATE PROCEDURE [dbo].[Create_Table_Applications_Support_Companies_Servers] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	CREATE TABLE Applications_Support_Companies_Servers (
		ID INT NOT NULL IDENTITY(1,1),
		Application_ID INT NOT NULL,
		Support_Company_ID INT NOT NULL,
		Server_ID INT NOT NULL,
		

		PRIMARY KEY (ID),
		FOREIGN KEY (Application_ID) REFERENCES dbo.Applications(ID),
		FOREIGN KEY (Support_Company_ID) REFERENCES dbo.Support_Companies(ID),
		FOREIGN KEY (Server_ID) REFERENCES dbo.Servers(ID),
	);

	SELECT 'Created Table "Applications_Support_Companies_Servers"';

END
GO


