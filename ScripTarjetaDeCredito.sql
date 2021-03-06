USE [master]
GO
/****** Object:  Database [TarjetasDeCreditoMVC.ZoeFernandez]    Script Date: 30/04/2021 11:13:22 ******/
CREATE DATABASE [TarjetasDeCreditoMVC.ZoeFernandez]
 CONTAINMENT = NONE
--ON  PRIMARY 
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TarjetasDeCreditoMVC.ZoeFernandez].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET ARITHABORT OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET RECOVERY FULL 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET  MULTI_USER 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TarjetasDeCreditoMVC.ZoeFernandez', N'ON'
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET QUERY_STORE = OFF
GO
USE [TarjetasDeCreditoMVC.ZoeFernandez]
GO
/****** Object:  Table [dbo].[CarterasDeConsumos]    Script Date: 30/04/2021 11:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarterasDeConsumos](
	[CarteraDeConsumoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
	[LimiteDeCredito] [decimal](18, 2) NOT NULL,
	[CostoDeRenovacion] [decimal](18, 2) NOT NULL,
	[Imagen] [nvarchar](256) NULL,
 CONSTRAINT [PK_CarterasDeConsumos] PRIMARY KEY CLUSTERED 
(
	[CarteraDeConsumoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 30/04/2021 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDeDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
	[FechaDeNacimiento] [date] NOT NULL,
	[Suspenso] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comercios]    Script Date: 30/04/2021 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comercios](
	[ComercioId] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[PersonaDeContacto] [nvarchar](120) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Comercios] PRIMARY KEY CLUSTERED 
(
	[ComercioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 30/04/2021 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [nvarchar](100) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 30/04/2021 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 30/04/2021 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[TarjetaId] [int] IDENTITY(1,1) NOT NULL,
	[NroDeTarjeta] [nvarchar](16) NOT NULL,
	[CarteraDeConsumoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[ValidaDesde] [nvarchar](4) NOT NULL,
	[ValidaHasta] [nvarchar](4) NOT NULL,
	[Vigente] [bit] NOT NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[TarjetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeDocumentos]    Script Date: 30/04/2021 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeDocumentos](
	[TipoDeDocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDeDocumentos] PRIMARY KEY CLUSTERED 
(
	[TipoDeDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CarterasDeConsumos] ON 

INSERT [dbo].[CarterasDeConsumos] ([CarteraDeConsumoId], [Descripcion], [LimiteDeCredito], [CostoDeRenovacion], [Imagen]) VALUES (1, N'Nacional', CAST(31000.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), N'visa-classic-400x225.jpg')
INSERT [dbo].[CarterasDeConsumos] ([CarteraDeConsumoId], [Descripcion], [LimiteDeCredito], [CostoDeRenovacion], [Imagen]) VALUES (2, N'Internacional', CAST(43000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), N'SinImagenDisponible.jpg')
INSERT [dbo].[CarterasDeConsumos] ([CarteraDeConsumoId], [Descripcion], [LimiteDeCredito], [CostoDeRenovacion], [Imagen]) VALUES (3, N'Gold', CAST(50000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)), N'gold-400x225.jpg')
INSERT [dbo].[CarterasDeConsumos] ([CarteraDeConsumoId], [Descripcion], [LimiteDeCredito], [CostoDeRenovacion], [Imagen]) VALUES (4, N'Platinum', CAST(62000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)), N'visa-platinum-400x225.jpg')
INSERT [dbo].[CarterasDeConsumos] ([CarteraDeConsumoId], [Descripcion], [LimiteDeCredito], [CostoDeRenovacion], [Imagen]) VALUES (5, N'Signature', CAST(68000.00 AS Decimal(18, 2)), CAST(35000.00 AS Decimal(18, 2)), N'visa-signature-400x225.jpg')
SET IDENTITY_INSERT [dbo].[CarterasDeConsumos] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento], [Suspenso]) VALUES (3, N'Juan', N'Perez', 8, N'8488817', N'hdudeui', 4, 5, N'nsjcjscbsdchds', NULL, NULL, CAST(N'1999-02-15' AS Date), 0)
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento], [Suspenso]) VALUES (4, N'Juana', N'Gonzakes', 8, N'284894848', N'hsubyeudx', 4, 5, NULL, N'bxyxbsuxsbux', NULL, CAST(N'0198-05-04' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Comercios] ON 

INSERT [dbo].[Comercios] ([ComercioId], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (1, N'Mima', N'Miriam', N'Ayacucho 368 ', 2, 1, N'258755', N'484891418', N'')
INSERT [dbo].[Comercios] ([ComercioId], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (2, N'Carreful', N'Gonzalo Perez', N'Av. Buenos Aires 2575', 2, 1, N'285848', NULL, NULL)
INSERT [dbo].[Comercios] ([ComercioId], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (4, N'Ni idea', N'Fulanita Perez', N'Alamos 1478', 5, 4, N'4785199', N'788555', N'nidea')
INSERT [dbo].[Comercios] ([ComercioId], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (5, N'La gardenia', N'Andrea Giabino', N'Peron 58', 3, 1, N'148752', N'488755988', N'hxsuhxsixhisbix')
INSERT [dbo].[Comercios] ([ComercioId], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (6, N'La garden', N'Andrea Giabino', N'Peron 58', 3, 1, N'148752', N'488755988', N'hxsuhxsixhisbix')
INSERT [dbo].[Comercios] ([ComercioId], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (7, N'Videro El eucalipto', N'Pepe', N'Necochea 1487', 5, 4, N'148752', N'488755988', N'hxsuhxsixhisbix')
SET IDENTITY_INSERT [dbo].[Comercios] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (2, N'CABA', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (3, N'Olavarria', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (4, N'Bariloche', 5)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (5, N'Rosario', 4)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (6, N'Bahia Blanca', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (9, N'Calamuchita', 3)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (6, N'Chubut')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (3, N'Cordoba')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (9, N'Editado')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2, N'Mendoza')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (5, N'Neuquen')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (20, N'Salta')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (4, N'Santa Fe')
SET IDENTITY_INSERT [dbo].[Provincias] OFF
SET IDENTITY_INSERT [dbo].[Tarjetas] ON 

INSERT [dbo].[Tarjetas] ([TarjetaId], [NroDeTarjeta], [CarteraDeConsumoId], [ClienteId], [ValidaDesde], [ValidaHasta], [Vigente]) VALUES (1, N'18818812228', 1, 4, N'0218', N'0228', 1)
INSERT [dbo].[Tarjetas] ([TarjetaId], [NroDeTarjeta], [CarteraDeConsumoId], [ClienteId], [ValidaDesde], [ValidaHasta], [Vigente]) VALUES (3, N'84181888184', 2, 3, N'0819', N'0829', 1)
SET IDENTITY_INSERT [dbo].[Tarjetas] OFF
SET IDENTITY_INSERT [dbo].[TiposDeDocumentos] ON 

INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (8, N'DNI')
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (9, N'DU')
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (10, N'LC')
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (11, N'LE')
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (12, N'Pasaporte')
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (1025, N'sdffgg')
SET IDENTITY_INSERT [dbo].[TiposDeDocumentos] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Descripcion_CarterasDeConsumos]    Script Date: 30/04/2021 11:13:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Descripcion_CarterasDeConsumos] ON [dbo].[CarterasDeConsumos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NroDocumento_Clientes]    Script Date: 30/04/2021 11:13:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_NroDocumento_Clientes] ON [dbo].[Clientes]
(
	[NroDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NombreLocalidad_Localidades]    Script Date: 30/04/2021 11:13:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_NombreLocalidad_Localidades] ON [dbo].[Localidades]
(
	[NombreLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NombreProvincia_Provincias]    Script Date: 30/04/2021 11:13:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_NombreProvincia_Provincias] ON [dbo].[Provincias]
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NroDeTarjeta_Tarjetas]    Script Date: 30/04/2021 11:13:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_NroDeTarjeta_Tarjetas] ON [dbo].[Tarjetas]
(
	[NroDeTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Descripcion_TiposDeDocumentos]    Script Date: 30/04/2021 11:13:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Descripcion_TiposDeDocumentos] ON [dbo].[TiposDeDocumentos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Suspenso]  DEFAULT ((0)) FOR [Suspenso]
GO
ALTER TABLE [dbo].[Tarjetas] ADD  CONSTRAINT [DF_Tarjetas_Vigente]  DEFAULT ((1)) FOR [Vigente]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Localidades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Provincias]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDeDocumentos] FOREIGN KEY([TipoDeDocumentoId])
REFERENCES [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDeDocumentos]
GO
ALTER TABLE [dbo].[Comercios]  WITH CHECK ADD  CONSTRAINT [FK_Comercios_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Comercios] CHECK CONSTRAINT [FK_Comercios_Localidades]
GO
ALTER TABLE [dbo].[Comercios]  WITH CHECK ADD  CONSTRAINT [FK_Comercios_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Comercios] CHECK CONSTRAINT [FK_Comercios_Provincias]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_CarterasDeConsumos] FOREIGN KEY([CarteraDeConsumoId])
REFERENCES [dbo].[CarterasDeConsumos] ([CarteraDeConsumoId])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_CarterasDeConsumos]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_Clientes]
GO
USE [master]
GO
ALTER DATABASE [TarjetasDeCreditoMVC.ZoeFernandez] SET  READ_WRITE 
GO
