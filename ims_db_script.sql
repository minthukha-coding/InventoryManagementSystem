USE [InventoryManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Category]    Script Date: 5/29/2024 10:34:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Category](
	[CategoryName] [varchar](50) NOT NULL,
	[CategoryId] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Item]    Script Date: 5/29/2024 10:34:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Item](
	[ItemName] [varchar](50) NOT NULL,
	[ItemCategory] [varchar](50) NOT NULL,
	[ItemPrice] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Order]    Script Date: 5/29/2024 10:34:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Order](
	[OrderId] [varchar](50) NOT NULL,
	[OrderItemId] [varchar](50) NOT NULL,
	[OrderItemPrice] [decimal](18, 2) NOT NULL,
	[OrderItemAmount] [int] NOT NULL,
	[OrderTotalPrice] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
