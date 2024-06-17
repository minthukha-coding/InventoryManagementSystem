USE [master]
GO
/****** Object:  Database [InventoryManagementSystem]    Script Date: 6/17/2024 11:17:16 PM ******/
CREATE DATABASE [InventoryManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManangementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryManangementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryManangementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryManangementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InventoryManagementSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [InventoryManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryManagementSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InventoryManagementSystem', N'ON'
GO
ALTER DATABASE [InventoryManagementSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [InventoryManagementSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InventoryManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Category]    Script Date: 6/17/2024 11:17:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Category](
	[CategoryName] [varchar](50) NOT NULL,
	[CategoryId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Item]    Script Date: 6/17/2024 11:17:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Item](
	[ItemName] [varchar](50) NOT NULL,
	[ItemCategory] [varchar](50) NOT NULL,
	[ItemPrice] [decimal](18, 0) NOT NULL,
	[IteamAmount] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Item1] PRIMARY KEY CLUSTERED 
(
	[ItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Order]    Script Date: 6/17/2024 11:17:17 PM ******/
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
INSERT [dbo].[Tbl_Category] ([CategoryName], [CategoryId]) VALUES (N'Beer', N'BER1')
INSERT [dbo].[Tbl_Category] ([CategoryName], [CategoryId]) VALUES (N'EnergyDrink', N'ED1')
INSERT [dbo].[Tbl_Category] ([CategoryName], [CategoryId]) VALUES (N'Glass', N'GS2')
INSERT [dbo].[Tbl_Category] ([CategoryName], [CategoryId]) VALUES (N'Tablet', N'TBL1')
INSERT [dbo].[Tbl_Category] ([CategoryName], [CategoryId]) VALUES (N'Water', N'WR1')
GO
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'ABC', N'BER1', CAST(2900 AS Decimal(18, 0)), N'1200')
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'Carabaung', N'ED1', CAST(10000 AS Decimal(18, 0)), N'100')
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'Henkieen', N'BER1', CAST(1850 AS Decimal(18, 0)), N'1912')
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'Lion', N'ED1', CAST(10000 AS Decimal(18, 0)), N'100')
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'Shark', N'ED1', CAST(10000 AS Decimal(18, 0)), N'98')
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'Speed', N'ED1', CAST(900 AS Decimal(18, 0)), N'98')
INSERT [dbo].[Tbl_Item] ([ItemName], [ItemCategory], [ItemPrice], [IteamAmount]) VALUES (N'Tiger', N'BER1', CAST(4300 AS Decimal(18, 0)), N'120')
GO
USE [master]
GO
ALTER DATABASE [InventoryManagementSystem] SET  READ_WRITE 
GO
