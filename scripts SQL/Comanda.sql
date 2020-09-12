USE [TestDgBar]
GO

/****** Object:  Table [dbo].[Comanda]    Script Date: 09-Sep-20 10:33:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comanda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](10) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Comanda] VALUES('Comanda 1')
INSERT INTO [dbo].[Comanda] VALUES('Comanda 2')
INSERT INTO [dbo].[Comanda] VALUES('Comanda 3')
INSERT INTO [dbo].[Comanda] VALUES('Comanda 4')