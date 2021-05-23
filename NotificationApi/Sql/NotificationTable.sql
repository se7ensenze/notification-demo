USE [TestDb]
GO

/****** Object:  Table [dbo].[Notification]    Script Date: 5/23/2021 10:58:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Notification](
	[Id] [uniqueidentifier] NOT NULL,
	[Receiver] [varchar](50) NOT NULL,
	[Sender] [varchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReadDate] [datetime] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

