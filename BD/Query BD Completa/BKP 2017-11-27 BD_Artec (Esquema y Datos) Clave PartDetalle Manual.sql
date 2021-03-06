USE [master]
GO
/****** Object:  Database [Artec]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionesConBienesPorIdPartida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[AsigDetalleCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignacionCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[BaseDatosRespaldar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[BienTraerIdPorDescripMarcaModelo]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaDetBienesTraerPorIdPartida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHard]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoft]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[ConfigMailHostTraer]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionConteo]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrearRelSolicDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorIdPartidaDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitudYDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesPorIdDependencia]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesResp]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerNombrePorIDSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[DepositoTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoInvTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolDetallesTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[EtiquetasTraerTodosPorIdioma]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[EtiquetaTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaActualizarIdiomaDefault]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaUsuarioActualModificar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioAdquiridoCantPorPartDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioEntregadoPorSolicDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioEstadoUpdate]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioHardCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioHardTraerListosParaAsignar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioSoftCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignarPorSolicDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[MarcaTraerPorIdCategoria]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[ModeloTraerPorMarcaCategoria]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaAsociar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaDetalleCrearSinCotiz]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaDetallePorIdCategoriaIdPartida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaDetalleTraerTodosPorNroPart]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaModifMontoSolic]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidasBuscarPorIdSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaTraerPorNroPart]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PoliticaPorDepYCategCantidad]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PoliticaTraerPorTipoDepYCat]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[Prueba]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RelCotizPartDetalleCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RelCotSolDetalleDeletePorIdSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RelPDetAdqPartidaTieneAdq]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteAgregar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteEliminar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionModificar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionTraerIdRendPorIdPartida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleDeletePorSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetallePartidaDetalleAsociacionTraer]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerAgentesAsociados]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerPorNroSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleUpdateEstado]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudBuscar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudDetalleCrear]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudModificar]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudTraerIdsolNomdepPorIdPartida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudTraerPorNroSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerIDTipoBienPorIdCategoria]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTipoBienPorIdCategoria]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoDependenciaTraerPorDependencia]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[TraerLimitePartida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPorLogin]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodos]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Adquisicion]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Agente]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[AsigDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Asignacion]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Bien]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Cargo]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[ConfigMailHost]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Dependencia]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Deposito]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Direccion]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[EstadoInventario]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[EstadoSolicDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Inventario]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Limite]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[ModeloVersion]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Nota]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Partida]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[PartidaDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Politica]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Prioridad]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Provincia]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelCotizPartDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelCotSolDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelDepAgenteCargo]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelPDetAdq]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelProveedorDire]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelProveedorTel]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[RelSolDetalleAgente]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Rendicion]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[SolicDetalle]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Solicitud]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Telefono]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[TipoBien]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[TipoDependencia]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 29/11/2017 21:48:17 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/11/2017 21:48:17 ******/
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
SET IDENTITY_INSERT [dbo].[Adquisicion] ON 

INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (2, CAST(0x0000A72F00000000 AS DateTime), CAST(0x0000A72F00000000 AS DateTime), N'Fact111', NULL, CAST(500.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (3, CAST(0x0000A7A7013589A7 AS DateTime), CAST(0x0000A7A700000000 AS DateTime), N'444', NULL, CAST(500.00 AS Decimal(10, 2)), NULL, 3)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (4, CAST(0x0000A7A701417DCA AS DateTime), CAST(0x0000A7A700000000 AS DateTime), N'555', NULL, CAST(555.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (8, CAST(0x0000A7A7016F4C16 AS DateTime), CAST(0x0000A7A700000000 AS DateTime), N'7777', NULL, CAST(7777.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (9, CAST(0x0000A7A801225274 AS DateTime), CAST(0x0000A7A800000000 AS DateTime), N'6666', NULL, CAST(200.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (10, CAST(0x0000A7A8017E40EF AS DateTime), CAST(0x0000A7A800000000 AS DateTime), N'1122', NULL, CAST(399.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (12, CAST(0x0000A7AB01366523 AS DateTime), CAST(0x0000A7AB00000000 AS DateTime), N'12345', NULL, CAST(12345.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (13, CAST(0x0000A7AB01385E39 AS DateTime), CAST(0x0000A7AB00000000 AS DateTime), N'1000', NULL, CAST(1000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (14, CAST(0x0000A7AB01399474 AS DateTime), CAST(0x0000A7AB00000000 AS DateTime), N'999', NULL, CAST(999.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (17, CAST(0x0000A7B401611C62 AS DateTime), CAST(0x0000A7B400000000 AS DateTime), N'tttt', NULL, CAST(550.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (18, CAST(0x0000A7B501890EF1 AS DateTime), CAST(0x0000A7A300000000 AS DateTime), N'asdf', NULL, CAST(111.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (19, CAST(0x0000A7B5018AB1D1 AS DateTime), CAST(0x0000A7B400000000 AS DateTime), N'555', NULL, CAST(555.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (20, CAST(0x0000A7B5018AFF73 AS DateTime), CAST(0x0000A7B500000000 AS DateTime), N'56465', NULL, CAST(445.00 AS Decimal(10, 2)), NULL, 3)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (21, CAST(0x0000A7B600015DE9 AS DateTime), CAST(0x0000A7A300000000 AS DateTime), N'asdfsd', NULL, CAST(11.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (22, CAST(0x0000A7B6000BF9EE AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'asdf23', NULL, CAST(233.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (27, CAST(0x0000A7B600D26229 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'FacturaPru11', NULL, CAST(1200.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (28, CAST(0x0000A7B600D6BD0D AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'FacAA11', NULL, CAST(322.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (29, CAST(0x0000A7B600D825E1 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'ffgg', NULL, CAST(332.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (30, CAST(0x0000A7B6011E8189 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'AAA111', NULL, CAST(16000.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (31, CAST(0x0000A7B6012399AB AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'FACTRR343', NULL, CAST(12000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (32, CAST(0x0000A7B601576ECF AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'Fact45rt', NULL, CAST(10000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (33, CAST(0x0000A7B601606868 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'FFrrtt552', NULL, CAST(5000.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1026, CAST(0x0000A7B6016E6177 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'aaadd3', NULL, CAST(22000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1027, CAST(0x0000A7B60170B4DD AS DateTime), CAST(0x0000A7B600000000 AS DateTime), N'ee3344s', NULL, CAST(12000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1028, CAST(0x0000A7B7017541B2 AS DateTime), CAST(0x0000A7B700000000 AS DateTime), N'aa445512', NULL, CAST(40000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1029, CAST(0x0000A7B70177AC3F AS DateTime), CAST(0x0000A7B700000000 AS DateTime), N'44hhjyt', NULL, CAST(20000.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1030, CAST(0x0000A7DC01482ACF AS DateTime), CAST(0x0000A7DC00000000 AS DateTime), N'444', NULL, CAST(300.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1031, CAST(0x0000A7DD016C6AE4 AS DateTime), CAST(0x0000A7DD00000000 AS DateTime), N'4456', NULL, CAST(100.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1032, CAST(0x0000A809016D2E48 AS DateTime), CAST(0x0000A80500000000 AS DateTime), N'3434', NULL, CAST(1000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1034, CAST(0x0000A8190095DC7B AS DateTime), CAST(0x0000A81900000000 AS DateTime), N'FA271001', NULL, CAST(40000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1035, CAST(0x0000A8190096F766 AS DateTime), CAST(0x0000A81900000000 AS DateTime), N'FA271002', NULL, CAST(3000.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1036, CAST(0x0000A81C00986F26 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), N'FACT311001', NULL, CAST(1336.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1037, CAST(0x0000A81C01505E15 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), N'FACT30102020', NULL, CAST(4222.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1038, CAST(0x0000A81C01531706 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), N'FACT30102033', NULL, CAST(2224.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1039, CAST(0x0000A81C0159DE78 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), N'FA3010172057', NULL, CAST(4000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1040, CAST(0x0000A81C015C7920 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), N'FA30102108a', NULL, CAST(10000.00 AS Decimal(10, 2)), NULL, 1)
SET IDENTITY_INSERT [dbo].[Adquisicion] OFF
SET IDENTITY_INSERT [dbo].[Agente] ON 

INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (1, N'Pablo', N'Diez')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (2, N'Gustavo', N'Ripamonti')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (3, N'Damian', N'Daniel')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (4, N'Mariano', N'Marcovecchio')
SET IDENTITY_INSERT [dbo].[Agente] OFF
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 2, 17, 1, 1312, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 8, 24, 1, 1313, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 10, 41, 1, 1314, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 11, 39, 1, 1314, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 12, 47, 2, 1316, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 13, 48, 1, 1317, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1009, 1036, 1, 2314, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1010, 1040, 1, 2316, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1011, 1044, 2, 2316, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1012, 1046, 1, 2318, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1013, 1067, 1, 2330, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 2, 18, 1, 1312, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 8, 25, 2, 1313, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 10, 40, 1, 1314, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 13, 49, 1, 1317, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 1009, 1037, 1, 2314, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 1010, 1041, 1, 2316, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 1011, 1045, 2, 2316, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (3, 2, 19, 2, 1312, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (3, 13, 50, 2, 1317, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (3, 1009, 1038, 2, 2314, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (3, 1010, 1042, 1, 2316, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (4, 1010, 1043, 2, 2316, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Asignacion] ON 

INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (2, CAST(0x0000A7B400000000 AS DateTime), 1)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (8, CAST(0x0000A7B400000000 AS DateTime), 1)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (10, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (11, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (12, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (13, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1009, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1010, CAST(0x0000A7B700000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1011, CAST(0x0000A7B700000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1012, CAST(0x0000A7DC00000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1013, CAST(0x0000A81C00000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Asignacion] OFF
SET IDENTITY_INSERT [dbo].[Bien] ON 

INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (1, 3, N'PC', 1, 1, 2, 1)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (2, 5, N'Office 2016', 1, 4, 4, 2)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (3, 2, N'Notebook', 1, 1, 5, 1)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [DescripBien], [Homologado], [IdMarca], [IdModeloVersion], [IdTipoBien]) VALUES (4, 3, N'PC', 1, 1, 1, 1)
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
INSERT [dbo].[ConfigMailHost] ([Puerto], [Host], [Ssl], [Remitente], [Remps]) VALUES (587, N'smtp.gmail.com', 1, N'martinez.juan.marcos@gmail.com', N'descargas')
SET IDENTITY_INSERT [dbo].[Cotizacion] ON 

INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1, 200.0000, CAST(0x0000A72B00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (2, 300.0000, CAST(0x0000A72B00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (3, 450.0000, CAST(0x0000A72B00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (4, 300.0000, CAST(0x0000A77500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (5, 400.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (6, 390.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (7, 200.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (8, 250.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (9, 250.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (10, 250.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (11, 390.0000, CAST(0x0000A77500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (12, 300.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (13, 300.0000, CAST(0x0000A77500000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (14, 300.0000, CAST(0x0000A77500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (15, 300.0000, CAST(0x0000A77500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (16, 300.0000, CAST(0x0000A77500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (17, 399.0000, CAST(0x0000A77500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (18, 400.0000, CAST(0x0000A77500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (19, 300.0000, CAST(0x0000A77600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (20, 400.0000, CAST(0x0000A77900000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (21, 359.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (22, 356.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (23, 333.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (24, 334.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (25, 337.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (26, 356.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (27, 500.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (28, 501.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (29, 502.0000, CAST(0x0000A77A00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (30, 503.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (31, 504.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (32, 505.0000, CAST(0x0000A77A00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (33, 506.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (34, 507.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (35, 508.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (36, 509.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (37, 510.0000, CAST(0x0000A77A00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (38, 511.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (39, 512.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (40, 502.0000, CAST(0x0000A77A00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (41, 444.0000, CAST(0x0000A77A00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (42, 513.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (43, 445.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (44, 446.0000, CAST(0x0000A77A00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (45, 447.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (46, 448.0000, CAST(0x0000A77A00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (47, 449.0000, CAST(0x0000A77A00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (48, 400.0000, CAST(0x0000A77D00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (49, 457.0000, CAST(0x0000A77F00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (50, 2100.0000, CAST(0x0000A78300000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (51, 33.0000, CAST(0x0000A79300000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (52, 455.0000, CAST(0x0000A7A000000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (53, 555.0000, CAST(0x0000A7A000000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (54, 442.0000, CAST(0x0000A7A000000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (55, 466.0000, CAST(0x0000A7A000000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (56, 556.0000, CAST(0x0000A7A000000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (57, 500.0000, CAST(0x0000A7A000000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (58, 100.0000, CAST(0x0000A7A800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (59, 100.0000, CAST(0x0000A7A800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (60, 1111.0000, CAST(0x0000A7A800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (61, 111.0000, CAST(0x0000A7A800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (62, 222.0000, CAST(0x0000A7A800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (63, 233.0000, CAST(0x0000A7A800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (64, 1000.0000, CAST(0x0000A7AB00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (65, 1000.0000, CAST(0x0000A7AB00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (66, 1000.0000, CAST(0x0000A7AB00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (67, 999.0000, CAST(0x0000A7AB00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (68, 999.0000, CAST(0x0000A7AB00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (69, 999.0000, CAST(0x0000A7AB00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (70, 500.0000, CAST(0x0000A7B400000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (71, 500.0000, CAST(0x0000A7B400000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (72, 500.0000, CAST(0x0000A7B400000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (73, 50.0000, CAST(0x0000A7B400000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (74, 50.0000, CAST(0x0000A7B400000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (75, 50.0000, CAST(0x0000A7B400000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (76, 222.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (77, 333.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (78, 322.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (79, 100.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (80, 100.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (81, 110.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (82, 13000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (83, 13500.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (84, 13200.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (85, 7800.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (86, 8000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (87, 8000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (88, 8000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (89, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (90, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (91, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (92, 5000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (93, 5000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (94, 5000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (95, 5000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (96, 5000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (97, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (98, 10000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (99, 10000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
GO
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (100, 10000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (101, 9000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1076, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1077, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1078, 6000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1079, 12000.0000, CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1080, 12000.0000, CAST(0x0000A7B600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1081, 12000.0000, CAST(0x0000A7B600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1082, 10000.0000, CAST(0x0000A7B700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1083, 10000.0000, CAST(0x0000A7B700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1084, 10000.0000, CAST(0x0000A7B700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1085, 10000.0000, CAST(0x0000A7B700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1086, 10000.0000, CAST(0x0000A7B700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1087, 10000.0000, CAST(0x0000A7B700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1088, 100.0000, CAST(0x0000A7DC00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1089, 100.0000, CAST(0x0000A7DC00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1090, 100.0000, CAST(0x0000A7DC00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1091, 122.0000, CAST(0x0000A7FB00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1092, 233.0000, CAST(0x0000A80500000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1093, 222.0000, CAST(0x0000A80700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1094, 222.0000, CAST(0x0000A80700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1095, 23232.0000, CAST(0x0000A80700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1096, 23232.0000, CAST(0x0000A80700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1097, 23232.0000, CAST(0x0000A80700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1098, 2222.0000, CAST(0x0000A80700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1099, 1222.0000, CAST(0x0000A80700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1100, 1223.0000, CAST(0x0000A80700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1101, 333.0000, CAST(0x0000A80700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1102, 334.0000, CAST(0x0000A80700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1103, 334.0000, CAST(0x0000A80700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1104, 233.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1105, 1224.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1106, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1107, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1108, 333.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1109, 334.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1110, 344.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1111, 344.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1112, 343.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1113, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1114, 334.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1115, 335.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1116, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1117, 333.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1118, 333.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1119, 444.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1120, 444.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1121, 444.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1122, 444.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1123, 444.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1124, 444.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1125, 2223.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1126, 2223.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1127, 2223.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1128, 500.0000, CAST(0x0000A80900000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1129, 500.0000, CAST(0x0000A80900000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1130, 500.0000, CAST(0x0000A80900000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1131, 500.0000, CAST(0x0000A80900000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1132, 500.0000, CAST(0x0000A80900000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1133, 500.0000, CAST(0x0000A80900000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1135, 333.0000, CAST(0x0000A80F00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1137, 4000.0000, CAST(0x0000A81000000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1139, 5556.0000, CAST(0x0000A81000000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1140, 5557.0000, CAST(0x0000A81000000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1141, 222.0000, CAST(0x0000A81300000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1142, 222.0000, CAST(0x0000A81300000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1143, 334.0000, CAST(0x0000A81400000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1144, 334.0000, CAST(0x0000A81400000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1145, 334.0000, CAST(0x0000A81400000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1146, 10000.0000, CAST(0x0000A81900000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1147, 10000.0000, CAST(0x0000A81900000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1148, 10000.0000, CAST(0x0000A81900000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1149, 3000.0000, CAST(0x0000A81900000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1150, 3000.0000, CAST(0x0000A81900000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1151, 3000.0000, CAST(0x0000A81900000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1152, 222.0000, CAST(0x0000A81300000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1153, 1000.0000, CAST(0x0000A81C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1154, 1000.0000, CAST(0x0000A81C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1155, 2000.0000, CAST(0x0000A81C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1156, 2000.0000, CAST(0x0000A81C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1157, 2000.0000, CAST(0x0000A81C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1158, 2000.0000, CAST(0x0000A81C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1159, 2000.0000, CAST(0x0000A81C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1160, 2000.0000, CAST(0x0000A81C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1161, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1162, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1163, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1164, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1165, 334.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1166, 335.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1167, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1168, 333.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1169, 333.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1170, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1171, 334.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1172, 335.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1173, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1174, 333.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1175, 333.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1176, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
GO
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1177, 334.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1178, 335.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1179, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1180, 333.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1181, 333.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1182, 222.0000, CAST(0x0000A82C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1183, 399.0000, CAST(0x0000A82C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1184, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1185, 334.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1186, 335.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1187, 333.0000, CAST(0x0000A80800000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1188, 333.0000, CAST(0x0000A80800000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1189, 333.0000, CAST(0x0000A80800000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1190, 222.0000, CAST(0x0000A82C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1191, 399.0000, CAST(0x0000A82C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1192, 333.0000, CAST(0x0000A82C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1193, 333.0000, CAST(0x0000A82C00000000 AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Cotizacion] OFF
SET IDENTITY_INSERT [dbo].[Dependencia] ON 

INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (1, N'Fiscalia Nacional en lo Criminal y Correccional Nro 1', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (2, N'Fiscalia Nacional en lo Criminal y Correccional Nro 2', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (3, N'Fiscalia Nacional en lo Criminal y Correccional Nro 3', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (4, N'Fiscalia en lo Criminal de Instruccion Nro 1', 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia]) VALUES (5, N'Procuraduría Lavado de Activos', 2)
SET IDENTITY_INSERT [dbo].[Dependencia] OFF
SET IDENTITY_INSERT [dbo].[Deposito] ON 

INSERT [dbo].[Deposito] ([IdDeposito], [NombreDeposito], [IdDireccion]) VALUES (1, N'Informatica 3ro', 1)
SET IDENTITY_INSERT [dbo].[Deposito] OFF
SET IDENTITY_INSERT [dbo].[Direccion] ON 

INSERT [dbo].[Direccion] ([IdDireccion], [Calle], [NumeroCalle], [Localidad], [IdProvincia], [Piso]) VALUES (1, N'Belgrano', N'999', N'CABA', 1, N'3')
SET IDENTITY_INSERT [dbo].[Direccion] OFF
SET IDENTITY_INSERT [dbo].[EstadoInventario] ON 

INSERT [dbo].[EstadoInventario] ([IdEstadoInventario], [DescripEstadoInv]) VALUES (1, N'Disponible')
INSERT [dbo].[EstadoInventario] ([IdEstadoInventario], [DescripEstadoInv]) VALUES (2, N'Entregado')
SET IDENTITY_INSERT [dbo].[EstadoInventario] OFF
SET IDENTITY_INSERT [dbo].[EstadoSolicDetalle] ON 

INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (2, N'Cotizado')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (3, N'Adquirido')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (4, N'Entregado')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (5, N'Cancelado')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (6, N'EnPartida')
SET IDENTITY_INSERT [dbo].[EstadoSolicDetalle] OFF
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] ON 

INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (2, N'Finalizada')
INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (3, N'Cerrada')
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] OFF
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'Backup', N'Respaldo y Restauración de la Base de Datos', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnAgregarProd', N'Add', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnAgregarProd', N'Agregar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnBuscar', N'Buscar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnBuscar', N'Find', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnCrearProveedor', N'Crear', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnCrearProveedor', N'New', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnDinBorrar', N'Quitar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnDinBorrar', N'Remove', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnDireccion', N'Add', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnDireccion', N'Agregar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnExaminarRespaldar', N'Examinar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnExaminarRespaldar', N'Explore', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnExaminarRestaurar', N'Examinar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnExaminarRestaurar', N'Explore', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnLogin', N'Ingresar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnLogin', N'Sign in', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnRespaldar', N'Backup', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnRespaldar', N'Respaldar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnRestaurar', N'Restaurar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnRestaurar', N'Restore', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnTelefono', N'Add', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'btnTelefono', N'Agregar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'buttonX1', N'Crear Solicitud', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'buttonX1', N'Create Issue', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'gboxRespaldar', N'Backup', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'gboxRespaldar', N'Respaldar (Realizar Backup)', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'gboxRestaurar', N'Restaurar', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'gboxRestaurar', N'Restore', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'gpanelProductos', N'Productos', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'gpanelProductos', N'Products', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblAgenteResponsable', N'In Charge', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblAgenteResponsable', N'Responsable', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblAlias', N'Alias', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblAlias', N'Nickname', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblContacto', N'Contact', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblContacto', N'Contacto', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblDependencia', N'Attorney', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblDependencia', N'Dependencia', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblDestinoRespaldar', N'Destino', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblDestinoRespaldar', N'Destiny', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblDireccion', N'Adress', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblDireccion', N'Dirección', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblMailContacto', N'Contact Mail', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblMailContacto', N'Mail del Contacto', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblMailEmpresa', N'Company Mail', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblMailEmpresa', N'Mail Alternativo', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblMailEmpresa', N'Mail de la Empresa', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblNombreRespaldar', N'Name', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblNombreRespaldar', N'Nombre', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblNombreRestaurar', N'Name', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblNombreRestaurar', N'Nombre', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblNroSolicitud', N'Issue', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblNroSolicitud', N'Solicitud', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblObservaciones', N'Observaciones', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblObservaciones', N'Observations', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblPrueba', N'Esto es una prueba', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblPrueba', N'This is a test', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblRazonSocial', N'Company Name', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblRazonSocial', N'Razón Social', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblSalir', N'Exit', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblSalir', N'Salir', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblTelefono', N'Phone/s', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblTelefono', N'Teléfono/s', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblUbicacionRestaurar', N'Location', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'lblUbicacionRestaurar', N'Ubicación', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'Mensaje1', N'Este pedido no cumple con las políticas de Informática ¿Desea continuar?', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'Mensaje1', N'The request does not comply with the IT policies ¿Continue?', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'Mensaje2', N'Usuario y/o Contraseña incorrectos', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'Mensaje2', N'Wrong User or Password ', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'metroSolicitud', N'Crear Solicitud', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'pnlTitulo', N'Iniciar Sesion', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'pnlTitulo', N'Sign in', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'ProveedorCrear', N'Crear Proveedor', 1)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'ProveedorCrear', N'New Supplier', 2)
INSERT [dbo].[Etiqueta] ([NombreControl], [Texto], [IdIdioma]) VALUES (N'tabSolic', N'Solicitudes', 1)
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [NombreIdioma], [ElIdiomaDefault]) VALUES (1, N'Español', 1)
INSERT [dbo].[Idioma] ([IdIdioma], [NombreIdioma], [ElIdiomaDefault]) VALUES (2, N'English', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
SET IDENTITY_INSERT [dbo].[Inventario] ON 

INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1, 1, NULL, N'111110', 2, 1, 1, 2, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (2, 1, NULL, N'111112', 2, 1, 1, 2, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (3, 3, NULL, N'111111', 2, 1, 1, 1, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (4, 3, NULL, N'sss444', 3, 1, 1, 1, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (5, 4, NULL, N'sss555', 3, 1, 1, 2, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (6, 1, NULL, N'sss666', 3, 1, 1, 2, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (7, 3, NULL, N'rr444', 4, 1, 1, 1, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (8, 4, NULL, N'ttt555', 4, 1, 1, 2, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (9, 3, NULL, N'aaa1122', 8, 1, 1, 1, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (10, 4, NULL, N'aaa1124', 8, 1, 1, 2, 56, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (11, 2, N'serial', N'productkey', 9, NULL, 1, 2, 58, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (12, 4, NULL, N'asdf22', 10, 1, 1, 1, 58, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (15, 1, NULL, N'123346', 12, 1, 1, 1, 58, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (16, 1, NULL, N'123345', 12, 1, 1, 1, 58, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (17, 3, NULL, N'a12345', 13, 1, 1, 1, 59, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (18, 3, NULL, N'a12346', 13, 1, 1, 1, 59, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (19, 4, NULL, N'a11111', 14, 1, 1, 2, 59, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (24, 1, NULL, N'rrrttt', 17, 1, 2, 1, 60, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (25, 2, NULL, N'tttrrrr', 17, NULL, 2, 2, 60, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (26, 1, NULL, N'4343', 18, 1, 1, 1, 57, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (27, 1, NULL, N'hh67a', 19, 1, 1, 1, 57, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (28, 4, NULL, N'r2fsd234', 20, 1, 1, 1, 57, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (29, 2, NULL, N'wert453', 21, NULL, 1, 2, 57, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (30, 4, NULL, N'agga22221', 22, 1, 1, 1, 55, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (37, 1, NULL, N'Serie221', 27, 1, 1, 1, 55, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (38, 1, NULL, N'Serie222', 27, 1, 1, 1, 55, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (39, 1, NULL, N'Hola111', 28, 1, 2, 1, 61, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (40, 1, NULL, N'Hola112', 28, 1, 2, 1, 61, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (41, 1, NULL, N'Hola113', 28, 1, 2, 1, 61, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (42, 3, NULL, N'fffr111', 29, 1, 1, 2, 61, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (43, 3, NULL, N'fffr112', 29, 1, 1, 2, 61, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (44, 4, NULL, N'aaa20071', 30, 1, 1, 2, 62, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (45, 4, NULL, N'aaa20072', 30, 1, 1, 2, 62, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (46, 4, NULL, N'200717401', 31, 1, 1, 1, 63, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (47, 3, NULL, N'200717411', 31, 1, 2, 2, 63, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (48, 3, NULL, N'200720491', 32, 1, 2, 1, 64, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (49, 3, NULL, N'200720492', 32, 1, 2, 1, 64, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (50, 1, NULL, N'200720491', 32, 1, 2, 2, 64, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (51, 4, NULL, N'200721221', 33, 1, 1, 2, 64, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1036, 1, NULL, N'200722131', 1026, 1, 2, 1, 1061, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1037, 1, NULL, N'200722132', 1026, 1, 2, 1, 1061, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1038, 3, NULL, N'200722131', 1026, 1, 2, 2, 1061, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1039, 3, NULL, N'200722221', 1027, 1, 1, 2, 1061, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1040, 1, NULL, N'210722381', 1028, 1, 2, 1, 1062, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1041, 1, NULL, N'210722382', 1028, 1, 2, 1, 1062, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1042, 1, NULL, N'210722383', 1028, 1, 2, 1, 1062, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1043, 3, NULL, N'210722381', 1028, 1, 2, 2, 1062, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1044, 3, NULL, N'210722471', 1029, 1, 2, 2, 1062, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1045, 3, NULL, N'210722472', 1029, 1, 2, 2, 1062, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1046, 1, NULL, N'270820171', 1030, 1, 2, 1, 1063, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1047, 1, NULL, N'280820171', 1031, 1, 1, 1, 1063, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1048, 1, NULL, N'234234', 1032, 1, 1, 1, 1064, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1049, 1, NULL, N'2342322', 1032, 1, 1, 1, 1064, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1051, 3, NULL, N'27101701', 1034, 1, 1, 1, 1065, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1052, 3, NULL, N'27101702', 1034, 1, 1, 1, 1065, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1053, 3, NULL, N'27101703', 1034, 1, 1, 1, 1065, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1054, 3, NULL, N'27101704', 1034, 1, 1, 1, 1065, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1055, 2, N'1', N'27101701', 1035, NULL, 1, 2, 1065, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1056, 1, NULL, N'31100900', 1036, 1, 1, 1, 1066, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1057, 1, NULL, N'31100901', 1036, 1, 1, 1, 1066, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1058, 1, NULL, N'31100902', 1036, 1, 1, 1, 1066, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1059, 1, NULL, N'31100903', 1036, 1, 1, 1, 1066, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1060, 3, NULL, N'30101701', 1037, 1, 1, 2, 1067, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1061, 3, NULL, N'30101702', 1037, 1, 1, 2, 1067, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1062, 3, NULL, N'30102034', 1038, 1, 1, 2, 1067, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1063, 3, NULL, N'3010203401', 1038, 1, 1, 2, 1067, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1064, 1, NULL, N'301020581', 1039, 1, 1, 1, 1068, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1065, 1, NULL, N'301020582', 1039, 1, 1, 1, 1068, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1066, 3, NULL, N'30101721081', 1040, 1, 1, 1, 1069, NULL)
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdAdquisicion], [IdDeposito], [IdEstadoInventario], [IdPartidaDetalle], [IdPartida], [Costo]) VALUES (1067, 3, NULL, N'30101721082', 1040, 1, 2, 1, 1069, NULL)
SET IDENTITY_INSERT [dbo].[Inventario] OFF
SET IDENTITY_INSERT [dbo].[Limite] ON 

INSERT [dbo].[Limite] ([IdLimite], [DescripLimite], [ValorLimite]) VALUES (1, N'Limite Caja', 2000.0000)
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
SET IDENTITY_INSERT [dbo].[Partida] ON 

INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (2, CAST(2100.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A783015B3C39 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (3, CAST(2100.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A783017E4A01 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (4, CAST(2100.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A783017E913A AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (5, CAST(2100.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A783017F41D1 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (6, CAST(2100.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A783017FEEFA AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (7, CAST(2100.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78400A0E6D4 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (8, CAST(2400.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A784010BB2B6 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (9, CAST(200.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A784010DC79E AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (10, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401422610 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (11, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840143228D AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (12, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840143400B AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (13, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401451B8C AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (14, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401461DBB AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (15, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840146714E AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (17, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840150F53D AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (18, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840151231B AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (19, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840151AB01 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (20, CAST(2400.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401522F1A AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (21, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840153256B AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (22, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401553D54 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (23, CAST(5000.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401558394 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (24, CAST(5000.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401560764 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (25, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401561FB4 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (26, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A784015FF44C AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (27, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401614D58 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (28, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7840163ADAE AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (29, CAST(5000.12 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78401651F5D AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (30, CAST(5001.11 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A784016611DB AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (31, CAST(5010.45 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A784016853A2 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (32, CAST(5040.46 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A784016881CB AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (33, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7850091D71E AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (35, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78500933E20 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (36, CAST(2611.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78500939CD7 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (37, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7850093FD42 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (39, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78500950ED3 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (41, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7850136D1EC AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (42, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7850137249E AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (43, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A785013DD287 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (44, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A785013EBBFA AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (45, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A785013ED34C AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (46, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7850142746D AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (47, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78501427832 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (48, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78501432DD0 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (49, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7850145A29D AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (50, CAST(500.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)), N'YA123', CAST(0x0000A7850145BAC4 AS DateTime), CAST(0x0000A78900000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (51, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A785014A7A67 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (52, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A785014D988D AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (53, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A785014D9CC8 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (54, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78800DAA824 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (55, CAST(500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A78900E87F50 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (56, CAST(942.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7A0016A5D9D AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (57, CAST(200.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7A801202EC5 AS DateTime), NULL, 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (58, CAST(200.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7A8012124AA AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (59, CAST(1999.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A7AB0137A10F AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (60, CAST(550.00 AS Decimal(10, 2)), CAST(550.00 AS Decimal(10, 2)), N'442r', CAST(0x0000A7B4015BBD53 AS DateTime), CAST(0x0000A7B400000000 AS DateTime), 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (61, CAST(322.00 AS Decimal(10, 2)), CAST(322.00 AS Decimal(10, 2)), N'AAPartInf1', CAST(0x0000A7B600D5CEFC AS DateTime), CAST(0x0000A7B600000000 AS DateTime), 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (62, CAST(21000.00 AS Decimal(10, 2)), CAST(21000.00 AS Decimal(10, 2)), N'PART200720', CAST(0x0000A7B6011DC497 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (63, CAST(17000.00 AS Decimal(10, 2)), CAST(17000.00 AS Decimal(10, 2)), N'AASS22', CAST(0x0000A7B60122F9D8 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (64, CAST(28000.00 AS Decimal(10, 2)), CAST(28000.00 AS Decimal(10, 2)), N'lll999', CAST(0x0000A7B60156A257 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1061, CAST(36000.00 AS Decimal(10, 2)), CAST(36000.00 AS Decimal(10, 2)), N'aaa342', CAST(0x0000A7B6016CC650 AS DateTime), CAST(0x0000A7B600000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1062, CAST(60000.00 AS Decimal(10, 2)), CAST(60000.00 AS Decimal(10, 2)), N'gg4455', CAST(0x0000A7B701739777 AS DateTime), CAST(0x0000A7B700000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1063, CAST(300.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)), N'1063ADM', CAST(0x0000A7DC01475D45 AS DateTime), CAST(0x0000A7DC00000000 AS DateTime), 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1064, CAST(1500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A809016C2BD2 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1065, CAST(43000.00 AS Decimal(10, 2)), CAST(43000.00 AS Decimal(10, 2)), N'Part271001', CAST(0x0000A8190094A3CC AS DateTime), CAST(0x0000A81900000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1066, CAST(1336.00 AS Decimal(10, 2)), CAST(1336.00 AS Decimal(10, 2)), N'PART301001', CAST(0x0000A81C00964697 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1067, CAST(4222.00 AS Decimal(10, 2)), CAST(4222.00 AS Decimal(10, 2)), N'PART301020', CAST(0x0000A81C014F34A1 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1068, CAST(4000.00 AS Decimal(10, 2)), CAST(4000.00 AS Decimal(10, 2)), N'PART301017', CAST(0x0000A81C0159310B AS DateTime), CAST(0x0000A81C00000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1069, CAST(10000.00 AS Decimal(10, 2)), CAST(10000.00 AS Decimal(10, 2)), N'PA30102107', CAST(0x0000A81C015C0A25 AS DateTime), CAST(0x0000A81C00000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1070, CAST(1500.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A81E016595F7 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1071, CAST(43000.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A829010C4522 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1072, CAST(1332.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A82C00978493 AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Partida] OFF
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 2, 1, 37, 1)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 3, 1, 37, 2)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 4, 1, 37, 3)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 5, 1, 37, 4)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 6, 1, 37, 5)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 7, 1, 37, 6)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 8, 1, 37, 7)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 9, 1, 37, 8)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 10, 1, 37, 9)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 11, 1, 37, 10)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 12, 1, 37, 11)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 13, 1, 37, 12)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 14, 1, 37, 13)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 15, 1, 37, 14)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 17, 1, 37, 15)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 18, 1, 37, 16)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 19, 1, 37, 17)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 20, 1, 37, 18)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 21, 1, 37, 19)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 22, 1, 37, 20)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 23, 1, 37, 21)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 24, 1, 37, 22)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 25, 1, 37, 23)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 26, 1, 37, 24)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 27, 1, 37, 25)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 28, 1, 37, 26)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 29, 1, 37, 27)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 30, 1, 37, 28)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 31, 1, 37, 29)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 32, 1, 37, 30)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 33, 1, 37, 31)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 35, 1, 37, 32)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 36, 1, 37, 33)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 37, 1, 37, 34)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 39, 1, 37, 35)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 41, 1, 37, 36)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 42, 1, 37, 37)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 43, 1, 37, 38)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 44, 1, 37, 39)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 45, 1, 37, 40)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 46, 1, 37, 41)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 47, 1, 37, 42)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 48, 1, 37, 43)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 49, 1, 37, 44)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 50, 1, 37, 45)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 51, 1, 37, 46)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 52, 1, 37, 47)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 53, 1, 37, 48)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 54, 1, 37, 49)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 55, 1, 37, 50)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 56, 1, 1311, 51)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 57, 1, 1310, 52)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 58, 1, 1310, 53)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 59, 1, 1312, 54)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 60, 1, 1313, 55)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 61, 1, 1314, 56)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 62, 1, 1315, 57)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 63, 1, 1316, 58)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 64, 1, 1317, 59)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1061, 1, 2314, 60)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1062, 1, 2316, 61)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1063, 1, 2318, 62)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1064, 1, 2324, 63)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1065, 1, 2328, 64)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1066, 1, 2325, 65)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1067, 1, 2326, 66)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1068, 1, 2329, 67)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1069, 1, 2330, 68)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1070, 1, 2324, 69)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1071, 1, 2328, 70)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1072, 1, 2322, 71)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 8, 2, 37, 72)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 10, 2, 37, 73)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 11, 2, 37, 74)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 12, 2, 37, 75)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 13, 2, 37, 76)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 14, 2, 37, 77)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 15, 2, 37, 78)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 17, 2, 37, 79)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 18, 2, 37, 80)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 19, 2, 37, 81)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 20, 2, 37, 82)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 21, 2, 37, 83)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 22, 2, 37, 84)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 23, 2, 37, 85)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 24, 2, 37, 86)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 25, 2, 37, 87)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 26, 2, 37, 88)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 27, 2, 37, 89)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 28, 2, 37, 90)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 29, 2, 37, 91)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 30, 2, 37, 92)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 31, 2, 37, 93)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 32, 2, 37, 94)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 33, 2, 37, 95)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 35, 2, 37, 96)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 36, 2, 37, 97)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 37, 2, 37, 98)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 39, 2, 37, 99)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 41, 2, 37, 100)
GO
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 42, 2, 37, 101)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 43, 2, 37, 102)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 44, 2, 37, 103)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 45, 2, 37, 104)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 46, 2, 37, 105)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 47, 2, 37, 106)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 48, 2, 37, 107)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 49, 2, 37, 108)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 50, 2, 37, 109)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 51, 2, 37, 110)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 52, 2, 37, 111)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 53, 2, 37, 112)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 54, 2, 37, 113)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 55, 2, 37, 114)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 56, 2, 1311, 115)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 57, 2, 1310, 116)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 58, 2, 1310, 117)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 59, 2, 1312, 118)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 60, 2, 1313, 119)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 61, 2, 1314, 120)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 62, 2, 1315, 121)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 63, 2, 1316, 122)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 64, 2, 1317, 123)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1061, 2, 2314, 124)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1062, 2, 2316, 125)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1064, 2, 2324, 126)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1065, 2, 2328, 127)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1067, 2, 2326, 128)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1070, 2, 2324, 129)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1071, 2, 2328, 130)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (3, 1072, 3, 2322, 131)
INSERT [dbo].[Politica] ([IdTipoDependencia], [IdCategoria], [Cantidad]) VALUES (1, 2, 1)
INSERT [dbo].[Politica] ([IdTipoDependencia], [IdCategoria], [Cantidad]) VALUES (1, 3, 3)
SET IDENTITY_INSERT [dbo].[Prioridad] ON 

INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (1, N'Baja')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (2, N'Normal')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (3, N'Alta')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (4, N'Inmediata')
SET IDENTITY_INSERT [dbo].[Prioridad] OFF
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocialProv], [AliasProv], [ContactoProv], [MailContactoProv], [MailAlternativoProv]) VALUES (1, N'Proveedor1', N'Proveedor1', N'Juan', N'martinez.juan.marcos@gmail.com', NULL)
INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocialProv], [AliasProv], [ContactoProv], [MailContactoProv], [MailAlternativoProv]) VALUES (2, N'Proveedor2', N'Proveedor2', N'Pepe', N'loyolajavi@gmail.com', N'info@Prov2.com.ar')
INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocialProv], [AliasProv], [ContactoProv], [MailContactoProv], [MailAlternativoProv]) VALUES (3, N'Empresa1', N'Empresa1', N'Lola', N'martinez.juan.marcos@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
SET IDENTITY_INSERT [dbo].[Provincia] ON 

INSERT [dbo].[Provincia] ([IdProvincia], [NombreProvincia]) VALUES (1, N'Buenos Aires')
SET IDENTITY_INSERT [dbo].[Provincia] OFF
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 9)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 10)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 11)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 12)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 13)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 14)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 15)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 17)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 18)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 19)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 21)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 22)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 23)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 24)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 25)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 26)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 27)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 28)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 29)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 30)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 31)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 32)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 33)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 35)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 37)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 39)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 41)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 42)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 43)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 44)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 45)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 46)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 47)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 48)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 49)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 50)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 51)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 52)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 53)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 54)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1, 1, 55)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 9)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 10)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 11)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 12)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 13)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 14)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 15)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 17)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 18)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 19)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 21)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 22)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 23)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 24)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 25)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 26)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 27)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 28)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 29)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 30)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 31)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 32)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 33)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 35)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 37)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 39)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 41)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 42)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 43)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 44)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 45)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 46)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 47)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 48)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 49)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 50)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 51)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 52)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 53)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 54)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (7, 1, 55)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 9)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 10)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 11)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 12)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 13)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 14)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 15)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 17)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 18)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 19)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 21)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 22)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 23)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 24)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 25)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 26)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 27)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 28)
GO
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 29)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 30)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 31)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 32)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 33)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 35)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 37)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 39)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 41)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 42)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 43)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 44)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 45)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 46)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 47)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 48)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 49)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 50)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 51)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 52)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 53)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 54)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (8, 1, 55)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 8)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 10)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 11)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 12)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 13)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 14)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 15)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 17)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 18)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 19)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 20)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 21)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 22)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 23)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 24)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 25)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 26)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 27)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 28)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 29)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 30)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 31)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 32)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 33)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 35)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 37)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 39)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 41)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 42)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 43)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 44)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 45)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 46)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 47)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 48)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 49)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 50)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 51)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 52)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 53)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 54)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (12, 2, 55)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 8)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 10)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 11)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 12)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 13)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 14)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 15)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 17)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 18)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 19)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 20)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 21)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 22)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 23)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 24)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 25)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 26)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 27)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 28)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 29)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 30)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 31)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 32)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 33)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 35)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 37)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 39)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 41)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 42)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 43)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 44)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 45)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 46)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 47)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 48)
GO
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 49)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 50)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 51)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 52)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 53)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 54)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (13, 2, 55)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 8)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 10)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 11)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 12)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 13)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 14)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 15)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 17)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 18)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 19)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 20)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 21)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 22)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 23)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 24)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 25)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 26)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 27)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 28)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 29)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 30)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 31)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 32)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 33)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 35)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 37)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 39)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 41)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 42)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 43)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 44)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 45)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 46)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 47)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 48)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 49)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 50)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 51)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 52)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 53)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 54)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (14, 2, 55)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (38, 2, 36)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 2)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 3)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 4)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 5)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 6)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 7)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 8)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 20)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (50, 1, 36)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (52, 1, 56)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (53, 2, 56)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (54, 1, 56)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (55, 1, 56)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (56, 2, 56)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (57, 2, 56)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (58, 1, 57)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (58, 1, 58)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (59, 2, 57)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (59, 2, 58)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (60, 1, 57)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (60, 1, 58)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (61, 1, 57)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (61, 1, 58)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (62, 2, 57)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (62, 2, 58)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (63, 2, 57)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (63, 2, 58)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (64, 1, 59)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (65, 1, 59)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (66, 1, 59)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (67, 2, 59)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (68, 2, 59)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (69, 2, 59)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (70, 1, 60)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (71, 1, 60)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (72, 1, 60)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (73, 2, 60)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (74, 2, 60)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (75, 2, 60)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (76, 1, 61)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (77, 1, 61)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (78, 1, 61)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (79, 2, 61)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (80, 2, 61)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (81, 2, 61)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (82, 1, 62)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (83, 1, 62)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (84, 1, 62)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (86, 2, 62)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (87, 2, 62)
GO
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (88, 2, 62)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (89, 1, 63)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (90, 1, 63)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (91, 1, 63)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (92, 2, 63)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (93, 2, 63)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (94, 2, 63)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (95, 1, 64)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (96, 1, 64)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (97, 1, 64)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (98, 2, 64)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (99, 2, 64)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (101, 2, 64)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1076, 1, 1061)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1077, 1, 1061)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1078, 1, 1061)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1079, 2, 1061)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1080, 2, 1061)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1081, 2, 1061)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1082, 1, 1062)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1083, 1, 1062)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1084, 1, 1062)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1085, 2, 1062)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1086, 2, 1062)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1087, 2, 1062)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1088, 1, 1063)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1089, 1, 1063)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1090, 1, 1063)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1128, 1, 1064)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1128, 1, 1070)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1129, 1, 1064)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1129, 1, 1070)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1130, 1, 1064)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1130, 1, 1070)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1131, 2, 1064)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1131, 2, 1070)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1132, 2, 1064)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1132, 2, 1070)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1133, 2, 1064)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1133, 2, 1070)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1143, 1, 1066)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1144, 1, 1066)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1145, 1, 1066)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1146, 1, 1065)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1146, 1, 1071)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1147, 1, 1065)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1147, 1, 1071)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1148, 1, 1065)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1148, 1, 1071)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1149, 2, 1065)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1149, 2, 1071)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1150, 2, 1065)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1150, 2, 1071)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1151, 2, 1065)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1151, 2, 1071)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1152, 1, 1067)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1153, 1, 1067)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1154, 1, 1067)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1155, 2, 1067)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1156, 2, 1067)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1157, 2, 1067)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1158, 1, 1068)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1159, 1, 1068)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1160, 1, 1068)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1161, 1, 1069)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1162, 1, 1069)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1163, 1, 1069)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1184, 1, 1072)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1185, 1, 1072)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1186, 1, 1072)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1191, 3, 1072)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1192, 3, 1072)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartidaDetalle], [IdPartida]) VALUES (1193, 3, 1072)
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
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 50)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 37, 51)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1310, 58)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1310, 60)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1310, 61)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1311, 52)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1311, 54)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1311, 55)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1312, 64)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1312, 65)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1312, 66)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1313, 70)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1313, 71)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1313, 72)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1314, 76)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1314, 77)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1314, 78)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1315, 82)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1315, 83)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1315, 84)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1316, 89)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1316, 90)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1316, 91)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1317, 95)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1317, 96)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 1317, 97)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2314, 1076)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2314, 1077)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2314, 1078)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2316, 1082)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2316, 1083)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2316, 1084)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2318, 1088)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2318, 1089)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2318, 1090)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1092)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1093)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1094)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1095)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1096)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1097)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2319, 1104)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2322, 1184)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2322, 1185)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2322, 1186)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2324, 1128)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2324, 1129)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2324, 1130)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2325, 1143)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2325, 1144)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2325, 1145)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2326, 1152)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2326, 1153)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2326, 1154)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2328, 1146)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2328, 1147)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2328, 1148)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2329, 1158)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2329, 1159)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2329, 1160)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2330, 1161)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2330, 1162)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2330, 1163)
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
GO
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
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1310, 59)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1310, 62)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1310, 63)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1311, 53)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1311, 56)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1311, 57)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1312, 67)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1312, 68)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1312, 69)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1313, 73)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1313, 74)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1313, 75)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1314, 79)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1314, 80)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1314, 81)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1315, 85)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1315, 86)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1315, 87)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1315, 88)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1316, 92)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1316, 93)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1316, 94)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1317, 98)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1317, 99)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1317, 100)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 1317, 101)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2314, 1079)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2314, 1080)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2314, 1081)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2316, 1085)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2316, 1086)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2316, 1087)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2319, 1098)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2319, 1099)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2319, 1100)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2319, 1105)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2322, 1187)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2322, 1188)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2322, 1189)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2322, 1190)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2324, 1131)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2324, 1132)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2324, 1133)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2326, 1155)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2326, 1156)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2326, 1157)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2328, 1149)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2328, 1150)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2328, 1151)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2322, 1191)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2322, 1192)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2322, 1193)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (1, 3, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (2, 3, 3)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 2, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (4, 1, 4)
INSERT [dbo].[RelPDetAdq] ([IdPartidaDetalle], [IdPartida], [IdAdquisicion]) VALUES (1, 1062, 1028)
INSERT [dbo].[RelPDetAdq] ([IdPartidaDetalle], [IdPartida], [IdAdquisicion]) VALUES (2, 1062, 1028)
INSERT [dbo].[RelPDetAdq] ([IdPartidaDetalle], [IdPartida], [IdAdquisicion]) VALUES (2, 1062, 1029)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (1, 2326, 1)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (2, 2319, 2)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (2, 2324, 4)
SET IDENTITY_INSERT [dbo].[Rendicion] ON 

INSERT [dbo].[Rendicion] ([IdRendicion], [MontoGasto], [IdPartida], [FechaRen]) VALUES (2, CAST(60000.00 AS Decimal(18, 2)), 1062, CAST(0x0000A7CE00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Rendicion] OFF
SET IDENTITY_INSERT [dbo].[SolicDetalle] ON 

INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 21, 3, 22, 1, 1)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 23, 3, 12, 1, 2)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 24, 3, 2, 1, 3)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 25, 3, 2, 1, 4)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 27, 3, 2, 1, 5)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 28, 3, 2, 1, 6)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 29, 5, 1, 1, 7)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 30, 5, 1, 1, 8)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 32, 5, 1, 1, 9)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 33, 5, 1, 1, 10)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 34, 3, 2, 1, 11)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 35, 5, 1, 1, 12)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 37, 3, 2, 2, 13)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1305, 3, 2, 1, 14)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1308, 3, 2, 1, 15)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1309, 3, 2, 1, 16)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1310, 3, 3, 1, 17)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1311, 2, 1, 3, 18)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1312, 2, 2, 3, 19)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1313, 3, 1, 3, 20)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1314, 3, 3, 4, 21)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1315, 2, 2, 1, 22)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1316, 3, 2, 1, 23)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1317, 2, 2, 3, 24)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2314, 3, 2, 4, 25)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2315, 3, 3, 1, 26)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2316, 3, 3, 4, 27)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2318, 3, 3, 1, 28)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2319, 3, 5, 2, 29)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2321, 5, 2, 2, 64)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2322, 3, 2, 6, 109)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2324, 3, 2, 2, 33)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2325, 3, 4, 2, 86)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2326, 5, 1, 2, 93)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2328, 2, 4, 6, 91)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2329, 3, 2, 2, 96)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2330, 2, 2, 3, 100)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 23, 5, 1, 1, 34)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 24, 5, 2, 1, 35)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 27, 5, 2, 1, 36)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 28, 5, 1, 1, 37)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 33, 5, 1, 1, 38)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 35, 3, 1, 1, 39)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 36, 3, 2, 1, 40)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 37, 3, 4, 1, 41)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1308, 5, 2, 1, 42)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1309, 5, 1, 1, 43)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1310, 5, 1, 1, 44)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1311, 3, 2, 3, 45)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1312, 3, 1, 3, 46)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1313, 5, 1, 3, 47)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1314, 2, 2, 4, 48)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1315, 3, 2, 1, 49)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1316, 2, 1, 3, 50)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1317, 3, 2, 3, 51)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2314, 2, 2, 3, 52)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2315, 2, 3, 1, 53)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2316, 2, 3, 4, 54)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2319, 5, 1, 2, 55)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2321, 2, 1, 1, 65)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2322, 5, 1, 6, 110)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2324, 5, 1, 2, 59)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2326, 2, 2, 2, 94)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2328, 5, 1, 6, 92)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (3, 2322, 2, 1, 6, 111)
SET IDENTITY_INSERT [dbo].[SolicDetalle] OFF
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
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1311, CAST(0x0000A7A000000000 AS DateTime), NULL, 1, 2, 1, 1, 4)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1312, CAST(0x0000A7AB00000000 AS DateTime), NULL, 1, 1, 1, 1, 4)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1313, CAST(0x0000A7B400000000 AS DateTime), NULL, 1, 2, 1, 1, 4)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1314, CAST(0x0000A7B600000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1315, CAST(0x0000A7B600000000 AS DateTime), NULL, 3, 1, 1, 1, 2)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1316, CAST(0x0000A7B600000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (1317, CAST(0x0000A7B600000000 AS DateTime), NULL, 1, 1, 1, 1, 4)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2314, CAST(0x0000A7B600000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2315, CAST(0x0000A7B600000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2316, CAST(0x0000A7B700000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2317, CAST(0x0000A7D100000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2318, CAST(0x0000A7DC00000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2319, CAST(0x0000A7DE00000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2321, CAST(0x0000A7F200000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2322, CAST(0x0000A80800000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2323, CAST(0x0000A80800000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2324, CAST(0x0000A80900000000 AS DateTime), NULL, 1, 1, 1, 1, 4)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2325, CAST(0x0000A80B00000000 AS DateTime), NULL, 3, 2, 1, 2, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2326, CAST(0x0000A81000000000 AS DateTime), NULL, 3, 1, 1, 1, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2327, CAST(0x0000A80F00000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2328, CAST(0x0000A81900000000 AS DateTime), NULL, 3, 3, 1, 2, 1)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2329, CAST(0x0000A81C00000000 AS DateTime), NULL, 2, 1, 1, 1, 3)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente]) VALUES (2330, CAST(0x0000A81C00000000 AS DateTime), NULL, 1, 1, 1, 1, 4)
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
SET IDENTITY_INSERT [dbo].[TipoBien] ON 

INSERT [dbo].[TipoBien] ([IdTipoBien], [DescripTipoBien]) VALUES (1, N'Hardware')
INSERT [dbo].[TipoBien] ([IdTipoBien], [DescripTipoBien]) VALUES (2, N'Software')
SET IDENTITY_INSERT [dbo].[TipoBien] OFF
SET IDENTITY_INSERT [dbo].[TipoDependencia] ON 

INSERT [dbo].[TipoDependencia] ([IdTipoDependencia], [DescripTipoDependencia]) VALUES (1, N'Comun')
INSERT [dbo].[TipoDependencia] ([IdTipoDependencia], [DescripTipoDependencia]) VALUES (2, N'Especial')
SET IDENTITY_INSERT [dbo].[TipoDependencia] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual]) VALUES (1, N'pargi', N'E59pyTwEJJao6VjsWTBmLGzMr78=', 1)
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual]) VALUES (2, N'lola', N'E59pyTwEJJao6VjsWTBmLGzMr78=', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Inventario]    Script Date: 29/11/2017 21:48:17 ******/
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
