USE [InventoryManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Catagory]    Script Date: 5/29/2024 10:17:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Catagory](
	[CatagoryName] [varchar](50) NOT NULL,
	[CatagoryId] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Item]    Script Date: 5/29/2024 10:17:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Item](
	[ItemName] [varchar](50) NOT NULL,
	[ItemCatagory] [varchar](50) NOT NULL,
	[ItemPrice] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Order]    Script Date: 5/29/2024 10:17:44 PM ******/
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
