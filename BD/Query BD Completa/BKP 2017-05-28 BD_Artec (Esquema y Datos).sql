USE [master]
GO
/****** Object:  Database [Artec]    Script Date: 28/05/2017 23:04:04 ******/
CREATE DATABASE [Artec] ON  PRIMARY 
( NAME = N'Artec', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Artec.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Artec_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Artec_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  StoredProcedure [dbo].[BaseDatosRespaldar]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BaseDatosRespaldar]
(
	@Nombre varchar(50),
	@Destino varchar(300),
	@Obser varchar(500)
)


AS
BEGIN

BACKUP DATABASE Artec TO DISK = @Destino WITH DESCRIPTION = @Obser, NOFORMAT, NOINIT, NAME = @Nombre, SKIP, NOREWIND, NOUNLOAD,  STATS = 10

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, Bi.IdBien, TB.IdTipoBien 
FROM Categoria Cat
INNER JOIN Bien Bi
ON Bi.IdCategoria = Cat.IdCategoria
INNER JOIN TipoBien TB
ON TB.IdTipoBien = BI.IdTipoBien


END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHard]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosHard]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria
FROM Categoria Cat
INNER JOIN Bien Bi
ON Bi.IdCategoria = Cat.IdCategoria
INNER JOIN TipoBien TB
ON TB.IdTipoBien = BI.IdTipoBien
WHERE TB.IdTipoBien = 1

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoft]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[CategoriaTraerTodosSoft]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria
FROM Categoria Cat
INNER JOIN Bien Bi
ON Bi.IdCategoria = Cat.IdCategoria
INNER JOIN TipoBien TB
ON TB.IdTipoBien = BI.IdTipoBien
WHERE TB.IdTipoBien = 2

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionConteo]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionConteo]
(
	@IdSolicitud int
)


AS
BEGIN

	SET NOCOUNT ON;

select IdSolicitudDetalle, ISNULL(COUNT(IdCotizacion),0) as Cotizaciones
from RelCotSolDetalle
WHERE IdSolicitud = @IdSolicitud
group by IdSolicitudDetalle

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionCrear]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionCrear]
(
	@MontoCotizado money,
	@FechaCotizacion datetime,
	@IdProveedor int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Cotizacion(MontoCotizado, FechaCotizacion, IdProveedor)
VALUES (@MontoCotizado, @FechaCotizacion, @IdProveedor)

select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionCrearRelSolicDetalle]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionCrearRelSolicDetalle]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@IdCotizacion int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelCotSolDetalle(IdSolicitudDetalle, IdSolicitud, IdCotizacion)
VALUES (@IdSolicitudDetalle, @IdSolicitud, @IdCotizacion)

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitud]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionTraerPorSolicitud]
(
	@IdSolicitud int
)


AS
BEGIN

	SET NOCOUNT ON;

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Coti.IdPartidaDetalle, Coti.IdPartida, Det.IdSolicitudDetalle, Det.IdSolicitud
from Cotizacion Coti
INNER JOIN Proveedor Prov
ON Coti.IdProveedor = Prov.IdProveedor
INNER JOIN RelCotSolDetalle Rel
ON Coti.IdCotizacion = Rel.IdCotizacion
INNER JOIN SolicDetalle Det
ON Rel.IdSolicitud = Det.IdSolicitud AND Rel.IdSolicitudDetalle = Det.IdSolicitudDetalle
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
WHERE Sol.IdSolicitud = @IdSolicitud

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitudYDetalle]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionTraerPorSolicitudYDetalle]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int
)


