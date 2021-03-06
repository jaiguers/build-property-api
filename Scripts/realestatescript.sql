USE [Real_Estate]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 13/08/2021 8:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[Id_Owner] [bigint] IDENTITY(1,1) NOT NULL,
	[Identification] [varchar](50) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Photo] [varchar](150) NULL,
	[Birthday] [date] NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[Id_Owner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 13/08/2021 8:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id_Property] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Internal_Code] [varchar](10) NOT NULL,
	[Year] [int] NOT NULL,
	[Id_Owner] [bigint] NOT NULL,
	[Id_State] [bigint] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id_Property] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property_Image]    Script Date: 13/08/2021 8:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property_Image](
	[Id_Property_Image] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Property] [bigint] NOT NULL,
	[Files] [varchar](150) NOT NULL,
	[Id_State] [bigint] NOT NULL,
 CONSTRAINT [PK_Property_Image] PRIMARY KEY CLUSTERED 
(
	[Id_Property_Image] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property_Trace]    Script Date: 13/08/2021 8:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property_Trace](
	[Id_Property_Trace] [bigint] IDENTITY(1,1) NOT NULL,
	[Date_Sale] [date] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](12, 2) NOT NULL,
	[Id_Property] [bigint] NOT NULL,
 CONSTRAINT [PK_Property_Trace] PRIMARY KEY CLUSTERED 
(
	[Id_Property_Trace] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 13/08/2021 8:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id_State] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id_State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Owner] ON 

INSERT [dbo].[Owner] ([Id_Owner], [Identification], [Name], [Address], [Photo], [Birthday]) VALUES (1, N'123', N'Jair Guerrero', N'Calle 23', N'path', NULL)
INSERT [dbo].[Owner] ([Id_Owner], [Identification], [Name], [Address], [Photo], [Birthday]) VALUES (3, N'1130', N'Man Power', N'Palm Springs', N'Photo', NULL)
INSERT [dbo].[Owner] ([Id_Owner], [Identification], [Name], [Address], [Photo], [Birthday]) VALUES (4, N'1005', N'Robert Smith', N'Ave 10th', N'photo', NULL)
SET IDENTITY_INSERT [dbo].[Owner] OFF
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([Id_Property], [Name], [Address], [Price], [Internal_Code], [Year], [Id_Owner], [Id_State]) VALUES (1, N'Boca raton mansion', N'601 North Ocean', CAST(2000000.00 AS Decimal(18, 2)), N'INTER123', 2000, 1, 1)
INSERT [dbo].[Property] ([Id_Property], [Name], [Address], [Price], [Internal_Code], [Year], [Id_Owner], [Id_State]) VALUES (4, N'Palm beach mansion', N'Chapel Hill', CAST(1000000.00 AS Decimal(18, 2)), N'INTER456', 1986, 3, 1)
SET IDENTITY_INSERT [dbo].[Property] OFF
SET IDENTITY_INSERT [dbo].[Property_Image] ON 

INSERT [dbo].[Property_Image] ([Id_Property_Image], [Id_Property], [Files], [Id_State]) VALUES (1, 1, N'/photo/1.jpg', 1)
INSERT [dbo].[Property_Image] ([Id_Property_Image], [Id_Property], [Files], [Id_State]) VALUES (3, 1, N'/photo/2.jpg', 1)
INSERT [dbo].[Property_Image] ([Id_Property_Image], [Id_Property], [Files], [Id_State]) VALUES (4, 4, N'/photo/1.jpg', 1)
INSERT [dbo].[Property_Image] ([Id_Property_Image], [Id_Property], [Files], [Id_State]) VALUES (5, 4, N'/photo/2.jpg', 1)
SET IDENTITY_INSERT [dbo].[Property_Image] OFF
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id_State], [Description]) VALUES (1, N'Active')
INSERT [dbo].[State] ([Id_State], [Description]) VALUES (2, N'Inactive')
INSERT [dbo].[State] ([Id_State], [Description]) VALUES (3, N'Sold')
INSERT [dbo].[State] ([Id_State], [Description]) VALUES (4, N'Enabled')
INSERT [dbo].[State] ([Id_State], [Description]) VALUES (5, N'Disabled')
SET IDENTITY_INSERT [dbo].[State] OFF
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Owner] FOREIGN KEY([Id_Owner])
REFERENCES [dbo].[Owner] ([Id_Owner])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Owner]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_State] FOREIGN KEY([Id_State])
REFERENCES [dbo].[State] ([Id_State])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_State]
GO
ALTER TABLE [dbo].[Property_Image]  WITH CHECK ADD  CONSTRAINT [FK_Property_Image_Property] FOREIGN KEY([Id_Property])
REFERENCES [dbo].[Property] ([Id_Property])
GO
ALTER TABLE [dbo].[Property_Image] CHECK CONSTRAINT [FK_Property_Image_Property]
GO
ALTER TABLE [dbo].[Property_Image]  WITH CHECK ADD  CONSTRAINT [FK_Property_Image_State] FOREIGN KEY([Id_State])
REFERENCES [dbo].[State] ([Id_State])
GO
ALTER TABLE [dbo].[Property_Image] CHECK CONSTRAINT [FK_Property_Image_State]
GO
ALTER TABLE [dbo].[Property_Trace]  WITH CHECK ADD  CONSTRAINT [FK_Property_Trace_Property] FOREIGN KEY([Id_Property])
REFERENCES [dbo].[Property] ([Id_Property])
GO
ALTER TABLE [dbo].[Property_Trace] CHECK CONSTRAINT [FK_Property_Trace_Property]
GO
