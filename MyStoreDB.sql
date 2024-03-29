USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 6/21/2022 4:24:03 PM ******/
CREATE DATABASE [MyStore]
GO
USE [MyStore]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/21/2022 4:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/21/2022 4:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitslnStock] [smallint] NOT NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Beverages')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Condiments')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Confections')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Dairy Products')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Grains/Cereals')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Meat/Poultry')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Produce')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (8, N'Seafood')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (1, N'Genen Shouyu', 500000.0000, 39, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (2, N'Alice Mutton', 300000.0000, 17, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (3, N'Aniseed Syrup', 400000.0000, 13, 3)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (4, N'Perth Pasties', 220000.0000, 53, 2)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (5, N'Carnarvon Tigers', 213500.0000, 0, 4)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (6, N'Gula Malacca', 250000.0000, 120, 2)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (7, N'Steeleye', 3000000.0000, 15, 7)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (8, N'Chocolade', 400000.0000, 6, 5)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (9, N'Mishi Kobe Niku', 970000.0000, 29, 6)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (10, N'Ikura', 310000.0000, 31, 8)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitslnStock], [CategoryID]) VALUES (13, N'Demo 1', 1000.0000, 10, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO
