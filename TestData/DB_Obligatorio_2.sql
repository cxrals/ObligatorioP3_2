USE [Obligatorio_P3]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 19/6/2024 18:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[CodigoProveedor] [nvarchar](13) NOT NULL,
	[Precio] [int] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientosDeStock]    Script Date: 19/6/2024 18:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientosDeStock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[TipoMovimientoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_MovimientosDeStock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 19/6/2024 18:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeMovimientos]    Script Date: 19/6/2024 18:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeMovimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](450) NOT NULL,
	[TipoAccion] [nvarchar](24) NOT NULL,
 CONSTRAINT [PK_TiposDeMovimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/6/2024 18:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Contraseña] [nvarchar](max) NOT NULL,
	[ContraseniaEncriptada] [nvarchar](max) NULL,
	[Tipo] [nvarchar](24) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovimientosDeStock]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosDeStock_Articulos_ArticuloId] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimientosDeStock] CHECK CONSTRAINT [FK_MovimientosDeStock_Articulos_ArticuloId]
GO
ALTER TABLE [dbo].[MovimientosDeStock]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosDeStock_TiposDeMovimientos_TipoMovimientoId] FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TiposDeMovimientos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimientosDeStock] CHECK CONSTRAINT [FK_MovimientosDeStock_TiposDeMovimientos_TipoMovimientoId]
GO
ALTER TABLE [dbo].[MovimientosDeStock]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosDeStock_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimientosDeStock] CHECK CONSTRAINT [FK_MovimientosDeStock_Usuarios_UsuarioId]
GO
