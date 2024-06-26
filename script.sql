USE [master]
GO
/****** Object:  Database [EnocaDb]    Script Date: 1.04.2024 10:46:05 ******/
CREATE DATABASE [EnocaDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnocaDb', FILENAME = N'C:\Users\Yusuf\EnocaDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EnocaDb_log', FILENAME = N'C:\Users\Yusuf\EnocaDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EnocaDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnocaDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnocaDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnocaDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnocaDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnocaDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnocaDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnocaDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EnocaDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnocaDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnocaDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnocaDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnocaDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnocaDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnocaDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnocaDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnocaDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EnocaDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnocaDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnocaDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnocaDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnocaDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnocaDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EnocaDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnocaDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EnocaDb] SET  MULTI_USER 
GO
ALTER DATABASE [EnocaDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnocaDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnocaDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnocaDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EnocaDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EnocaDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EnocaDb] SET QUERY_STORE = OFF
GO
USE [EnocaDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1.04.2024 10:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrierConfigurations]    Script Date: 1.04.2024 10:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierConfigurations](
	[CarrierConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CarrierMaxDesi] [int] NOT NULL,
	[CarrierMinDesi] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY CLUSTERED 
(
	[CarrierConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 1.04.2024 10:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[CarrierId] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](max) NOT NULL,
	[CarrierIsActive] [bit] NOT NULL,
	[CarrierPlusDesiCost] [int] NOT NULL,
	[CarrierConfigurationId] [int] NOT NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1.04.2024 10:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[OrderDesi] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderCarrierCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240401073418_init', N'6.0.10')
GO
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] ON 

INSERT [dbo].[CarrierConfigurations] ([CarrierConfigurationId], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (1, 1, 25, 15, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[CarrierConfigurations] ([CarrierConfigurationId], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (2, 2, 25, 15, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[CarrierConfigurations] ([CarrierConfigurationId], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (3, 3, 25, 15, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[CarrierConfigurations] ([CarrierConfigurationId], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (4, 3, 60, 40, CAST(250.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] OFF
GO
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([CarrierId], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (1, N'MNG', 1, 12, 1)
INSERT [dbo].[Carriers] ([CarrierId], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (2, N'ARAS', 1, 17, 2)
INSERT [dbo].[Carriers] ([CarrierId], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (3, N'YURT ICI', 1, 15, 4)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CarrierId], [OrderDesi], [OrderDate], [OrderCarrierCost]) VALUES (1, 3, 27, CAST(N'2024-04-01T10:42:39.7406022' AS DateTime2), CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CarrierId], [OrderDesi], [OrderDate], [OrderCarrierCost]) VALUES (2, 3, 40, CAST(N'2024-04-01T10:43:11.7735252' AS DateTime2), CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CarrierId], [OrderDesi], [OrderDate], [OrderCarrierCost]) VALUES (3, 3, 30, CAST(N'2024-04-01T10:43:32.2329888' AS DateTime2), CAST(135.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
USE [master]
GO
ALTER DATABASE [EnocaDb] SET  READ_WRITE 
GO
