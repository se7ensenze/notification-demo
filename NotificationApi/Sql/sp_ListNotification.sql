USE [TestDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_ListNotification]    Script Date: 5/23/2021 11:11:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ListNotification]
	@Receiver varchar(50),
	@PageNo int,
	@PageSize int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id]
		,[Receiver]
		,[Sender]
		,[Message]
		,[CreatedDate]
		,[ReadDate]
	FROM [TestDb].[dbo].[Notification]
	WHERE Receiver = @Receiver
		AND CreatedDate >= DATEADD(day, -90, CONVERT(date, GETDATE()))
	ORDER BY CreatedDate DESC
	OFFSET (@PageNo - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

END
GO


