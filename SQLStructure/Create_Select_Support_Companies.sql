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

/****** Object:  StoredProcedure [dbo].[Create_Select_Support_Companies]    Script Date: 02/01/2018 08:42:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Azari
-- Create date: 19/12/17
-- Description:	Creates select query for support companies
-- =============================================
CREATE PROCEDURE [dbo].[Create_Select_Support_Companies]
AS
BEGIN
	EXEC('
		CREATE PROCEDURE Select_Support_Companies(
			@GET_All INT = 0,
			@ORDER_BY NVARCHAR(50) = NULL,
			@ID INT = 0,
			@Name NVARCHAR(50) = NULL,
			@Address_1 NVARCHAR(200) = NULL,
			@Address_2 NVARCHAR(200) = NULL,
			@Post_Code NVARCHAR(10) = NULL,
			@Tel int = NULL,
			@Email NVARCHAR(200) = NULL,
			@Website NVARCHAR(200) = NULL,
			@Comment NVARCHAR(2000) = NULL,
			@Out_Of_Hours BIT = NULL,
			@Created DateTime = NULL,
			@Status BIT = NULL,
			@Deleted BIT = NULL
		)
		AS
		BEGIN
			SET ANSI_NULLS ON
			SET QUOTED_IDENTIFIER ON
			-- =============================================
			-- Author:		Steven Azari
			-- Create date: 19/12/2017
			-- Description:	Selects support companies, can be used for search
			-- =============================================

			-- SET NOCOUNT ON added to prevent extra result sets from
			-- interfering with SELECT statements.
			SET NOCOUNT ON;

			SELECT
				ID,
				ISNULL(Name,'') AS Name,
				ISNULL(Address_1,'') AS Address_1,
				ISNULL(Address_2,'') AS Address_2,
				ISNULL(Post_Code,'') AS Post_Code,
				ISNULL(Tel,'') AS Tel,
				ISNULL(Email,'') AS Email,
				ISNULL(Website,'') AS Website,
				ISNULL(Comment,'') AS Comment,
				Out_Of_Hours,
				Status
			FROM
				Support_Companies
			WHERE 
				@GET_All = 0 
				AND	(
					(ID = @ID									AND @ID > 0)
					OR (Name LIKE ''%'' + @Name + ''%''				AND @Name IS NOT NULL)
					OR (Address_1 LIKE ''%'' + @Address_1 + ''%''	AND @Address_1 IS NOT NULL)
					OR (Address_2 LIKE ''%'' + @Address_2 + ''%''	AND @Address_2 IS NOT NULL)
					OR (Post_Code LIKE ''%'' + @Post_Code + ''%''	AND @Post_Code IS NOT NULL)
					OR (Tel = @Tel								AND @Tel IS NOT NULL)
					OR (Email LIKE ''%'' + @Email + ''%''			AND @Email IS NOT NULL)
					OR (Website LIKE ''%'' + @Website + ''%''		AND @Website IS NOT NULL)
					OR (Comment LIKE ''%'' + @Comment + ''%''		AND @Comment IS NOT NULL)
					OR (Out_Of_Hours = @Out_Of_Hours			AND @Out_Of_Hours IS NOT NULL)
					OR (Created = @Created						AND @Created IS NOT NULL)
					OR (Status = @Status 						AND @Status IS NOT NULL)
					OR (Deleted = @Deleted						AND @Deleted IS NOT NULL)
				)
				OR @GET_All = 1
			ORDER BY
				ID DESC,
				Name DESC,
				Status DESC,
				Deleted DESC
		END
	')
END
GO

