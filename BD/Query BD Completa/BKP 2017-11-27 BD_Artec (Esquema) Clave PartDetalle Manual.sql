USE [master]
GO
/****** Object:  Database [Artec]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdquisicionCrear]
(
	@FechaAdq datetime,
	@FechaCompra datetime,
	@NroFactura varchar(50),
	@MontoCompra decimal(10,2),
	@IdProveedor int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Adquisicion (FechaAdq, FechaCompra, NroFactura, MontoCompra, IdProveedor)
VALUES (@FechaAdq, @FechaCompra, @NroFactura, @MontoCompra, @IdProveedor)

SELECT SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[AdquisicionesConBienesPorIdPartida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdquisicionesConBienesPorIdPartida]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

select adq.IdAdquisicion, adq.NroFactura, cat.idCategoria, cat.DescripCategoria, inv.SerieKey, inv.Costo
from Adquisicion adq
INNER JOIN Inventario inv
ON adq.IdAdquisicion = inv.IdAdquisicion
INNER JOIN Bien 
ON inv.IdBienEspecif = Bien.IdBien
INNER JOIN Categoria cat
ON cat.IdCategoria = Bien.IdCategoria
WHERE inv.IdPartida = @IdPartida

END

GO
/****** Object:  StoredProcedure [dbo].[AsigDetalleCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsigDetalleCrear]
(
	@IdAsigDetalle int,
	@IdAsignacion int,
	@IdInventario int,
	@IdSolicitudDetalle int,
	@IdSolicitud int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO AsigDetalle(IdAsigDetalle, IdAsignacion, IdInventario, IdSolicitudDetalle, IdSolicitud)
VALUES (@IdAsigDetalle, @IdAsignacion, @IdInventario, @IdSolicitudDetalle, @IdSolicitud)



END

GO
/****** Object:  StoredProcedure [dbo].[AsignacionCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsignacionCrear]
(
	@Fecha Datetime,
	@IdDependencia int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Asignacion(Fecha, IdDependencia)
VALUES (@Fecha, @IdDependencia)

select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[BaseDatosRespaldar]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[BienTraerIdPorDescripMarcaModelo]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BienTraerIdPorDescripMarcaModelo]
(
	@IdCategoria INT,
	@IdTipoBien INT,
	@IdMarca INT,
	@IdModelo INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Bi.IdBien
FROM Bien Bi
INNER JOIN Marca Mar
ON Mar.IdMarca = Bi.IdMarca
INNER JOIN ModeloVersion Mode
ON Bi.IdModeloVersion = Mode.IdModeloVersion
INNER JOIN TipoBien Tipo
ON Bi.IdTipoBien = Tipo.IdTipoBien
INNER JOIN Categoria Cat
ON Bi.IdCategoria = Cat.IdCategoria
WHERE Tipo.IdTipoBien = @IdTipoBien
AND Cat.IdCategoria = @IdCategoria
AND Mar.IdMarca = @IdMarca
AND Mode.IdModeloVersion = @IdModelo

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaDetBienesTraerPorIdPartida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaDetBienesTraerPorIdPartida]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

select cat.DescripCategoria, sdet.Cantidad, cat.IdCategoria, sdet.IdSolicitud, sdet.IdSolicitudDetalle--, tipo.DescripTipoBien
from PartidaDetalle pdet
INNER JOIN SolicDetalle sdet
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle
INNER JOIN Partida par
ON par.IdPartida = pdet.IdPartida
INNER JOIN Categoria cat
ON cat.IdCategoria = sdet.IdCategoria
Left JOIN Bien bi
ON bi.IdBien = cat.IdCategoria
--INNER JOIN TipoBien tipo
--ON tipo.IdTipoBien = bi.IdTipoBien
WHERE par.IdPartida = @IdPartida
AND sdet.IdEstadoSolicDetalle < 3--Que el estado del detalle no sea Adquirido ni Entregado



--SELECT Cat.DescripCategoria, SolDet.Cantidad
--FROM SolicDetalle SolDet
--INNER JOIN Categoria Cat
--ON SolDet.IdCategoria = Cat.IdCategoria
--INNER JOIN PartidaDetalle PDet
--ON SolDet.IdSolicitud = PDet.IdSolicitud AND SolDet.IdSolicitudDetalle = PDet.IdSolicitudDetalle
--INNER JOIN Partida Par
--ON Par.IdPartida = PDet.IdPartida
--WHERE Par.IdPartida = @IdPartida
--AND SolDet.IdEstadoSolicDetalle != 2--Distinto de Finalizado


END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHard]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosHard]

AS
BEGIN

	SET NOCOUNT ON;

SELECT DISTINCT Cat.IdCategoria, Cat.DescripCategoria
FROM Categoria Cat
INNER JOIN Bien Bi
ON Bi.IdCategoria = Cat.IdCategoria
INNER JOIN TipoBien TB
ON TB.IdTipoBien = BI.IdTipoBien
WHERE TB.IdTipoBien = 1

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoft]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosSoft]

AS
BEGIN

	SET NOCOUNT ON;

SELECT DISTINCT Cat.IdCategoria, Cat.DescripCategoria
FROM Categoria Cat
INNER JOIN Bien Bi
ON Bi.IdCategoria = Cat.IdCategoria
INNER JOIN TipoBien TB
ON TB.IdTipoBien = BI.IdTipoBien
WHERE TB.IdTipoBien = 2

END

GO
/****** Object:  StoredProcedure [dbo].[ConfigMailHostTraer]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConfigMailHostTraer]


AS
BEGIN

	SET NOCOUNT ON;

SELECT cm.Puerto, cm.Host, cm.Ssl, cm.Remitente, cm.Remps
FROM ConfigMailHost cm

END


GO
/****** Object:  StoredProcedure [dbo].[CotizacionConteo]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrear]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrearRelSolicDetalle]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorIdPartidaDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionTraerPorIdPartidaDetalle]
(
	@IdPartidaDetalle int,
	@IdPartida int
)


AS
BEGIN

	SET NOCOUNT ON;

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Det.IdPartidaDetalle, Det.IdPartida
from Cotizacion Coti
INNER JOIN Proveedor Prov
ON Coti.IdProveedor = Prov.IdProveedor
INNER JOIN RelCotizPartDetalle Rel
ON Coti.IdCotizacion = Rel.IdCotizacion
INNER JOIN PartidaDetalle Det
ON Rel.IdPartida = Det.IdPartida AND Rel.IdPartidaDetalle = Det.IdPartidaDetalle
WHERE Det.IdPartida = @IdPartida
AND Det.IdPartidaDetalle = @IdPartidaDetalle
END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
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

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Det.IdSolicitudDetalle, Det.IdSolicitud, Det.UIDSolicDetalle
--select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Coti.IdPartidaDetalle, Coti.IdPartida, Det.IdSolicitudDetalle, Det.IdSolicitud
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitudYDetalle]    Script Date: 29/11/2017 21:47:30 ******/
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

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Det.IdSolicitudDetalle, Det.IdSolicitud
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesPorIdDependencia]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesResp]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerNombrePorIDSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaTraerNombrePorIDSolicitud]
(
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT dep.NombreDependencia
FROM Dependencia dep
WHERE dep.IdDependencia = (
	SELECT sol.IdDependencia
	FROM Solicitud sol
	WHERE sol.IdSolicitud = @IdSolicitud
	)

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[DepositoTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DepositoTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM Deposito


END

GO
/****** Object:  StoredProcedure [dbo].[EstadoInvTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EstadoInvTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM EstadoInventario


END

GO
/****** Object:  StoredProcedure [dbo].[EstadoSolDetallesTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[EtiquetasTraerTodosPorIdioma]    Script Date: 29/11/2017 21:47:30 ******/
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

SELECT Et.NombreControl, Et.Texto
FROM Etiqueta Et
WHERE IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[EtiquetaTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaActualizarIdiomaDefault]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdiomaActualizarIdiomaDefault]
(
	@IdIdioma INT,
	@ElIdiomaDefault bit
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Idioma
SET ElIdiomaDefault = @ElIdiomaDefault
WHERE IdIdioma = @IdIdioma


END

GO
/****** Object:  StoredProcedure [dbo].[IdiomaTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaUsuarioActualModificar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdiomaUsuarioActualModificar]
(
	@IdiomaUsuarioActual INT,
	@IdUsuario INT
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Usuario
SET IdiomaUsuarioActual = @IdiomaUsuarioActual
WHERE IdUsuario = @IdUsuario


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioAdquiridoCantPorPartDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioAdquiridoCantPorPartDetalle]
(
	@IdPartida2 INT
)


AS
BEGIN

	SET NOCOUNT ON;

--select pdet.IdPartidaDetalle, count(inv.IdInventario) as Comprado from Inventario inv
--INNER JOIN PartidaDetalle pdet
--ON inv.IdPartida = pdet.IdPartida and inv.IdPartidaDetalle = pdet.IdPartidaDetalle
--LEFT JOIN SolicDetalle sdet
--ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle
--WHERE pdet.IdPartida = @IdPartida2
--and sdet.IdEstadoSolicDetalle != 2--Distinto a finalizado
--group by pdet.IdPartidaDetalle
select sdet.IdSolicitudDetalle, count(inv.IdInventario) as Comprado from Inventario inv
INNER JOIN PartidaDetalle pdet
ON inv.IdPartida = pdet.IdPartida and inv.IdPartidaDetalle = pdet.IdPartidaDetalle
LEFT JOIN SolicDetalle sdet
ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle
WHERE pdet.IdPartida = @IdPartida2
--and sdet.IdEstadoSolicDetalle != 2--Distinto a finalizado 30/10/2017 Comente esto para probar
group by sdet.IdSolicitudDetalle


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioEntregadoPorSolicDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioEntregadoPorSolicDetalle]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

select count(asigdet.IdAsigDetalle) as Entregado 
FROM AsigDetalle asigdet
WHERE IdSolicitud = @IdSolicitud
AND IdSolicitudDetalle = @IdSolicitudDetalle


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioEstadoUpdate]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioEstadoUpdate]
(
	@IdInventario INT
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Inventario
SET IdEstadoInventario = 2 --Entregado
WHERE IdInventario = @IdInventario


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioHardCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioHardCrear]
(
	@IdBienEspecif INT,
	@SerieKey nvarchar(300),
	@IdAdquisicion INT,
	@IdDeposito INT,
	@IdEstadoInventario INT,
	@IdPartidaDetalle INT,
	@IdPartida INT
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Inventario (IdBienEspecif, SerieKey, IdAdquisicion, IdDeposito, IdEstadoInventario, IdPartidaDetalle, IdPartida)
VALUES (@IdBienEspecif, @SerieKey, @IdAdquisicion, @IdDeposito, @IdEstadoInventario, @IdPartidaDetalle, @IdPartida)


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioHardTraerListosParaAsignar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioHardTraerListosParaAsignar]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle int--,
	--@IdEstadoSolicDetalle int
)


AS
BEGIN

	SET NOCOUNT ON;

--SELECT inv.IdInventario, inv.SerieKey
--FROM Inventario inv
--INNER JOIN PartidaDetalle pdet
--ON inv.IdPartida = pdet.IdPartida and inv.IdPartidaDetalle = pdet.IdPartidaDetalle
--INNER JOIN SolicDetalle sdet
--ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle

SELECT inv.IdInventario, inv.SerieKey, ma.DescripMarca, mo.DescripModeloVersion
FROM Inventario inv
INNER JOIN Bien bi
ON inv.IdBienEspecif = bi.IdBien
INNER JOIN Marca ma
ON bi.IdMarca = ma.IdMarca
INNER JOIN ModeloVersion mo
ON bi.IdModeloVersion = mo.IdModeloVersion
INNER JOIN PartidaDetalle pdet
ON inv.IdPartida = pdet.IdPartida and inv.IdPartidaDetalle = pdet.IdPartidaDetalle
INNER JOIN SolicDetalle sdet
ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle
WHERE sdet.IdSolicitud = @IdSolicitud
--and sdet.IdEstadoSolicDetalle = @IdEstadoSolicDetalle--Adquirido
--and sdet.IdSolicitudDetalle = @IdSolicitudDetalle COMENTADO 30/10/2017 (AL IGUAL QUE EN LOS PARAMETROS)
and inv.IdEstadoInventario = 1--Disponible


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioSoftCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioSoftCrear]
(
	@IdBienEspecif INT,
	@SerieKey nvarchar(300),
	@IdAdquisicion INT,
	@SerialMaster nvarchar(300),
	@IdEstadoInventario INT,
	@IdPartidaDetalle INT,
	@IdPartida INT
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Inventario (IdBienEspecif, SerieKey, IdAdquisicion, SerialMaster, IdEstadoInventario, IdPartidaDetalle, IdPartida)
VALUES (@IdBienEspecif, @SerieKey, @IdAdquisicion, @SerialMaster, @IdEstadoInventario, @IdPartidaDetalle, @IdPartida)


END

GO
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventariosTraerListosParaAsignar]
(
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

Select inv.IdInventario, inv.SerieKey, inv.SerialMaster, inv.IdEstadoInventario, inv.IdPartida, inv.IdPartidaDetalle, inv.IdDeposito, inv.IdAdquisicion, bi.IdBien, bi.IdTipoBien
--Agregar inv.costo
FROM Inventario inv
INNER JOIN Bien bi
ON inv.IdBienEspecif = bi.IdBien
Where inv.IdEstadoInventario = 1 --Disponible
and inv.IdPartida in
	(
		Select pdet.IdPartida
		from PartidaDetalle pdet
		Where pdet.IdSolicitud = @IdSolicitud
	)


END

GO
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignarPorSolicDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventariosTraerListosParaAsignarPorSolicDetalle]
(
	@IdSolicitud INT,
	@IdSolicDetalle int
)


AS
BEGIN

	SET NOCOUNT ON;

Select inv.IdInventario, inv.SerieKey, inv.SerialMaster, inv.IdEstadoInventario, inv.IdPartida, inv.IdPartidaDetalle, inv.IdDeposito, inv.IdAdquisicion, bi.IdBien, bi.IdTipoBien, ma.DescripMarca, mo.DescripModeloVersion
--Agregar inv.costo
FROM Inventario inv
INNER JOIN Bien bi
ON inv.IdBienEspecif = bi.IdBien
INNER JOIN Marca ma
ON ma.IdMarca = bi.IdMarca
INNER JOIN ModeloVersion mo
ON mo.IdModeloVersion = bi.IdModeloVersion
Where inv.IdEstadoInventario = 1 --Disponible
and inv.IdPartida in
	(
		Select pdet.IdPartida
		from PartidaDetalle pdet
		Where pdet.IdSolicitud = @IdSolicitud
		and pdet.IdSolicitudDetalle = @IdSolicDetalle
	)


END

GO
/****** Object:  StoredProcedure [dbo].[MarcaTraerPorIdCategoria]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MarcaTraerPorIdCategoria]
(
	@IdCategoria INT,
	@IdTipoBien INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT distinct Mar.IdMarca, Mar.DescripMarca
FROM Marca Mar
INNER JOIN Bien Bi
ON Mar.IdMarca = Bi.IdMarca
INNER JOIN TipoBien Tipo
ON Bi.IdTipoBien = Tipo.IdTipoBien
INNER JOIN Categoria Cat
ON Bi.IdCategoria = Cat.IdCategoria
WHERE Tipo.IdTipoBien = @IdTipoBien
AND Cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[ModeloTraerPorMarcaCategoria]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModeloTraerPorMarcaCategoria]
(
	@IdCategoria INT,
	@IdTipoBien INT,
	@IdMarca INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Mode.IdModeloVersion, Mode.DescripModeloVersion
FROM Marca Mar
INNER JOIN Bien Bi
ON Mar.IdMarca = Bi.IdMarca
INNER JOIN ModeloVersion Mode
ON Bi.IdModeloVersion = Mode.IdModeloVersion
INNER JOIN TipoBien Tipo
ON Bi.IdTipoBien = Tipo.IdTipoBien
INNER JOIN Categoria Cat
ON Bi.IdCategoria = Cat.IdCategoria
WHERE Tipo.IdTipoBien = @IdTipoBien
AND Cat.IdCategoria = @IdCategoria
AND Mar.IdMarca = @IdMarca

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaAsociar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaAsociar]
(
	@IdPartida int,
	@FechaAcreditacion datetime,
	@MontoOtorgado decimal(10, 2),
	@NroPartida varchar(10)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Partida 
SET FechaAcreditacion = @FechaAcreditacion,
	MontoOtorgado = @MontoOtorgado,
	NroPartida = @NroPartida
WHERE IdPartida = @IdPartida
	



END

GO
/****** Object:  StoredProcedure [dbo].[PartidaCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaCrear]
(
	@FechaEnvio Datetime,
	@MontoSolicitado money,
	@Caja bit
	--@MontoOtorgado money,
	--@FechaAcreditacion Datetime,
	--@NroPartida varchar(10)
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Partida (FechaEnvio, MontoSolicitado, Caja)
VALUES (@FechaEnvio, @MontoSolicitado, @Caja)

select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleCrearSinCotiz]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaDetalleCrearSinCotiz]
(
	@IdPartidaDetalle int,
	@IdPartida int,
	@IdSolicitud int,
	@IdSolicitudDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO PartidaDetalle (IdPartidaDetalle, IdPartida, IdSolicitud, IdSolicitudDetalle)
VALUES (@IdPartidaDetalle, @IdPartida, @IdSolicitud, @IdSolicitudDetalle)


END

GO
/****** Object:  StoredProcedure [dbo].[PartidaDetallePorIdCategoriaIdPartida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaDetallePorIdCategoriaIdPartida]
(
	@IdPartida INT,
	@IdCategoria INT
)


AS
BEGIN

	SET NOCOUNT ON;

select pdet.IdPartidaDetalle
from Categoria cat
INNER JOIN SolicDetalle sdet 
ON cat.IdCategoria = sdet.IdCategoria
INNER JOIN PartidaDetalle pdet
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle
Where pdet.IdPartida = @IdPartida
and cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleTraerTodosPorNroPart]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaDetalleTraerTodosPorNroPart]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT dpar.IdPartidaDetalle, dpar.IdPartida, dsol.IdSolicitud, dsol.IdSolicitudDetalle, Cat.DescripCategoria, dsol.Cantidad
FROM PartidaDetalle dPar
INNER JOIN SolicDetalle dSol
ON dpar.IdSolicitud = dsol.IdSolicitud and dpar.IdSolicitudDetalle = dsol.IdSolicitudDetalle
INNER JOIN Categoria Cat
ON dSol.IdCategoria = Cat.IdCategoria
WHERE IdPartida = @IdPartida

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaModifMontoSolic]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaModifMontoSolic]
(
	@IdPartida INT,
	@MontoSolicitado DECIMAL(10,2)
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Partida
SET MontoSolicitado = @MontoSolicitado
WHERE IdPartida = @IdPartida


END

GO
/****** Object:  StoredProcedure [dbo].[PartidasBuscarPorIdSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidasBuscarPorIdSolicitud]
(
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

select * from
Partida par
Where par.IdPartida in
	(
	select pdet.IdPartida
	From PartidaDetalle pdet
	Where pdet.IdSolicitud = @IdSolicitud
	)

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaTraerPorNroPart]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaTraerPorNroPart]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM Partida
WHERE IdPartida = @IdPartida

END

GO
/****** Object:  StoredProcedure [dbo].[PoliticaPorDepYCategCantidad]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[PoliticaTraerPorTipoDepYCat]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[Prueba]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[RelCotizPartDetalleCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelCotizPartDetalleCrear]
(
	@IdCotizacion int,
	@IdPartida int,
	@IdPartidaDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelCotizPartDetalle (IdCotizacion, IdPartida, IdPartidaDetalle)
VALUES (@IdCotizacion, @IdPartida, @IdPartidaDetalle)


END

GO
/****** Object:  StoredProcedure [dbo].[RelCotSolDetalleDeletePorIdSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelCotSolDetalleDeletePorIdSolicitud]
(
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

DELETE from Cotizacion
WHERE IdCotizacion IN
(
	SELECT rcotdet.IdCotizacion from RelCotSolDetalle rcotdet
	where rcotdet.IdSolicitud = @IdSolicitud
)

DELETE from RelCotSolDetalle
WHERE IdSolicitud = @IdSolicitud


END

GO
/****** Object:  StoredProcedure [dbo].[RelPDetAdqPartidaTieneAdq]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelPDetAdqPartidaTieneAdq]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

select distinct IdPartida from RelPDetAdq
where IdPartida = @IdPartida



END

GO
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteAgregar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelSolDetalleAgenteAgregar]
(
	@IdSolicitudDetalle INT,
	@IdSolicitud INT,
	@IdAgente INT
)


AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelSolDetalleAgente (IdSolicitudDetalle, IdSolicitud, IdAgente)
VALUES (@IdSolicitudDetalle, @IdSolicitud, @IdAgente)



END

GO
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteEliminar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelSolDetalleAgenteEliminar]
(
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelSolDetalleAgente
WHERE IdSolicitud = @IdSolicitud


END

GO
/****** Object:  StoredProcedure [dbo].[RendicionCrear]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RendicionCrear]
(
	@FechaRen Datetime,
	@IdPartida int,
	@MontoGasto decimal(18, 2)
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Rendicion (FechaRen, IdPartida,  MontoGasto)
VALUES (@FechaRen, @IdPartida, @MontoGasto)

select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[RendicionModificar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RendicionModificar]
(
	@IdRendicion int,
	@FechaRen Datetime,
	@IdPartida int,
	@MontoGasto decimal(18, 2)
)

AS
BEGIN

	SET NOCOUNT ON;

update Rendicion
SET FechaRen = @FechaRen, IdPartida = @IdPartida, MontoGasto = @MontoGasto
WHERE IdRendicion = @IdRendicion

END

GO
/****** Object:  StoredProcedure [dbo].[RendicionTraerIdRendPorIdPartida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RendicionTraerIdRendPorIdPartida]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

select ren.IdRendicion
from Rendicion ren
where ren.IdPartida = @IdPartida



END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetalleDeletePorSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleDeletePorSolicitud]
(
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

DELETE from SolicDetalle
WHERE IdSolicitud = @IdSolicitud


END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetallePartidaDetalleAsociacionTraer]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallePartidaDetalleAsociacionTraer]
(
	@IdSolicitud INT,
	@IdSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT dpar.IdPartidaDetalle, dpar.IdPartida, dpar.IdSolicitud, dpar.IdSolicitudDetalle
FROM PartidaDetalle dPar
WHERE dpar.IdSolicitud = @IdSolicitud AND dpar.IdSolicitudDetalle = @IdSolicDetalle

END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerAgentesAsociados]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallesTraerAgentesAsociados]
(
	@IdSolicDetalle INT,
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT  ag.IdAgente, ag.NombreAgente, ag.ApellidoAgente
FROM Agente ag
WHERE ag.IdAgente IN
	(
		SELECT rel.IdAgente 
		FROM RelSolDetalleAgente rel
		WHERE rel.IdSolicitudDetalle = @IdSolicDetalle
		AND rel.IdSolicitud = @IdSolicitud
	)



END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerPorNroSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
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

SELECT Det.IdSolicitudDetalle, Det.Cantidad, Est.IdEstadoSolicDetalle, Est.DescripEstadoSolicDetalle, Cat.IdCategoria, Cat.DescripCategoria, Sol.IdSolicitud, det.UIDSolicDetalle
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleUpdateEstado]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleUpdateEstado]
(
	@IdSolicitud INT,
	@IdSolicDetalle int,
	@NuevoEstado int
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE SolicDetalle
SET IdEstadoSolicDetalle = @NuevoEstado --Todos los bienes del detalle fueron Adquiridos (un 3 debería ser)
WHERE IdSolicitud = @IdSolicitud 
and IdSolicitudDetalle = @IdSolicDetalle


END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudBuscar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudBuscar]
(
	@NombreDep varchar(300) = null,
	@EstadoSolic varchar(50) = null,
	@bien varchar(300) = null,
	@priori varchar(20) = null,
	@usasig varchar(30) = null
)


AS
BEGIN

	SET NOCOUNT ON;

select distinct sol.IdSolicitud, sol.FechaFin, sol.FechaInicio, dep.IdDependencia, dep.NombreDependencia, Pri.IdPrioridad, Pri.DescripPrioridad, est.IdEstadoSolicitud, est.DescripEstadoSolic, Us.IdUsuario, Us.NombreUsuario, Ag.IdAgente, Ag.ApellidoAgente
from solicitud sol 
INNER JOIN Dependencia dep
ON sol.IdDependencia = dep.IdDependencia
INNER JOIN EstadoSolicitud est
ON sol.IdEstado = est.IdEstadoSolicitud
INNER JOIN Prioridad Pri
ON Sol.IdPrioridad = Pri.IdPrioridad
INNER JOIN Usuario Us
ON Sol.IdUsuario = Us.IdUsuario
INNER JOIN SolicDetalle sdet
ON sol.IdSolicitud = sdet.IdSolicitud
INNER JOIN Categoria cat
ON sdet.IdCategoria = cat.IdCategoria
LEFT JOIN Agente Ag
ON Sol.IdAgente = Ag.IdAgente
WHERE (UPPER(dep.NombreDependencia) LIKE UPPER('%' + @NombreDep + '%') OR @NombreDep IS NULL)
and (UPPER(est.DescripEstadoSolic) LIKE UPPER('%' + @EstadoSolic + '%') OR @EstadoSolic IS NULL)
and (UPPER(cat.DescripCategoria) LIKE UPPER('%' + @bien + '%') OR @bien IS NULL)
and (UPPER(pri.DescripPrioridad) LIKE UPPER('%' + @priori + '%') OR @priori IS NULL)
and (UPPER(Us.NombreUsuario) LIKE UPPER('%' + @usasig + '%') OR @usasig IS NULL)


END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudCrear]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudDetalleCrear]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudModificar]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudModificar]
(
	@FechaInicio datetime,
	@IdDependencia int,
	@IdPrioridad int,
	@IdEstado int,
	@IdUsuario int,
	@IdAgente int,
	@IdSolicitud INT
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Solicitud
SET FechaInicio = @FechaInicio, 
	IdDependencia = @IdDependencia,
	IdPrioridad = @IdPrioridad,
	IdEstado = @IdEstado,
	IdUsuario = @IdUsuario,
	IdAgente = @IdAgente
WHERE IdSolicitud = @IdSolicitud 

END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerIdsolNomdepPorIdPartida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerIdsolNomdepPorIdPartida]
(
	@IdPartida INT
)


AS
BEGIN

	SET NOCOUNT ON;

select distinct sol.IdSolicitud, dep.NombreDependencia
from Solicitud sol
inner join Dependencia dep
on sol.IdDependencia = dep.IdDependencia
inner join SolicDetalle sdet
on sol.IdSolicitud = sdet.IdSolicitud
inner join PartidaDetalle pdet
on pdet.IdSolicitud = sdet.IdSolicitud
where pdet.IdPartida = @IdPartida


END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerPorNroSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerIDTipoBienPorIdCategoria]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TipoBienTraerIDTipoBienPorIdCategoria]
(
	@IdCategoria INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT TB.IdTipoBien
FROM TipoBien TB
INNER JOIN Bien 
ON TB.IdTipoBien = Bien.IdTipoBien
INNER JOIN Categoria Cat
ON Bien.IdCategoria = Cat.IdCategoria
WHERE Cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTipoBienPorIdCategoria]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoDependenciaTraerPorDependencia]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[TraerLimitePartida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerLimitePartida]
AS

SET NOCOUNT ON

SELECT ValorLimite
FROM Limite
GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPorLogin]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodos]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Adquisicion]    Script Date: 29/11/2017 21:47:30 ******/
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
	[RutaDocumentos] [nvarchar](500) NULL,
	[MontoCompra] [decimal](10, 2) NULL,
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
/****** Object:  Table [dbo].[Agente]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[AsigDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AsigDetalle](
	[IdAsigDetalle] [int] NOT NULL,
	[IdAsignacion] [int] NOT NULL,
	[IdInventario] [int] NOT NULL,
	[IdSolicitudDetalle] [int] NULL,
	[IdSolicitud] [int] NULL,
	[IdAgente] [int] NULL,
	[Observacion] [varchar](300) NULL,
 CONSTRAINT [PK_AsigDetalle] PRIMARY KEY CLUSTERED 
(
	[IdAsigDetalle] ASC,
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Bien]    Script Date: 29/11/2017 21:47:30 ******/
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
	[IdMarca] [int] NOT NULL,
	[IdModeloVersion] [int] NOT NULL,
	[IdTipoBien] [int] NOT NULL,
 CONSTRAINT [PK_Bien] PRIMARY KEY CLUSTERED 
(
	[IdBien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[ConfigMailHost]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfigMailHost](
	[Puerto] [int] NOT NULL,
	[Host] [varchar](50) NOT NULL,
	[Ssl] [bit] NOT NULL,
	[Remitente] [varchar](300) NOT NULL,
	[Remps] [nvarchar](15) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[IdCotizacion] [int] IDENTITY(1,1) NOT NULL,
	[MontoCotizado] [money] NOT NULL,
	[FechaCotizacion] [datetime] NOT NULL,
	[IdProveedor] [int] NOT NULL,
 CONSTRAINT [PK_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dependencia]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Deposito]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Direccion]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[EstadoInventario]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[EstadoSolicDetalle]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 29/11/2017 21:47:30 ******/
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
 CONSTRAINT [PK_Etiqueta] PRIMARY KEY CLUSTERED 
(
	[NombreControl] ASC,
	[Texto] ASC,
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[NombreIdioma] [varchar](30) NOT NULL,
	[ElIdiomaDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdBienEspecif] [int] NOT NULL,
	[SerialMaster] [nvarchar](300) NULL,
	[SerieKey] [nvarchar](300) NOT NULL,
	[IdAdquisicion] [int] NOT NULL,
	[IdDeposito] [int] NULL,
	[IdEstadoInventario] [int] NOT NULL,
	[IdPartidaDetalle] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
	[Costo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Limite]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[ModeloVersion]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Nota]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Partida]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partida](
	[IdPartida] [int] IDENTITY(1,1) NOT NULL,
	[MontoSolicitado] [decimal](10, 2) NOT NULL,
	[MontoOtorgado] [decimal](10, 2) NULL,
	[NroPartida] [varchar](10) NULL,
	[FechaEnvio] [datetime] NOT NULL,
	[FechaAcreditacion] [datetime] NULL,
	[Caja] [bit] NOT NULL,
 CONSTRAINT [PK_Partida] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PartidaDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidaDetalle](
	[IdPartidaDetalle] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[UIDPartidaDetalle] [int] NULL,
 CONSTRAINT [PK_PartidaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdPartidaDetalle] ASC,
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Politica]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Prioridad]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Provincia]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[RelCotizPartDetalle]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelCotizPartDetalle](
	[IdCotizacion] [int] NOT NULL,
	[IdPartidaDetalle] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
 CONSTRAINT [PK_RelCotizPartDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC,
	[IdPartidaDetalle] ASC,
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelCotSolDetalle]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[RelDepAgenteCargo]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[RelPDetAdq]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelPDetAdq](
	[IdPartidaDetalle] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
	[IdAdquisicion] [int] NOT NULL,
 CONSTRAINT [PK_RelPDetAdq] PRIMARY KEY CLUSTERED 
(
	[IdPartidaDetalle] ASC,
	[IdPartida] ASC,
	[IdAdquisicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelProveedorDire]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[RelProveedorTel]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[RelSolDetalleAgente]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Rendicion]    Script Date: 29/11/2017 21:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rendicion](
	[IdRendicion] [int] IDENTITY(1,1) NOT NULL,
	[MontoGasto] [decimal](18, 2) NOT NULL,
	[IdPartida] [int] NOT NULL,
	[FechaRen] [datetime] NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[IdRendicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolicDetalle]    Script Date: 29/11/2017 21:47:30 ******/
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
	[UIDSolicDetalle] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SolicDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Telefono]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[TipoBien]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[TipoDependencia]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 29/11/2017 21:47:30 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/11/2017 21:47:30 ******/
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
	[IdiomaUsuarioActual] [int] NOT NULL,
 CONSTRAINT [PK_IdUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Inventario]    Script Date: 29/11/2017 21:47:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Inventario] ON [dbo].[Inventario]
