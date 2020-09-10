USE [TestDgBar]
GO

/****** Object:  Table [dbo].[ComandaItem]    Script Date: 10-Sep-20 12:17:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ComandaItem](
	[ComandaId] [int] NULL,
	[ItemId] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ComandaItem]  WITH CHECK ADD FOREIGN KEY([ComandaId])
REFERENCES [dbo].[Comanda] ([Id])
GO

ALTER TABLE [dbo].[ComandaItem]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO


