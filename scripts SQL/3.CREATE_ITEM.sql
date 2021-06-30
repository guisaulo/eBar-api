USE [eBar]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 14-Sep-20 10:32:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](10) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Item] VALUES('Cerveja', 5)
INSERT INTO [dbo].[Item] VALUES('Conhaque', 20)
INSERT INTO [dbo].[Item] VALUES('Suco', 50)
INSERT INTO [dbo].[Item] VALUES('Água', 70)