AS
BEGIN

	SET NOCOUNT ON;

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Coti.IdPartidaDetalle, Coti.IdPartida, Det.IdSolicitudDetalle, Det.IdSolicitud
from Cotizacion Coti
INNER JOIN Proveedor Prov
ON Coti.IdProveedor = Prov.IdProveedor
INNER JOIN RelCotSolDetalle Rel
ON Coti.IdCotizacion = Rel.IdCotizacion
INNER JOIN SolicDetalle Det
ON Rel.IdSolicitud = Det.IdSolicitud AND Rel.IdSolicitudDetalle = Det.IdSolicitudDetalle
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
WHERE Sol.IdSolicitud = @IdSolicitud
AND Det.IdSolicitudDetalle = @IdSolicitudDetalle

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesPorIdDependencia]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaTraerAgentesPorIdDependencia]
(
	@IdDependencia INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Ag.IdAgente, Ag.NombreAgente, Ag.ApellidoAgente
FROM Agente Ag
INNER JOIN RelDepAgenteCargo Rel
ON Ag.IdAgente = Rel.IdAgente
WHERE Rel.IdDependencia = @IdDependencia

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesResp]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaTraerAgentesResp]
(
	@IdDependencia INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Ag.IdAgente, Ag.NombreAgente, Ag.ApellidoAgente
FROM Agente Ag
INNER JOIN RelDepAgenteCargo Rel
ON Ag.IdAgente = Rel.IdAgente
INNER JOIN Cargo Car
ON Rel.IdCargo = Car.IdCargo
WHERE Rel.IdDependencia = @IdDependencia
AND (Car.DescripCargo = 'Secretario'
OR Car.DescripCargo = 'Fiscal')

END


GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolDetallesTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EstadoSolDetallesTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM EstadoSolicDetalle

 
END

GO
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EstadoSolicitudTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM EstadoSolicitud

 
END

GO
/****** Object:  StoredProcedure [dbo].[EtiquetasTraerTodosPorIdioma]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EtiquetasTraerTodosPorIdioma]
(
	@IdIdioma INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM Etiqueta
WHERE IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[EtiquetaTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EtiquetaTraerTodos]

AS

SET NOCOUNT ON

SELECT *
FROM Etiqueta
GO
/****** Object:  StoredProcedure [dbo].[IdiomaActualizarIdiomaActual]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdiomaActualizarIdiomaActual]
(
	@IdIdioma INT,
	@IdiomaActual bit
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Idioma
SET IdiomaActual = @IdiomaActual
WHERE IdIdioma = @IdIdioma


END

GO
/****** Object:  StoredProcedure [dbo].[IdiomaTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdiomaTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM Idioma


END

GO
/****** Object:  StoredProcedure [dbo].[PoliticaPorDepYCategCantidad]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PoliticaPorDepYCategCantidad]
(
	@IdDependencia INT,
	@IdCategoria int
)


AS
BEGIN

	SET NOCOUNT ON;

select ISNULL(SUM(Det.Cantidad),0) as CantidadSolicitada
FROM SolicDetalle Det
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
INNER JOIN Dependencia Dep
ON Sol.IdDependencia = Dep.IdDependencia
WHERE Det.IdCategoria = @IdCategoria
AND Dep.IdDependencia = @IdDependencia
AND Sol.FechaInicio >= DATEADD(d, -30, GETDATE())



END

GO
/****** Object:  StoredProcedure [dbo].[PoliticaTraerPorTipoDepYCat]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PoliticaTraerPorTipoDepYCat]
(
	@IdTipoDependencia INT,
	@IdCategoria int
)


AS
BEGIN

	SET NOCOUNT ON;

select * from Politica Pol
Where pol.IdCategoria = @IdCategoria
AND pol.IdTipoDependencia = @IdTipoDependencia



END

GO
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[PrioridadTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
from Prioridad


END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
from Proveedor


END

GO
/****** Object:  StoredProcedure [dbo].[Prueba]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Prueba]



AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM Dependencia Dep
INNER JOIN TipoDependencia Tipo
ON Dep.IdTipoDependencia = Tipo.IdTipoDependencia



END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerPorNroSolicitud]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallesTraerPorNroSolicitud]
(
	@NroSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Det.IdSolicitudDetalle, Det.Cantidad, Est.IdEstadoSolicDetalle, Est.DescripEstadoSolicDetalle, Cat.IdCategoria, Cat.DescripCategoria
FROM SolicDetalle Det
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
INNER JOIN EstadoSolicDetalle Est
ON Det.IdEstadoSolicDetalle = Est.IdEstadoSolicDetalle
INNER JOIN Categoria Cat
ON Det.IdCategoria = Cat.IdCategoria
WHERE Sol.IdSolicitud = @NroSolicitud


END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudCrear]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudCrear]
(
	@FechaInicio Datetime,
	@IdDependencia int,
	@IdPrioridad int,
	@IdEstado int,
	@IdUsuario int,
	@IdAgente int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Solicitud (FechaInicio, IdDependencia,  IdPrioridad, IdEstado, IdUsuario, IdAgente)
VALUES (@FechaInicio, @IdDependencia, @IdPrioridad, @IdEstado, @IdUsuario, @IdAgente)

select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudDetalleCrear]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudDetalleCrear]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@IdCategoria int,
	@Cantidad int,
	@IdEstadoSolDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO SolicDetalle(IdSolicitudDetalle, IdSolicitud, IdCategoria, Cantidad, IdEstadoSolicDetalle)
VALUES (@IdSolicitudDetalle, @IdSolicitud, @IdCategoria, @Cantidad, @IdEstadoSolDetalle)



END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerPorNroSolicitud]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerPorNroSolicitud]
(
	@NroSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Sol.FechaFin, Sol.FechaInicio, Sol.IdSolicitud, Dep.IdDependencia, Dep.NombreDependencia, Pri.IdPrioridad, Pri.DescripPrioridad, Est.IdEstadoSolicitud, Est.DescripEstadoSolic, Us.IdUsuario, Us.NombreUsuario, Ag.IdAgente, Ag.ApellidoAgente
FROM Solicitud Sol
INNER JOIN Dependencia Dep
ON Sol.IdDependencia = Dep.IdDependencia
INNER JOIN Prioridad Pri
ON Sol.IdPrioridad = Pri.IdPrioridad
INNER JOIN EstadoSolicitud Est
ON Sol.IdEstado = Est.IdEstadoSolicitud
INNER JOIN Usuario Us
ON Sol.IdUsuario = Us.IdUsuario
LEFT JOIN Agente Ag
ON Sol.IdAgente = Ag.IdAgente
WHERE Sol.IdSolicitud = @NroSolicitud

END

GO
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTipoBienPorIdCategoria]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TipoBienTraerTipoBienPorIdCategoria]
(
	@IdCategoria INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT TB.IdTipoBien, TB.DescripTipoBien
FROM TipoBien TB
INNER JOIN Bien 
ON TB.IdTipoBien = Bien.IdTipoBien
INNER JOIN Categoria Cat
ON Bien.IdCategoria = Cat.IdCategoria
WHERE Cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TipoBienTraerTodos]

AS

SET NOCOUNT ON

SELECT *
FROM TipoBien
GO
/****** Object:  StoredProcedure [dbo].[TipoDependenciaTraerPorDependencia]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TipoDependenciaTraerPorDependencia]
(
	@IdDependencia INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT TipoDep.IdTipoDependencia, TipoDep.DescripTipoDependencia
FROM TipoDependencia TipoDep
INNER JOIN Dependencia Dep
ON TipoDep.IdTipoDependencia = Dep.IdTipoDependencia
WHERE Dep.IdDependencia = @IdDependencia

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPorLogin]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerPorLogin]
(
	@Us varchar(30),
	@Pass nvarchar(200)
)

AS
BEGIN

	SET NOCOUNT ON;

SELECT * 
from Usuario
WHERE NombreUsuario = @Us
AND Pass = @Pass


END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodos]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM usuario


END

GO
/****** Object:  Table [dbo].[Adquisicion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Agente]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[AsigDetalle]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Asignacion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Bien]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bien](
	[IdBien] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[DescripBien] [varchar](300) NOT NULL,
	[Homologado] [bit] NOT NULL,
	[IdTipoLicencia] [int] NULL,
	[IdMarca] [int] NOT NULL,
	[IdModeloVersion] [int] NULL,
	[IdTipoBien] [int] NOT NULL,
 CONSTRAINT [PK_Bien] PRIMARY KEY CLUSTERED 
(
	[IdBien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripCategoria] [varchar](300) NOT NULL,
	[IdProveedor] [int] NULL,
 CONSTRAINT [PK_SubCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[IdCotizacion] [int] IDENTITY(1,1) NOT NULL,
	[MontoCotizado] [money] NOT NULL,
	[FechaCotizacion] [datetime] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdPartidaDetalle] [int] NULL,
	[IdPartida] [int] NULL,
 CONSTRAINT [PK_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dependencia]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dependencia](
	[IdDependencia] [int] IDENTITY(1,1) NOT NULL,
	[NombreDependencia] [varchar](300) NOT NULL,
	[IdTipoDependencia] [int] NOT NULL,
 CONSTRAINT [PK_Dependencia] PRIMARY KEY CLUSTERED 
(
	[IdDependencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Deposito]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Direccion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[EstadoInventario]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[EstadoSolicDetalle]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoSolicDetalle](
	[IdEstadoSolicDetalle] [int] IDENTITY(1,1) NOT NULL,
	[DescripEstadoSolicDetalle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoSolDetalle] PRIMARY KEY CLUSTERED 
(
	[IdEstadoSolicDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Etiqueta](
	[NombreControl] [nvarchar](300) NOT NULL,
	[Texto] [varchar](200) NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[IdFormulario] [int] NOT NULL,
 CONSTRAINT [PK_MultiIdioma] PRIMARY KEY CLUSTERED 
(
	[NombreControl] ASC,
	[Texto] ASC,
	[IdIdioma] ASC,
	[IdFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Formulario]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Formulario](
	[IdFormulario] [int] IDENTITY(1,1) NOT NULL,
	[NombreFormulario] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Formulario] PRIMARY KEY CLUSTERED 
(
	[IdFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[NombreIdioma] [varchar](30) NOT NULL,
	[IdiomaActual] [bit] NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdBienEspecif] [int] NOT NULL,
	[SerialMaster] [nvarchar](300) NULL,
	[SerieKey] [nvarchar](300) NOT NULL,
	[FechaSuscrip] [datetime] NULL,
	[FechaFinSuscrip] [datetime] NULL,
	[IdAdquisicion] [int] NOT NULL,
	[IdDeposito] [int] NOT NULL,
	[IdEstadoInventario] [int] NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC,
	[IdBienEspecif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Limite]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Limite](
	[IdLimite] [int] IDENTITY(1,1) NOT NULL,
	[DescripLimite] [varchar](50) NOT NULL,
	[ValorLimite] [money] NOT NULL,
 CONSTRAINT [PK_Limite] PRIMARY KEY CLUSTERED 
(
	[IdLimite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[ModeloVersion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Nota]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Partida]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[PartidaDetalle]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Politica]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Politica](
	[IdTipoDependencia] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Politica] PRIMARY KEY CLUSTERED 
(
	[IdTipoDependencia] ASC,
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prioridad]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocialProv] [varchar](100) NOT NULL,
	[AliasProv] [varchar](100) NOT NULL,
	[ContactoProv] [varchar](100) NULL,
	[MailContactoProv] [nvarchar](200) NULL,
	[MailAlternativoProv] [nvarchar](200) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[RelCotSolDetalle]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[RelDepAgenteCargo]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[RelProveedorDire]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[RelProveedorTel]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[RelSolDetalleAgente]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Rendicion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[SolicDetalle]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicDetalle](
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdEstadoSolicDetalle] [int] NOT NULL,
 CONSTRAINT [PK_SolicDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 28/05/2017 23:04:05 ******/
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
	[IdEstado] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdAgente] [int] NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[TipoAdquisicion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[TipoAsignacion]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[TipoBien]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoBien](
	[IdTipoBien] [int] IDENTITY(1,1) NOT NULL,
	[DescripTipoBien] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdTipoBien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDependencia]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDependencia](
	[IdTipoDependencia] [int] IDENTITY(1,1) NOT NULL,
	[DescripTipoDependencia] [varchar](30) NULL,
 CONSTRAINT [PK_TipoDependencia] PRIMARY KEY CLUSTERED 
(
	[IdTipoDependencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoLicencia]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoLicencia](
	[IdTipoLicencia] [int] IDENTITY(1,1) NOT NULL,
	[DescripTipoLicencia] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TipoLicencia] PRIMARY KEY CLUSTERED 
(
	[IdTipoLicencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 28/05/2017 23:04:05 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/05/2017 23:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](30) NOT NULL,
	[Pass] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_IdUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Agente] ON 

INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (1, N'Pablo', N'Diez')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (2, N'Gustavo', N'Ripamonti')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (3, N'Damian', N'Daniel')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (4, N'Mariano', N'Marcovecchio')
SET IDENTITY_INSERT [dbo].[Agente] OFF
SET IDENTITY_INSERT [dbo].[Bien] ON 

INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdTipoLicencia], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (1, 3, N'PC', 1, NULL, 1, 2, 1)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdTipoLicencia], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (2, 5, N'Office 2016', 1, 1, 4, 4, 2)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdTipoLicencia], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (3, 2, N'Notebook', 1, NULL, 1, 5, 1)
SET IDENTITY_INSERT [dbo].[Bien] OFF
SET IDENTITY_INSERT [dbo].[Cargo] ON 

