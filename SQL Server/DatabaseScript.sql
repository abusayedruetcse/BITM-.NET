CREATE DATABASE StudentDB
USE [StudentDB]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 6/12/2019 4:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Age] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([ID], [Name], [Age]) VALUES (3, N'KHALID', 25)
INSERT [dbo].[Students] ([ID], [Name], [Age]) VALUES (4, N'KHAIRUL', 10)
INSERT [dbo].[Students] ([ID], [Name], [Age]) VALUES (5, N'JAMIL', 20)
INSERT [dbo].[Students] ([ID], [Name], [Age]) VALUES (6, N'JAMIL', 20)
INSERT [dbo].[Students] ([ID], [Name], [Age]) VALUES (7, N'KHALID', 25)
SET IDENTITY_INSERT [dbo].[Students] OFF

SELECT * FROM Students
