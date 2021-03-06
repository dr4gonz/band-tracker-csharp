CREATE DATABASE band_tracker
GO
USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/22/2016 10:20:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[website] [varchar](255) NULL,
	[email] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/22/2016 10:20:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[email] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues_bands]    Script Date: 7/22/2016 10:20:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_id] [int] NULL,
	[band_id] [int] NULL
) ON [PRIMARY]

GO

CREATE DATABASE band_tracker_test
GO
USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/22/2016 10:20:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[website] [varchar](255) NULL,
	[email] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/22/2016 10:20:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[email] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues_bands]    Script Date: 7/22/2016 10:20:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_id] [int] NULL,
	[band_id] [int] NULL
) ON [PRIMARY]

GO