INSERT [dbo].[Cargo] ([IdCargo], [DescripCargo]) VALUES (1, N'Escribiente')
INSERT [dbo].[Cargo] ([IdCargo], [DescripCargo]) VALUES (2, N'Escribiente Auxiliar')
INSERT [dbo].[Cargo] ([IdCargo], [DescripCargo]) VALUES (3, N'Secretario')
INSERT [dbo].[Cargo] ([IdCargo], [DescripCargo]) VALUES (4, N'Fiscal')
SET IDENTITY_INSERT [dbo].[Cargo] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdProveedor]) VALUES (1, N'Disco Externo 1TB', NULL)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdProveedor]) VALUES (2, N'Notebook', NULL)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdProveedor]) VALUES (3, N'PC', NULL)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdProveedor]) VALUES (4, N'Ultrabook', NULL)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdProveedor]) VALUES (5, N'Office', NULL)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdProveedor]) VALUES (6, N'Scanner de Mano', NULL)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Cotizacion] ON 

INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (1, 200.0000, CAST(0x0000A72B00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (2, 300.0000, CAST(0x0000A72B00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (3, 450.0000, CAST(0x0000A72B00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (4, 300.0000, CAST(0x0000A77500000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (5, 400.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (6, 390.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (7, 200.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (8, 250.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (9, 250.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (10, 250.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (11, 390.0000, CAST(0x0000A77500000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (12, 300.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (13, 300.0000, CAST(0x0000A77500000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (14, 300.0000, CAST(0x0000A77500000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (15, 300.0000, CAST(0x0000A77500000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (16, 300.0000, CAST(0x0000A77500000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (17, 399.0000, CAST(0x0000A77500000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (18, 400.0000, CAST(0x0000A77500000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (19, 300.0000, CAST(0x0000A77600000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (20, 400.0000, CAST(0x0000A77900000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (21, 359.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (22, 356.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (23, 333.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (24, 334.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (25, 337.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (26, 356.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (27, 500.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (28, 501.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (29, 502.0000, CAST(0x0000A77A00000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (30, 503.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (31, 504.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (32, 505.0000, CAST(0x0000A77A00000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (33, 506.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (34, 507.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (35, 508.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (36, 509.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (37, 510.0000, CAST(0x0000A77A00000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (38, 511.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (39, 512.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (40, 502.0000, CAST(0x0000A77A00000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (41, 444.0000, CAST(0x0000A77A00000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (42, 513.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (43, 445.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (44, 446.0000, CAST(0x0000A77A00000000 AS DateTime), 2, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (45, 447.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (46, 448.0000, CAST(0x0000A77A00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (47, 449.0000, CAST(0x0000A77A00000000 AS DateTime), 3, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (48, 400.0000, CAST(0x0000A77D00000000 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor], [IdPartidaDetalle], [IdPartida]) VALUES (49, 457.0000, CAST(0x0000A77F00000000 AS DateTime), 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cotizacion] OFF
SET IDENTITY_INSERT [dbo].[Dependencia] ON 

INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (1, N'Fiscalia Nacional en lo Criminal y Correccional Nro 1', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (2, N'Fiscalia Nacional en lo Criminal y Correccional Nro 2', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (3, N'Fiscalia Nacional en lo Criminal y Correccional Nro 3', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (4, N'Fiscalia en lo Criminal de Instruccion Nro 1', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (5, N'Procuraduría Lavado de Activos', 2)
SET IDENTITY_INSERT [dbo].[Dependencia] OFF
SET IDENTITY_INSERT [dbo].[EstadoSolicDetalle] ON 

INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (2, N'Finalizado')
SET IDENTITY_INSERT [dbo].[EstadoSolicDetalle] OFF
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] ON 

INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (2, N'Finalizada')
INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (3, N'Cerrada')
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] OFF
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'Backup', N'Respaldo y Restauración de la Base de Datos', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnAgregarProd', N'Add', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnAgregarProd', N'Agregar', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnBuscar', N'Buscar', 1, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnCrearProveedor', N'Crear', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnCrearProveedor', N'New', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnDinBorrar', N'Quitar', 1, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnDireccion', N'Add', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnDireccion', N'Agregar', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnExaminarRespaldar', N'Examinar', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnExaminarRespaldar', N'Explore', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnExaminarRestaurar', N'Examinar', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnExaminarRestaurar', N'Explore', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnLogin', N'Ingresar', 1, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnLogin', N'Sign in', 2, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnRespaldar', N'Backup', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnRespaldar', N'Respaldar', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnRestaurar', N'Restaurar', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnRestaurar', N'Restore', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnTelefono', N'Add', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'btnTelefono', N'Agregar', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'gboxRespaldar', N'Backup', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'gboxRespaldar', N'Respaldar (Realizar Backup)', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'gboxRestaurar', N'Restaurar', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'gboxRestaurar', N'Restore', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'gpanelProductos', N'Productos', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'gpanelProductos', N'Products', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblAgenteResponsable', N'In Charge', 2, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblAgenteResponsable', N'Responsable', 1, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblAlias', N'Alias', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblAlias', N'Nickname', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblContacto', N'Contact', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblContacto', N'Contacto', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblDependencia', N'Dependex', 1, 6)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblDestinoRespaldar', N'Destino', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblDestinoRespaldar', N'Destiny', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblDireccion', N'Adress', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblDireccion', N'Dirección', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblMailContacto', N'Contact Mail', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblMailContacto', N'Mail del Contacto', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblMailEmpresa', N'Company Mail', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblMailEmpresa', N'Mail Alternativo', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblMailEmpresa', N'Mail de la Empresa', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblNombreRespaldar', N'Name', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblNombreRespaldar', N'Nombre', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblNombreRestaurar', N'Name', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblNombreRestaurar', N'Nombre', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblNroSolicitud', N'Solicitud', 1, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblObservaciones', N'Observaciones', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblObservaciones', N'Observations', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblPrueba', N'Esto es una prueba', 1, 5)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblPrueba', N'This is a test', 2, 5)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblRazonSocial', N'Company Name', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblRazonSocial', N'Razón Social', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblSalir', N'Exit', 2, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblSalir', N'Salir', 1, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblTelefono', N'Phone/s', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblTelefono', N'Teléfono/s', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblUbicacionRestaurar', N'Location', 2, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'lblUbicacionRestaurar', N'Ubicación', 1, 3)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'Mensaje1', N'Este pedido no cumple con las políticas de Informática ¿Desea continuar?', 1, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'Mensaje1', N'The request does not comply with the IT policies ¿Continue?', 2, 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'Mensaje2', N'Usuario y/o Contraseña incorrectos', 1, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'Mensaje2', N'Wrong User or Password ', 2, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'metroSolicitud', N'Crear Solicitud', 1, 6)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'pnlTitulo', N'Iniciar Sesion', 1, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'pnlTitulo', N'Sign in', 2, 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'ProveedorCrear', N'Crear Proveedor', 1, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'ProveedorCrear', N'New Supplier', 2, 4)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma], [IdFormulario]) VALUES (N'tabSolic', N'Solicitudes', 1, 6)
SET IDENTITY_INSERT [dbo].[Formulario] ON 

INSERT [dbo].[Formulario] ([IdFormulario], [NombreFormulario]) VALUES (1, N'Login')
INSERT [dbo].[Formulario] ([IdFormulario], [NombreFormulario]) VALUES (2, N'CrearSolicitud')
INSERT [dbo].[Formulario] ([IdFormulario], [NombreFormulario]) VALUES (3, N'Backup')
INSERT [dbo].[Formulario] ([IdFormulario], [NombreFormulario]) VALUES (4, N'ProveedorCrear')
INSERT [dbo].[Formulario] ([IdFormulario], [NombreFormulario]) VALUES (5, N'Prueba')
INSERT [dbo].[Formulario] ([IdFormulario], [NombreFormulario]) VALUES (6, N'Principal')
SET IDENTITY_INSERT [dbo].[Formulario] OFF
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [NombreIdioma], [IdiomaActual]) VALUES (1, N'Español', 1)
INSERT [dbo].[Idioma] ([IdIdioma], [NombreIdioma], [IdiomaActual]) VALUES (2, N'English', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
SET IDENTITY_INSERT [dbo].[Limite] ON 

INSERT [dbo].[Limite] ([IdLimite], [DescripLimite], [ValorLimite]) VALUES (1, N'MaximoCaja', 2000.0000)
SET IDENTITY_INSERT [dbo].[Limite] OFF
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([IdMarca], [DescripMarca]) VALUES (1, N'Dell')
INSERT [dbo].[Marca] ([IdMarca], [DescripMarca]) VALUES (2, N'HP')
INSERT [dbo].[Marca] ([IdMarca], [DescripMarca]) VALUES (3, N'Samsung')
INSERT [dbo].[Marca] ([IdMarca], [DescripMarca]) VALUES (4, N'Microsoft')
SET IDENTITY_INSERT [dbo].[Marca] OFF
SET IDENTITY_INSERT [dbo].[ModeloVersion] ON 

INSERT [dbo].[ModeloVersion] ([IdModeloVersion], [DescripModeloVersion]) VALUES (1, N'ER2200')
INSERT [dbo].[ModeloVersion] ([IdModeloVersion], [DescripModeloVersion]) VALUES (2, N'Optiplex 990')
INSERT [dbo].[ModeloVersion] ([IdModeloVersion], [DescripModeloVersion]) VALUES (3, N'1TB')
INSERT [dbo].[ModeloVersion] ([IdModeloVersion], [DescripModeloVersion]) VALUES (4, N'2016 Profesional')
INSERT [dbo].[ModeloVersion] ([IdModeloVersion], [DescripModeloVersion]) VALUES (5, N'NoteDell1')
SET IDENTITY_INSERT [dbo].[ModeloVersion] OFF
INSERT [dbo].[Politica] ([IdTipoDependencia], [IdCategoria], [Cantidad]) VALUES (1, 2, 1)
INSERT [dbo].[Politica] ([IdTipoDependencia], [IdCategoria], [Cantidad]) VALUES (1, 3, 3)
SET IDENTITY_INSERT [dbo].[Prioridad] ON 

INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (1, N'Baja')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (2, N'Normal')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (3, N'Alta')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (4, N'Inmediata')
SET IDENTITY_INSERT [dbo].[Prioridad] OFF
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocialProv], [AliasProv], [ContactoProv], [MailContactoProv], [MailAlternativoProv]) VALUES (1, N'Proveedor1', N'Proveedor1', N'Juan', N'Juan@gmail.com', NULL)
INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocialProv], [AliasProv], [ContactoProv], [MailContactoProv], [MailAlternativoProv]) VALUES (2, N'Proveedor2', N'Proveedor2', N'Pepe', N'pepe@gmail.com', N'info@Prov2.com.ar')
INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocialProv], [AliasProv], [ContactoProv], [MailContactoProv], [MailAlternativoProv]) VALUES (3, N'Empresa1', N'Empresa1', N'Lola', N'lola@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 1)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 2)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 4)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 7)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 8)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 9)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 10)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 16)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 17)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 18)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 19)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 20)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 26)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 28)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 40)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 41)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 43)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 44)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 45)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 46)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 47)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 48)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 49)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 3)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 5)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 6)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 11)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 12)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 13)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 14)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 15)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 21)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 22)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 23)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 24)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 25)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 27)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 29)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 30)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 31)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 32)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 33)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 34)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 35)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 36)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 37)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 38)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 39)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 37, 42)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (1, 3, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (2, 3, 3)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 2, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (4, 1, 4)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 21, 3, 22, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 23, 3, 12, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 24, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 25, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 27, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 28, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 29, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 30, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 32, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 33, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 34, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 35, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 37, 3, 2, 2)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 1305, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 1308, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 1309, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (1, 1310, 3, 3, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 23, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 24, 5, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 27, 5, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 28, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 33, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 35, 3, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 36, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 37, 3, 4, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 1305, 3, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 1308, 5, 2, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 1309, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (2, 1310, 5, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle]) VALUES (3, 1305, 3, 2, 1)
SET IDENTITY_INSERT [dbo].[Solicitud] ON 

INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (3, CAST(0x0000A75500000000 AS DateTime), NULL, 1, 4, 1, 2, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (4, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 2, 1, 2, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (5, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (6, CAST(0x0000A75500000000 AS DateTime), NULL, 4, 3, 2, 2, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (7, CAST(0x0000A75500000000 AS DateTime), NULL, 2, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (8, CAST(0x0000A75500000000 AS DateTime), NULL, 1, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (9, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (10, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (11, CAST(0x0000A75500000000 AS DateTime), NULL, 4, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (12, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (16, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 2, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (17, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 2, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (21, CAST(0x0000A75500000000 AS DateTime), NULL, 4, 1, 1, 2, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (23, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 3, 1, 2, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (24, CAST(0x0000A75600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (25, CAST(0x0000A75600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (26, CAST(0x0000A75800000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (27, CAST(0x0000A75800000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (28, CAST(0x0000A75900000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (29, CAST(0x0000A75D00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (30, CAST(0x0000A75D00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (31, CAST(0x0000A76100000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (32, CAST(0x0000A76100000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (33, CAST(0x0000A76600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (34, CAST(0x0000A72B00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (35, CAST(0x0000A76600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (36, CAST(0x0000A76B00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (37, CAST(0x0000A76B00000000 AS DateTime), NULL, 3, 2, 1, 1, 2)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (38, CAST(0x0000A72B00000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1305, CAST(0x0000A76F00000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1306, CAST(0x0000A77000000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1308, CAST(0x0000A77600000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1309, CAST(0x0000A77D00000000 AS DateTime), NULL, 1, 1, 1, 1, 4)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1310, CAST(0x0000A77F00000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
SET IDENTITY_INSERT [dbo].[TipoBien] ON 

INSERT [dbo].[TipoBien] ([IdTipoBien], [DescripTipoBien]) VALUES (1, N'Hardware')
INSERT [dbo].[TipoBien] ([IdTipoBien], [DescripTipoBien]) VALUES (2, N'Software')
SET IDENTITY_INSERT [dbo].[TipoBien] OFF
SET IDENTITY_INSERT [dbo].[TipoDependencia] ON 

INSERT [dbo].[TipoDependencia] ([IdTipoDependencia], [DescripTipoDependencia]) VALUES (1, N'Comun')
INSERT [dbo].[TipoDependencia] ([IdTipoDependencia], [DescripTipoDependencia]) VALUES (2, N'Especial')
SET IDENTITY_INSERT [dbo].[TipoDependencia] OFF
SET IDENTITY_INSERT [dbo].[TipoLicencia] ON 

INSERT [dbo].[TipoLicencia] ([IdTipoLicencia], [DescripTipoLicencia]) VALUES (1, N'Perpetua')
INSERT [dbo].[TipoLicencia] ([IdTipoLicencia], [DescripTipoLicencia]) VALUES (2, N'Suscripcion')
SET IDENTITY_INSERT [dbo].[TipoLicencia] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass]) VALUES (1, N'pargi', N'E59pyTwEJJao6VjsWTBmLGzMr78=')
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass]) VALUES (2, N'lola', N'E59pyTwEJJao6VjsWTBmLGzMr78=')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
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
REFERENCES [dbo].[Inventario] ([IdInventario], [IdBienEspecif])
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
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_Bien_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_Bien_Categoria]
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
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_Bien_TipoBien] FOREIGN KEY([IdTipoBien])
REFERENCES [dbo].[TipoBien] ([IdTipoBien])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_Bien_TipoBien]
GO
ALTER TABLE [dbo].[Bien]  WITH CHECK ADD  CONSTRAINT [FK_Bien_TipoLicencia] FOREIGN KEY([IdTipoLicencia])
REFERENCES [dbo].[TipoLicencia] ([IdTipoLicencia])
GO
ALTER TABLE [dbo].[Bien] CHECK CONSTRAINT [FK_Bien_TipoLicencia]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Proveedor]
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
ALTER TABLE [dbo].[Dependencia]  WITH CHECK ADD  CONSTRAINT [FK_Dependencia_TipoDependencia] FOREIGN KEY([IdTipoDependencia])
REFERENCES [dbo].[TipoDependencia] ([IdTipoDependencia])
GO
ALTER TABLE [dbo].[Dependencia] CHECK CONSTRAINT [FK_Dependencia_TipoDependencia]
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
ALTER TABLE [dbo].[Etiqueta]  WITH CHECK ADD  CONSTRAINT [FKEtiqueta_Formulario] FOREIGN KEY([IdFormulario])
REFERENCES [dbo].[Formulario] ([IdFormulario])
GO
ALTER TABLE [dbo].[Etiqueta] CHECK CONSTRAINT [FKEtiqueta_Formulario]
GO
ALTER TABLE [dbo].[Etiqueta]  WITH CHECK ADD  CONSTRAINT [FKEtiqueta_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[Etiqueta] CHECK CONSTRAINT [FKEtiqueta_Idioma]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Adquisicion] FOREIGN KEY([IdAdquisicion])
REFERENCES [dbo].[Adquisicion] ([IdAdquisicion])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Adquisicion]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Bien] FOREIGN KEY([IdBienEspecif])
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
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Usuario]
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
ALTER TABLE [dbo].[Politica]  WITH CHECK ADD  CONSTRAINT [FK_Politica_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Politica] CHECK CONSTRAINT [FK_Politica_Categoria]
GO
ALTER TABLE [dbo].[Politica]  WITH CHECK ADD  CONSTRAINT [FK_Politica_TipoDependencia] FOREIGN KEY([IdTipoDependencia])
REFERENCES [dbo].[TipoDependencia] ([IdTipoDependencia])
GO
ALTER TABLE [dbo].[Politica] CHECK CONSTRAINT [FK_Politica_TipoDependencia]
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
ALTER TABLE [dbo].[SolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicDetalle_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[SolicDetalle] CHECK CONSTRAINT [FK_SolicDetalle_Categoria]
GO
ALTER TABLE [dbo].[SolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicDetalle_EstadoSolDetalle] FOREIGN KEY([IdEstadoSolicDetalle])
REFERENCES [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle])
GO
ALTER TABLE [dbo].[SolicDetalle] CHECK CONSTRAINT [FK_SolicDetalle_EstadoSolDetalle]
GO
ALTER TABLE [dbo].[SolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicDetalle_Solicitud] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[Solicitud] ([IdSolicitud])
GO
ALTER TABLE [dbo].[SolicDetalle] CHECK CONSTRAINT [FK_SolicDetalle_Solicitud]
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
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Usuario]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [Solicitud_Agente] FOREIGN KEY([IdAgente])
REFERENCES [dbo].[Agente] ([IdAgente])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [Solicitud_Agente]
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
