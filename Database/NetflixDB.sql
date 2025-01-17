USE [master]
GO
/****** Object:  Database [Netflix]    Script Date: 05/21/2019 11:43:05 ******/
CREATE DATABASE [Netflix] ON  PRIMARY 
( NAME = N'Netflix', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Netflix.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Netflix_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Netflix_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Netflix] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Netflix].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Netflix] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Netflix] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Netflix] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Netflix] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Netflix] SET ARITHABORT OFF
GO
ALTER DATABASE [Netflix] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Netflix] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Netflix] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Netflix] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Netflix] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Netflix] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Netflix] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Netflix] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Netflix] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Netflix] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Netflix] SET  DISABLE_BROKER
GO
ALTER DATABASE [Netflix] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Netflix] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Netflix] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Netflix] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Netflix] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Netflix] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Netflix] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Netflix] SET  READ_WRITE
GO
ALTER DATABASE [Netflix] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Netflix] SET  MULTI_USER
GO
ALTER DATABASE [Netflix] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Netflix] SET DB_CHAINING OFF
GO
USE [Netflix]
GO
/****** Object:  Table [dbo].[videos]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[videos](
	[video_id] [int] IDENTITY(1,1) NOT NULL,
	[video_name] [nvarchar](255) NULL,
	[video_time] [int] NULL,
	[video_rel_country] [nvarchar](255) NULL,
	[category_id] [int] NULL,
	[release_date] [date] NULL,
	[director] [nvarchar](255) NULL,
	[writers] [nvarchar](255) NULL,
	[stars] [nvarchar](255) NULL,
	[rating] [float] NULL,
 CONSTRAINT [PK_videos] PRIMARY KEY CLUSTERED 
(
	[video_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[account_id] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[account_type] [nvarchar](255) NULL,
	[payment_gmail] [nvarchar](255) NOT NULL,
	[birthday] [date] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_users] UNIQUE NONCLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[playlist_video]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playlist_video](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[playlist_id] [int] NULL,
	[user_id] [int] NULL,
	[video_id] [int] NULL,
 CONSTRAINT [PK_playlist_video] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[playlist]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playlist](
	[playlist_id] [int] IDENTITY(1,1) NOT NULL,
	[playlist_name] [nvarchar](255) NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_playlist] PRIMARY KEY CLUSTERED 
(
	[playlist_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[purchase_date] [datetime] NULL,
	[expiration_date] [datetime] NULL,
	[account_type] [nvarchar](255) NULL,
 CONSTRAINT [PK_payments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[favorite_videos]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favorite_videos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[video_id] [int] NULL,
 CONSTRAINT [PK_favorite_videos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 05/21/2019 11:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](255) NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_users_account_type]    Script Date: 05/21/2019 11:43:05 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_account_type]  DEFAULT (N'basic') FOR [account_type]
GO
