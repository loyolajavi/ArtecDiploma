USE [master]
GO
/****** Object:  Database [Artec]    Script Date: 02/04/2017 14:04:40 ******/
CREATE DATABASE [Artec] ON  PRIMARY 
( NAME = N'Artec', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Artec.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Artec_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Artec_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Artec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Artec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Artec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Artec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Artec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Artec] SET ARITHABORT OFF 
GO
ALTER DATABASE [Artec] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Artec] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Artec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Artec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Artec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Artec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Artec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Artec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Artec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Artec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Artec] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Artec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Artec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Artec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Artec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Artec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Artec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Artec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Artec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Artec] SET  MULTI_USER 
GO
ALTER DATABASE [Artec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Artec] SET DB_CHAINING OFF 
GO
USE [Artec]
GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerTodos]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DependenciaTraerTodos]

AS

SET NOCOUNT ON

SELECT *
FROM Dependencia
GO
/****** Object:  Table [dbo].[Adquisicion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adquisicion](
	[IdAdquisicion] [int] IDENTITY(1,1) NOT NULL,
	[FechaAdq] [datetime] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[NroFactura] [varchar](50) NULL,
	[NroExpediente] [varchar](50) NULL,
	[NroOrdenCompra] [varchar](50) NULL,
	[RutaDocumentos] [nvarchar](500) NULL,
	[MontoCompra] [money] NULL,
	[IdTipoAdquisicion] [int] NOT NULL,
	[IdRendicion] [int] NULL,
	[IdProveedor] [int] NOT NULL,
 CONSTRAINT [PK_Adquisicion] PRIMARY KEY CLUSTERED 
(
	[IdAdquisicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Agente]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agente](
	[IdAgente] [int] IDENTITY(1,1) NOT NULL,
	[NombreAgente] [varchar](300) NOT NULL,
	[ApellidoAgente] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Agente] PRIMARY KEY CLUSTERED 
(
	[IdAgente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AsigDetalle]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AsigDetalle](
	[IdAsigDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdAsignacion] [int] NOT NULL,
	[IdInventario] [int] NOT NULL,
	[IdSolicitudDetalle] [int] NULL,
	[IdSolicitud] [int] NULL,
	[IdTipoAsignacion] [int] NOT NULL,
	[IdAgente] [int] NULL,
	[Observacion] [varchar](300) NULL,
	[TiempoAsignacion] [int] NULL,
	[IdBien] [int] NOT NULL,
 CONSTRAINT [PK_AsigDetalle] PRIMARY KEY CLUSTERED 
(
	[IdAsigDetalle] ASC,
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdDependencia] [int] NOT NULL,
 CONSTRAINT [PK_Asignacion] PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bien]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bien](
	[IdBien] [int] IDENTITY(1,1) NOT NULL,
	[IdSubCategoria] [int] NOT NULL,
	[DescripBien] [varchar](300) NOT NULL,
	[Homologado] [bit] NOT NULL,
	[IdTipoLicencia] [int] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdModeloVersion] [int] NULL,
 CONSTRAINT [PK_Bien] PRIMARY KEY CLUSTERED 
(
	[IdBien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
	[DescripCargo] [varchar](100) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripCategoria] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[IdCotizacion] [int] IDENTITY(1,1) NOT NULL,
	[MontoCotizado] [money] NOT NULL,
	[FechaCotizacion] [datetime] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdPartidaDetalle] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
 CONSTRAINT [PK_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dependencia]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dependencia](
	[IdDependencia] [int] IDENTITY(1,1) NOT NULL,
	[NombreDependencia] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Dependencia] PRIMARY KEY CLUSTERED 
(
	[IdDependencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Deposito]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Deposito](
	[IdDeposito] [int] IDENTITY(1,1) NOT NULL,
	[NombreDeposito] [varchar](100) NOT NULL,
	[IdDireccion] [int] NOT NULL,
 CONSTRAINT [PK_Deposito] PRIMARY KEY CLUSTERED 
(
	[IdDeposito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Direccion](
	[IdDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Calle] [varchar](100) NOT NULL,
	[NumeroCalle] [varchar](100) NOT NULL,
	[Localidad] [varchar](100) NULL,
	[IdProvincia] [int] NULL,
	[Piso] [varchar](10) NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoInventario]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoInventario](
	[IdEstadoInventario] [int] IDENTITY(1,1) NOT NULL,
	[DescripEstadoInv] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoInventario] PRIMARY KEY CLUSTERED 
(
	[IdEstadoInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoSolDetalle]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoSolDetalle](
	[IdEstadoSolDetalle] [int] IDENTITY(1,1) NOT NULL,
	[DescripSolDetalle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoSolDetalle] PRIMARY KEY CLUSTERED 
(
	[IdEstadoSolDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoSolicitud](
	[IdEstadoSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[DescripEstadoSolic] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoSolicitud] PRIMARY KEY CLUSTERED 
(
	[IdEstadoSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdBien] [int] NOT NULL,
	[SerialMaster] [nvarchar](300) NULL,
	[SerieKey] [nvarchar](300) NOT NULL,
	[FechaSuscrip] [datetime] NULL,
	[FechaFinSuscrip] [datetime] NULL,
	[IdAdquisicion] [int] NOT NULL,
	[IdDeposito] [int] NOT NULL,
	[IdEstadoInventario] [int] NOT NULL,
	[DescripTipoBien] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC,
	[IdBien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[DescripMarca] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ModeloVersion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ModeloVersion](
	[IdModeloVersion] [int] IDENTITY(1,1) NOT NULL,
	[DescripModeloVersion] [varchar](300) NOT NULL,
 CONSTRAINT [PK_ModeloVersion] PRIMARY KEY CLUSTERED 
(
	[IdModeloVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nota](
	[IdNota] [int] IDENTITY(1,1) NOT NULL,
	[FechaNota] [datetime] NOT NULL,
	[DescripNota] [varchar](500) NULL,
	[IdUsuario] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[IdNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Partida]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partida](
	[IdPartida] [int] IDENTITY(1,1) NOT NULL,
	[MontoSolicitado] [money] NOT NULL,
	[MontoOtorgado] [money] NULL,
	[NroPartida] [varchar](10) NULL,
	[FechaEnvio] [datetime] NOT NULL,
	[FechaAcreditacion] [datetime] NULL,
 CONSTRAINT [PK_Partida] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PartidaDetalle]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidaDetalle](
	[IdPartidaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdPartida] [int] NOT NULL,
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdAdquisicion] [int] NULL,
	[IdSolicitud] [int] NOT NULL,
 CONSTRAINT [PK_PartidaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdPartidaDetalle] ASC,
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prioridad]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prioridad](
	[IdPrioridad] [int] IDENTITY(1,1) NOT NULL,
	[DescripPrioridad] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Prioridad] PRIMARY KEY CLUSTERED 
(
	[IdPrioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[NombreProveedor] [varchar](100) NOT NULL,
	[ContactoProveedor] [varchar](100) NULL,
	[MailProveedor] [nvarchar](200) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[IdProvincia] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RelCotSolDetalle]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelCotSolDetalle](
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdCotizacion] [int] NOT NULL,
 CONSTRAINT [PK_RelCotSolDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC,
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelDepAgenteCargo]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelDepAgenteCargo](
	[IdAgente] [int] NOT NULL,
	[IdDependencia] [int] NOT NULL,
	[IdCargo] [int] NOT NULL,
 CONSTRAINT [PK_RelDepAgenteCargo] PRIMARY KEY CLUSTERED 
(
	[IdAgente] ASC,
	[IdDependencia] ASC,
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelProveedorDire]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelProveedorDire](
	[IdProveedor] [int] NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_RelProveedorDire] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC,
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelProveedorTel]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelProveedorTel](
	[IdProveedor] [int] NOT NULL,
	[IdTelefono] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_RelProveedorTel] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC,
	[IdTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelSolDetalleAgente]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelSolDetalleAgente](
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdAgente] [int] NOT NULL,
 CONSTRAINT [PK_RelSolDetalleAgente] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC,
	[IdAgente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rendicion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rendicion](
	[IdRendicion] [int] IDENTITY(1,1) NOT NULL,
	[MontoGasto] [money] NOT NULL,
	[IdPartida] [int] NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[IdRendicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolicDetalle]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicDetalle](
	[IdSolicitudDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdSubCategoria] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdEstadoSolDetalle] [int] NOT NULL,
 CONSTRAINT [PK_SolicDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[IdSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NULL,
	[IdDependencia] [int] NOT NULL,
	[IdPrioridad] [int] NOT NULL,
	[IdResponsable] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategoria]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubCategoria](
	[IdSubCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripSubcategoria] [varchar](300) NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_SubCategoria] PRIMARY KEY CLUSTERED 
(
	[IdSubCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[IdTelefono] [int] IDENTITY(1,1) NOT NULL,
	[CodArea] [int] NOT NULL,
	[NroTelefono] [int] NOT NULL,
	[IdTipoTelefono] [int] NOT NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[IdTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoAdquisicion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoAdquisicion](
	[IdTipoAdquisicion] [int] IDENTITY(1,1) NOT NULL,
	[DescripTipoAdq] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoAdquisicion] PRIMARY KEY CLUSTERED 
(
	[IdTipoAdquisicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoAsignacion]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoAsignacion](
	[IdTipoAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[DescripTipoAsig] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoAsignacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 02/04/2017 14:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoTelefono](
	[IdTipoTelefono] [int] IDENTITY(1,1) NOT NULL,
	[DescripTipoTel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoTelefono] PRIMARY KEY CLUSTERED 
(
	[IdTipoTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Adquisicion]  WITH CHECK ADD  CONSTRAINT [FK_Adquisicion_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Adquisicion] CHECK CONSTRAINT [FK_Adquisicion_Proveedor]
GO
ALTER TABLE [dbo].[Adquisicion]  WITH CHECK ADD  CONSTRAINT [FK_Adquisicion_Rendicion] FOREIGN KEY([IdRendicion])
REFERENCES [dbo].[Rendicion] ([IdRendicion])
GO
ALTER TABLE [dbo].[Adquisicion] CHECK CONSTRAINT [FK_Adquisicion_Rendicion]
GO
ALTER TABLE [dbo].[Adquisicion]  WITH CHECK ADD  CONSTRAINT [FK_Adquisicion_TipoAdquisicion] FOREIGN KEY([IdTipoAdquisicion])
REFERENCES [dbo].[TipoAdquisicion] ([IdTipoAdquisicion])
GO
ALTER TABLE [dbo].[Adquisicion] CHECK CONSTRAINT [FK_Adquisicion_TipoAdquisicion]
GO
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_Agente] FOREIGN KEY([IdAgente])
REFERENCES [dbo].[Agente] ([IdAgente])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_Agente]
GO
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_Asignacion] FOREIGN KEY([IdAsignacion])
REFERENCES [dbo].[Asignacion] ([IdAsignacion])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_Asignacion]
GO
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_Inventario] FOREIGN KEY([IdInventario], [IdBien])
REFERENCES [dbo].[Inventario] ([IdInventario], [IdBien])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_Inventario]
GO
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_SolicDetalle]
GO
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_TipoAsignacion] FOREIGN KEY([IdTipoAsignacion])
REFERENCES [dbo].[TipoAsignacion] ([IdTipoAsignacion])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_TipoAsignacion]
GO
ALTER TABLE [dbo].[Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Dependencia] FOREIGN KEY([IdDependencia])
REFERENCES [dbo].[Dependencia] ([IdDependencia])
GO
ALTER TABLE [dbo].[Asignacion] CHECK CONSTRAINT [FK_Asignacion_Dependencia]
GO
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_Bien_Marca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([IdMarca])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_Bien_Marca]
GO
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_Bien_ModeloVersion] FOREIGN KEY([IdModeloVersion])
REFERENCES [dbo].[ModeloVersion] ([IdModeloVersion])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_Bien_ModeloVersion]
GO
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_Bien_SubCategoria] FOREIGN KEY([IdSubCategoria])
REFERENCES [dbo].[SubCategoria] ([IdSubCategoria])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_Bien_SubCategoria]
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Cotizacion_PartidaDetalle] FOREIGN KEY([IdPartidaDetalle], [IdPartida])
REFERENCES [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_Cotizacion_PartidaDetalle]
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Cotizacion_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_Cotizacion_Proveedor]
GO
ALTER TABLE [dbo].[Deposito]  WITH CHECK ADD  CONSTRAINT [FK_Deposito_Direccion] FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([IdDireccion])
GO
ALTER TABLE [dbo].[Deposito] CHECK CONSTRAINT [FK_Deposito_Direccion]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Provincia] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([IdProvincia])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Provincia]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Adquisicion] FOREIGN KEY([IdAdquisicion])
REFERENCES [dbo].[Adquisicion] ([IdAdquisicion])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Adquisicion]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Bien] FOREIGN KEY([IdBien])
REFERENCES [dbo].[Bien] ([IdBien])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Bien]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Deposito] FOREIGN KEY([IdDeposito])
REFERENCES [dbo].[Deposito] ([IdDeposito])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Deposito]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Estado] FOREIGN KEY([IdEstadoInventario])
REFERENCES [dbo].[EstadoInventario] ([IdEstadoInventario])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Estado]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Solicitud] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[Solicitud] ([IdSolicitud])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Solicitud]
GO
ALTER TABLE [dbo].[PartidaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PartidaDetalle_Adquisicion] FOREIGN KEY([IdAdquisicion])
REFERENCES [dbo].[Adquisicion] ([IdAdquisicion])
GO
ALTER TABLE [dbo].[PartidaDetalle] CHECK CONSTRAINT [FK_PartidaDetalle_Adquisicion]
GO
ALTER TABLE [dbo].[PartidaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PartidaDetalle_Partida] FOREIGN KEY([IdPartida])
REFERENCES [dbo].[Partida] ([IdPartida])
GO
ALTER TABLE [dbo].[PartidaDetalle] CHECK CONSTRAINT [FK_PartidaDetalle_Partida]
GO
ALTER TABLE [dbo].[PartidaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PartidaDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud])
GO
ALTER TABLE [dbo].[PartidaDetalle] CHECK CONSTRAINT [FK_PartidaDetalle_SolicDetalle]
GO
ALTER TABLE [dbo].[RelCotSolDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotSolDetalle_Cotizacion] FOREIGN KEY([IdCotizacion])
REFERENCES [dbo].[Cotizacion] ([IdCotizacion])
GO
ALTER TABLE [dbo].[RelCotSolDetalle] CHECK CONSTRAINT [FK_RelCotSolDetalle_Cotizacion]
GO
ALTER TABLE [dbo].[RelCotSolDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotSolDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud])
GO
ALTER TABLE [dbo].[RelCotSolDetalle] CHECK CONSTRAINT [FK_RelCotSolDetalle_SolicDetalle]
GO
ALTER TABLE [dbo].[RelDepAgenteCargo]  WITH CHECK ADD  CONSTRAINT [FK_RelDepAgenteCar_Agente] FOREIGN KEY([IdAgente])
REFERENCES [dbo].[Agente] ([IdAgente])
GO
ALTER TABLE [dbo].[RelDepAgenteCargo] CHECK CONSTRAINT [FK_RelDepAgenteCar_Agente]
GO
ALTER TABLE [dbo].[RelDepAgenteCargo]  WITH CHECK ADD  CONSTRAINT [FK_RelDepAgenteCar_Cargo] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[Cargo] ([IdCargo])
GO
ALTER TABLE [dbo].[RelDepAgenteCargo] CHECK CONSTRAINT [FK_RelDepAgenteCar_Cargo]
GO
ALTER TABLE [dbo].[RelDepAgenteCargo]  WITH CHECK ADD  CONSTRAINT [FK_RelDepAgenteCar_Dependencia] FOREIGN KEY([IdDependencia])
REFERENCES [dbo].[Dependencia] ([IdDependencia])
GO
ALTER TABLE [dbo].[RelDepAgenteCargo] CHECK CONSTRAINT [FK_RelDepAgenteCar_Dependencia]
GO
ALTER TABLE [dbo].[RelProveedorDire]  WITH CHECK ADD  CONSTRAINT [FK_RelProveedorDire_Direccion] FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([IdDireccion])
GO
ALTER TABLE [dbo].[RelProveedorDire] CHECK CONSTRAINT [FK_RelProveedorDire_Direccion]
GO
ALTER TABLE [dbo].[RelProveedorDire]  WITH CHECK ADD  CONSTRAINT [FK_RelProveedorDire_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[RelProveedorDire] CHECK CONSTRAINT [FK_RelProveedorDire_Proveedor]
GO
ALTER TABLE [dbo].[RelProveedorTel]  WITH CHECK ADD  CONSTRAINT [FK_RelProveedorTel_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[RelProveedorTel] CHECK CONSTRAINT [FK_RelProveedorTel_Proveedor]
GO
ALTER TABLE [dbo].[RelProveedorTel]  WITH CHECK ADD  CONSTRAINT [FK_RelProveedorTel_Telefono] FOREIGN KEY([IdTelefono])
REFERENCES [dbo].[Telefono] ([IdTelefono])
GO
ALTER TABLE [dbo].[RelProveedorTel] CHECK CONSTRAINT [FK_RelProveedorTel_Telefono]
GO
ALTER TABLE [dbo].[RelSolDetalleAgente]  WITH CHECK ADD  CONSTRAINT [FK_RelSolDetalleAgente_Agente] FOREIGN KEY([IdAgente])
REFERENCES [dbo].[Agente] ([IdAgente])
GO
ALTER TABLE [dbo].[RelSolDetalleAgente] CHECK CONSTRAINT [FK_RelSolDetalleAgente_Agente]
GO
ALTER TABLE [dbo].[RelSolDetalleAgente]  WITH CHECK ADD  CONSTRAINT [FK_RelSolDetalleAgente_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud])
GO
ALTER TABLE [dbo].[RelSolDetalleAgente] CHECK CONSTRAINT [FK_RelSolDetalleAgente_SolicDetalle]
GO
ALTER TABLE [dbo].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Rendicion_Partida] FOREIGN KEY([IdPartida])
REFERENCES [dbo].[Partida] ([IdPartida])
GO
ALTER TABLE [dbo].[Rendicion] CHECK CONSTRAINT [FK_Rendicion_Partida]
GO
ALTER TABLE [dbo].[SolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicDetalle_EstadoSolDetalle] FOREIGN KEY([IdEstadoSolDetalle])
REFERENCES [dbo].[EstadoSolDetalle] ([IdEstadoSolDetalle])
GO
ALTER TABLE [dbo].[SolicDetalle] CHECK CONSTRAINT [FK_SolicDetalle_EstadoSolDetalle]
GO
ALTER TABLE [dbo].[SolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicDetalle_Solicitud] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[Solicitud] ([IdSolicitud])
GO
ALTER TABLE [dbo].[SolicDetalle] CHECK CONSTRAINT [FK_SolicDetalle_Solicitud]
GO
ALTER TABLE [dbo].[SolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicDetalle_SubCategoria] FOREIGN KEY([IdSubCategoria])
REFERENCES [dbo].[SubCategoria] ([IdSubCategoria])
GO
ALTER TABLE [dbo].[SolicDetalle] CHECK CONSTRAINT [FK_SolicDetalle_SubCategoria]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Dependencia] FOREIGN KEY([IdDependencia])
REFERENCES [dbo].[Dependencia] ([IdDependencia])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Dependencia]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoSolicitud] ([IdEstadoSolicitud])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Estado]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Prioridad] FOREIGN KEY([IdPrioridad])
REFERENCES [dbo].[Prioridad] ([IdPrioridad])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Prioridad]
GO
ALTER TABLE [dbo].[SubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_SubCategoria_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[SubCategoria] CHECK CONSTRAINT [FK_SubCategoria_Categoria]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_TipoTelefono] FOREIGN KEY([IdTipoTelefono])
REFERENCES [dbo].[TipoTelefono] ([IdTipoTelefono])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_TipoTelefono]
GO
USE [master]
GO
ALTER DATABASE [Artec] SET  READ_WRITE 
GO
