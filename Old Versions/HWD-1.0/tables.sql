/* Generate needed tables for HWD System */

CREATE TABLE [HWD] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ComputerName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[OS] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Username] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Manufacturer] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Model] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SerialNumber] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RAM] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Processor] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IDKind] [int] NULL ,
	[IDLocation] [int] NULL ,
	[Status] [bit] NULL CONSTRAINT [DF_HWD_Status] DEFAULT (1),
	[Notes] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	CONSTRAINT [PK_HWD] PRIMARY KEY  CLUSTERED 
	(
		[ComputerName]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

CREATE TABLE [SWD] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ComputerName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SoftwareName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Version] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Vendor] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	CONSTRAINT [PK_SWD] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

CREATE TABLE [KWD] (
	[IDKind] [int] IDENTITY (1, 1) NOT NULL ,
	[KindName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	CONSTRAINT [PK_KWD] PRIMARY KEY  CLUSTERED 
	(
		[IDKind]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

CREATE TABLE [LWD] (
	[IDLocation] [int] IDENTITY (1, 1) NOT NULL ,
	[LocationName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	CONSTRAINT [PK_LWD] PRIMARY KEY  CLUSTERED 
	(
		[IDLocation]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