(
	[IdBienEspecif] ASC,
	[SerieKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_Inventario] FOREIGN KEY([IdInventario])
REFERENCES [dbo].[Inventario] ([IdInventario])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_Inventario]
GO
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud])
GO
ALTER TABLE [dbo].[AsigDetalle] CHECK CONSTRAINT [FK_AsigDetalle_SolicDetalle]
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
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Proveedor]
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
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_PartidaDetalle] FOREIGN KEY([IdPartidaDetalle], [IdPartida])
REFERENCES [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_PartidaDetalle]
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
ALTER TABLE [dbo].[RelCotizPartDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotizPartDetalle_Cotizacion] FOREIGN KEY([IdCotizacion])
REFERENCES [dbo].[Cotizacion] ([IdCotizacion])
GO
ALTER TABLE [dbo].[RelCotizPartDetalle] CHECK CONSTRAINT [FK_RelCotizPartDetalle_Cotizacion]
GO
ALTER TABLE [dbo].[RelCotizPartDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotizPartDetalle_PartidaDetalle] FOREIGN KEY([IdPartidaDetalle], [IdPartida])
REFERENCES [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida])
GO
ALTER TABLE [dbo].[RelCotizPartDetalle] CHECK CONSTRAINT [FK_RelCotizPartDetalle_PartidaDetalle]
GO
ALTER TABLE [dbo].[RelCotSolDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotSolDetalle_Cotizacion] FOREIGN KEY([IdCotizacion])
REFERENCES [dbo].[Cotizacion] ([IdCotizacion])
GO
ALTER TABLE [dbo].[RelCotSolDetalle] CHECK CONSTRAINT [FK_RelCotSolDetalle_Cotizacion]
GO
ALTER TABLE [dbo].[RelCotSolDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotSolDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud])
ON DELETE CASCADE
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
ALTER TABLE [dbo].[RelPDetAdq]  WITH CHECK ADD  CONSTRAINT [FK_RelPDetAdq_Adquisicion] FOREIGN KEY([IdAdquisicion])
REFERENCES [dbo].[Adquisicion] ([IdAdquisicion])
GO
ALTER TABLE [dbo].[RelPDetAdq] CHECK CONSTRAINT [FK_RelPDetAdq_Adquisicion]
GO
ALTER TABLE [dbo].[RelPDetAdq]  WITH CHECK ADD  CONSTRAINT [FK_RelPDetAdq_PartidaDetalle] FOREIGN KEY([IdPartidaDetalle], [IdPartida])
REFERENCES [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida])
GO
ALTER TABLE [dbo].[RelPDetAdq] CHECK CONSTRAINT [FK_RelPDetAdq_PartidaDetalle]
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
ON DELETE CASCADE
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
