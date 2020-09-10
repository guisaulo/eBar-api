USE [TestDgBar]
GO

/****** Object:  Table [dbo].[ComandaItem]    Script Date: 10-Sep-20 2:18:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ComandaItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComandaId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ComandaItem]  WITH CHECK ADD FOREIGN KEY([ComandaId])
REFERENCES [dbo].[Comanda] ([Id])
GO

ALTER TABLE [dbo].[ComandaItem]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO