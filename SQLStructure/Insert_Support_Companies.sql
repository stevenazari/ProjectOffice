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

/****** Object:  StoredProcedure [dbo].[Insert_Support_Companies]    Script Date: 02/01/2018 08:54:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


		CREATE PROCEDURE [dbo].[Insert_Support_Companies](
			@ORDER_BY NVARCHAR(50) = NULL,
			@Get_All INT = NULL,
			@ID int = NULL,
			@Name NVARCHAR(50),
			@Address_1 NVARCHAR(200) = NULL,
			@Address_2 NVARCHAR(200) = NULL,
			@Post_Code NVARCHAR(10) = NULL,
			@Tel int = NULL,
			@Email NVARCHAR(200) = NULL,
			@Website NVARCHAR(200) = NULL,
			@Comment NVARCHAR(2000) = NULL,
			@Out_Of_Hours BIT = 0,
			@Created Datetime,
			@Status BIT = 1,
			@Deleted BIT = 0
		)
		AS
		BEGIN
			SET ANSI_NULLS ON
			SET QUOTED_IDENTIFIER ON
			-- =============================================
			-- Author:		Steven Azari
			-- Create date: 19/12/2017
			-- Description:	inserts data to Table_Support_Companies
			-- =============================================

			-- SET NOCOUNT ON added to prevent extra result sets from
			-- interfering with SELECT statements.
			SET NOCOUNT ON;

			-- Check if record exists
			DECLARE @ItemExists BIT
			SET @ItemExists = 0

			-- IF (Check_Item_Exists("Support_Companies", @Name))
				-- Insert statements for procedure here
				INSERT INTO
					Support_Companies (
						Name,
						Address_1,
						Address_2,
						Post_Code,
						Tel,
						Email,
						Website,
						Comment,
						Out_Of_Hours,
						Status
					)
				VALUES (
					@Name,
					@Address_1,
					@Address_2,
					@Post_Code,
					@Tel,
					@Email,
					@Website,
					@Comment,
					@Out_Of_Hours,
					@Status
				)
				-- Return "Success"
			-- ELSE
				-- Return "Item already exists"

			EXEC dbo.Select_Support_Companies 
				0,		-- Get_All
				NULL,	-- ORDER BY
				NULL,	-- ID
				@Name,	-- Name
				NULL,	-- Address_1 
				NULL,	-- Address_2 
				NULL,	-- Post_Code 
				NULL,	-- Tel 
				NULL,	-- Email 
				NULL,	-- Website 
				NULL,	-- Comment 
				NULL,	-- Out_Of_Hours 
				NULL,	-- Created
				NULL,	-- Status
				NULL	-- Deleted

		END
	
GO

