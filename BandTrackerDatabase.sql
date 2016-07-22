CREATE DATABASE band_tracker
GO
USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/22/2016 8:58:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[website] [varchar](50) NULL,
	[email] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/22/2016 8:58:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues_bands]    Script Date: 7/22/2016 8:58:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues_bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_id] [int] NULL,
	[band_id] [int] NULL
) ON [PRIMARY]

GO

CREATE DATABASE band_tracker_test
GO
USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/22/2016 8:58:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[website] [varchar](50) NULL,
	[email] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/22/2016 8:58:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues_bands]    Script Date: 7/22/2016 8:58:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues_bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_id] [int] NULL,
	[band_id] [int] NULL
) ON [PRIMARY]

GO
