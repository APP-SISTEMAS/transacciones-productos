USE [Tienda]
GO

/****** Object:  Table [dbo].[Fact_DetalleTransacciones]    Script Date: 8/9/2025 1:09:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fact_DetalleTransacciones](
	[Num] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoTransaccion] [varchar](2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Observacion] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Fact_DetalleTransacciones] PRIMARY KEY CLUSTERED 
(
	[Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


