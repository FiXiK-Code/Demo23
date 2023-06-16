USE [uch1]
GO
/****** Object:  Table [dbo].[podzharow_DEMO]    Script Date: 13.05.2023 11:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[podzharow_DEMO](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](60) NULL,
	[img_path] [varchar](100) NULL,
	[description] [text] NULL,
	[manufacturer] [varchar](100) NULL,
	[prise] [float] NULL,
	[descount] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[podzharow_DEMO] ON 
GO
INSERT [dbo].[podzharow_DEMO] ([id], [name], [img_path], [description], [manufacturer], [prise], [descount]) VALUES (1, N'Хлеб', NULL, N'Булка', N'Пекарня', 40, 0)
GO
INSERT [dbo].[podzharow_DEMO] ([id], [name], [img_path], [description], [manufacturer], [prise], [descount]) VALUES (2, N'мясо', NULL, N'свинина', N'мясокомбинат', 300, 11)
GO
INSERT [dbo].[podzharow_DEMO] ([id], [name], [img_path], [description], [manufacturer], [prise], [descount]) VALUES (3, N'молоко', NULL, N'колье молоко', N'молочка', 100, 16)
GO
SET IDENTITY_INSERT [dbo].[podzharow_DEMO] OFF
GO
