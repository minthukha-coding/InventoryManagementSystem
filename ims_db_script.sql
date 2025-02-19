USE
[master]
GO
/****** Object:  Database [InventoryManagementSystem]    Script Date: 8/5/2024 10:45:55 PM ******/
CREATE
DATABASE [InventoryManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER
DATABASE [InventoryManagementSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER
DATABASE [InventoryManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET ARITHABORT OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER
DATABASE [InventoryManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER
DATABASE [InventoryManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET  DISABLE_BROKER 
GO
ALTER
DATABASE [InventoryManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER
DATABASE [InventoryManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET RECOVERY FULL 
GO
ALTER
DATABASE [InventoryManagementSystem] SET  MULTI_USER 
GO
ALTER
DATABASE [InventoryManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER
DATABASE [InventoryManagementSystem] SET DB_CHAINING OFF 
GO
ALTER
DATABASE [InventoryManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER
DATABASE [InventoryManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER
DATABASE [InventoryManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER
DATABASE [InventoryManagementSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InventoryManagementSystem', N'ON'
GO
ALTER
DATABASE [InventoryManagementSystem] SET QUERY_STORE = ON
GO
ALTER
DATABASE [InventoryManagementSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InventoryManagementSystem]
GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 8/5/2024 10:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category]
(
    [
    categoryId] [
    varchar]
(
    50
) NOT NULL,
    [categoryName] [varchar]
(
    50
) NOT NULL,
    [createdDateTime] [datetime] NOT NULL,
    [updatedDateTime] [datetime] NULL,
    [createdUserId] [varchar]
(
    50
) NOT NULL,
    [updatedUserId] [varchar]
(
    50
) NULL,
    [isDeleted] [int] NOT NULL,
    CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED
(
[
    categoryId]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[tbl_item]    Script Date: 8/5/2024 10:45:55 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[tbl_item]
(
    [
    ItemName] [
    varchar]
(
    50
) NOT NULL,
    [ItemCategory] [varchar]
(
    50
) NOT NULL,
    [ItemPrice] [decimal]
(
    18,
    2
) NOT NULL,
    [ItemAmount] [varchar]
(
    50
) NOT NULL,
    [createdDateTime] [datetime] NOT NULL,
    [createdUserId] [varchar]
(
    50
) NOT NULL,
    [updatedDateTime] [datetime] NULL,
    [updatedUserId] [varchar]
(
    50
) NULL,
    CONSTRAINT [PK_tbl_item] PRIMARY KEY CLUSTERED
(
[
    ItemName]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 8/5/2024 10:45:55 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[tbl_order]
(
    [
    orderId] [
    varchar]
(
    50
) NOT NULL,
    [orderDate] [datetime] NOT NULL,
    [customerName] [varchar]
(
    50
) NOT NULL,
    [customerUserId] [nchar]
(
    10
) NOT NULL,
    [orderItemId] [varchar]
(
    50
) NOT NULL,
    [orderItemPrice] [nchar]
(
    10
) NOT NULL,
    [orderItemAmount] [nchar]
(
    10
) NOT NULL,
    [orderItemTotalPrice] [nchar]
(
    10
) NOT NULL,
    [isDeliveried] [int] NOT NULL,
    CONSTRAINT [PK_Tbl_Order] PRIMARY KEY CLUSTERED
(
[
    orderId]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[tbl_orderInvoice]    Script Date: 8/5/2024 10:45:55 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[tbl_orderInvoice]
(
    [
    orderInvoiceId] [
    varchar]
(
    50
) NOT NULL,
    [orderId] [varchar]
(
    50
) NOT NULL,
    [invoiceDate] [datetime] NOT NULL,
    [totalAmount] [decimal]
(
    18,
    2
) NOT NULL,
    CONSTRAINT [PK_tbl_orderInvoice] PRIMARY KEY CLUSTERED
(
[
    orderInvoiceId]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[tbl_orderItem]    Script Date: 8/5/2024 10:45:55 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[tbl_orderItem]
(
    [
    orderItemId] [
    varchar]
(
    50
) NOT NULL,
    [orderId] [varchar]
(
    50
) NOT NULL,
    [itemId] [varchar]
(
    50
) NOT NULL,
    [quantity] [varchar]
(
    50
) NOT NULL,
    [price] [decimal]
(
    18,
    2
) NOT NULL,
    CONSTRAINT [PK_tbl_orderItem] PRIMARY KEY CLUSTERED
(
[
    orderItemId]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 8/5/2024 10:45:55 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[tbl_user]
(
    [
    usereId] [
    varchar]
(
    50
) NOT NULL,
    [userName] [varchar]
(
    50
) NOT NULL,
    [hashPassword] [varchar]
(
    50
) NOT NULL,
    [role] [varchar]
(
    50
) NOT NULL,
    [createdDateTime] [datetime] NOT NULL,
    [updatedDateTime] [nchar]
(
    10
) NULL,
    [isDeleted] [int] NOT NULL,
    CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED
(
[
    usereId]
    ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
    USE [master]
    GO
ALTER
DATABASE [InventoryManagementSystem] SET  READ_WRITE 
GO
