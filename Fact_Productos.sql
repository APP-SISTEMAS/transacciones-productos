USE [Tienda]
GO

/****** Object:  Table [dbo].[Fact_Productos]    Script Date: 8/9/2025 1:08:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fact_Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](15) NULL,
	[Descripcion] [varchar](50) NULL,
	[Cantidad] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Fact_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


