USE [TestDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddNotification]    Script Date: 5/23/2021 11:11:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AddNotification]
	@Id	uniqueidentifier,
	@Receiver	varchar(50),
	@Sender	varchar(50),
	@Message	nvarchar(MAX),
	@CreatedDate	datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Notification]
			   ([Id]
			   ,[Receiver]
			   ,[Sender]
			   ,[Message]
			   ,[CreatedDate]
			   ,[ReadDate])
		 VALUES
			   (@Id
			   ,@Receiver
			   ,@Sender
			   ,@Message
			   ,@CreatedDate
			   ,NULL)

	RETURN @@ROWCOUNT

END
GO


