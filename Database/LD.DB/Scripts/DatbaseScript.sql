USE [LevenshteinDistanceDB]
GO
/****** Object:  Schema [LD]    Script Date: 5/28/2021 10:15:55 PM ******/
CREATE SCHEMA [LD]
GO
/****** Object:  Table [LD].[GenericMetaData]    Script Date: 5/28/2021 10:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LD].[GenericMetaData](
	[Id] [varchar](36) NOT NULL,
	[MetaSource] [varchar](100) NOT NULL,
	[MetaType] [varchar](36) NULL,
	[MetaData] [nvarchar](max) NULL,
	[Code] [varchar](100) NULL,
	[Description] [nvarchar](2000) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [LD].[GenericStringsComputations]    Script Date: 5/28/2021 10:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LD].[GenericStringsComputations](
	[Id] [varchar](36) NOT NULL,
	[Source] [nvarchar](max) NULL,
	[Target] [nvarchar](max) NULL,
	[LevenshteinDistance] [int] NULL,
	[Code] [varchar](100) NULL,
	[Description] [nvarchar](2000) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [LD].[GenericMetaData] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [LD].[GenericStringsComputations] ADD  DEFAULT ((-101)) FOR [LevenshteinDistance]
GO
ALTER TABLE [LD].[GenericStringsComputations] ADD  DEFAULT ((1)) FOR [Active]
GO
