USE [IchiPaint]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 12/06/2018 9:24:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Color](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,	 
	[Description] [nvarchar](max) NULL,
	[Avatar] [nvarchar](max) NULL,
	[Lstord] [numeric] (18, 0),
	[CreateDate] [varchar](20) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


