USE [master]
GO
/****** Object:  Database [Artec]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionesConBienesPorIdPartida]    Script Date: 05/09/2018 21:08:20 ******/
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

--Select adq.IdAdquisicion, adq.NroFactura, cat.idCategoria, cat.DescripCategoria, inv.SerieKey, inv.Costo
--FROM Categoria cat
--INNER JOIN Bien bi ON (bi.IdCategoria = cat.IdCategoria)
--INNER JOIN Inventario inv ON inv.IdBienEspecif = bi.IdBien
--LEFT JOIN RelPDetAdq rel ON inv.IdInventario = rel.IdInventario
--LEFT JOIN Adquisicion adq ON rel.IdAdquisicion = adq.IdAdquisicion
--WHERE inv.IdInventario in
--	(
--	select rel.IdInventario
--	from RelPDetAdq rel
--	Where rel.IdPartida = 1084
--	and rel.IdAdquisicion not in
--		(
--		select adq.IdAdquisicion
--		from Adquisicion adq
--		Where adq.IdRendicion != null
--		)
--	)

--Comentado 24/08/2018 para no traer los productos que ya fueron rendidos
select adq.IdAdquisicion, adq.NroFactura, cat.idCategoria, cat.DescripCategoria, inv.SerieKey, inv.Costo
from Adquisicion adq
INNER JOIN RelPDetAdq relpdet
ON adq.IdAdquisicion = relpdet.IdAdquisicion
INNER JOIN Inventario inv
ON relpdet.IdInventario = inv.IdInventario
INNER JOIN Bien 
ON inv.IdBienEspecif = Bien.IdBien
INNER JOIN Categoria cat
ON cat.IdCategoria = Bien.IdCategoria
WHERE relpdet.IdPartida = @IdPartida






END

GO
/****** Object:  StoredProcedure [dbo].[AgenteBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgenteBuscar]
(
	@ApellidoAgente varchar(300)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT ag.IdAgente, ag.NombreAgente, ag.ApellidoAgente
FROM Agente ag
WHERE ag.ApellidoAgente = @ApellidoAgente
	
END

GO
/****** Object:  StoredProcedure [dbo].[AgenteCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgenteCrear]
(
	@NombreAgente VARCHAR(300),
	@ApellidoAgente VARCHAR(300)
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Agente(NombreAgente, ApellidoAgente)
VALUES (@NombreAgente, @ApellidoAgente)

SELECT SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[AgenteModificar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgenteModificar]
(
	@IdAgente int,
	@NombreAgente varchar(300),
	@ApellidoAgente varchar(300)
)

AS
BEGIN


UPDATE Agente
SET NombreAgente = @NombreAgente, 
	ApellidoAgente = @ApellidoAgente
WHERE IdAgente = @IdAgente

END

GO
/****** Object:  StoredProcedure [dbo].[AgentesTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgentesTraerTodos]
AS

SET NOCOUNT ON

SELECT *
FROM Agente
GO
/****** Object:  StoredProcedure [dbo].[AgenteTraerCargoPorDep]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgenteTraerCargoPorDep]
(
	@IdDependencia int,
	@IdAgente int,
	@IdIdioma int
)


AS
BEGIN

SET NOCOUNT ON;

select ca.IdCargo, ca.DescripCargo
from IdiomaCargo ca
Where ca.IdCargo in
	(
	select rel.IdCargo
	from RelDepAgenteCargo rel
	WHERE rel.IdAgente = @IdAgente
	and rel.IdDependencia = @IdDependencia
	)
and ca.IdIdioma = @IdIdioma
	
END

GO
/****** Object:  StoredProcedure [dbo].[AgenteTraerDependencias]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgenteTraerDependencias]
(
	@IdAgente int
)


AS
BEGIN

SET NOCOUNT ON;

select dep.IdDependencia, dep.NombreDependencia, tp.IdTipoDependencia, tp.DescripTipoDependencia
from Dependencia dep
inner join TipoDependencia tp ON tp.IdTipoDependencia = dep.IdTipoDependencia
Where dep.IdDependencia in
	(
	SELECT rel.IdDependencia
	From RelDepAgenteCargo rel
	Where rel.IdAgente = @IdAgente
	)
and dep.Activo = 1
	
END

GO
/****** Object:  StoredProcedure [dbo].[AsigDetalleCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignacionBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsignacionBuscar]
(
	@IdAsignacion int = null,
	@NombreDependencia varchar(300) = null,
	@IdSolicitud int = null,
	@fechaDesde datetime = null,
	@fechaHasta datetime = null
	
)


AS
BEGIN

	SET NOCOUNT ON;


select distinct asi.IdAsignacion, asi.Fecha, asi.IdDependencia, dep.NombreDependencia, asidet.IdSolicitud
from Asignacion asi
INNER JOIN Dependencia dep ON dep.IdDependencia = asi.IdDependencia
INNER JOIN AsigDetalle asidet ON asidet.IdAsignacion = asi.IdAsignacion
WHERE (asi.IdAsignacion = @IdAsignacion OR @IdAsignacion IS NULL)
and (asidet.IdSolicitud = @IdSolicitud OR @IdSolicitud IS NULL)
and (UPPER(dep.NombreDependencia) LIKE UPPER('%' + @NombreDependencia + '%') OR @NombreDependencia IS NULL)
and (asi.Fecha >= @fechaDesde OR @fechaDesde IS NULL)
and (asi.Fecha < @fechaHasta+1 OR @fechaHasta IS NULL)

END

GO
/****** Object:  StoredProcedure [dbo].[AsignacionCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignacionTraerBienesAsignados]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsignacionTraerBienesAsignados]
(
	@IdAsignacion int
)


AS
BEGIN

	SET NOCOUNT ON;


select cat.IdCategoria, cat.DescripCategoria, inv.SerieKey, cat.IdTipoBien, inv.IdInventario, bi.IdBien
FROM Inventario inv
INNER JOIN Bien bi ON bi.IdBien = inv.IdBienEspecif
INNER JOIN Categoria cat ON cat.IdCategoria = bi.IdCategoria
Where inv.IdInventario in
	(
	SELECT asidet.IdInventario
	FROM AsigDetalle asidet
	WHERE asidet.IdAsignacion = @IdAsignacion
	)

END

GO
/****** Object:  StoredProcedure [dbo].[BaseDatosRespaldar]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[BienTraerIdPorDescripMarcaModelo]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BienTraerIdPorDescripMarcaModelo]
(
	@IdCategoria INT,
	--@IdTipoBien INT,
	@IdMarca INT,
	@IdModelo INT
)


AS
BEGIN

	SET NOCOUNT ON;

select bi.IdBien
from Bien bi
WHERE bi.IdMarca = @IdMarca
and bi.IdModeloVersion = @IdModelo
and bi.IdCategoria = @IdCategoria

--Comentado en el proceso de pasar TIpoBien hacia Categoria 01/08/2018
--SELECT Bi.IdBien
--FROM Bien Bi
--INNER JOIN Marca Mar
--ON Mar.IdMarca = Bi.IdMarca
--INNER JOIN ModeloVersion Mode
--ON Bi.IdModeloVersion = Mode.IdModeloVersion
--INNER JOIN TipoBien Tipo
--ON Bi.IdTipoBien = Tipo.IdTipoBien
--INNER JOIN Categoria Cat
--ON Bi.IdCategoria = Cat.IdCategoria
--WHERE Tipo.IdTipoBien = @IdTipoBien
--AND Cat.IdCategoria = @IdCategoria
--AND Mar.IdMarca = @IdMarca
--AND Mode.IdModeloVersion = @IdModelo

END

GO
/****** Object:  StoredProcedure [dbo].[BitacoraLogCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BitacoraLogCrear]
(
	@IdUsuario int,
	@NombreUsuario varchar(30),
	@Fecha datetime,
	@TipoLog varchar(10),
	@Accion VARCHAR(50),
	@Mensaje VARCHAR(5000)
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Bitacora(IdUsuario, NombreUsuario, Fecha, TipoLog, Accion, Mensaje)
VALUES (@IdUsuario, @NombreUsuario, @Fecha, @TipoLog, @Accion, @Mensaje)

SELECT SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[BitacoraVerLogs]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BitacoraVerLogs]
(
	@TipoLog varchar(10),
	@fechaInicio datetime = null,
	@fechaFin datetime = null
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT *
from Bitacora bi
WHERE bi.TipoLog = @TipoLog
and (bi.Fecha >= @fechaInicio OR @fechaInicio IS NULL)
and (bi.Fecha < @fechaFin+1 OR @fechaFin IS NULL)

END

GO
/****** Object:  StoredProcedure [dbo].[CargosTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CargosTraerTodos]
AS

SET NOCOUNT ON

SELECT *
FROM Cargo
GO
/****** Object:  StoredProcedure [dbo].[CargosTraerTodosPorIdioma]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CargosTraerTodosPorIdioma]
(
	@IdIdioma INT
)

AS

SET NOCOUNT ON

SELECT ca.IdCargo, id.DescripCargo
FROM Cargo ca
INNER JOIN IdiomaCargo id ON ca.IdCargo = id.IdCargo
Where id.IdIdioma = @IdIdioma
GO
/****** Object:  StoredProcedure [dbo].[CategoriaBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaBuscar]
(
	@NomCategoria varchar(300)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT cat.IdCategoria, cat.DescripCategoria, cat.IdTipoBien, cat.Activo
FROM Categoria cat
WHERE cat.DescripCategoria = @NomCategoria
	
END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaCrear]
(
	@DescripCategoria varchar(300),
	@IdTipoBien int
)

AS
BEGIN


INSERT INTO Categoria(DescripCategoria, IdTipoBien, Activo)
VALUES (@DescripCategoria, @IdTipoBien, 1)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaDetBienesTraerPorIdPartida]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaDetBienesTraerPorIdPartida]
(
	@IdPartida INT,
	@IdEstadoSolic INT
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
AND sdet.IdEstadoSolicDetalle = @IdEstadoSolic--Que el estado del detalle no sea Adquirido ni Entregado, ni cancelado



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
/****** Object:  StoredProcedure [dbo].[CategoriaEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaEliminar]
(
	@IdCategoria int
)


AS
BEGIN

update Categoria
set Activo = 0
where IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaModificar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaModificar]
(
	@DescripCategoria varchar(300),
	@IdTipoBien int,
	@IdCategoria int
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Categoria
SET DescripCategoria = @DescripCategoria, 
	IdTipoBien = @IdTipoBien
WHERE IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaProvAsociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaProvAsociar]
(
	@IdCategoria int,
	@IdProveedor int
)

AS
BEGIN


INSERT INTO RelCatProv(IdCategoria, IdProveedor)
VALUES (@IdCategoria, @IdProveedor)


END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaProvDesasociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaProvDesasociar]
(
	@IdCategoria int,
	@IdProveedor int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelCatProv
WHERE IdCategoria = @IdCategoria
and IdProveedor = @IdProveedor

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaReactivar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaReactivar]
(
	@IdCategoria int
)


AS
BEGIN

update Categoria
set Activo = 1
where IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerProveedores]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerProveedores]
(
	@IdCategoria int
)


AS
BEGIN

SET NOCOUNT ON;

SELECT *
FROM Proveedor pro
WHERE pro.IdProveedor in
	(
		SELECT rel.IdProveedor
		FROM RelCatProv rel
		WHERE rel.IdCategoria = @IdCategoria
	)
and pro.Activo = 1
	
END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, Cat.IdTipoBien
FROM Categoria Cat

--Comentado en el proceso de cambio de relacionar TipoBien con Categoria
--SELECT Cat.IdCategoria, Cat.DescripCategoria, Bi.IdBien, TB.IdTipoBien 
--FROM Categoria Cat
--INNER JOIN Bien Bi
--ON Bi.IdCategoria = Cat.IdCategoria
--INNER JOIN TipoBien TB
--ON TB.IdTipoBien = BI.IdTipoBien


END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosActivos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosActivos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, ti.IdTipoBien, ti.DescripTipoBien
FROM Categoria Cat
INNER JOIN TipoBien ti ON ti.IdTipoBien = cat.IdTipoBien
WHERE Cat.Activo = 1

--Comentado en el proceso de cambio de relacionar TipoBien con Categoria
--SELECT Cat.IdCategoria, Cat.DescripCategoria, Bi.IdBien, TB.IdTipoBien 
--FROM Categoria Cat
--INNER JOIN Bien Bi
--ON Bi.IdCategoria = Cat.IdCategoria
--INNER JOIN TipoBien TB
--ON TB.IdTipoBien = BI.IdTipoBien


END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHard]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosHard]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, Cat.IdTipoBien
FROM Categoria Cat
WHERE Cat.IdTipoBien = 1

--Comentado en el proceso de cambio de relacionar TipoBien con Categoria
--SELECT DISTINCT Cat.IdCategoria, Cat.DescripCategoria
--FROM Categoria Cat
--INNER JOIN Bien Bi
--ON Bi.IdCategoria = Cat.IdCategoria
--INNER JOIN TipoBien TB
--ON TB.IdTipoBien = BI.IdTipoBien
--WHERE TB.IdTipoBien = 1

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHardActivos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosHardActivos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, Cat.IdTipoBien
FROM Categoria Cat
WHERE Cat.IdTipoBien = 1
AND Cat.Activo = 1

--Comentado en el proceso de cambio de relacionar TipoBien con Categoria
--SELECT DISTINCT Cat.IdCategoria, Cat.DescripCategoria
--FROM Categoria Cat
--INNER JOIN Bien Bi
--ON Bi.IdCategoria = Cat.IdCategoria
--INNER JOIN TipoBien TB
--ON TB.IdTipoBien = BI.IdTipoBien
--WHERE TB.IdTipoBien = 1

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoft]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosSoft]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, Cat.IdTipoBien
FROM Categoria Cat
WHERE Cat.IdTipoBien = 2

--Comentado en el proceso de cambio de relacionar TipoBien con Categoria
--SELECT DISTINCT Cat.IdCategoria, Cat.DescripCategoria
--FROM Categoria Cat
--INNER JOIN Bien Bi
--ON Bi.IdCategoria = Cat.IdCategoria
--INNER JOIN TipoBien TB
--ON TB.IdTipoBien = BI.IdTipoBien
--WHERE TB.IdTipoBien = 2

END

GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoftActivos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerTodosSoftActivos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cat.IdCategoria, Cat.DescripCategoria, Cat.IdTipoBien
FROM Categoria Cat
WHERE Cat.IdTipoBien = 2
AND Cat.Activo = 1

--Comentado en el proceso de cambio de relacionar TipoBien con Categoria
--SELECT DISTINCT Cat.IdCategoria, Cat.DescripCategoria
--FROM Categoria Cat
--INNER JOIN Bien Bi
--ON Bi.IdCategoria = Cat.IdCategoria
--INNER JOIN TipoBien TB
--ON TB.IdTipoBien = BI.IdTipoBien
--WHERE TB.IdTipoBien = 2

END

GO
/****** Object:  StoredProcedure [dbo].[ConfigMailHostTraer]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[CotiSolicDetDesasociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotiSolicDetDesasociar]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@IdCotizacion int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelCotSolDetalle
WHERE IdCotizacion = @IdCotizacion
and IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicitudDetalle

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionConteo]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrearRelSolicDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionEliminar]
(
	@IdCotizacion int
)


AS
BEGIN

DELETE FROM Cotizacion
WHERE IdCotizacion = @IdCotizacion

END

GO
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitudYDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorUIDPartidaDetalle]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionTraerPorUIDPartidaDetalle]
(
	@UIDPartidaDetalle int,
	@IdPartida int
)


AS
BEGIN

	SET NOCOUNT ON;

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Det.IdPartidaDetalle, Det.IdPartida, Det.UIDPartidaDetalle
from Cotizacion Coti
INNER JOIN Proveedor Prov
ON Coti.IdProveedor = Prov.IdProveedor
INNER JOIN RelCotizPartDetalle Rel
ON Coti.IdCotizacion = Rel.IdCotizacion
INNER JOIN PartidaDetalle Det
ON Rel.IdPartida = Det.IdPartida AND Rel.UIDPartidaDetalle = Det.UIDPartidaDetalle
WHERE Det.IdPartida = @IdPartida
AND Det.UIDPartidaDetalle = @UIDPartidaDetalle
END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaAgenteAgregar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaAgenteAgregar]
(
	@IdAgente int,
	@IdCargo int,
	@IdDependencia int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelDepAgenteCargo(IdAgente, IdDependencia, IdCargo)
VALUES (@IdAgente, @IdDependencia, @IdCargo)


END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaAgentesQuitarLista]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaAgentesQuitarLista]
(
	@IdAgente INT,
	@IdDependencia int
)


AS
BEGIN

	SET NOCOUNT ON;

delete from RelDepAgenteCargo
where IdAgente = @IdAgente
and IdDependencia = @IdDependencia


END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaBuscar]
(
	@NomDependencia varchar(300)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT dep.IdDependencia, dep.NombreDependencia, dep.IdTipoDependencia, dep.Activo
FROM Dependencia dep
WHERE dep.NombreDependencia = @NomDependencia
	
END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaCrear]
(
	@NombreDependencia varchar(300),
	@IdTipoDependencia int
)

AS
BEGIN


INSERT INTO Dependencia(NombreDependencia, IdTipoDependencia, Activo)
VALUES (@NombreDependencia, @IdTipoDependencia, 1)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaEliminar]
(
	@IdDependencia int
)


AS
BEGIN

update Dependencia
set Activo = 0
where IdDependencia = @IdDependencia

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaModifNombre]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaModifNombre]
(
	@IdDependencia INT,
	@NombreDependencia varchar(300)
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Dependencia
SET NombreDependencia = @NombreDependencia
WHERE IdDependencia = @IdDependencia


END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaModifTipoDep]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaModifTipoDep]
(
	@IdDependencia INT,
	@IdTipoDependencia INT
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Dependencia
SET IdTipoDependencia = @IdTipoDependencia
WHERE IdDependencia = @IdDependencia


END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaReactivar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaReactivar]
(
	@IdDependencia int
)


AS
BEGIN

update Dependencia
set Activo = 1
where IdDependencia = @IdDependencia

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesPorIdDependencia]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaTraerAgentesPorIdDependencia]
(
	@IdDependencia INT,
	@IdIdioma int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Ag.IdAgente, Ag.NombreAgente, Ag.ApellidoAgente, ca.IdCargo, id.DescripCargo
FROM Agente Ag
INNER JOIN RelDepAgenteCargo Rel
ON Ag.IdAgente = Rel.IdAgente
INNER JOIN Cargo ca ON ca.IdCargo = Rel.IdCargo
INNER JOIN IdiomaCargo id ON id.IdCargo = ca.IdCargo
WHERE Rel.IdDependencia = @IdDependencia
and id.IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesResp]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DependenciaTraerAgentesResp]
(
	@IdDependencia INT,
	@IdIdioma INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Ag.IdAgente, Ag.NombreAgente, Ag.ApellidoAgente, car.IdCargo, idicar.DescripCargo
FROM Agente Ag
INNER JOIN RelDepAgenteCargo Rel
ON Ag.IdAgente = Rel.IdAgente
INNER JOIN Cargo Car
ON Rel.IdCargo = Car.IdCargo
INNER JOIN IdiomaCargo idicar
ON idicar.IdCargo = car.IdCargo
WHERE Rel.IdDependencia = @IdDependencia
and idicar.IdIdioma = @IdIdioma
AND (Car.IdCargo = 3--'Secretario'
OR Car.IdCargo = 4)--'Fiscal')

END


GO
/****** Object:  StoredProcedure [dbo].[DependenciaTraerNombrePorIDSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[DepositoTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[DireccionCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DireccionCrear]
(
	@Calle varchar(100),
	@NumeroCalle varchar(100),
	@Piso varchar(10),
	@Localidad varchar(100),
	@IdProvincia int
)

AS
BEGIN


INSERT INTO Direccion(Calle, NumeroCalle, Piso, Localidad, IdProvincia)
VALUES (@Calle, @NumeroCalle, @Piso, @Localidad, @IdProvincia)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[DireccionProvinciaTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DireccionProvinciaTraerTodos]
AS

SET NOCOUNT ON

SELECT *
FROM Provincia
GO
/****** Object:  StoredProcedure [dbo].[DireccionTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DireccionTraerTodos]
AS

SET NOCOUNT ON

SELECT *
FROM Direccion
GO
/****** Object:  StoredProcedure [dbo].[DVActualizarDVH]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DVActualizarDVH]
(
	@NombreTabla varchar(128),
	@IdFila int,
	@ValorAcum bigint,
	@NomColumna varchar(50)
)


AS
BEGIN

DECLARE @SQL NVARCHAR(max),@Nom VARCHAR(128), @IdF int, @Val bigint, @Col varchar(50)

SET @SQL=
REPLACE(REPLACE(REPLACE(REPLACE(
'UPDATE [@Nom] SET [DVH] = @Val WHERE [@Col] = @IdF','@Nom',@NombreTabla),
'@Val',@ValorAcum),'@Col',@NomColumna),'@IdF',@IdFila)	
        EXECUTE(@SQL)

END

GO
/****** Object:  StoredProcedure [dbo].[DVActualizarDVV]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DVActualizarDVV]
(
	@NombreTabla varchar(30),
	@ClaveDVV nvarchar(300)
)


AS
BEGIN

UPDATE DVV 
SET ClaveDVV = @ClaveDVV
WHERE NombreTabla = @NombreTabla


END

GO
/****** Object:  StoredProcedure [dbo].[DVTraerDVHSuma]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DVTraerDVHSuma]
(
	@NombreTabla varchar(30)
)


AS
BEGIN

DECLARE @SQL NVARCHAR(max),@Nom VARCHAR(30)

SET @SQL=
REPLACE(
'SELECT [DVH] FROM [@Nom]','@Nom',@NombreTabla)
        EXECUTE(@SQL)


	
END

GO
/****** Object:  StoredProcedure [dbo].[DVTraerDVV]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DVTraerDVV]
(
	@NombreTabla varchar(30)
)


AS
BEGIN

select ClaveDVV
from DVV
where NombreTabla = @NombreTabla


	
END

GO
/****** Object:  StoredProcedure [dbo].[EstadoInvTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EstadoInvTraerTodos]
(
	@IdIdioma INT
)

AS
BEGIN

	SET NOCOUNT ON;

SELECT estinv.IdEstadoInventario, idiestinv.DescripEstadoInv
FROM EstadoInventario estinv
INNER JOIN IdiomaEstadoInventario idiestinv
ON idiestinv.IdEstadoInventario = estinv.IdEstadoInventario
WHERE idiestinv.IdIdioma = @IdIdioma


END

GO
/****** Object:  StoredProcedure [dbo].[EstadoSolDetallesTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EstadoSolDetallesTraerTodos]
(
	@IdIdioma INT
)
AS
BEGIN

	SET NOCOUNT ON;

SELECT est.IdEstadoSolicDetalle, idiest.DescripEstadoSolicDetalle
FROM EstadoSolicDetalle est
INNER JOIN IdiomaEstadoSolicDetalle idiest
ON est.IdEstadoSolicDetalle = idiest.IdEstadoSolicDetalle
WHERE idiest.IdIdioma = @IdIdioma

 
END

GO
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodosPorIdioma]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EstadoSolicitudTraerTodosPorIdioma]
(
	@IdIdioma INT
)

AS

SET NOCOUNT ON

SELECT es.IdEstadoSolicitud, id.DescripEstadoSolic
FROM EstadoSolicitud es
INNER JOIN IdiomaEstadoSolicitud id ON es.IdEstadoSolicitud = id.IdEstadoSolicitud
Where id.IdIdioma = @IdIdioma
GO
/****** Object:  StoredProcedure [dbo].[EtiquetasTraerTodosPorIdioma]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[EtiquetaTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaBuscar]
(
	@NombreFamilia varchar(50)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT fam.IdFamilia, fam.NombreFamilia
FROM Familia fam
WHERE fam.NombreFamilia = @NombreFamilia
	
END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaCrear]
(
	@NombreFamilia varchar(50)
)

AS
BEGIN


INSERT INTO Familia(NombreFamilia)
VALUES (@NombreFamilia)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaEliminar]
(
	@IdFamilia int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM Familia
WHERE IdFamilia = @IdFamilia

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaEliminarAsocFamilias]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaEliminarAsocFamilias]
(
	@IdFamiliaPadre int,
	@IdFamiliaHijo int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelFamFam
WHERE IdFamiliaPadre = @IdFamiliaPadre
or IdFamiliaHijo = @IdFamiliaHijo

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaEliminarAsocPatentes]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaEliminarAsocPatentes]
(
	@IdFamilia int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelFamPat
WHERE IdFamilia = @IdFamilia

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaFamiliaAsociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaFamiliaAsociar]
(
	@IdFamiliaPadre int,
	@IdFamiliaHijo int
)

AS
BEGIN


INSERT INTO RelFamFam(IdFamiliaPadre, IdFamiliaHijo)
VALUES (@IdFamiliaPadre, @IdFamiliaHijo)


END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaFamiliaDesasociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaFamiliaDesasociar]
(
	@IdFamiliaPadre int,
	@IdFamiliaHijo int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelFamFam
WHERE IdFamiliaPadre = @IdFamiliaPadre
and IdFamiliaHijo = @IdFamiliaHijo

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaModificar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaModificar]
(
	@NombreFamilia varchar(50),
	@IdFamilia int
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Familia
SET NombreFamilia = @NombreFamilia
WHERE IdFamilia = @IdFamilia

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteAsociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteAsociar]
(
	@IdFamilia int,
	@IdPatente int
)

AS
BEGIN


INSERT INTO RelFamPat(IdFamilia, IdPatente)
VALUES (@IdFamilia, @IdPatente)


END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteDesasociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteDesasociar]
(
	@IdFamilia int,
	@IdPatente int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelFamPat
WHERE IdFamilia = @IdFamilia
and IdPatente = IdPatente

END

GO
/****** Object:  StoredProcedure [dbo].[FamiliasTraerTodas]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FamiliasTraerTodas]
AS
	SELECT fam.IdFamilia, fam.NombreFamilia
	FROM Familia fam
	
	

GO
/****** Object:  StoredProcedure [dbo].[FamiliaTraerFamiliasHijas]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FamiliaTraerFamiliasHijas]
	@IdFamilia int
AS
	SELECT fam.IdFamilia, fam.NombreFamilia
	FROM Familia fam
	WHERE fam.IdFamilia IN
	(
		SELECT ff.IdFamiliaHijo
		FROM RelFamFam ff
		WHERE ff.IdFamiliaPadre = @IdFamilia
	)
	

GO
/****** Object:  StoredProcedure [dbo].[FamiliaTraerPatentes]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FamiliaTraerPatentes]
	@IdFamilia int
AS
	SELECT pat.IdPatente, pat.NombrePatente
	FROM Patente pat
	WHERE pat.IdPatente IN
	(
		SELECT fp.IdPatente
		FROM RelFamPat fp
		WHERE fp.IdFamilia = @IdFamilia	
	)


GO
/****** Object:  StoredProcedure [dbo].[FamiliaUsuariosAsociados]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaUsuariosAsociados]
(
	@IdFamilia int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM usuario us
WHERE us.IdUsuario in
	(
	 SELECT usfam.IdUsuario
	 FROM RelUsuFam usfam
	 WHERE usfam.IdFamilia = @IdFamilia
	)


END

GO
/****** Object:  StoredProcedure [dbo].[FamiliaUsuariosComprometidos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaUsuariosComprometidos]
(
	@IdFamilia int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM usuario us
WHERE us.IdUsuario not in
	(
	 Select uspat.IdUsuario
	 From RelUsuPat uspat
	)
AND us.IdUsuario in
	(
	 SELECT usfam.IdUsuario
	 FROM RelUsuFam usfam
	 WHERE usfam.IdFamilia = @IdFamilia
	)


END

GO
/****** Object:  StoredProcedure [dbo].[IdiomaActualizarIdiomaDefault]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaUsuarioActualModificar]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioAdquiridoCantPorPartDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
INNER JOIN RelPDetAdq pdetadq
ON inv.IdInventario = pdetadq.IdInventario
INNER JOIN PartidaDetalle pdet
ON pdetadq.IdPartida = pdet.IdPartida and pdetadq.UIDPartidaDetalle = pdet.UIDPartidaDetalle
LEFT JOIN SolicDetalle sdet
ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle
WHERE pdet.IdPartida = @IdPartida2
--and sdet.IdEstadoSolicDetalle != 2--Distinto a finalizado 30/10/2017 Comente esto para probar
group by sdet.IdSolicitudDetalle


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioEntregadoPorSolicDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioEstadoUpdate]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioHardCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioHardCrear]
(
	@IdBienEspecif INT,
	@SerieKey nvarchar(300),
	@IdDeposito INT,
	@IdEstadoInventario INT,
	@Costo decimal(18, 2)
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Inventario (IdBienEspecif, SerieKey, IdDeposito, IdEstadoInventario, Costo)
VALUES (@IdBienEspecif, @SerieKey, @IdDeposito, @IdEstadoInventario, @Costo)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[InventarioHardTraerListosParaAsignar]    Script Date: 05/09/2018 21:08:20 ******/
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
INNER JOIN RelPDetAdq relpdet
ON relpdet.IdInventario = inv.IdInventario
INNER JOIN PartidaDetalle pdet
ON relpdet.IdPartida = pdet.IdPartida and relpdet.UIDPartidaDetalle = pdet.UIDPartidaDetalle
INNER JOIN SolicDetalle sdet
ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle
WHERE sdet.IdSolicitud = @IdSolicitud
--and sdet.IdEstadoSolicDetalle = @IdEstadoSolicDetalle--Adquirido
and sdet.IdSolicitudDetalle = @IdSolicitudDetalle --COMENTADO 30/10/2017 (AL IGUAL QUE EN LOS PARAMETROS)
and inv.IdEstadoInventario = 1--Disponible


END

GO
/****** Object:  StoredProcedure [dbo].[InventarioSoftCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioSoftCrear]
(
	@IdBienEspecif INT,
	@SerieKey nvarchar(300),
	@SerialMaster nvarchar(300),
	@IdEstadoInventario INT,
	@Costo decimal(18, 2)
	
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Inventario (IdBienEspecif, SerieKey, SerialMaster, IdEstadoInventario, Costo)
VALUES (@IdBienEspecif, @SerieKey, @SerialMaster, @IdEstadoInventario, @Costo)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignar]    Script Date: 05/09/2018 21:08:20 ******/
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

Select inv.IdInventario, inv.SerieKey, inv.SerialMaster, inv.IdEstadoInventario, relpdet.IdPartida, relpdet.UIDPartidaDetalle, inv.IdDeposito, relpdet.IdAdquisicion, bi.IdBien, cat.IdTipoBien, inv.Costo
FROM Inventario inv
INNER JOIN Bien bi
ON inv.IdBienEspecif = bi.IdBien
INNER JOIN Categoria cat
ON cat.IdCategoria = bi.IdCategoria
INNER JOIN RelPDetAdq relpdet
ON inv.IdInventario = relpdet.IdInventario
Where inv.IdEstadoInventario = 1 --Disponible
and relpdet.IdPartida in
	(
		Select pdet.IdPartida
		from PartidaDetalle pdet
		Where pdet.IdSolicitud = @IdSolicitud
	)


END

GO
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignarPorSolicDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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

--NO SE UTILIZA 
--Select inv.IdInventario, inv.SerieKey, inv.SerialMaster, inv.IdEstadoInventario, inv.IdPartida, inv.UIDPartidaDetalle, inv.IdDeposito, inv.IdAdquisicion, bi.IdBien, bi.IdTipoBien, ma.DescripMarca, mo.DescripModeloVersion
----Agregar inv.costo
--FROM Inventario inv
--INNER JOIN Bien bi
--ON inv.IdBienEspecif = bi.IdBien
--INNER JOIN Marca ma
--ON ma.IdMarca = bi.IdMarca
--INNER JOIN ModeloVersion mo
--ON mo.IdModeloVersion = bi.IdModeloVersion
--Where inv.IdEstadoInventario = 1 --Disponible
--and inv.IdPartida in
--	(
--		Select pdet.IdPartida
--		from PartidaDetalle pdet
--		Where pdet.IdSolicitud = @IdSolicitud
--		and pdet.IdSolicitudDetalle = @IdSolicDetalle
--	)


END

GO
/****** Object:  StoredProcedure [dbo].[MarcaTraerPorIdCategoria]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MarcaTraerPorIdCategoria]
(
	@IdCategoria INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT mar.IdMarca, mar.DescripMarca
FROM Marca mar
WHERE mar.IdMarca in
	(
	SELECT bi.IdMarca
	FROM Bien bi
	WHERE bi.IdCategoria = @IdCategoria
	)

--Comentado 01/08/2018 por Modif en TipoBien para relacion con Categoria en vez de con Bien
--SELECT distinct Mar.IdMarca, Mar.DescripMarca
--FROM Marca Mar
--INNER JOIN Bien Bi
--ON Mar.IdMarca = Bi.IdMarca
--INNER JOIN TipoBien Tipo
--ON Bi.IdTipoBien = Tipo.IdTipoBien
--INNER JOIN Categoria Cat
--ON Bi.IdCategoria = Cat.IdCategoria
--WHERE Tipo.IdTipoBien = @IdTipoBien
--AND Cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[ModeloTraerPorMarcaCategoria]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModeloTraerPorMarcaCategoria]
(
	@IdCategoria INT,
	--@IdTipoBien INT,
	@IdMarca INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT mo.IdModeloVersion, mo.DescripModeloVersion
FROM Bien bi
INNER JOIN ModeloVersion mo ON mo.IdModeloVersion = bi.IdModeloVersion
WHERE bi.IdCategoria = @IdCategoria
AND bi.IdMarca = @IdMarca

--Comentado en el proceso de relacionar TipoBien con Categoria
--SELECT Mode.IdModeloVersion, Mode.DescripModeloVersion
--FROM Marca Mar
--INNER JOIN Bien Bi
--ON Mar.IdMarca = Bi.IdMarca
--INNER JOIN ModeloVersion Mode
--ON Bi.IdModeloVersion = Mode.IdModeloVersion
--INNER JOIN TipoBien Tipo
--ON Bi.IdTipoBien = Tipo.IdTipoBien
--INNER JOIN Categoria Cat
--ON Bi.IdCategoria = Cat.IdCategoria
--WHERE Tipo.IdTipoBien = @IdTipoBien
--AND Cat.IdCategoria = @IdCategoria
--AND Mar.IdMarca = @IdMarca

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaAsociar]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaDetalleCrearSinCotiz]    Script Date: 05/09/2018 21:08:20 ******/
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
select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleTraerTodosPorNroPart]    Script Date: 05/09/2018 21:08:20 ******/
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

SELECT dpar.UIDPartidaDetalle, dpar.IdPartidaDetalle, dpar.IdPartida, dsol.IdSolicitud, dsol.IdSolicitudDetalle, Cat.DescripCategoria, dsol.Cantidad
FROM PartidaDetalle dPar
INNER JOIN SolicDetalle dSol
ON dpar.IdSolicitud = dsol.IdSolicitud and dpar.IdSolicitudDetalle = dsol.IdSolicitudDetalle
INNER JOIN Categoria Cat
ON dSol.IdCategoria = Cat.IdCategoria
WHERE IdPartida = @IdPartida

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleUIDPorIdCategoriaIdPartida]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaDetalleUIDPorIdCategoriaIdPartida]
(
	@IdPartida INT,
	@IdCategoria INT
)


AS
BEGIN

	SET NOCOUNT ON;

select pdet.UIDPartidaDetalle
from Categoria cat
INNER JOIN SolicDetalle sdet 
ON cat.IdCategoria = sdet.IdCategoria
INNER JOIN PartidaDetalle pdet
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle
Where pdet.IdPartida = @IdPartida
and cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaModEliminarDetalle]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaModEliminarDetalle]
(
	@IdPartida INT,
	@UIDPartidaDetalle int,
	@IdPartidaDetalle int
)


AS
BEGIN

	SET NOCOUNT ON;

delete from PartidaDetalle
where UIDPartidaDetalle = @UIDPartidaDetalle
and IdPartida = @IdPartida

update PartidaDetalle
set IdPartidaDetalle = (IdPartidaDetalle-1)
where IdPartidaDetalle > @IdPartidaDetalle
and IdPartida = @IdPartida

END

GO
/****** Object:  StoredProcedure [dbo].[PartidaModifDetalles]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaModifDetalles]
(
	@IdCotizacion INT
)


AS
BEGIN

	SET NOCOUNT ON;

delete from RelCotizPartDetalle
WHERE IdCotizacion = @IdCotizacion


END

GO
/****** Object:  StoredProcedure [dbo].[PartidaModifMontoSolic]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidasBuscarPorIdSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaTraerPorNroPart]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PatentesTraerTodas]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PatentesTraerTodas]
AS
	SELECT pat.IdPatente, pat.NombrePatente
	FROM Patente pat
	
	

GO
/****** Object:  StoredProcedure [dbo].[PoliticaPorDepYCategCantidad]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PoliticaTraerPorTipoDepYCat]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodosPorIdioma]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PrioridadTraerTodosPorIdioma]
(
	@IdIdioma INT
)

AS
BEGIN

	SET NOCOUNT ON;

SELECT pri.IdPrioridad, id.DescripPrioridad
from Prioridad pri
INNER JOIN IdiomaPrioridad id ON pri.IdPrioridad = id.IdPrioridad
Where id.IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorBuscar]
(
	@NomProveedor varchar(100)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT pro.IdProveedor, pro.AliasProv, pro.ContactoProv, pro.MailContactoProv
FROM Proveedor pro
WHERE pro.AliasProv = @NomProveedor
	
END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorCrear]
(
	@AliasProv varchar(100),
	@ContactoProv varchar(100),
	@MailContactoProv nvarchar(200)
)

AS
BEGIN


INSERT INTO Proveedor(AliasProv, ContactoProv, MailContactoProv, Activo)
VALUES (@AliasProv, @ContactoProv, @MailContactoProv, 1)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorDireAsociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorDireAsociar]
(
	@IdProveedor int,
	@IdDireccion int
)

AS
BEGIN


INSERT INTO RelProveedorDire(IdProveedor, IdDireccion)
VALUES (@IdProveedor, @IdDireccion)


END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorDireDesasociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorDireDesasociar]
(
	@IdProveedor int,
	@IdDireccion int
)

AS
BEGIN

DELETE FROM RelProveedorDire
WHERE IdProveedor = @IdProveedor
and IdDireccion = @IdDireccion


END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorEliminar]
(
	@IdProveedor int
)


AS
BEGIN

update Proveedor
set Activo = 0
where IdProveedor = @IdProveedor

END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorModificar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorModificar]
(
	@IdProveedor int,
	@AliasProv varchar(100),
	@ContactoProv varchar(100),
	@MailContactoProv nvarchar(200)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Proveedor
SET AliasProv = @AliasProv, 
	ContactoProv = @ContactoProv,
	MailContactoProv = @MailContactoProv
WHERE IdProveedor = @IdProveedor

END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorReactivar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorReactivar]
(
	@IdProveedor int
)


AS
BEGIN

update Proveedor
set Activo = 1
where IdProveedor = @IdProveedor

END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTelAsociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTelAsociar]
(
	@IdProveedor int,
	@IdTelefono int
)

AS
BEGIN


INSERT INTO RelProveedorTel(IdProveedor, IdTelefono)
VALUES (@IdProveedor, @IdTelefono)


END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTelDesasociar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTelDesasociar]
(
	@IdProveedor int,
	@IdTelefono int
)

AS
BEGIN

DELETE FROM RelProveedorTel
WHERE IdProveedor = @IdProveedor
and IdTelefono = @IdTelefono


END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTraerCategorias]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTraerCategorias]
(
	@IdProveedor int
)


AS
BEGIN

SET NOCOUNT ON;
SELECT cat.IdCategoria, cat.DescripCategoria, ti.IdTipoBien, ti.DescripTipoBien
FROM Categoria cat
inner join TipoBien ti ON ti.IdTipoBien = cat.IdTipoBien
WHERE cat.IdCategoria in
	(
		SELECT rel.IdCategoria
		FROM RelCatProv rel
		WHERE rel.IdProveedor = @IdProveedor
	)
and cat.Activo = 1
	
END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTraerDirecciones]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTraerDirecciones]
(
	@IdProveedor int
)


AS
BEGIN

SET NOCOUNT ON;

SELECT dir.IdDireccion, dir.Calle, dir.NumeroCalle, dir.Piso, dir.Localidad, prov.IdProvincia, prov.NombreProvincia
FROM Direccion dir
inner join Provincia prov ON prov.IdProvincia = dir.IdProvincia
WHERE dir.IdDireccion in
	(
		SELECT rel.IdDireccion
		FROM RelProveedorDire rel
		WHERE rel.IdProveedor = @IdProveedor
	)
	
END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTelefonos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTraerTelefonos]
(
	@IdProveedor int
)


AS
BEGIN

SET NOCOUNT ON;

SELECT tel.IdTelefono, tel.CodArea, tel.NroTelefono, ti.IdTipoTelefono, ti.DescripTipoTel
FROM Telefono tel
inner join TipoTelefono ti ON ti.IdTipoTelefono = tel.IdTipoTelefono
WHERE tel.IdTelefono in
	(
		SELECT rel.IdTelefono
		FROM RelProveedorTel rel
		WHERE rel.IdProveedor = @IdProveedor
	)
	
END

GO
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodosActivos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProveedorTraerTodosActivos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT *
from Proveedor
where Activo = 1


END

GO
/****** Object:  StoredProcedure [dbo].[Prueba]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RelCotizPartDetalleCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelCotizPartDetalleCrear]
(
	@IdCotizacion int,
	@IdPartida int,
	@UIDPartidaDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelCotizPartDetalle (IdCotizacion, IdPartida, UIDPartidaDetalle)
VALUES (@IdCotizacion, @IdPartida, @UIDPartidaDetalle)


END

GO
/****** Object:  StoredProcedure [dbo].[RelCotSolDetalleDeletePorIdSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RelDepAgenteCargoCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelDepAgenteCargoCrear]
(
	@IdAgente int,
	@IdDependencia int,
	@IdCargo int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelDepAgenteCargo(IdAgente, IdDependencia, IdCargo)
VALUES (@IdAgente, @IdDependencia, @IdCargo)


END

GO
/****** Object:  StoredProcedure [dbo].[RelPDetAdqCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelPDetAdqCrear]
(
	@IdInventario INT,
	@IdPartida INT,
	@UIDPartidaDetalle INT,
	@IdAdquisicion INT
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelPDetAdq(IdInventario, IdPartida, UIDPartidaDetalle, IdAdquisicion)
VALUES (@IdInventario, @IdPartida, @UIDPartidaDetalle, @IdAdquisicion)


END

GO
/****** Object:  StoredProcedure [dbo].[RelPDetAdqPartidaTieneAdq]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteAgregar]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteEliminar]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RendicionBuscar]
(
	@IdRendicion int = null,
	@IdPartida int = null,
	@IdSolicitud int = null,
	@NombreDependencia varchar(300) = null
)


AS
BEGIN

	SET NOCOUNT ON;


SELECT distinct ren.IdRendicion, ren.MontoGasto, ren.IdPartida, ren.FechaRen
FROM Rendicion ren
INNER JOIN Partida par ON par.IdPartida = ren.IdPartida
INNER JOIN PartidaDetalle pdet ON pdet.IdPartida = par.IdPartida
INNER JOIN SolicDetalle sdet ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle
INNER JOIN Solicitud sol ON sol.IdSolicitud = sdet.IdSolicitud
INNER JOIN Dependencia dep ON dep.IdDependencia = sol.IdDependencia
WHERE (ren.IdRendicion = @IdRendicion OR @IdRendicion IS NULL)
and (par.IdPartida = @IdPartida OR @IdPartida IS NULL)
and (sol.IdSolicitud = @IdSolicitud OR @IdSolicitud IS NULL)
and (UPPER(dep.NombreDependencia) LIKE UPPER('%' + @NombreDependencia + '%') OR @NombreDependencia IS NULL)

END

GO
/****** Object:  StoredProcedure [dbo].[RendicionCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RendicionEliminar]
(
	@IdRendicion int
)


AS
BEGIN

DELETE FROM Rendicion
WHERE IdRendicion = @IdRendicion

END

GO
/****** Object:  StoredProcedure [dbo].[RendicionModificar]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionTraerIdRendPorIdPartida]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleDeletePorSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetallePartidaDetalleAsociacionTraer]    Script Date: 05/09/2018 21:08:20 ******/
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

SELECT dpar.UIDPartidaDetalle, dpar.IdPartidaDetalle, dpar.IdPartida, dpar.IdSolicitud, dpar.IdSolicitudDetalle
FROM PartidaDetalle dPar
WHERE dpar.IdSolicitud = @IdSolicitud AND dpar.IdSolicitudDetalle = @IdSolicDetalle

END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerAgentesAsociados]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerPorNroSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallesTraerPorNroSolicitud]
(
	@NroSolicitud INT,
	@IdIdioma int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Det.IdSolicitudDetalle, Det.Cantidad, Est.IdEstadoSolicDetalle, idiestsoldet.DescripEstadoSolicDetalle, Cat.IdCategoria, Cat.DescripCategoria, Sol.IdSolicitud, det.UIDSolicDetalle
FROM SolicDetalle Det
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
INNER JOIN EstadoSolicDetalle Est
ON Det.IdEstadoSolicDetalle = Est.IdEstadoSolicDetalle
INNER JOIN IdiomaEstadoSolicDetalle idiestsoldet
ON idiestsoldet.IdEstadoSolicDetalle = Det.IdEstadoSolicDetalle
INNER JOIN Categoria Cat
ON Det.IdCategoria = Cat.IdCategoria
WHERE Sol.IdSolicitud = @NroSolicitud
and idiestsoldet.IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[SolicDetalleUpdateEstado]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudBuscar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudBuscar]
(
	@NombreDep varchar(300) = null,
	@EstadoSolic int = null,
	@bien varchar(300) = null,
	@priori int = null,
	@usasig int = null,
	@ididioma int,
	@fechaInicio datetime = null,
	@fechaInicio2 datetime = null,
	@fechaFin datetime = null,
	@fechaFin2 datetime = null
)


AS
BEGIN

	SET NOCOUNT ON;

select distinct sol.IdSolicitud, sol.FechaFin, sol.FechaInicio, dep.IdDependencia, dep.NombreDependencia, Pri.IdPrioridad, idipri.DescripPrioridad, est.IdEstadoSolicitud, idiEstSol.DescripEstadoSolic, Us.IdUsuario, Us.NombreUsuario, Ag.IdAgente, Ag.ApellidoAgente
from solicitud sol 
INNER JOIN Dependencia dep
ON sol.IdDependencia = dep.IdDependencia
INNER JOIN EstadoSolicitud est
ON sol.IdEstado = est.IdEstadoSolicitud
INNER JOIN IdiomaEstadoSolicitud idiEstSol
ON idiEstSol.IdEstadoSolicitud = est.IdEstadoSolicitud
INNER JOIN Prioridad Pri
ON Sol.IdPrioridad = Pri.IdPrioridad
INNER JOIN IdiomaPrioridad idipri 
ON idipri.IdPrioridad = pri.IdPrioridad
INNER JOIN Usuario Us
ON Sol.IdUsuario = Us.IdUsuario
INNER JOIN SolicDetalle sdet
ON sol.IdSolicitud = sdet.IdSolicitud
INNER JOIN Categoria cat
ON sdet.IdCategoria = cat.IdCategoria
INNER JOIN Agente Ag
ON Sol.IdAgente = Ag.IdAgente
WHERE (UPPER(dep.NombreDependencia) LIKE UPPER('%' + @NombreDep + '%') OR @NombreDep IS NULL)
and (est.IdEstadoSolicitud = @EstadoSolic and idiEstSol.IdIdioma = @ididioma OR @EstadoSolic IS NULL and idiEstSol.IdIdioma = @ididioma OR @EstadoSolic = -1 and idiEstSol.IdIdioma = @ididioma)
and (UPPER(cat.DescripCategoria) LIKE UPPER('%' + @bien + '%') OR @bien IS NULL)
and (pri.IdPrioridad = @priori and idipri.IdIdioma = @ididioma OR @priori IS NULL and idipri.IdIdioma = @ididioma OR @priori = -1 and idipri.IdIdioma = @ididioma)
and (Us.IdUsuario = @usasig OR @usasig IS NULL OR @usasig = -1)
and (sol.FechaInicio between @fechaInicio and @fechaInicio2 OR @fechaInicio IS NULL and @fechaInicio2 IS NULL)
and (sol.FechaFin between @fechaFin and @fechaFin2 OR @fechaFin IS NULL and @fechaFin2 IS NULL)


END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudDetalleCrear]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudModificar]    Script Date: 05/09/2018 21:08:20 ******/
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
	@IdSolicitud INT,
	@FechaFin datetime = null
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
	IdAgente = @IdAgente,
	FechaFin = @FechaFin
WHERE IdSolicitud = @IdSolicitud 

END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerDatosDVV]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerDatosDVV]

AS
BEGIN

	SET NOCOUNT ON;

SELECT Sol.FechaFin, Sol.FechaInicio, Sol.IdSolicitud, Sol.IdDependencia, Sol.IdPrioridad, Sol.IdEstado, Sol.IdUsuario, Sol.IdAgente, Sol.DVH
FROM Solicitud Sol

END

GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerIdsolNomdepPorIdPartida]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudTraerPorNroSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerPorNroSolicitud]
(
	@NroSolicitud INT,
	@IdIdioma int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT Sol.FechaFin, Sol.FechaInicio, Sol.IdSolicitud, Dep.IdDependencia, Dep.NombreDependencia, Pri.IdPrioridad, idipri.DescripPrioridad, Est.IdEstadoSolicitud, idiestsol.DescripEstadoSolic, Us.IdUsuario, Us.NombreUsuario, Ag.IdAgente, Ag.ApellidoAgente
FROM Solicitud Sol
INNER JOIN Dependencia Dep
ON Sol.IdDependencia = Dep.IdDependencia
INNER JOIN Prioridad Pri
ON Sol.IdPrioridad = Pri.IdPrioridad
INNER JOIN IdiomaPrioridad idipri
ON idipri.IdPrioridad = Pri.IdPrioridad
INNER JOIN EstadoSolicitud Est
ON Sol.IdEstado = Est.IdEstadoSolicitud
INNER JOIN IdiomaEstadoSolicitud idiestsol
ON idiestsol.IdEstadoSolicitud = Est.IdEstadoSolicitud
INNER JOIN Usuario Us
ON Sol.IdUsuario = Us.IdUsuario
LEFT JOIN Agente Ag
ON Sol.IdAgente = Ag.IdAgente
WHERE Sol.IdSolicitud = @NroSolicitud
and idipri.IdIdioma = @IdIdioma
and idiestsol.IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[TelefonoCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TelefonoCrear]
(
	@CodArea int,
	@NroTelefono int,
	@IdTipoTelefono int
)

AS
BEGIN


INSERT INTO Telefono(CodArea, NroTelefono, IdTipoTelefono)
VALUES (@CodArea, @NroTelefono, @IdTipoTelefono)

SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[TelefonoTipoTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TelefonoTipoTraerTodos]
AS

SET NOCOUNT ON

SELECT *
FROM TipoTelefono
GO
/****** Object:  StoredProcedure [dbo].[TelefonoTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TelefonoTraerTodos]
AS

SET NOCOUNT ON

SELECT *
FROM Telefono
GO
/****** Object:  StoredProcedure [dbo].[TipoBienTraerIDTipoBienPorIdCategoria]    Script Date: 05/09/2018 21:08:20 ******/
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

SELECT cat.IdTipoBien
FROM Categoria cat
WHERE cat.IdCategoria = @IdCategoria

--Comentado en el proceso de relacionar TipoBien con Categoria
--SELECT TB.IdTipoBien
--FROM TipoBien TB
--INNER JOIN Bien 
--ON TB.IdTipoBien = Bien.IdTipoBien
--INNER JOIN Categoria Cat
--ON Bien.IdCategoria = Cat.IdCategoria
--WHERE Cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTipoBienPorIdCategoria]    Script Date: 05/09/2018 21:08:20 ******/
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

SELECT ti.IdTipoBien, ti.DescripTipoBien
FROM TipoBien ti
Where ti.IdTipoBien in
	(
	SELECT cat.IdTipoBien
	FROM Categoria cat
	WHERE cat.IdCategoria = @IdCategoria
	)
--Comentado 01/08/2018 para por lo de TipoBien a Categoría
--SELECT TB.IdTipoBien, TB.DescripTipoBien
--FROM TipoBien TB
--INNER JOIN Bien 
--ON TB.IdTipoBien = Bien.IdTipoBien
--INNER JOIN Categoria Cat
--ON Bien.IdCategoria = Cat.IdCategoria
--WHERE Cat.IdCategoria = @IdCategoria

END

GO
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoDependenciaTraerPorDependencia]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TipoDependenciaTraerPorDependencia]
(
	@IdDependencia INT,
	@IdIdioma int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT TipoDep.IdTipoDependencia, iditipodep.DescripTipoDependencia
FROM TipoDependencia TipoDep
INNER JOIN Dependencia Dep
ON TipoDep.IdTipoDependencia = Dep.IdTipoDependencia
INNER JOIN IdiomaTipoDependencia iditipodep
ON iditipodep.IdTipoDependencia = TipoDep.IdTipoDependencia
WHERE Dep.IdDependencia = @IdDependencia
and iditipodep.IdIdioma = @IdIdioma

END

GO
/****** Object:  StoredProcedure [dbo].[TipoDepTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TipoDepTraerTodos]
(
	@IdIdioma int
)

AS

SET NOCOUNT ON

SELECT tipodep.IdTipoDependencia, iditipodep.DescripTipoDependencia
FROM TipoDependencia tipodep
INNER JOIN IdiomaTipoDependencia iditipodep
ON iditipodep.IdTipoDependencia = tipodep.IdTipoDependencia
WHERE iditipodep.IdIdioma = @IdIdioma
GO
/****** Object:  StoredProcedure [dbo].[TraerLimitePartida]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioActualizarDVH]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioActualizarDVH]
(
	@IdUsuario int,
	@ValorAcum bigint
)


AS
BEGIN
--Ya no se utiliza este procedimiento, se utiliza DVActualizarDVH
update Usuario
set DVH = @ValorAcum
where IdUsuario = @IdUsuario

END


GO
/****** Object:  StoredProcedure [dbo].[UsuarioAgregarFamilia]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioAgregarFamilia]
(
	@IdFamilia int,
	@IdUsuario int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelUsuFam(IdFamilia, IdUsuario)
VALUES (@IdFamilia, @IdUsuario)


END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioAgregarPatente]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioAgregarPatente]
(
	@IdPatente int,
	@IdUsuario int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelUsuPat(IdPatente, IdUsuario)
VALUES (@IdPatente, @IdUsuario)


END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioCrear]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioCrear]
(
	@NomUs varchar(30),
	@Pass nvarchar(200),
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Mail nvarchar(100),
	@Idioma int,
	@Activo int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Usuario (NombreUsuario, Pass, Nombre, Apellido, Mail, IdiomaUsuarioActual, Activo)
VALUES (@NomUs, @Pass, @Nombre, @Apellido, @Mail, @Idioma, @Activo)

select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioEliminar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioEliminar]
(
	@IdUsuario int,
	@DVH bigint
)


AS
BEGIN

update Usuario
set Activo = 0, DVH = @DVH
where IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioModificarApellido]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioModificarApellido]
(
	@IdUsuario int,
	@Apellido Varchar(50)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Usuario
SET Apellido = @Apellido
WHERE IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioModificarMail]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioModificarMail]
(
	@IdUsuario int,
	@Mail nvarchar(100)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Usuario
SET Mail = @Mail
WHERE IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioModificarNombre]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioModificarNombre]
(
	@IdUsuario int,
	@Nombre Varchar(50)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Usuario
SET Nombre = @Nombre
WHERE IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioModificarNomUs]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioModificarNomUs]
(
	@IdUsuario int,
	@NomUs Varchar(30)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Usuario
SET NombreUsuario = @NomUs
WHERE IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioModificarPass]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioModificarPass]
(
	@IdUsuario int,
	@Pass nvarchar(200)
)

AS
BEGIN

	SET NOCOUNT ON;

UPDATE Usuario
SET Pass = @Pass
WHERE IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioQuitarFamilia]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioQuitarFamilia]
(
	@IdFamilia int,
	@IdUsuario int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelUsuFam
WHERE IdFamilia = @IdFamilia
and IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioQuitarPatente]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioQuitarPatente]
(
	@IdPatente int,
	@IdUsuario int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelUsuPat
WHERE IdPatente = @IdPatente
and IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioReactivar]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioReactivar]
(
	@IdUsuario int,
	@DVH bigint
)


AS
BEGIN

update Usuario
set Activo = 1, DVH = @DVH
where IdUsuario = @IdUsuario

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerDatosPorNomUs]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerDatosPorNomUs]
(
	@Us varchar(30)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT us.IdUsuario, us.NombreUsuario, us.Pass, us.IdiomaUsuarioActual, us.Nombre, us.Apellido, us.Mail, us.Activo
FROM Usuario us
WHERE us.NombreUsuario = @Us
	
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerFamilias]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerFamilias]
(
	@IdUsuario INT
)


AS
BEGIN

SET NOCOUNT ON;

SELECT fam.IdFamilia, fam.NombreFamilia
FROM Familia fam
WHERE fam.IdFamilia IN 
	(	SELECT usfa.IdFamilia
		FROM RelUsuFam usfa
		WHERE usfa.IdUsuario = @IdUsuario
	)

	
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPatentes]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerPatentes]
(
	@IdUsuario INT
)


AS
BEGIN

SET NOCOUNT ON;

SELECT pat.IdPatente, pat.NombrePatente
FROM Patente pat
WHERE pat.IdPatente IN 
	(	SELECT uspa.IdPatente
		FROM RelUsuPat uspa
		WHERE uspa.IdUsuario = @IdUsuario
	)

	
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPorLogin]    Script Date: 05/09/2018 21:08:20 ******/
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

SELECT us.IdUsuario, us.NombreUsuario, us.Pass, us.Nombre, us.Apellido, us.Mail, us.IdiomaUsuarioActual, us.Activo
from Usuario us
WHERE NombreUsuario = @Us
AND Pass = @Pass


END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerTodos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT us.IdUsuario, us.NombreUsuario
FROM usuario us


END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodosActivos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerTodosActivos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT us.IdUsuario, us.NombreUsuario
FROM usuario us
where us.Activo = 1

END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodosDatosCompletos]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioTraerTodosDatosCompletos]

AS
BEGIN

	SET NOCOUNT ON;

SELECT us.IdUsuario, us.NombreUsuario, us.Nombre, us.Apellido, us.Pass, us.IdiomaUsuarioActual, us.Mail, us.Activo, us.DVH
FROM usuario us


END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioVerificarNomUs]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioVerificarNomUs]
(
	@Us varchar(30)
)


AS
BEGIN

SET NOCOUNT ON;

SELECT us.NombreUsuario
FROM Usuario us
WHERE us.NombreUsuario = @Us
	
END

GO
/****** Object:  Table [dbo].[Adquisicion]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Agente]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[AsigDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Asignacion]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Bien]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bien](
	[IdBien] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdModeloVersion] [int] NOT NULL,
 CONSTRAINT [PK_Bien] PRIMARY KEY CLUSTERED 
(
	[IdBien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[NombreUsuario] [varchar](30) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoLog] [varchar](10) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Mensaje] [varchar](5000) NOT NULL,
 CONSTRAINT [PK_Bitacora_1] PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripCategoria] [varchar](300) NOT NULL,
	[IdTipoBien] [int] NOT NULL,
	[Activo] [int] NOT NULL,
 CONSTRAINT [PK_SubCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConfigMailHost]    Script Date: 05/09/2018 21:08:20 ******/
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
	[Remps] [nvarchar](300) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Dependencia]    Script Date: 05/09/2018 21:08:20 ******/
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
	[Activo] [int] NOT NULL,
 CONSTRAINT [PK_Dependencia] PRIMARY KEY CLUSTERED 
(
	[IdDependencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Deposito]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Direccion]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[DVV]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DVV](
	[IdDVV] [int] IDENTITY(1,1) NOT NULL,
	[NombreTabla] [varchar](30) NOT NULL,
	[ClaveDVV] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[IdDVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoInventario]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[EstadoSolicDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Familia]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Familia](
	[IdFamilia] [int] IDENTITY(1,1) NOT NULL,
	[NombreFamilia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[IdiomaCargo]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaCargo](
	[IdCargo] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripCargo] [varchar](300) NOT NULL,
 CONSTRAINT [PK_IdiomaCargo] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC,
	[IdIdioma] ASC,
	[DescripCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaEstadoInventario]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaEstadoInventario](
	[IdEstadoInventario] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripEstadoInv] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdiomaEstadoInventario] PRIMARY KEY CLUSTERED 
(
	[IdEstadoInventario] ASC,
	[IdIdioma] ASC,
	[DescripEstadoInv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaEstadoSolicDetalle]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaEstadoSolicDetalle](
	[IdEstadoSolicDetalle] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripEstadoSolicDetalle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdiomaEstadoSolicDetalle] PRIMARY KEY CLUSTERED 
(
	[IdEstadoSolicDetalle] ASC,
	[IdIdioma] ASC,
	[DescripEstadoSolicDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaEstadoSolicitud]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaEstadoSolicitud](
	[IdEstadoSolicitud] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripEstadoSolic] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdiomaEstadoSolicitud] PRIMARY KEY CLUSTERED 
(
	[IdEstadoSolicitud] ASC,
	[IdIdioma] ASC,
	[DescripEstadoSolic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaPrioridad]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaPrioridad](
	[IdPrioridad] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripPrioridad] [varchar](20) NOT NULL,
 CONSTRAINT [PK_IdiomaPrioridad] PRIMARY KEY CLUSTERED 
(
	[IdPrioridad] ASC,
	[IdIdioma] ASC,
	[DescripPrioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaTipoDependencia]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaTipoDependencia](
	[IdTipoDependencia] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripTipoDependencia] [varchar](30) NOT NULL,
 CONSTRAINT [PK_IdiomaTipoDependencia] PRIMARY KEY CLUSTERED 
(
	[IdTipoDependencia] ASC,
	[IdIdioma] ASC,
	[DescripTipoDependencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaTipoTelefono]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaTipoTelefono](
	[IdTipoTelefono] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[DescripTipoTel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdiomaTipoTelefono] PRIMARY KEY CLUSTERED 
(
	[IdTipoTelefono] ASC,
	[IdIdioma] ASC,
	[DescripTipoTel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdBienEspecif] [int] NOT NULL,
	[SerialMaster] [nvarchar](300) NULL,
	[SerieKey] [nvarchar](300) NOT NULL,
	[IdDeposito] [int] NULL,
	[IdEstadoInventario] [int] NOT NULL,
	[Costo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Limite]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[ModeloVersion]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Nota]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Partida]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[PartidaDetalle]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidaDetalle](
	[IdPartidaDetalle] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[UIDPartidaDetalle] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PartidaDetalle_1] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC,
	[UIDPartidaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patente]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patente](
	[IdPatente] [int] IDENTITY(1,1) NOT NULL,
	[NombrePatente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Politica]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Prioridad]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prioridad](
	[IdPrioridad] [int] IDENTITY(1,1) NOT NULL,
	[DescripPrioridad] [varchar](20) NULL,
 CONSTRAINT [PK_Prioridad] PRIMARY KEY CLUSTERED 
(
	[IdPrioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[AliasProv] [varchar](100) NOT NULL,
	[ContactoProv] [varchar](100) NULL,
	[MailContactoProv] [nvarchar](200) NULL,
	[Activo] [int] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[RelCatProv]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelCatProv](
	[IdCategoria] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
 CONSTRAINT [PK_RelCatProv] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelCotizPartDetalle]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelCotizPartDetalle](
	[IdCotizacion] [int] NOT NULL,
	[IdPartida] [int] NOT NULL,
	[UIDPartidaDetalle] [int] NOT NULL,
 CONSTRAINT [PK_RelCotizPartDetalle] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC,
	[IdPartida] ASC,
	[UIDPartidaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelCotSolDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[RelDepAgenteCargo]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[RelFamFam]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelFamFam](
	[IdFamiliaPadre] [int] NOT NULL,
	[IdFamiliaHijo] [int] NOT NULL,
 CONSTRAINT [PK_RelFamFam] PRIMARY KEY CLUSTERED 
(
	[IdFamiliaPadre] ASC,
	[IdFamiliaHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelFamPat]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelFamPat](
	[IdPatente] [int] NOT NULL,
	[IdFamilia] [int] NOT NULL,
 CONSTRAINT [PK_RelFamPat] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelPDetAdq]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelPDetAdq](
	[IdPartida] [int] NOT NULL,
	[UIDPartidaDetalle] [int] NOT NULL,
	[IdAdquisicion] [int] NOT NULL,
	[IdInventario] [int] NOT NULL,
 CONSTRAINT [PK_RelPDetAdq] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC,
	[UIDPartidaDetalle] ASC,
	[IdAdquisicion] ASC,
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelProveedorDire]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelProveedorDire](
	[IdProveedor] [int] NOT NULL,
	[IdDireccion] [int] NOT NULL,
 CONSTRAINT [PK_RelProveedorDire] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC,
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelProveedorTel]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelProveedorTel](
	[IdProveedor] [int] NOT NULL,
	[IdTelefono] [int] NOT NULL,
 CONSTRAINT [PK_RelProveedorTel] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC,
	[IdTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelSolDetalleAgente]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[RelUsuFam]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelUsuFam](
	[IdUsuario] [int] NOT NULL,
	[IdFamilia] [int] NOT NULL,
 CONSTRAINT [PK_RelUsuFam] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelUsuPat]    Script Date: 05/09/2018 21:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelUsuPat](
	[IdUsuario] [int] NOT NULL,
	[IdPatente] [int] NOT NULL,
 CONSTRAINT [PK_RelUsuPat] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rendicion]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[SolicDetalle]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Solicitud]    Script Date: 05/09/2018 21:08:20 ******/
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
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[TipoBien]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[TipoDependencia]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 05/09/2018 21:08:20 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/09/2018 21:08:20 ******/
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
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Mail] [nvarchar](100) NOT NULL,
	[Activo] [int] NOT NULL,
	[DVH] [bigint] NULL,
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
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1041, CAST(0x0000A83E01469D0A AS DateTime), CAST(0x0000A83E00000000 AS DateTime), N'aa334422', NULL, CAST(1000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1042, CAST(0x0000A83E0163C402 AS DateTime), CAST(0x0000A83E00000000 AS DateTime), N'aadd3455', NULL, CAST(500.00 AS Decimal(10, 2)), NULL, 2)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1044, CAST(0x0000A83F01777DF6 AS DateTime), CAST(0x0000A83F00000000 AS DateTime), N'0412rrtee', NULL, CAST(500.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1045, CAST(0x0000A844010F284B AS DateTime), CAST(0x0000A84400000000 AS DateTime), N'091211', NULL, CAST(1000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1046, CAST(0x0000A84801609F43 AS DateTime), CAST(0x0000A84800000000 AS DateTime), N'gg555', NULL, CAST(1100.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1047, CAST(0x0000A94601761092 AS DateTime), CAST(0x0000A94600000000 AS DateTime), N'asdfggff', NULL, CAST(17000.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Adquisicion] ([IdAdquisicion], [FechaAdq], [FechaCompra], [NroFactura], [RutaDocumentos], [MontoCompra], [IdRendicion], [IdProveedor]) VALUES (1048, CAST(0x0000A946017F54FC AS DateTime), CAST(0x0000A94600000000 AS DateTime), N'240820182309', NULL, CAST(7000.00 AS Decimal(10, 2)), NULL, 1)
SET IDENTITY_INSERT [dbo].[Adquisicion] OFF
SET IDENTITY_INSERT [dbo].[Agente] ON 

INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (1, N'Pablo', N'Diez')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (2, N'Gustavo', N'Ripamonti')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (3, N'Damian', N'Daniel')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (4, N'Mariano', N'Marcovecchio')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (6, N'Cesar', N'Russo')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (7, N'Mariela', N'Deodatto')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (17, N'Matias', N'Gonzalez')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (18, N'Adrian', N'Rodriguez')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (19, N'Gonzalo', N'Ramirez')
INSERT [dbo].[Agente] ([IdAgente], [NombreAgente], [ApellidoAgente]) VALUES (20, N'Nestor', N'Martinez')
SET IDENTITY_INSERT [dbo].[Agente] OFF
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1014, 1, 1, 2332, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1015, 2, 1, 2332, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1016, 7, 1, 2333, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (1, 1017, 11, 1, 2338, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 1016, 8, 1, 2333, NULL, NULL)
INSERT [dbo].[AsigDetalle] ([IdAsigDetalle], [IdAsignacion], [IdInventario], [IdSolicitudDetalle], [IdSolicitud], [IdAgente], [Observacion]) VALUES (2, 1017, 12, 1, 2338, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Asignacion] ON 

INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1014, CAST(0x0000A84100000000 AS DateTime), 3)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1015, CAST(0x0000A84100000000 AS DateTime), 3)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1016, CAST(0x0000A8F600000000 AS DateTime), 2)
INSERT [dbo].[Asignacion] ([IdAsignacion], [Fecha], [IdDependencia]) VALUES (1017, CAST(0x0000A94600000000 AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[Asignacion] OFF
SET IDENTITY_INSERT [dbo].[Bien] ON 

INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [IdMarca], [IdModeloVersion]) VALUES (1, 3, 1, 2)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [IdMarca], [IdModeloVersion]) VALUES (2, 5, 4, 4)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [IdMarca], [IdModeloVersion]) VALUES (3, 2, 1, 5)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [IdMarca], [IdModeloVersion]) VALUES (4, 3, 1, 1)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [IdMarca], [IdModeloVersion]) VALUES (5, 6, 1, 2)
INSERT [dbo].[Bien] ([IdBien], [IdCategoria], [IdMarca], [IdModeloVersion]) VALUES (6, 1, 4, 4)
SET IDENTITY_INSERT [dbo].[Bien] OFF
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (1, 1, N'pargi', CAST(0x0000A8F600000000 AS DateTime), N'Accion', N'Accion realizada', N'Msj111')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2, 1, N'pargi', CAST(0x0000A8F600000000 AS DateTime), N'Accion', N'Accion realizada', N'Msj111')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (1002, 1, N'pargi', CAST(0x0000A8F600000000 AS DateTime), N'Accion', N'Accion realizada', N'Msj111')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (1004, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'btnLogin_Click', N'
No se encontró el procedimiento almacenado ''UsuarioTraerPorLogin''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCo')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (1005, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'btnLogin_Click', N'
No se encontró el procedimiento almacenado ''UsuarioTraerPorLogin''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCo')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (1006, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'btnLogin_Click', N'
No se encontró el procedimiento almacenado ''UsuarioTraerPorLogin''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 60
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 35
   en ARTEC.GUI.Login.btnLogin_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\Login.cs:línea 119')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (1007, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'btnLogin_Click', N'
No se encontró el procedimiento almacenado ''UsuarioTraerPorLogin''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 60
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 35
   en ARTEC.GUI.Login.btnLogin_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\Login.cs:línea 119')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2006, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'btnLogin_Click', N'
No se encontró el procedimiento almacenado ''UsuarioTraerPorLogin''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 60
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 35
   en ARTEC.GUI.Login.btnLogin_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\Login.cs:línea 119')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2007, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'btnLogin_Click', N'
No se encontró el procedimiento almacenado ''UsuarioTraerPorLogin''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 60
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 35
   en ARTEC.GUI.Login.btnLogin_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\Login.cs:línea 119')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2010, 0, N'SIN_USUARIO', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2011, 1, N'pargi', CAST(0x0000A8F600000000 AS DateTime), N'Error', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2012, 1, N'pargi', CAST(0x0000A8F600000000 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2013, 1, N'pargi', CAST(0x0000A8F6015E0B85 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2014, 0, N'SIN_USUARIO', CAST(0x0000A8F601747FDD AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2015, 1, N'pargi', CAST(0x0000A8F6017486D5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2016, 1, N'pargi', CAST(0x0000A8F6017B6F29 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2017, 1, N'pargi', CAST(0x0000A8F6017C59FF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2018, 1, N'pargi', CAST(0x0000A8F6017E5A7C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2019, 1, N'pargi', CAST(0x0000A8F6018134A7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2020, 1, N'pargi', CAST(0x0000A8F60181CF65 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2021, 1, N'pargi', CAST(0x0000A8F6018279E2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2022, 1, N'pargi', CAST(0x0000A8F60182A946 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2023, 1, N'pargi', CAST(0x0000A8F6018478DA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2024, 1, N'pargi', CAST(0x0000A8F6018624F2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2025, 1, N'pargi', CAST(0x0000A8F601881AD5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2026, 0, N'SIN_USUARIO', CAST(0x0000A8F6018AE777 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2027, 1, N'pargi', CAST(0x0000A8F6018AE803 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2028, 1, N'pargi', CAST(0x0000A8F70124AF74 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2029, 1, N'pargi', CAST(0x0000A8F70128888C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2030, 1, N'pargi', CAST(0x0000A8F701288D25 AS DateTime), N'Error', N'btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 55')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2031, 1, N'pargi', CAST(0x0000A8F70128BFA7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2032, 1, N'pargi', CAST(0x0000A8F70128C402 AS DateTime), N'Error', N'btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 55')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2033, 1, N'pargi', CAST(0x0000A8F70129AF51 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2034, 1, N'pargi', CAST(0x0000A8F70136FABD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2035, 1, N'pargi', CAST(0x0000A8F701370218 AS DateTime), N'Error', N'btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 55')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2036, 1, N'pargi', CAST(0x0000A8F701379558 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2037, 1, N'pargi', CAST(0x0000A8F701379CBF AS DateTime), N'Error', N'btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 58')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2038, 1, N'pargi', CAST(0x0000A8F70137BE55 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2039, 1, N'pargi', CAST(0x0000A8F70137C8F6 AS DateTime), N'Error', N'btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 58')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2040, 1, N'pargi', CAST(0x0000A8F70137D9F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2041, 1, N'pargi', CAST(0x0000A8F701381E73 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2042, 1, N'pargi', CAST(0x0000A8F701390C0C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2043, 1, N'pargi', CAST(0x0000A8F7013B8F29 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2044, 1, N'pargi', CAST(0x0000A8F70141DE65 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2045, 1, N'pargi', CAST(0x0000A8F7014248FD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2046, 1, N'pargi', CAST(0x0000A8F70142AB49 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2047, 1, N'pargi', CAST(0x0000A8F701441686 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2048, 1, N'pargi', CAST(0x0000A8F701446998 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2049, 1, N'pargi', CAST(0x0000A8F701457C73 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2050, 1, N'pargi', CAST(0x0000A8F70145D6F0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2051, 1, N'pargi', CAST(0x0000A8F70147017C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2052, 1, N'pargi', CAST(0x0000A8F701476FE0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2053, 1, N'pargi', CAST(0x0000A8F70148152D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2054, 1, N'pargi', CAST(0x0000A8F7014817D9 AS DateTime), N'Error', N'btnBuscar_Click', N'
Al control DataGridView no se puede agregar ninguna fila que no tenga columnas. Las columnas se deben agregar primero.
Archivo: 
Linea: 0
   en System.Windows.Forms.DataGridViewRowCollection.AddInternal(Boolean newRow, Object[] values)
   en System.Windows.Forms.DataGridViewRowCollection.Add(Object[] values)
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 71')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2055, 1, N'pargi', CAST(0x0000A8F7014E2D67 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2056, 1, N'pargi', CAST(0x0000A8F7014F6C1E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2057, 1, N'pargi', CAST(0x0000A8F7014FA7E1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2058, 1, N'pargi', CAST(0x0000A8F7014FA860 AS DateTime), N'Error', N'SolicitudBuscar_Load', N'
No se encontró el procedimiento almacenado ''EstadoSolicitudTraerTodosPorIdioma''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALEstadoSolicitud.EstadoSolicitudTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALEstadoSolicitud.cs:línea 42
   en ARTEC.BLL.BLLEstadoSolicitud.EstadoSolicitudTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLEstadoSolicitud.cs:línea 20
   en ARTEC.GUI.SolicitudBuscar.SolicitudBuscar_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 115')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2059, 1, N'pargi', CAST(0x0000A8F7015029D5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2060, 1, N'pargi', CAST(0x0000A8F701502A4A AS DateTime), N'Error', N'SolicitudBuscar_Load', N'
No se encontró el procedimiento almacenado ''EstadoSolicitudTraerTodosPorIdioma''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALEstadoSolicitud.EstadoSolicitudTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALEstadoSolicitud.cs:línea 42
   en ARTEC.BLL.BLLEstadoSolicitud.EstadoSolicitudTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLEstadoSolicitud.cs:línea 20
   en ARTEC.GUI.SolicitudBuscar.SolicitudBuscar_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 115')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2061, 1, N'pargi', CAST(0x0000A8F701503535 AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs
Linea: 54
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 54')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2062, 1, N'pargi', CAST(0x0000A8F701503BEB AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs
Linea: 54
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 54')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2063, 1, N'pargi', CAST(0x0000A8F701505F2E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2064, 1, N'pargi', CAST(0x0000A8F701505FA7 AS DateTime), N'Error', N'SolicitudBuscar_Load', N'
No se encontró el procedimiento almacenado ''EstadoSolicitudTraerTodosPorIdioma''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALEstadoSolicitud.EstadoSolicitudTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALEstadoSolicitud.cs:línea 42
   en ARTEC.BLL.BLLEstadoSolicitud.EstadoSolicitudTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLEstadoSolicitud.cs:línea 20
   en ARTEC.GUI.SolicitudBuscar.SolicitudBuscar_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 115')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2065, 1, N'pargi', CAST(0x0000A8F701506557 AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs
Linea: 54
   en ARTEC.GUI.SolicitudBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\SolicitudBuscar.cs:línea 54')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2066, 1, N'pargi', CAST(0x0000A8F7015A7A8B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2067, 0, N'SIN_USUARIO', CAST(0x0000A8F7015E8372 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2068, 1, N'pargi', CAST(0x0000A8F7015E8628 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2069, 1, N'pargi', CAST(0x0000A8F800C6299B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2070, 1, N'pargi', CAST(0x0000A8F800C90AFF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2071, 1, N'pargi', CAST(0x0000A8F800CDD5A3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2072, 1, N'pargi', CAST(0x0000A8F800CF4277 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2073, 1, N'pargi', CAST(0x0000A8F800D08ECF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2074, 1, N'pargi', CAST(0x0000A8F800D18853 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2075, 1, N'pargi', CAST(0x0000A8F800D274ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2076, 1, N'pargi', CAST(0x0000A8F800D2D33C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2077, 1, N'pargi', CAST(0x0000A8F800D3642E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2078, 1, N'pargi', CAST(0x0000A8F800D41D65 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2079, 1, N'pargi', CAST(0x0000A8F800D4B052 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2080, 1, N'pargi', CAST(0x0000A8F800D51B92 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2081, 1, N'pargi', CAST(0x0000A8F800D6810E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2082, 1, N'pargi', CAST(0x0000A8F800D85A7C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2083, 1, N'pargi', CAST(0x0000A8F800DFB0D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2084, 1, N'pargi', CAST(0x0000A8F800E01658 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2085, 1, N'pargi', CAST(0x0000A8F800E302B4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2086, 1, N'pargi', CAST(0x0000A8F901789164 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2087, 1, N'pargi', CAST(0x0000A8F90187D8AE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2088, 1, N'pargi', CAST(0x0000A8F901893052 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2089, 0, N'SIN_USUARIO', CAST(0x0000A8F90189B6A8 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2090, 0, N'SIN_USUARIO', CAST(0x0000A8F90189B893 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2091, 1, N'pargi', CAST(0x0000A8F90189BADC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2092, 1, N'pargi', CAST(0x0000A91200F8AC3E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2093, 1, N'pargi', CAST(0x0000A91300B9D300 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2094, 1, N'pargi', CAST(0x0000A913010D9DD5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2095, 1, N'pargi', CAST(0x0000A913015F3370 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2096, 1, N'pargi', CAST(0x0000A913015F8EF2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2097, 1, N'pargi', CAST(0x0000A913015FE422 AS DateTime), N'Error', N'UsuarioTraerPermisos', N'
Otro SqlParameterCollection ya contiene SqlParameter.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlParameterCollection.Validate(Int32 index, Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(SqlParameter value)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearComando(SqlConnection Conexion, CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 199
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 102
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 52')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2098, 1, N'pargi', CAST(0x0000A913015FE431 AS DateTime), N'Error', N'btnLogin_Click', N'
Otro SqlParameterCollection ya contiene SqlParameter.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlParameterCollection.Validate(Int32 index, Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(SqlParameter value)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearComando(SqlConnection Conexion, CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 199
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 102
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 57
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 40
   en ARTEC.GUI.Login.btnLogin_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\Login.cs:línea 118')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2099, 1, N'pargi', CAST(0x0000A91301751CE2 AS DateTime), N'Error', N'UsuarioTraerPermisos', N'
Otro SqlParameterCollection ya contiene SqlParameter.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlParameterCollection.Validate(Int32 index, Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(SqlParameter value)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearComando(SqlConnection Conexion, CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 199
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 102
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 52')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2100, 1, N'pargi', CAST(0x0000A91301751CF2 AS DateTime), N'Error', N'btnLogin_Click', N'
Otro SqlParameterCollection ya contiene SqlParameter.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlParameterCollection.Validate(Int32 index, Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(Object value)
   en System.Data.SqlClient.SqlParameterCollection.Add(SqlParameter value)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearComando(SqlConnection Conexion, CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 199
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.DALUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 102
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPermisos(Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 57
   en ARTEC.BLL.BLLUsuario.UsuarioTraerPorLogin(String NomUs, String PassHash) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 40
   en ARTEC.GUI.Login.btnLogin_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\Login.cs:línea 118')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2101, 1, N'pargi', CAST(0x0000A91301784595 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2102, 1, N'pargi', CAST(0x0000A913017A0BF2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2103, 1, N'pargi', CAST(0x0000A913017AF627 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2104, 1, N'pargi', CAST(0x0000A913017B6FC8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2105, 1, N'pargi', CAST(0x0000A9140017AC22 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2106, 1, N'pargi', CAST(0x0000A91400184008 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2107, 1, N'pargi', CAST(0x0000A9140023DE1D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2108, 1, N'pargi', CAST(0x0000A914002434D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2109, 1, N'pargi', CAST(0x0000A91400B930AC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2110, 2, N'lola', CAST(0x0000A91400B96172 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2111, 1, N'pargi', CAST(0x0000A91400F95EBD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2112, 1, N'pargi', CAST(0x0000A91400F9B696 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2113, 1, N'pargi', CAST(0x0000A91400FAC794 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2114, 1, N'pargi', CAST(0x0000A91400FB8E80 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2115, 1, N'pargi', CAST(0x0000A91400FC7FAF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2116, 1, N'pargi', CAST(0x0000A91400FD52D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2117, 1, N'pargi', CAST(0x0000A91400FD66AD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2118, 1, N'pargi', CAST(0x0000A914010A6F36 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2119, 1, N'pargi', CAST(0x0000A914010B6908 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2120, 1, N'pargi', CAST(0x0000A91401501AE9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2121, 1, N'pargi', CAST(0x0000A91401617A2B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2122, 1, N'pargi', CAST(0x0000A91401620066 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2123, 1, N'pargi', CAST(0x0000A914016290A2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2124, 1, N'pargi', CAST(0x0000A91500ED7C15 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2125, 1, N'pargi', CAST(0x0000A9150109027A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2126, 2, N'lola', CAST(0x0000A91501091380 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2127, 1, N'pargi', CAST(0x0000A915010AB675 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2128, 1, N'pargi', CAST(0x0000A915010D696C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2129, 1, N'pargi', CAST(0x0000A915011A2C6B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2130, 0, N'SIN_USUARIO', CAST(0x0000A915011C460F AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2131, 1, N'pargi', CAST(0x0000A915011C4743 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2132, 1, N'pargi', CAST(0x0000A915011C6D38 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2133, 1, N'pargi', CAST(0x0000A915011D81C1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2134, 1, N'pargi', CAST(0x0000A915011F75D5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2135, 1, N'pargi', CAST(0x0000A916010AB30D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2136, 1, N'pargi', CAST(0x0000A916010AB5D9 AS DateTime), N'Error', N'PermisosTraerTodos', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 94
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 39')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2137, 1, N'pargi', CAST(0x0000A916010B6046 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2138, 1, N'pargi', CAST(0x0000A916010B630E AS DateTime), N'Error', N'PermisosTraerTodos', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 94
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 39')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2139, 1, N'pargi', CAST(0x0000A916010B8BA2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2140, 1, N'pargi', CAST(0x0000A916010C447F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2141, 1, N'pargi', CAST(0x0000A916010C477A AS DateTime), N'Error', N'PermisosTraerTodos', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 93
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 39')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2142, 1, N'pargi', CAST(0x0000A916010C4788 AS DateTime), N'Error', N'frmUsuariosGestion_Load', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 93
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 44
   en ARTEC.GUI.frmUsuariosGestion.frmUsuariosGestion_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosGestion.cs:línea 31')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2143, 1, N'pargi', CAST(0x0000A916010C717F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2144, 1, N'pargi', CAST(0x0000A916010C7454 AS DateTime), N'Error', N'PermisosTraerTodos', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 93
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 39')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2145, 1, N'pargi', CAST(0x0000A916010C7462 AS DateTime), N'Error', N'frmUsuariosGestion_Load', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 93
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 44
   en ARTEC.GUI.frmUsuariosGestion.frmUsuariosGestion_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosGestion.cs:línea 31')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2146, 1, N'pargi', CAST(0x0000A916010C7AA3 AS DateTime), N'Error', N'PermisosTraerTodos', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 93
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 39')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2147, 1, N'pargi', CAST(0x0000A916010C7AB1 AS DateTime), N'Error', N'frmUsuariosGestion_Load', N'
No se encontró el procedimiento almacenado ''FamiliasTraerTodas''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   en System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   en System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.CrearDataSet(SqlCommand unComando) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 239
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 111
   en ARTEC.DAL.Servicios.DALFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 93
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 44
   en ARTEC.GUI.frmUsuariosGestion.frmUsuariosGestion_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosGestion.cs:línea 31')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2148, 1, N'pargi', CAST(0x0000A916010D2238 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2149, 1, N'pargi', CAST(0x0000A9160127CB0E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2150, 1, N'pargi', CAST(0x0000A9160127CDDA AS DateTime), N'Error', N'FamiliaTraerSubPermisos', N'
No se puede implementar el método o la operación.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.ENTIDADES\Servicios\Patente.cs
Linea: 30
   en ARTEC.ENTIDADES.Servicios.Patente.Agregar(IFamPat ElementoFamPat) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.ENTIDADES\Servicios\Patente.cs:línea 30
   en ARTEC.DAL.Servicios.DALFamilia.FamiliaTraerFamiliasHijas(IFamPat unaFamilia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 57
   en ARTEC.BLL.Servicios.BLLFamilia.FamiliaTraerSubPermisos(List`1 unasFamilias) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 23')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2151, 1, N'pargi', CAST(0x0000A9160127CDE8 AS DateTime), N'Error', N'PermisosTraerTodos', N'
No se puede implementar el método o la operación.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.ENTIDADES\Servicios\Patente.cs
Linea: 30
   en ARTEC.ENTIDADES.Servicios.Patente.Agregar(IFamPat ElementoFamPat) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.ENTIDADES\Servicios\Patente.cs:línea 30
   en ARTEC.DAL.Servicios.DALFamilia.FamiliaTraerFamiliasHijas(IFamPat unaFamilia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 57
   en ARTEC.BLL.Servicios.BLLFamilia.FamiliaTraerSubPermisos(List`1 unasFamilias) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 31
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 41')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2152, 1, N'pargi', CAST(0x0000A9160127CDF2 AS DateTime), N'Error', N'frmUsuariosGestion_Load', N'
No se puede implementar el método o la operación.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.ENTIDADES\Servicios\Patente.cs
Linea: 30
   en ARTEC.ENTIDADES.Servicios.Patente.Agregar(IFamPat ElementoFamPat) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.ENTIDADES\Servicios\Patente.cs:línea 30
   en ARTEC.DAL.Servicios.DALFamilia.FamiliaTraerFamiliasHijas(IFamPat unaFamilia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 57
   en ARTEC.BLL.Servicios.BLLFamilia.FamiliaTraerSubPermisos(List`1 unasFamilias) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 31
   en ARTEC.BLL.Servicios.BLLFamilia.PermisosTraerTodos() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 47
   en ARTEC.GUI.frmUsuariosGestion.frmUsuariosGestion_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosGestion.cs:línea 31')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2153, 1, N'pargi', CAST(0x0000A916012834DC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2154, 1, N'pargi', CAST(0x0000A916012C4E76 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2155, 1, N'pargi', CAST(0x0000A916012D69ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2156, 1, N'pargi', CAST(0x0000A916012ECDC6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2157, 2, N'lola', CAST(0x0000A916012EE34F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2158, 1, N'pargi', CAST(0x0000A916013D7332 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2159, 1, N'pargi', CAST(0x0000A917016AD74B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2160, 1, N'pargi', CAST(0x0000A917016C0901 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2161, 1, N'pargi', CAST(0x0000A917016C1DDC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2162, 1, N'pargi', CAST(0x0000A917017F9DA2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2163, 1, N'pargi', CAST(0x0000A9170181102B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2164, 1, N'pargi', CAST(0x0000A91701812F0E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2165, 1, N'pargi', CAST(0x0000A91701873913 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2166, 1, N'pargi', CAST(0x0000A9180002C071 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2167, 1, N'pargi', CAST(0x0000A9180002F728 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2168, 1, N'pargi', CAST(0x0000A91800032439 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2169, 1, N'pargi', CAST(0x0000A9180004E90C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2170, 1, N'pargi', CAST(0x0000A9180006BD58 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2171, 1, N'pargi', CAST(0x0000A91800079C15 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2172, 1, N'pargi', CAST(0x0000A9180008522C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2173, 1, N'pargi', CAST(0x0000A9180008577C AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs
Linea: 175
   en ARTEC.DAL.DALUsuario.UsuarioVerificarNomUs(String NomUs) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 175
   en ARTEC.BLL.BLLUsuario.UsuarioVerificarNomUs(String NomUs) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 96
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 110')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2174, 1, N'pargi', CAST(0x0000A918000DFC7F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2175, 1, N'pargi', CAST(0x0000A918000E4BE6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2176, 1, N'pargi', CAST(0x0000A918000F93ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2177, 1, N'pargi', CAST(0x0000A918001036CC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2178, 1, N'pargi', CAST(0x0000A91800204EDE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2179, 1, N'pargi', CAST(0x0000A9190148F90F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2180, 1, N'pargi', CAST(0x0000A9190149C552 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2181, 1, N'pargi', CAST(0x0000A919014DDCA6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2182, 1, N'pargi', CAST(0x0000A9190152B528 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2183, 1, N'pargi', CAST(0x0000A919015522AA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2184, 1, N'pargi', CAST(0x0000A919015B73CC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2185, 1, N'pargi', CAST(0x0000A919015B7B12 AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs
Linea: 130
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass3.<>c__DisplayClass5.<btnBuscar_Click>b__1(IFamPat a) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 130
   en System.Linq.Enumerable.Any[TSource](IEnumerable`1 source, Func`2 predicate)
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass3.<btnBuscar_Click>b__0(IFamPat d) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 130
   en System.Linq.Enumerable.WhereListIterator`1.MoveNext()
   en System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   en System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 130')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2186, 1, N'pargi', CAST(0x0000A919015B8C34 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2187, 1, N'pargi', CAST(0x0000A91901615D51 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2188, 1, N'pargi', CAST(0x0000A91901616447 AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs
Linea: 131
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass4.<>c__DisplayClass6.<btnBuscar_Click>b__1(IFamPat a) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 131
   en System.Linq.Enumerable.Any[TSource](IEnumerable`1 source, Func`2 predicate)
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass4.<btnBuscar_Click>b__0(IFamPat d) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 131
   en System.Linq.Enumerable.WhereListIterator`1.MoveNext()
   en System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   en System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 131')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2189, 1, N'pargi', CAST(0x0000A91901617328 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2190, 1, N'pargi', CAST(0x0000A91901618CF8 AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs
Linea: 131
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass4.<>c__DisplayClass6.<btnBuscar_Click>b__1(IFamPat a) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 131
   en System.Linq.Enumerable.Any[TSource](IEnumerable`1 source, Func`2 predicate)
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass4.<btnBuscar_Click>b__0(IFamPat d) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 131
   en System.Linq.Enumerable.WhereListIterator`1.MoveNext()
   en System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   en System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 131')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2191, 1, N'pargi', CAST(0x0000A91901629037 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2192, 1, N'pargi', CAST(0x0000A919016298E5 AS DateTime), N'Error', N'btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs
Linea: 130
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass3.<>c__DisplayClass5.<btnBuscar_Click>b__1(IFamPat a) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 130
   en System.Linq.Enumerable.Any[TSource](IEnumerable`1 source, Func`2 predicate)
   en ARTEC.GUI.frmUsuariosModificar.<>c__DisplayClass3.<btnBuscar_Click>b__0(IFamPat d) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 130
   en System.Linq.Enumerable.WhereListIterator`1.MoveNext()
   en System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   en System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 130')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2193, 1, N'pargi', CAST(0x0000A9190163B097 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2194, 1, N'pargi', CAST(0x0000A91901662434 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2195, 1, N'pargi', CAST(0x0000A9190166BDC9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2196, 1, N'pargi', CAST(0x0000A919016CA77E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2197, 1, N'pargi', CAST(0x0000A919016D9AF3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2198, 1, N'pargi', CAST(0x0000A91A012E1CD8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2199, 1, N'pargi', CAST(0x0000A91A012EA4BC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2200, 1, N'pargi', CAST(0x0000A91A01588AD7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2201, 1, N'pargi', CAST(0x0000A91A015F8264 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2202, 1, N'pargi', CAST(0x0000A91A01608C54 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2203, 1, N'pargi', CAST(0x0000A91A016093D9 AS DateTime), N'Error', N'btnBuscar_Click', N'
No se puede agregar o insertar el elemento ''Familia: ABM Solicitud'' en más de un sitio. Debe quitarlo primero de su ubicación actual o clonarlo.
Nombre del parámetro: node
Archivo: 
Linea: 0
   en System.Windows.Forms.TreeNodeCollection.AddInternal(TreeNode node, Int32 delta)
   en System.Windows.Forms.TreeNodeCollection.Add(TreeNode node)
   en ARTEC.GUI.frmUsuariosModificar.ListarPermisosDisponiblesPrueba(List`1 PermisosVer, TreeNode elNodo) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 123
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 177')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2204, 1, N'pargi', CAST(0x0000A91A0161AB37 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2205, 1, N'pargi', CAST(0x0000A91A016289F6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2206, 1, N'pargi', CAST(0x0000A91A0164801D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2207, 1, N'pargi', CAST(0x0000A91A0164A511 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2208, 1, N'pargi', CAST(0x0000A91A016536E0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2209, 1, N'pargi', CAST(0x0000A91A0165AE4B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2210, 1, N'pargi', CAST(0x0000A91A0165B4C4 AS DateTime), N'Error', N'btnBuscar_Click', N'
No se puede agregar o insertar el elemento ''Familia: ABM Partida'' en más de un sitio. Debe quitarlo primero de su ubicación actual o clonarlo.
Nombre del parámetro: node
Archivo: 
Linea: 0
   en System.Windows.Forms.TreeNodeCollection.AddInternal(TreeNode node, Int32 delta)
   en System.Windows.Forms.TreeNodeCollection.Add(TreeNode node)
   en ARTEC.GUI.frmUsuariosModificar.ListarPermisosDisponiblesPrueba2(List`1 PermisosVer, TreeNode elNodo) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 155
   en ARTEC.GUI.frmUsuariosModificar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 209')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2211, 1, N'pargi', CAST(0x0000A91A016A0526 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2212, 1, N'pargi', CAST(0x0000A91A016E704B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2213, 1, N'pargi', CAST(0x0000A91A01701F6F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2214, 1, N'pargi', CAST(0x0000A91A0170C6AF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2215, 1, N'pargi', CAST(0x0000A91A0173D207 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2216, 1, N'pargi', CAST(0x0000A91A017575E8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2217, 1, N'pargi', CAST(0x0000A91A017629F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2218, 1, N'pargi', CAST(0x0000A91B01470AFF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2219, 1, N'pargi', CAST(0x0000A91B0149031C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2220, 1, N'pargi', CAST(0x0000A91B014B2954 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2221, 1, N'pargi', CAST(0x0000A91B014B5C0A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2222, 1, N'pargi', CAST(0x0000A91B01667CEA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2223, 1, N'pargi', CAST(0x0000A91B0168D5D5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2224, 1, N'pargi', CAST(0x0000A91B0169351A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2225, 1, N'pargi', CAST(0x0000A91B0175A32A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2226, 1, N'pargi', CAST(0x0000A91B017A0C4C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2227, 1, N'pargi', CAST(0x0000A91B017A365E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2228, 1, N'pargi', CAST(0x0000A91B017C526E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2229, 1, N'pargi', CAST(0x0000A91B017EA5E8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2230, 1, N'pargi', CAST(0x0000A91B0180551E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2231, 1, N'pargi', CAST(0x0000A91C00AFFA99 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2232, 1, N'pargi', CAST(0x0000A91C00B2A0FE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2233, 1, N'pargi', CAST(0x0000A91C00B38A68 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2234, 1, N'pargi', CAST(0x0000A91C00B4D1AF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2235, 1, N'pargi', CAST(0x0000A91C00B508EF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2236, 1, N'pargi', CAST(0x0000A91C00BB3430 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2237, 1, N'pargi', CAST(0x0000A91C00BB7B6A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2238, 1, N'pargi', CAST(0x0000A91C00BBC342 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2239, 1, N'pargi', CAST(0x0000A91C00C32D39 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2240, 1, N'pargi', CAST(0x0000A91C00C3CD7F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2241, 1, N'pargi', CAST(0x0000A91C00C3F7C4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2242, 1, N'pargi', CAST(0x0000A91C00C4DABE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2243, 1, N'pargi', CAST(0x0000A91C00C7706F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2244, 1, N'pargi', CAST(0x0000A91C00C7DCEA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2245, 1, N'pargi', CAST(0x0000A91C00C8926C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2246, 1, N'pargi', CAST(0x0000A91C00CA5E19 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2247, 1, N'pargi', CAST(0x0000A91C01205730 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2248, 1, N'pargi', CAST(0x0000A91C01228D09 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2249, 1, N'pargi', CAST(0x0000A91C01232859 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2250, 1, N'pargi', CAST(0x0000A91C01239772 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2251, 1, N'pargi', CAST(0x0000A91C0123D2A1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2252, 1, N'pargi', CAST(0x0000A91C01337E39 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2253, 1, N'pargi', CAST(0x0000A91C013EB6F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2254, 1, N'pargi', CAST(0x0000A91C01415678 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2255, 1, N'pargi', CAST(0x0000A91C0143ABD1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2256, 0, N'SIN_USUARIO', CAST(0x0000A91C01457EF3 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2257, 1, N'pargi', CAST(0x0000A91C01458D7A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2258, 1, N'pargi', CAST(0x0000A91C01527717 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2259, 1, N'pargi', CAST(0x0000A91C015394D2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2260, 1, N'pargi', CAST(0x0000A91C01565BAA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2261, 1, N'pargi', CAST(0x0000A91C015B56C1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2262, 1, N'pargi', CAST(0x0000A91C015BFA3B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2263, 1, N'pargi', CAST(0x0000A91C015C8266 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2264, 1, N'pargi', CAST(0x0000A91C015D0687 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2265, 1, N'pargi', CAST(0x0000A91C015FE483 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2266, 1, N'pargi', CAST(0x0000A91C0160EAC5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2267, 1, N'pargi', CAST(0x0000A91C0161C175 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2268, 1, N'pargi', CAST(0x0000A91C01621A96 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2269, 1, N'pargi', CAST(0x0000A91C0162863F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2270, 1, N'pargi', CAST(0x0000A91C016356D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2271, 1, N'pargi', CAST(0x0000A91C0164AB13 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2272, 1, N'pargi', CAST(0x0000A91C0165F6DE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2273, 1, N'pargi', CAST(0x0000A91C01664E13 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2274, 1, N'pargi', CAST(0x0000A91C0167860D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2275, 1, N'pargi', CAST(0x0000A91C0167E6E5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2276, 1, N'pargi', CAST(0x0000A91C016813C4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2277, 0, N'SIN_USUARIO', CAST(0x0000A91C016AC78F AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2278, 1, N'pargi', CAST(0x0000A91C016AC8E1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2279, 1, N'pargi', CAST(0x0000A91D00F5200E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2280, 1, N'pargi', CAST(0x0000A91D00F5B52A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2281, 1, N'pargi', CAST(0x0000A91D00F6803E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2282, 1, N'pargi', CAST(0x0000A91D00F6F4D2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2283, 1, N'pargi', CAST(0x0000A91D00F81691 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2284, 1, N'pargi', CAST(0x0000A91D00FC260A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2285, 1, N'pargi', CAST(0x0000A91D00FF10FD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2286, 1, N'pargi', CAST(0x0000A91D00FFAAD9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2287, 0, N'SIN_USUARIO', CAST(0x0000A91D010352CF AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2288, 1, N'pargi', CAST(0x0000A91D01039129 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2289, 1, N'pargi', CAST(0x0000A91D0103C760 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2290, 0, N'SIN_USUARIO', CAST(0x0000A91D0103D20B AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2291, 2, N'lola', CAST(0x0000A91D0103D447 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2292, 1, N'pargi', CAST(0x0000A91D010446EA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2293, 1, N'pargi', CAST(0x0000A91D0121DD7A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2294, 1, N'pargi', CAST(0x0000A91F00C80786 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2295, 1, N'pargi', CAST(0x0000A91F00C929C4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2296, 1, N'pargi', CAST(0x0000A91F00CAB387 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2297, 1, N'pargi', CAST(0x0000A91F0157CA9D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2298, 1, N'pargi', CAST(0x0000A91F015AC51C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2299, 1, N'pargi', CAST(0x0000A91F015B852D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2300, 1, N'pargi', CAST(0x0000A91F015BF877 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2301, 1, N'pargi', CAST(0x0000A91F015CF7CC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2302, 1, N'pargi', CAST(0x0000A91F015FC6EF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2303, 1, N'pargi', CAST(0x0000A91F0187101E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2304, 1, N'pargi', CAST(0x0000A91F018741C6 AS DateTime), N'Error', N'btnCrearUsuario_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosCrear.cs
Linea: 50
   en ARTEC.GUI.frmUsuariosCrear.btnCrearUsuario_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosCrear.cs:línea 50')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2305, 1, N'pargi', CAST(0x0000A91F01883588 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2306, 1, N'pargi', CAST(0x0000A91F0188753A AS DateTime), N'Error', N'btnCrearUsuario_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosCrear.cs
Linea: 50
   en ARTEC.GUI.frmUsuariosCrear.btnCrearUsuario_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosCrear.cs:línea 50')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2307, 1, N'pargi', CAST(0x0000A91F01899633 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2308, 1, N'pargi', CAST(0x0000A91F018ABCD1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2309, 1, N'pargi', CAST(0x0000A91F018B3A3E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2310, 1, N'pargi', CAST(0x0000A9200000E9D3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2311, 3, N'mgulli', CAST(0x0000A9200002013D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2312, 1, N'pargi', CAST(0x0000A92000026FC5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2313, 1, N'pargi', CAST(0x0000A92000028F21 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2314, 1, N'pargi', CAST(0x0000A9200002DB07 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2315, 1, N'pargi', CAST(0x0000A920000353B1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2316, 1, N'pargi', CAST(0x0000A9200003B199 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2317, 1, N'pargi', CAST(0x0000A92000040BA8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2318, 1, N'pargi', CAST(0x0000A92000D83DE2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2319, 1, N'pargi', CAST(0x0000A92000DCE400 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2320, 1, N'pargi', CAST(0x0000A92000DCED9E AS DateTime), N'Error', N'btnEliminarUsuario_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs
Linea: 286
   en ARTEC.GUI.frmUsuariosModificar.btnEliminarUsuario_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 286')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2321, 1, N'pargi', CAST(0x0000A92000DD264F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2322, 1, N'pargi', CAST(0x0000A92000DE6C76 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2323, 1, N'pargi', CAST(0x0000A92000E3E3F9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2324, 1, N'pargi', CAST(0x0000A92000E4CB33 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2325, 1, N'pargi', CAST(0x0000A92000E51BBD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2326, 1, N'pargi', CAST(0x0000A92000E5D084 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2327, 1, N'pargi', CAST(0x0000A92000E617AF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2328, 1, N'pargi', CAST(0x0000A92000E6B4C8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2329, 1, N'pargi', CAST(0x0000A92000E83CDA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2330, 1, N'pargi', CAST(0x0000A92000E88E88 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2331, 1, N'pargi', CAST(0x0000A92000EBF051 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2332, 1, N'pargi', CAST(0x0000A92000EE9E51 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2333, 1, N'pargi', CAST(0x0000A92000F09DD8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2334, 0, N'SIN_USUARIO', CAST(0x0000A92000F0E78C AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2335, 0, N'SIN_USUARIO', CAST(0x0000A92000F0E9D0 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2336, 1, N'pargi', CAST(0x0000A92000F1AF14 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2337, 1, N'pargi', CAST(0x0000A92000F70981 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2338, 1, N'pargi', CAST(0x0000A92000FB99A9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2339, 1, N'pargi', CAST(0x0000A92000FCEC1C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2340, 1, N'pargi', CAST(0x0000A92001090246 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2341, 1, N'pargi', CAST(0x0000A9200121253C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2342, 1, N'pargi', CAST(0x0000A9200122847F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2343, 0, N'SIN_USUARIO', CAST(0x0000A920016D6B24 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2344, 1, N'pargi', CAST(0x0000A920016DE1E2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2345, 1, N'pargi', CAST(0x0000A920016E3912 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2346, 1, N'pargi', CAST(0x0000A921000893F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2347, 1, N'pargi', CAST(0x0000A9210008F392 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2348, 1, N'pargi', CAST(0x0000A921000AD5FA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2349, 1, N'pargi', CAST(0x0000A921000B5419 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2350, 1, N'pargi', CAST(0x0000A921000BC2AE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2351, 1, N'pargi', CAST(0x0000A92200EAD276 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2352, 1, N'pargi', CAST(0x0000A92200EB7077 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2353, 1, N'pargi', CAST(0x0000A92200EC4482 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2354, 1, N'pargi', CAST(0x0000A92200ECAE32 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2355, 1, N'pargi', CAST(0x0000A92200ED2111 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2356, 1, N'pargi', CAST(0x0000A92200ED49EF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2357, 1, N'pargi', CAST(0x0000A92200ED8F11 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2358, 1, N'pargi', CAST(0x0000A92200EFA27B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2359, 1, N'pargi', CAST(0x0000A92200F0229F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2360, 1, N'pargi', CAST(0x0000A922010D803B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2361, 1, N'pargi', CAST(0x0000A9220117E4D5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2362, 1, N'pargi', CAST(0x0000A92201196252 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2363, 1, N'pargi', CAST(0x0000A9220119D568 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2364, 1, N'pargi', CAST(0x0000A923000EF77C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2365, 1, N'pargi', CAST(0x0000A9230013B4BE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2366, 1, N'pargi', CAST(0x0000A92300158F0D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2367, 1, N'pargi', CAST(0x0000A923011992F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (2368, 1, N'pargi', CAST(0x0000A923011C1B99 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3367, 1, N'pargi', CAST(0x0000A923012C6E62 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3368, 1, N'pargi', CAST(0x0000A923012ECDAA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3369, 1, N'pargi', CAST(0x0000A923012F4C4D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3370, 1, N'pargi', CAST(0x0000A92301348517 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3371, 1, N'pargi', CAST(0x0000A9230135BB53 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3372, 1, N'pargi', CAST(0x0000A9230136822D AS DateTime), N'Error', N'btnModifUsuario_Click', N'
No se encontró el procedimiento almacenado ''DVActualizarDVH''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 298
   en ARTEC.DAL.Servicios.DALDV.DVActualizarDVH(Int32 IdFila, Int64 Acum, String NomTabla, String NomColumnaWhere) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALDV.cs:línea 37
   en ARTEC.BLL.Servicios.BLLDV.DVActualizarDVH(Object unObjeto) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLDV.cs:línea 50
   en ARTEC.BLL.BLLUsuario.UsuarioModificar(Usuario UsModif, List`1 PerAgregar, List`1 PerQuitar, Usuario unUsuarioDVH) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 330
   en ARTEC.GUI.frmUsuariosModificar.btnModifUsuario_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 311')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3373, 1, N'pargi', CAST(0x0000A92500CB3EAE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3374, 1, N'pargi', CAST(0x0000A92500CC0D7E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3375, 1, N'pargi', CAST(0x0000A92500CC60DF AS DateTime), N'Error', N'btnCrearUsuario_Click', N'
No se puede insertar el valor NULL en la columna ''DVH'', tabla ''Artec.dbo.Usuario''. La columna no admite valores NULL. Error de INSERT.
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteScalar()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 280
   en ARTEC.DAL.DALUsuario.UsuarioCrear(Usuario unUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 536
   en ARTEC.BLL.BLLUsuario.UsuarioCrear(Usuario unUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 223
   en ARTEC.GUI.frmUsuariosCrear.btnCrearUsuario_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosCrear.cs:línea 68')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3376, 1, N'pargi', CAST(0x0000A92500D094CC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3377, 1, N'pargi', CAST(0x0000A92500D5A3B5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3378, 1, N'pargi', CAST(0x0000A92500DD1018 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3379, 1, N'pargi', CAST(0x0000A92500DE8342 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3380, 1, N'pargi', CAST(0x0000A92500DFE292 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3381, 1, N'pargi', CAST(0x0000A92500E2DE85 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3382, 1, N'pargi', CAST(0x0000A92500E34BAE AS DateTime), N'Error', N'btnModifUsuario_Click', N'
Infracción de la restricción PRIMARY KEY ''PK_RelUsuFam''. No se puede insertar una clave duplicada en el objeto ''dbo.RelUsuFam''. El valor de la clave duplicada es (6, 3).
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteScalar()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 280
   en ARTEC.DAL.DALUsuario.UsuarioAgregarFamilia(Familia unaFamilia, Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 259
   en ARTEC.DAL.DALUsuario.UsuarioAgregarPermisos(List`1 PerAgregar, Int32 IdUsuario) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALUsuario.cs:línea 235
   en ARTEC.BLL.BLLUsuario.UsuarioModificar(Usuario UsModif, List`1 PerAgregar, List`1 PerQuitar, Usuario unUsuarioDVH) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLUsuario.cs:línea 353
   en ARTEC.GUI.frmUsuariosModificar.btnModifUsuario_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmUsuariosModificar.cs:línea 311')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3383, 1, N'pargi', CAST(0x0000A92500E45B33 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3384, 1, N'pargi', CAST(0x0000A92500F91CAA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3385, 1, N'pargi', CAST(0x0000A925010896B1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3386, 1, N'pargi', CAST(0x0000A9250167992C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3387, 1, N'pargi', CAST(0x0000A92501687D3C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3388, 1, N'pargi', CAST(0x0000A92501699F4E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3389, 1, N'pargi', CAST(0x0000A925016AD18E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3390, 1, N'pargi', CAST(0x0000A925016BE548 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3391, 1, N'pargi', CAST(0x0000A925016C68FC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3392, 1, N'pargi', CAST(0x0000A925016D365F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3393, 1, N'pargi', CAST(0x0000A9250180BE94 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3394, 1, N'pargi', CAST(0x0000A92501830544 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3395, 1, N'pargi', CAST(0x0000A9250184D11D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3396, 1, N'pargi', CAST(0x0000A92501853207 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3397, 1, N'pargi', CAST(0x0000A9250187728C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3398, 1, N'pargi', CAST(0x0000A9250188B74C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3399, 1, N'pargi', CAST(0x0000A925018901B7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3400, 1, N'pargi', CAST(0x0000A9250189FFE1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3401, 1, N'pargi', CAST(0x0000A925018A669A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3402, 1, N'pargi', CAST(0x0000A9260000BC59 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3403, 1, N'pargi', CAST(0x0000A926000707CC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3404, 1, N'pargi', CAST(0x0000A9260007A0DB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3405, 1, N'pargi', CAST(0x0000A926011525E5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3406, 1, N'pargi', CAST(0x0000A926011962CB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3407, 1, N'pargi', CAST(0x0000A9260119D56C AS DateTime), N'Error', N'btnModifSolicitud_Click', N'
SqlTransaction se completó; ya no se puede utilizar.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlTransaction.ZombieCheck()
   en System.Data.SqlClient.SqlTransaction.Rollback()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 106
   en ARTEC.DAL.DALSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALSolicitud.cs:línea 438
   en ARTEC.BLL.BLLSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLSolicitud.cs:línea 87
   en ARTEC.GUI.frmSolicitudModificar.btnModifSolicitud_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmSolicitudModificar.cs:línea 1251')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3408, 1, N'pargi', CAST(0x0000A926011A1698 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3409, 1, N'pargi', CAST(0x0000A926011C0347 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3410, 1, N'pargi', CAST(0x0000A926011E47E9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3411, 1, N'pargi', CAST(0x0000A926012EA033 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3412, 1, N'pargi', CAST(0x0000A926012EB76D AS DateTime), N'Error', N'btnModifSolicitud_Click', N'
Instrucción DELETE en conflicto con la restricción REFERENCE "FK_PartidaDetalle_SolicDetalle". El conflicto ha aparecido en la base de datos "Artec", tabla "dbo.PartidaDetalle".
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 316
   en ARTEC.DAL.DALSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALSolicitud.cs:línea 439
   en ARTEC.BLL.BLLSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLSolicitud.cs:línea 87
   en ARTEC.GUI.frmSolicitudModificar.btnModifSolicitud_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmSolicitudModificar.cs:línea 1251')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3413, 1, N'pargi', CAST(0x0000A926012F2087 AS DateTime), N'Error', N'btnModifSolicitud_Click', N'
Instrucción DELETE en conflicto con la restricción REFERENCE "FK_PartidaDetalle_SolicDetalle". El conflicto ha aparecido en la base de datos "Artec", tabla "dbo.PartidaDetalle".
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 316
   en ARTEC.DAL.DALSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALSolicitud.cs:línea 439
   en ARTEC.BLL.BLLSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLSolicitud.cs:línea 87
   en ARTEC.GUI.frmSolicitudModificar.btnModifSolicitud_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmSolicitudModificar.cs:línea 1251')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3414, 1, N'pargi', CAST(0x0000A926012FE418 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3415, 1, N'pargi', CAST(0x0000A92601300D89 AS DateTime), N'Error', N'btnModifSolicitud_Click', N'
SqlTransaction se completó; ya no se puede utilizar.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlTransaction.ZombieCheck()
   en System.Data.SqlClient.SqlTransaction.Rollback()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 106
   en ARTEC.DAL.DALSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALSolicitud.cs:línea 438
   en ARTEC.BLL.BLLSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLSolicitud.cs:línea 87
   en ARTEC.GUI.frmSolicitudModificar.btnModifSolicitud_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmSolicitudModificar.cs:línea 1251')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3416, 1, N'pargi', CAST(0x0000A92601302BE7 AS DateTime), N'Error', N'btnModifSolicitud_Click', N'
SqlTransaction se completó; ya no se puede utilizar.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlTransaction.ZombieCheck()
   en System.Data.SqlClient.SqlTransaction.Rollback()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 106
   en ARTEC.DAL.DALSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALSolicitud.cs:línea 438
   en ARTEC.BLL.BLLSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLSolicitud.cs:línea 87
   en ARTEC.GUI.frmSolicitudModificar.btnModifSolicitud_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmSolicitudModificar.cs:línea 1251')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3417, 1, N'pargi', CAST(0x0000A92601311070 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3418, 1, N'pargi', CAST(0x0000A928015C6745 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3419, 1, N'pargi', CAST(0x0000A928015D29EA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3420, 1, N'pargi', CAST(0x0000A928015DCD9F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3421, 1, N'pargi', CAST(0x0000A928015EA32E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3422, 1, N'pargi', CAST(0x0000A928015ED2A0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3423, 1, N'pargi', CAST(0x0000A92900FBA6CB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3424, 1, N'pargi', CAST(0x0000A92901079680 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3425, 1, N'pargi', CAST(0x0000A9290108D144 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3426, 1, N'pargi', CAST(0x0000A9290109091B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3427, 1, N'pargi', CAST(0x0000A929010CA5BF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3428, 1, N'pargi', CAST(0x0000A929014ED106 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3429, 1, N'pargi', CAST(0x0000A92901505665 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3430, 1, N'pargi', CAST(0x0000A929015FB6D9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3431, 1, N'pargi', CAST(0x0000A92A00AA4905 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3432, 1, N'pargi', CAST(0x0000A92A00C24D2E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3433, 1, N'pargi', CAST(0x0000A92A00C28260 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3434, 0, N'SIN_USUARIO', CAST(0x0000A92A00CBE37F AS DateTime), N'Evento', N'Restaurar BD', N'Restauración realizada correctamente')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3435, 1, N'pargi', CAST(0x0000A92A00CCFAC1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3436, 1, N'pargi', CAST(0x0000A92A00D4A81C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3437, 2, N'lola', CAST(0x0000A92A00D4FB61 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3438, 2, N'lola', CAST(0x0000A92A00D7746C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3439, 2, N'lola', CAST(0x0000A92A00D7859C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3440, 2, N'lola', CAST(0x0000A92A00D8775F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3441, 2, N'lola', CAST(0x0000A92A00D9ACEB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3442, 2, N'lola', CAST(0x0000A92A00D9F487 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3443, 2, N'lola', CAST(0x0000A92A00DA4F31 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3444, 2, N'lola', CAST(0x0000A92A00DA88BC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3445, 0, N'SIN_USUARIO', CAST(0x0000A92A00DB2969 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3446, 1, N'pargi', CAST(0x0000A92A00DB2D66 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3447, 2, N'lola', CAST(0x0000A92A00DBEBBE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3448, 1, N'pargi', CAST(0x0000A92A00DC181C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3449, 1, N'pargi', CAST(0x0000A92A00DC3355 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3450, 0, N'SIN_USUARIO', CAST(0x0000A92A00E62B45 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3451, 2, N'lola', CAST(0x0000A92A00E6310C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3452, 2, N'lola', CAST(0x0000A92A00E77198 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3453, 2, N'lola', CAST(0x0000A92A00E787E1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3454, 2, N'lola', CAST(0x0000A92A00F4A950 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3455, 2, N'lola', CAST(0x0000A92A00F6470B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3456, 2, N'lola', CAST(0x0000A92A00F7F5CC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3457, 1, N'pargi', CAST(0x0000A92A00F8A875 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3458, 1, N'pargi', CAST(0x0000A92A00FED2D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3459, 1, N'pargi', CAST(0x0000A92D010F718A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3460, 1, N'pargi', CAST(0x0000A92D014E3820 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3461, 1, N'pargi', CAST(0x0000A92D0150CEEE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3462, 1, N'pargi', CAST(0x0000A92D016DF4FA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3463, 1, N'pargi', CAST(0x0000A92E015F7CC8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3464, 1, N'pargi', CAST(0x0000A92F0008DFDF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3465, 1, N'pargi', CAST(0x0000A92F0011036F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3466, 1, N'pargi', CAST(0x0000A92F0011D58B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3467, 1, N'pargi', CAST(0x0000A92F0132062E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3468, 1, N'pargi', CAST(0x0000A92F01379A48 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3469, 1, N'pargi', CAST(0x0000A92F0138C2ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3470, 1, N'pargi', CAST(0x0000A92F013C6C44 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3471, 1, N'pargi', CAST(0x0000A92F013ED033 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3472, 1, N'pargi', CAST(0x0000A92F013EE150 AS DateTime), N'Error', N'btnModifSolicitud_Click', N'
Instrucción DELETE en conflicto con la restricción REFERENCE "FK_PartidaDetalle_SolicDetalle". El conflicto ha aparecido en la base de datos "Artec", tabla "dbo.PartidaDetalle".
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 316
   en ARTEC.DAL.DALSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALSolicitud.cs:línea 439
   en ARTEC.BLL.BLLSolicitud.SolicitudModificarConDetallesEliminados(Solicitud laSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLSolicitud.cs:línea 87
   en ARTEC.GUI.frmSolicitudModificar.btnModifSolicitud_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmSolicitudModificar.cs:línea 1251')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3473, 1, N'pargi', CAST(0x0000A92F014589BA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3474, 1, N'pargi', CAST(0x0000A93001720AF4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3475, 1, N'pargi', CAST(0x0000A931012B29A3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3476, 1, N'pargi', CAST(0x0000A93101309925 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3477, 1, N'pargi', CAST(0x0000A93101314DBC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3478, 1, N'pargi', CAST(0x0000A9310131D077 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3479, 1, N'pargi', CAST(0x0000A931014C7DF1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3480, 1, N'pargi', CAST(0x0000A931014F3975 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3481, 1, N'pargi', CAST(0x0000A9310150096F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3482, 1, N'pargi', CAST(0x0000A9310151DBF6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3483, 1, N'pargi', CAST(0x0000A9310154BC77 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3484, 1, N'pargi', CAST(0x0000A93101755E07 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3485, 1, N'pargi', CAST(0x0000A9310175A462 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3486, 1, N'pargi', CAST(0x0000A93101761B6C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3487, 1, N'pargi', CAST(0x0000A93101810872 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3488, 1, N'pargi', CAST(0x0000A93101830E98 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3489, 1, N'pargi', CAST(0x0000A9310183C01E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3490, 1, N'pargi', CAST(0x0000A931018622FE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3491, 1, N'pargi', CAST(0x0000A9310186AAAF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3492, 1, N'pargi', CAST(0x0000A93101875F7B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3493, 1, N'pargi', CAST(0x0000A9310187AB4F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3494, 1, N'pargi', CAST(0x0000A93200093CDF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3495, 1, N'pargi', CAST(0x0000A9320143B8FC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3496, 1, N'pargi', CAST(0x0000A93201499946 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3497, 1, N'pargi', CAST(0x0000A932014D4566 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3498, 1, N'pargi', CAST(0x0000A93201551C1F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3499, 1, N'pargi', CAST(0x0000A9320155DB42 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3500, 1, N'pargi', CAST(0x0000A9320157AD46 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3501, 1, N'pargi', CAST(0x0000A93201580B14 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3502, 1, N'pargi', CAST(0x0000A9320159B28B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3503, 1, N'pargi', CAST(0x0000A93300D67B7B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3504, 1, N'pargi', CAST(0x0000A93300DD0617 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3505, 0, N'SIN_USUARIO', CAST(0x0000A93300E02F1D AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3506, 1, N'pargi', CAST(0x0000A93300E03166 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3507, 1, N'pargi', CAST(0x0000A93300E0BD5F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3508, 1, N'pargi', CAST(0x0000A93300E108BF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3509, 1, N'pargi', CAST(0x0000A93300E1B659 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3510, 1, N'pargi', CAST(0x0000A93301283016 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3511, 1, N'pargi', CAST(0x0000A9330132E735 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3512, 1, N'pargi', CAST(0x0000A9330133655D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3513, 1, N'pargi', CAST(0x0000A93301353788 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3514, 1, N'pargi', CAST(0x0000A933013E6A3A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3515, 1, N'pargi', CAST(0x0000A933013EC66D AS DateTime), N'Error', N'frmDependenciaCrear - btnCrear_Click', N'
No se encontró el procedimiento almacenado ''DependenciaCrear''.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   en System.Data.SqlClient.SqlDataReader.get_MetaData()
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   en System.Data.SqlClient.SqlCommand.ExecuteScalar()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 298
   en ARTEC.DAL.DALDependencia.DependenciaCrear(Dependencia nuevaDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALDependencia.cs:línea 416
   en ARTEC.BLL.BLLDependencia.DependenciaCrear(Dependencia nuevaDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLDependencia.cs:línea 95
   en ARTEC.GUI.frmDependenciaCrear.btnCrear_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmDependenciaCrear.cs:línea 82')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3516, 1, N'pargi', CAST(0x0000A933013FCDF9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3517, 1, N'pargi', CAST(0x0000A93301418BD3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3518, 1, N'pargi', CAST(0x0000A93301464B09 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3519, 1, N'pargi', CAST(0x0000A933014BE86E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3520, 1, N'pargi', CAST(0x0000A933016482ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3521, 1, N'pargi', CAST(0x0000A93301668EBA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3522, 1, N'pargi', CAST(0x0000A93301675AC6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3523, 1, N'pargi', CAST(0x0000A93301677EAA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3524, 1, N'pargi', CAST(0x0000A9330167C5A8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3525, 1, N'pargi', CAST(0x0000A9330168A06E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3526, 1, N'pargi', CAST(0x0000A9330169062E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3527, 1, N'pargi', CAST(0x0000A933016CB2CE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3528, 1, N'pargi', CAST(0x0000A9340007FFD9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3529, 1, N'pargi', CAST(0x0000A9340127FFEE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3530, 1, N'pargi', CAST(0x0000A934012972C7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3531, 1, N'pargi', CAST(0x0000A934012C55ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3532, 1, N'pargi', CAST(0x0000A934012C9B88 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3533, 1, N'pargi', CAST(0x0000A934012E0F10 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3534, 1, N'pargi', CAST(0x0000A9340144C44E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3535, 1, N'pargi', CAST(0x0000A93401459301 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3536, 1, N'pargi', CAST(0x0000A934015894DF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3537, 1, N'pargi', CAST(0x0000A9340158A613 AS DateTime), N'Error', N'frmAgentesGestion - btnBuscar_Click', N'
El DataBinding complejo acepta como origen de datos IList o IListSource.
Archivo: 
Linea: 0
   en System.Windows.Forms.ListControl.set_DataSource(Object value)
   en System.Windows.Forms.ComboBox.set_DataSource(Object value)
   en ARTEC.GUI.frmAgentesGestion.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs:línea 51')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3538, 1, N'pargi', CAST(0x0000A9340159BD93 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3539, 1, N'pargi', CAST(0x0000A9340159D021 AS DateTime), N'Error', N'frmAgentesGestion - btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs
Linea: 47
   en ARTEC.GUI.frmAgentesGestion.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3540, 1, N'pargi', CAST(0x0000A934015A5B09 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3541, 1, N'pargi', CAST(0x0000A934015A6DB4 AS DateTime), N'Error', N'frmAgentesGestion - btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs
Linea: 47
   en ARTEC.GUI.frmAgentesGestion.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3542, 1, N'pargi', CAST(0x0000A934015B4A08 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3543, 1, N'pargi', CAST(0x0000A934015DAC5F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3544, 1, N'pargi', CAST(0x0000A934015DBCA5 AS DateTime), N'Error', N'frmAgentesGestion - btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs
Linea: 47
   en ARTEC.GUI.frmAgentesGestion.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAgentesGestion.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3545, 1, N'pargi', CAST(0x0000A934015E0EF4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3546, 1, N'pargi', CAST(0x0000A934015EC159 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3547, 1, N'pargi', CAST(0x0000A934015FE560 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3548, 1, N'pargi', CAST(0x0000A9340160C653 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3549, 1, N'pargi', CAST(0x0000A9340161D8BA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3550, 1, N'pargi', CAST(0x0000A934016264FD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3551, 1, N'pargi', CAST(0x0000A934016583D2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3552, 1, N'pargi', CAST(0x0000A9340166AD7E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3553, 1, N'pargi', CAST(0x0000A93401681591 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3554, 1, N'pargi', CAST(0x0000A934016877C1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3555, 1, N'pargi', CAST(0x0000A9350152883E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3556, 1, N'pargi', CAST(0x0000A93501564CF8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3557, 1, N'pargi', CAST(0x0000A93501566A1F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3558, 1, N'pargi', CAST(0x0000A936013BB695 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3559, 1, N'pargi', CAST(0x0000A936013C0FE1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3560, 1, N'pargi', CAST(0x0000A936014328ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3561, 1, N'pargi', CAST(0x0000A936014543E4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3562, 1, N'pargi', CAST(0x0000A9360147DC67 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3563, 1, N'pargi', CAST(0x0000A9360148C013 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3564, 1, N'pargi', CAST(0x0000A936014F00DD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3565, 1, N'pargi', CAST(0x0000A936015B0E02 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3566, 1, N'pargi', CAST(0x0000A936015BFD7D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3567, 1, N'pargi', CAST(0x0000A936015CB8F7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3568, 1, N'pargi', CAST(0x0000A937016C5389 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3569, 1, N'pargi', CAST(0x0000A937017005C0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3570, 1, N'pargi', CAST(0x0000A93701736DC0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3571, 1, N'pargi', CAST(0x0000A9370174BDB0 AS DateTime), N'Error', N'frmProveedorCrear - btnCrearProveedor_Click', N'
No se puede insertar el valor NULL en la columna ''activo'', tabla ''Artec.dbo.RelProveedorTel''. La columna no admite valores NULL. Error de INSERT.
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 316
   en ARTEC.DAL.DALProveedor.ProveedorCrear(Proveedor nuevoProveedor) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALProveedor.cs:línea 243
   en ARTEC.BLL.BLLProveedor.ProveedorCrear(Proveedor nuevoProveedor) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLProveedor.cs:línea 81
   en ARTEC.GUI.frmProveedorCrear.btnCrearProveedor_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmProveedorCrear.cs:línea 425')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3572, 1, N'pargi', CAST(0x0000A93701793F2A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3573, 1, N'pargi', CAST(0x0000A9380003C842 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3574, 1, N'pargi', CAST(0x0000A9380005AFE0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3575, 1, N'pargi', CAST(0x0000A9380005F819 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3576, 1, N'pargi', CAST(0x0000A93800064D24 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3577, 1, N'pargi', CAST(0x0000A9380114121A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3578, 1, N'pargi', CAST(0x0000A9380124CEF2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3579, 1, N'pargi', CAST(0x0000A938012523D2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3580, 1, N'pargi', CAST(0x0000A9380125916B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3581, 1, N'pargi', CAST(0x0000A9380125950A AS DateTime), N'Error', N'frmProveedorCrear - ProveedorCrear_Load', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmProveedorCrear.cs
Linea: 616
   en ARTEC.GUI.frmProveedorCrear.FormatearGrillaCategorias() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmProveedorCrear.cs:línea 616
   en ARTEC.GUI.frmProveedorCrear.ProveedorCrear_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmProveedorCrear.cs:línea 66')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3582, 1, N'pargi', CAST(0x0000A93801520DE0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3583, 1, N'pargi', CAST(0x0000A938015323F4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3584, 1, N'pargi', CAST(0x0000A93801561505 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3585, 1, N'pargi', CAST(0x0000A93801571A9C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3586, 1, N'pargi', CAST(0x0000A9380157AD2F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3587, 1, N'pargi', CAST(0x0000A938015CEA15 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3588, 1, N'pargi', CAST(0x0000A938015E2E43 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3589, 1, N'pargi', CAST(0x0000A938015E7E69 AS DateTime), N'Error', N'frmProveedorCrear - btnModificar_Click', N'
Instrucción INSERT en conflicto con la restricción FOREIGN KEY "FK_RelProveedorTel_Telefono". El conflicto ha aparecido en la base de datos "Artec", tabla "dbo.Telefono", column ''IdTelefono''.
Se terminó la instrucción.
Archivo: 
Linea: 0
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en ARTEC.FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType ComandoTipo, String ComandoString, SqlParameter[] Parametros) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.FRAMEWORK\Persistencia\MotorBD.cs:línea 316
   en ARTEC.DAL.DALProveedor.ProveedorModificar(Proveedor unProvBuscar, List`1 CatQuitarMod, List`1 CatAgregarMod, List`1 TelQuitarMod, List`1 TelAgregarMod, List`1 DirQuitarMod, List`1 DirAgregarMod) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALProveedor.cs:línea 384
   en ARTEC.BLL.BLLProveedor.ProveedorModificar(Proveedor unProvBuscar, List`1 CatQuitarMod, List`1 CatAgregarMod, List`1 TelQuitarMod, List`1 TelAgregarMod, List`1 DirQuitarMod, List`1 DirAgregarMod) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLProveedor.cs:línea 95
   en ARTEC.GUI.frmProveedorCrear.btnModificar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmProveedorCrear.cs:línea 562')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3590, 1, N'pargi', CAST(0x0000A938015F6F1A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3591, 1, N'pargi', CAST(0x0000A93801602F0B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3592, 1, N'pargi', CAST(0x0000A93801611F5A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3593, 1, N'pargi', CAST(0x0000A93801634D43 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3594, 1, N'pargi', CAST(0x0000A93A000B4D35 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3595, 1, N'pargi', CAST(0x0000A93A000D743A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3596, 1, N'pargi', CAST(0x0000A93A000E2EC1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3597, 1, N'pargi', CAST(0x0000A93B015A49DA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3598, 1, N'pargi', CAST(0x0000A93B015B53C0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3599, 1, N'pargi', CAST(0x0000A93B015B5E9D AS DateTime), N'Error', N'frmFamiliaGestion - frmFamiliaGestion_Load', N'
No se puede enlazar con el nuevo miembro de presentación.
Nombre del parámetro: newDisplayMember
Archivo: 
Linea: 0
   en System.Windows.Forms.ListControl.SetDataConnection(Object newDataSource, BindingMemberInfo newDisplayMember, Boolean force)
   en System.Windows.Forms.ListControl.set_ValueMember(String value)
   en ARTEC.GUI.frmFamiliaGestion.frmFamiliaGestion_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmFamiliaGestion.cs:línea 37')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3600, 1, N'pargi', CAST(0x0000A93B015BC2F5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3601, 1, N'pargi', CAST(0x0000A93B015BF311 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3602, 1, N'pargi', CAST(0x0000A93B01652E88 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3603, 1, N'pargi', CAST(0x0000A93B01654985 AS DateTime), N'Error', N'FamiliaTraerSubPermisos', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs
Linea: 20
   en ARTEC.DAL.Servicios.DALFamilia.FamiliaTraerFamiliasHijas(IFamPat unaFamilia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\Servicios\DALFamilia.cs:línea 20
   en ARTEC.BLL.Servicios.BLLFamilia.FamiliaTraerSubPermisos(List`1 unasFamilias) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\Servicios\BLLFamilia.cs:línea 23')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3604, 1, N'pargi', CAST(0x0000A93C013AC60A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3605, 1, N'pargi', CAST(0x0000A93C014B429D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3606, 1, N'pargi', CAST(0x0000A93C014B9AB7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3607, 1, N'pargi', CAST(0x0000A93C014C4D11 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3608, 1, N'pargi', CAST(0x0000A93C014F70D9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3609, 1, N'pargi', CAST(0x0000A93C0151977F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3610, 1, N'pargi', CAST(0x0000A93C01579AB3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3611, 1, N'pargi', CAST(0x0000A93C016E2E04 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3612, 1, N'pargi', CAST(0x0000A93C016E96B7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3613, 1, N'pargi', CAST(0x0000A93C017FFE9F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3614, 1, N'pargi', CAST(0x0000A93C018165D5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3615, 1, N'pargi', CAST(0x0000A93D0116BB5E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3616, 1, N'pargi', CAST(0x0000A93D01174AB7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3617, 1, N'pargi', CAST(0x0000A93D011BA582 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3618, 1, N'pargi', CAST(0x0000A93D011D23DC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3619, 1, N'pargi', CAST(0x0000A93D011F7CDC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3620, 1, N'pargi', CAST(0x0000A93D011FCCE6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3621, 1, N'pargi', CAST(0x0000A93D012099DB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3622, 1, N'pargi', CAST(0x0000A93D0121764E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3623, 1, N'pargi', CAST(0x0000A93D0121F7BA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3624, 1, N'pargi', CAST(0x0000A93D0124347C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3625, 1, N'pargi', CAST(0x0000A93D0142ECDC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3626, 1, N'pargi', CAST(0x0000A93D014387C6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3627, 1, N'pargi', CAST(0x0000A93D0144222D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3628, 1, N'pargi', CAST(0x0000A93D0146294D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3629, 1, N'pargi', CAST(0x0000A93D014775F7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3630, 1, N'pargi', CAST(0x0000A93D01477DA1 AS DateTime), N'Error', N'frmFamiliaGestion - frmFamiliaGestion_Load', N'
No se puede modificar la colección Items cuando está establecida la propiedad DataSource.
Archivo: 
Linea: 0
   en System.Windows.Forms.ComboBox.CheckNoDataSource()
   en System.Windows.Forms.ComboBox.ObjectCollection.Add(Object item)
   en ARTEC.GUI.frmFamiliaGestion.frmFamiliaGestion_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmFamiliaGestion.cs:línea 44')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3631, 1, N'pargi', CAST(0x0000A93D01487B25 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3632, 1, N'pargi', CAST(0x0000A93D0148E019 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3633, 1, N'pargi', CAST(0x0000A93D01537E5B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3634, 1, N'pargi', CAST(0x0000A93D0156885F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3635, 1, N'pargi', CAST(0x0000A93D01574EB5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3636, 1, N'pargi', CAST(0x0000A93D0158CBDE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3637, 1, N'pargi', CAST(0x0000A93D015A3CBB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3638, 1, N'pargi', CAST(0x0000A93D015BD32A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3639, 1, N'pargi', CAST(0x0000A93D015F4466 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3640, 1, N'pargi', CAST(0x0000A93D015F65F4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3641, 0, N'SIN_USUARIO', CAST(0x0000A93D015F9135 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3642, 1, N'pargi', CAST(0x0000A93D015F95F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3643, 1, N'pargi', CAST(0x0000A93D0160283C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3644, 1, N'pargi', CAST(0x0000A93D016049BD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3645, 1, N'pargi', CAST(0x0000A93D0161C859 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3646, 1, N'pargi', CAST(0x0000A93F0002D217 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3647, 1, N'pargi', CAST(0x0000A93F015CDD06 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3648, 1, N'pargi', CAST(0x0000A93F015CF9CF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3649, 1, N'pargi', CAST(0x0000A93F015D852C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3650, 1, N'pargi', CAST(0x0000A93F015DB63A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3651, 1, N'pargi', CAST(0x0000A93F015EA4D3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3652, 1, N'pargi', CAST(0x0000A93F01610BF1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3653, 1, N'pargi', CAST(0x0000A93F0161A5E1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3654, 1, N'pargi', CAST(0x0000A93F01679651 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3655, 1, N'pargi', CAST(0x0000A93F0167DC0B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3656, 1, N'pargi', CAST(0x0000A93F016B14A1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3657, 1, N'pargi', CAST(0x0000A93F016B856F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3658, 1, N'pargi', CAST(0x0000A93F01725FDB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3659, 1, N'pargi', CAST(0x0000A93F0172770A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3660, 1, N'pargi', CAST(0x0000A93F0174A763 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3661, 1, N'pargi', CAST(0x0000A93F0175BEC3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3662, 1, N'pargi', CAST(0x0000A93F017BFB61 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3663, 1, N'pargi', CAST(0x0000A93F017C146C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3664, 1, N'pargi', CAST(0x0000A93F017D287C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3665, 1, N'pargi', CAST(0x0000A93F0181E50E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3666, 1, N'pargi', CAST(0x0000A93F0182C274 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3667, 1, N'pargi', CAST(0x0000A93F0183336B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3668, 1, N'pargi', CAST(0x0000A93F01840746 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3669, 1, N'pargi', CAST(0x0000A93F018608FB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3670, 1, N'pargi', CAST(0x0000A94001422B3D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3671, 1, N'pargi', CAST(0x0000A94001426643 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3672, 1, N'pargi', CAST(0x0000A9400144518D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3673, 1, N'pargi', CAST(0x0000A9400144B7A0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3674, 1, N'pargi', CAST(0x0000A940014527B4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3675, 1, N'pargi', CAST(0x0000A94001476482 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3676, 1, N'pargi', CAST(0x0000A9400147930D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3677, 1, N'pargi', CAST(0x0000A940014BB397 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3678, 1, N'pargi', CAST(0x0000A94001507514 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3679, 1, N'pargi', CAST(0x0000A9400150E7A3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3680, 1, N'pargi', CAST(0x0000A940015240A7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3681, 1, N'pargi', CAST(0x0000A94001529A10 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3682, 1, N'pargi', CAST(0x0000A94001534CC2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3683, 1, N'pargi', CAST(0x0000A94001538293 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3684, 1, N'pargi', CAST(0x0000A9400153CA94 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3685, 1, N'pargi', CAST(0x0000A94001572806 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3686, 1, N'pargi', CAST(0x0000A940015755DE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3687, 1, N'pargi', CAST(0x0000A940015D512C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3688, 1, N'pargi', CAST(0x0000A94100D77A69 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3689, 1, N'pargi', CAST(0x0000A94100D9CE62 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3690, 1, N'pargi', CAST(0x0000A94100DB2CEA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3691, 1, N'pargi', CAST(0x0000A94100DBBDC1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3692, 1, N'pargi', CAST(0x0000A94100DC8A00 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3693, 1, N'pargi', CAST(0x0000A94100DCDAA0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3694, 1, N'pargi', CAST(0x0000A94100DD875F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3695, 1, N'pargi', CAST(0x0000A941017537B7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3696, 1, N'pargi', CAST(0x0000A941017BAB5D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3697, 1, N'pargi', CAST(0x0000A942000B6CD2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3698, 1, N'pargi', CAST(0x0000A942000BC5B5 AS DateTime), N'Error', N'frmFamiliaGestion - btnEliminar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmFamiliaGestion.cs
Linea: 323
   en ARTEC.GUI.frmFamiliaGestion.btnEliminar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmFamiliaGestion.cs:línea 323')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3699, 1, N'pargi', CAST(0x0000A942000C05F3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3700, 1, N'pargi', CAST(0x0000A942000CE516 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3701, 1, N'pargi', CAST(0x0000A942000D62F0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3702, 1, N'pargi', CAST(0x0000A942000DC398 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3703, 1, N'pargi', CAST(0x0000A942001A62FF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3704, 1, N'pargi', CAST(0x0000A94200E9BF82 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3705, 1, N'pargi', CAST(0x0000A94200ED8ACA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3706, 1, N'pargi', CAST(0x0000A94200ED9456 AS DateTime), N'Error', N'frmFamiliaGestion - btnEliminar_Click', N'
El DataBinding complejo acepta como origen de datos IList o IListSource.
Archivo: 
Linea: 0
   en System.Windows.Forms.ListControl.set_DataSource(Object value)
   en System.Windows.Forms.ComboBox.set_DataSource(Object value)
   en ARTEC.GUI.frmFamiliaGestion.btnEliminar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmFamiliaGestion.cs:línea 340')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3707, 1, N'pargi', CAST(0x0000A94200EDF192 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3708, 1, N'pargi', CAST(0x0000A94200EE172B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3709, 1, N'pargi', CAST(0x0000A94200EEA0C5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3710, 1, N'pargi', CAST(0x0000A9420112E0AA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3711, 1, N'pargi', CAST(0x0000A942011B6F38 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3712, 1, N'pargi', CAST(0x0000A942011D831C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3713, 1, N'pargi', CAST(0x0000A9420120400A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3714, 1, N'pargi', CAST(0x0000A9420122BF89 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3715, 1, N'pargi', CAST(0x0000A9420123ECAF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3716, 1, N'pargi', CAST(0x0000A9420125132F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3717, 1, N'pargi', CAST(0x0000A944010B185D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3718, 1, N'pargi', CAST(0x0000A944010B9A32 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3719, 1, N'pargi', CAST(0x0000A944010DF9CD AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3720, 1, N'pargi', CAST(0x0000A944010E789F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3721, 1, N'pargi', CAST(0x0000A944011A575E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3722, 1, N'pargi', CAST(0x0000A944011B0017 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3723, 1, N'pargi', CAST(0x0000A944011E7179 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3724, 1, N'pargi', CAST(0x0000A94401264F3B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3725, 1, N'pargi', CAST(0x0000A944012EF569 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3726, 1, N'pargi', CAST(0x0000A944012FD3F2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3727, 1, N'pargi', CAST(0x0000A94500C65246 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3728, 1, N'pargi', CAST(0x0000A94500C7534B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3729, 1, N'pargi', CAST(0x0000A94500C7FF4E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3730, 1, N'pargi', CAST(0x0000A94500C87EF1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3731, 1, N'pargi', CAST(0x0000A94500C9337D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3732, 1, N'pargi', CAST(0x0000A94500C98035 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3733, 1, N'pargi', CAST(0x0000A94500D67320 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3734, 1, N'pargi', CAST(0x0000A94500D746DE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3735, 1, N'pargi', CAST(0x0000A94500DB49C8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3736, 1, N'pargi', CAST(0x0000A94500DD0D8E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3737, 1, N'pargi', CAST(0x0000A94500EA7556 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3738, 1, N'pargi', CAST(0x0000A94500EC593D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3739, 2, N'lola', CAST(0x0000A94500F11AB3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3740, 1, N'pargi', CAST(0x0000A94500F1685E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3741, 2, N'lola', CAST(0x0000A94500F1A501 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3742, 1, N'pargi', CAST(0x0000A94500F1B472 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3743, 1, N'pargi', CAST(0x0000A9450105B07B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3744, 2, N'lola', CAST(0x0000A945010769D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3745, 1, N'pargi', CAST(0x0000A94501077E68 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3746, 2, N'lola', CAST(0x0000A9450107917E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3747, 1, N'pargi', CAST(0x0000A9450107B343 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3748, 2, N'lola', CAST(0x0000A9450108BA9E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3749, 1, N'pargi', CAST(0x0000A9450108C87A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3750, 1, N'pargi', CAST(0x0000A9450108D339 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3751, 2, N'lola', CAST(0x0000A9450108E3A9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3752, 1, N'pargi', CAST(0x0000A9450108F3DB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3753, 2, N'lola', CAST(0x0000A945010A1F27 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3754, 1, N'pargi', CAST(0x0000A945010A2D67 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3755, 1, N'pargi', CAST(0x0000A945010A44D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3756, 1, N'pargi', CAST(0x0000A945010A53FE AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3757, 1, N'pargi', CAST(0x0000A945010B6E60 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3758, 1, N'pargi', CAST(0x0000A945010E7CA2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3759, 2, N'lola', CAST(0x0000A945010EBB64 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3760, 1, N'pargi', CAST(0x0000A945010EC8B3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3761, 1, N'pargi', CAST(0x0000A945010EF75D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3762, 1, N'pargi', CAST(0x0000A945010F0C46 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3763, 1, N'pargi', CAST(0x0000A9450112015E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3764, 2, N'lola', CAST(0x0000A94501136D37 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3765, 2, N'lola', CAST(0x0000A945011519B7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3766, 2, N'lola', CAST(0x0000A94501157F0A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3767, 0, N'SIN_USUARIO', CAST(0x0000A94501158BB4 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3768, 0, N'SIN_USUARIO', CAST(0x0000A9450115912E AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3769, 0, N'SIN_USUARIO', CAST(0x0000A94501159A38 AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3770, 2, N'lola', CAST(0x0000A945011631E9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3771, 2, N'lola', CAST(0x0000A9450117D564 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3772, 1, N'pargi', CAST(0x0000A9450117DF56 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3773, 2, N'lola', CAST(0x0000A945011AE5C6 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3774, 0, N'SIN_USUARIO', CAST(0x0000A945011AF41B AS DateTime), N'Evento', N'Login', N'Ingreso Incorrecto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3775, 2, N'lola', CAST(0x0000A945011AF8ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3776, 1, N'pargi', CAST(0x0000A945011B1015 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3777, 1, N'pargi', CAST(0x0000A946016EE35B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3778, 1, N'pargi', CAST(0x0000A946017075CF AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3779, 1, N'pargi', CAST(0x0000A94601720143 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3780, 1, N'pargi', CAST(0x0000A94601742AA3 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3781, 1, N'pargi', CAST(0x0000A946017C3EEB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3782, 1, N'pargi', CAST(0x0000A9470005FCA8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3783, 1, N'pargi', CAST(0x0000A947012DF5E9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3784, 1, N'pargi', CAST(0x0000A948012DD854 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3785, 1, N'pargi', CAST(0x0000A948012E739C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3786, 1, N'pargi', CAST(0x0000A94900045E13 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3787, 1, N'pargi', CAST(0x0000A9490004711F AS DateTime), N'Error', N'frmRendicionBuscar - btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.frmRendicionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3788, 1, N'pargi', CAST(0x0000A94900047B6A AS DateTime), N'Error', N'frmRendicionBuscar - btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.frmRendicionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3789, 1, N'pargi', CAST(0x0000A94900066351 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3790, 1, N'pargi', CAST(0x0000A94900066BA3 AS DateTime), N'Error', N'frmRendicionBuscar - btnBuscar_Click', N'
La columna ''IdAdquisicion'' no pertenece a la tabla tResultado.
Archivo: 
Linea: 0
   en System.Data.DataRow.GetDataColumn(String columnName)
   en System.Data.DataRow.get_Item(String columnName)
   en ARTEC.DAL.DALRendicion.MapearUnasRendiciones(DataSet ds) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs:línea 260
   en ARTEC.DAL.DALRendicion.RendicionBuscar(String IdRendicion, String IdPartida, String IdSolicitud, String NombreDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs:línea 212
   en ARTEC.BLL.BLLRendicion.RendicionBuscar(String IdRendicion, String IdPartida, String IdSolicitud, String NombreDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLRendicion.cs:línea 50
   en ARTEC.GUI.frmRendicionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3791, 1, N'pargi', CAST(0x0000A94900071A6B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3792, 1, N'pargi', CAST(0x0000A949014C144D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3793, 1, N'pargi', CAST(0x0000A949014C23B6 AS DateTime), N'Error', N'frmRendicionBuscar - btnBuscar_Click', N'
La conversión especificada no es válida.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs
Linea: 238
   en ARTEC.DAL.DALRendicion.MapearUnasRendiciones(DataSet ds) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs:línea 238
   en ARTEC.DAL.DALRendicion.RendicionBuscar(String IdRendicion, String IdPartida, String IdSolicitud, String NombreDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs:línea 212
   en ARTEC.BLL.BLLRendicion.RendicionBuscar(String IdRendicion, String IdPartida, String IdSolicitud, String NombreDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLRendicion.cs:línea 50
   en ARTEC.GUI.frmRendicionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3794, 1, N'pargi', CAST(0x0000A949014CE421 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3795, 1, N'pargi', CAST(0x0000A949014CEB7B AS DateTime), N'Error', N'frmRendicionBuscar - btnBuscar_Click', N'
La conversión especificada no es válida.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs
Linea: 238
   en ARTEC.DAL.DALRendicion.MapearUnasRendiciones(DataSet ds) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs:línea 238
   en ARTEC.DAL.DALRendicion.RendicionBuscar(String IdRendicion, String IdPartida, String IdSolicitud, String NombreDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALRendicion.cs:línea 212
   en ARTEC.BLL.BLLRendicion.RendicionBuscar(String IdRendicion, String IdPartida, String IdSolicitud, String NombreDependencia) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLRendicion.cs:línea 50
   en ARTEC.GUI.frmRendicionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 47')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3796, 1, N'pargi', CAST(0x0000A949014D2AB8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3797, 1, N'pargi', CAST(0x0000A949015E579D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
GO
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3798, 1, N'pargi', CAST(0x0000A9490160BA13 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3799, 1, N'pargi', CAST(0x0000A94901644477 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3800, 1, N'pargi', CAST(0x0000A94901644D18 AS DateTime), N'Error', N'frmRendicionBuscar - btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs
Linea: 205
   en ARTEC.GUI.frmRendicionBuscar.FormatearGrillaRendicionBuscar() en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 205
   en ARTEC.GUI.frmRendicionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionBuscar.cs:línea 151')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3801, 1, N'pargi', CAST(0x0000A9490164F9C9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3802, 1, N'pargi', CAST(0x0000A9490165668E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3803, 1, N'pargi', CAST(0x0000A94901659A60 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3804, 1, N'pargi', CAST(0x0000A9490167CB27 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3805, 1, N'pargi', CAST(0x0000A9490168231A AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3806, 1, N'pargi', CAST(0x0000A94F015A905E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3807, 1, N'pargi', CAST(0x0000A94F015ADF9E AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3808, 1, N'pargi', CAST(0x0000A94F015B3F30 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3809, 1, N'pargi', CAST(0x0000A94F015BEF09 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3810, 1, N'pargi', CAST(0x0000A94F015CC0AB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3811, 1, N'pargi', CAST(0x0000A9500155A3F1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3812, 1, N'pargi', CAST(0x0000A950015C6B63 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3813, 1, N'pargi', CAST(0x0000A950015C75F9 AS DateTime), N'Error', N'frmRendicionModif - frmRendicionModif_Load', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.GUI.frmRendicionModif.frmRendicionModif_Load(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmRendicionModif.cs:línea 56')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3814, 1, N'pargi', CAST(0x0000A950015CB987 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3815, 1, N'pargi', CAST(0x0000A950015D3E2D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3816, 1, N'pargi', CAST(0x0000A950016605F2 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (3817, 1, N'pargi', CAST(0x0000A95001667B11 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4811, 1, N'pargi', CAST(0x0000A95101302FB4 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4812, 1, N'pargi', CAST(0x0000A9510139AF8B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4813, 1, N'pargi', CAST(0x0000A951013B3877 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4814, 1, N'pargi', CAST(0x0000A951016260ED AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4815, 1, N'pargi', CAST(0x0000A9510162A0C0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4816, 1, N'pargi', CAST(0x0000A951017DE67F AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4817, 1, N'pargi', CAST(0x0000A951017DF71E AS DateTime), N'Error', N'frmAsignacionBuscar - btnBuscar_Click', N'
El índice estaba fuera del intervalo. Debe ser un valor no negativo e inferior al tamaño de la colección.
Nombre del parámetro: index
Archivo: 
Linea: 0
   en System.ThrowHelper.ThrowArgumentOutOfRangeException()
   en System.Collections.Generic.List`1.get_Item(Int32 index)
   en ARTEC.DAL.DALAsignacion.MapearUnasAsignaciones(DataSet ds) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALAsignacion.cs:línea 132
   en ARTEC.DAL.DALAsignacion.AsignacionBuscar(String IdAsignacion, String NombreDependencia, String IdSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALAsignacion.cs:línea 102
   en ARTEC.BLL.BLLAsignacion.AsignacionBuscar(String IdAsignacion, String NombreDependencia, String IdSolicitud) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLAsignacion.cs:línea 52
   en ARTEC.GUI.frmAsignacionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs:línea 50')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4818, 1, N'pargi', CAST(0x0000A951017E2360 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4819, 1, N'pargi', CAST(0x0000A951017F2DB0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4820, 1, N'pargi', CAST(0x0000A9510180370B AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4821, 1, N'pargi', CAST(0x0000A95101807F17 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4822, 1, N'pargi', CAST(0x0000A95200025840 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4823, 1, N'pargi', CAST(0x0000A95200031673 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4824, 1, N'pargi', CAST(0x0000A95200048A08 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4825, 1, N'pargi', CAST(0x0000A9520004C36C AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4826, 1, N'pargi', CAST(0x0000A9520006DD4D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4827, 1, N'pargi', CAST(0x0000A95200092C14 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4828, 1, N'pargi', CAST(0x0000A952000981B8 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4829, 1, N'pargi', CAST(0x0000A952000A56FA AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4830, 1, N'pargi', CAST(0x0000A952000AE859 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4831, 1, N'pargi', CAST(0x0000A952000D2AE1 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4832, 1, N'pargi', CAST(0x0000A952000D3172 AS DateTime), N'Error', N'frmAsignacionBuscar - btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs
Linea: 70
   en ARTEC.GUI.frmAsignacionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs:línea 70')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4833, 1, N'pargi', CAST(0x0000A952000D4960 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4834, 1, N'pargi', CAST(0x0000A952000D5075 AS DateTime), N'Error', N'frmAsignacionBuscar - btnBuscar_Click', N'
Referencia a objeto no establecida como instancia de un objeto.
Archivo: d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs
Linea: 70
   en ARTEC.GUI.frmAsignacionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs:línea 70')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4835, 1, N'pargi', CAST(0x0000A952000D795D AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4836, 1, N'pargi', CAST(0x0000A952000FD4D7 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4837, 1, N'pargi', CAST(0x0000A952015252C9 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4838, 1, N'pargi', CAST(0x0000A9520152E4E9 AS DateTime), N'Error', N'frmAsignacionBuscar - btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.DAL.DALAsignacion.AsignacionBuscar(String IdAsignacion, String NombreDependencia, String IdSolicitud, Nullable`1 fechaDesde, Nullable`1 fechaHasta) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALAsignacion.cs:línea 85
   en ARTEC.BLL.BLLAsignacion.AsignacionBuscar(String IdAsignacion, String NombreDependencia, String IdSolicitud, Nullable`1 fechaDesde, Nullable`1 fechaHasta) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLAsignacion.cs:línea 52
   en ARTEC.GUI.frmAsignacionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs:línea 52')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4839, 1, N'pargi', CAST(0x0000A95201530D5F AS DateTime), N'Error', N'frmAsignacionBuscar - btnBuscar_Click', N'
La cadena de entrada no tiene el formato correcto.
Archivo: 
Linea: 0
   en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
   en System.Int32.Parse(String s)
   en ARTEC.DAL.DALAsignacion.AsignacionBuscar(String IdAsignacion, String NombreDependencia, String IdSolicitud, Nullable`1 fechaDesde, Nullable`1 fechaHasta) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.DAL\DALAsignacion.cs:línea 85
   en ARTEC.BLL.BLLAsignacion.AsignacionBuscar(String IdAsignacion, String NombreDependencia, String IdSolicitud, Nullable`1 fechaDesde, Nullable`1 fechaHasta) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.BLL\BLLAsignacion.cs:línea 52
   en ARTEC.GUI.frmAsignacionBuscar.btnBuscar_Click(Object sender, EventArgs e) en d:\DocumentosDescargas\uni\Diploma\ArtecDiploma\DiplomaSolucion\ARTEC.GUI\frmAsignacionBuscar.cs:línea 52')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4840, 1, N'pargi', CAST(0x0000A952015496E5 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4841, 1, N'pargi', CAST(0x0000A9520154C5F0 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4842, 1, N'pargi', CAST(0x0000A9520156A710 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4843, 1, N'pargi', CAST(0x0000A95201572611 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4844, 1, N'pargi', CAST(0x0000A9520158B6FC AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4845, 1, N'pargi', CAST(0x0000A952015983DB AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4846, 1, N'pargi', CAST(0x0000A9520159A898 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
INSERT [dbo].[Bitacora] ([IdBitacora], [IdUsuario], [NombreUsuario], [Fecha], [TipoLog], [Accion], [Mensaje]) VALUES (4847, 1, N'pargi', CAST(0x0000A952015A3796 AS DateTime), N'Evento', N'Login', N'Ingreso Correcto')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
SET IDENTITY_INSERT [dbo].[Cargo] ON 

INSERT [dbo].[Cargo] ([IdCargo]) VALUES (1)
INSERT [dbo].[Cargo] ([IdCargo]) VALUES (2)
INSERT [dbo].[Cargo] ([IdCargo]) VALUES (3)
INSERT [dbo].[Cargo] ([IdCargo]) VALUES (4)
SET IDENTITY_INSERT [dbo].[Cargo] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (1, N'Disco Externo 1TB', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (2, N'Notebook', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (3, N'PC', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (4, N'Ultrabook', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (5, N'Office', 2, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (6, N'Scanner de Mano', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (8, N'Office 2016 H&B', 2, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [DescripCategoria], [IdTipoBien], [Activo]) VALUES (9, N'PC Servidor', 1, 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
INSERT [dbo].[ConfigMailHost] ([Puerto], [Host], [Ssl], [Remitente], [Remps]) VALUES (587, N'smtp.gmail.com', 1, N'martinez.juan.marcos@gmail.com', N'P8U3aXl83+irljIljtFMbA==')
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
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1194, 400.0000, CAST(0x0000A83C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1195, 400.0000, CAST(0x0000A83C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1196, 400.0000, CAST(0x0000A83C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1197, 200.0000, CAST(0x0000A83C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1198, 200.0000, CAST(0x0000A83C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1199, 150.0000, CAST(0x0000A83C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1200, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1201, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1202, 600.0000, CAST(0x0000A83C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1203, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1204, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1205, 600.0000, CAST(0x0000A83C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1206, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1207, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1208, 600.0000, CAST(0x0000A83C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1209, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1210, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1211, 500.0000, CAST(0x0000A83C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1212, 500.0000, CAST(0x0000A84400000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1213, 600.0000, CAST(0x0000A84400000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1214, 700.0000, CAST(0x0000A84400000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1215, 500.0000, CAST(0x0000A84700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1216, 500.0000, CAST(0x0000A84700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1217, 500.0000, CAST(0x0000A84700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1218, 500.0000, CAST(0x0000A84700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1219, 500.0000, CAST(0x0000A84700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1220, 500.0000, CAST(0x0000A84700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1221, 500.0000, CAST(0x0000A84700000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1222, 500.0000, CAST(0x0000A84700000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1223, 600.0000, CAST(0x0000A84700000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1224, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1225, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1226, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1227, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1228, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1229, 5000.0000, CAST(0x0000A81C00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1230, 10000.0000, CAST(0x0000A92D00000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1231, 10000.0000, CAST(0x0000A92D00000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1232, 12000.0000, CAST(0x0000A92D00000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1233, 11000.0000, CAST(0x0000A93000000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1234, 11000.0000, CAST(0x0000A93000000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1235, 11000.0000, CAST(0x0000A93000000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1236, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1239, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1240, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1241, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1243, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1244, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1245, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1247, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1248, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1249, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1250, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1251, 10000.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1253, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1254, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1255, 10000.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1257, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1258, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1259, 10000.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1260, 1000.0000, CAST(0x0000A94600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1261, 1000.0000, CAST(0x0000A94600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1262, 1200.0000, CAST(0x0000A94600000000 AS DateTime), 6)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1263, 8000.0000, CAST(0x0000A94500000000 AS DateTime), 5)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1264, 9000.0000, CAST(0x0000A94500000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1265, 10000.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1266, 1000.0000, CAST(0x0000A94600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1267, 1000.0000, CAST(0x0000A94600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1268, 1200.0000, CAST(0x0000A94600000000 AS DateTime), 6)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1269, 3000.0000, CAST(0x0000A94600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1270, 3000.0000, CAST(0x0000A94600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1271, 3200.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1272, 1000.0000, CAST(0x0000A94600000000 AS DateTime), 6)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1273, 1200.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1274, 1200.0000, CAST(0x0000A94600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1275, 3000.0000, CAST(0x0000A94600000000 AS DateTime), 1)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1276, 3000.0000, CAST(0x0000A94600000000 AS DateTime), 2)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1277, 3200.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1278, 1000.0000, CAST(0x0000A94600000000 AS DateTime), 6)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1279, 1200.0000, CAST(0x0000A94600000000 AS DateTime), 3)
INSERT [dbo].[Cotizacion] ([IdCotizacion], [MontoCotizado], [FechaCotizacion], [IdProveedor]) VALUES (1280, 1200.0000, CAST(0x0000A94600000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Cotizacion] OFF
SET IDENTITY_INSERT [dbo].[Dependencia] ON 

INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (1, N'Fiscalia Nacional en lo Criminal y Correccional Nro 1', 1, 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (2, N'Fiscalia Nacional en lo Criminal y Correccional Nro 2', 1, 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (3, N'Fiscalia Nacional en lo Criminal y Correccional Nro 3', 1, 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (4, N'Fiscalia en lo Criminal de Instruccion Nro 1', 1, 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (5, N'Procuraduría Lavado de Activos', 2, 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (6, N'Fiscalía Nro 1 del Trabajo', 1, 1)
INSERT [dbo].[Dependencia] ([IdDependencia], [NombreDependencia], [IdTipoDependencia], [Activo]) VALUES (7, N'Fiscalía Nro 2 del Trabajo', 1, 0)
SET IDENTITY_INSERT [dbo].[Dependencia] OFF
SET IDENTITY_INSERT [dbo].[Deposito] ON 

INSERT [dbo].[Deposito] ([IdDeposito], [NombreDeposito], [IdDireccion]) VALUES (1, N'Informatica 3ro', 1)
SET IDENTITY_INSERT [dbo].[Deposito] OFF
SET IDENTITY_INSERT [dbo].[Direccion] ON 

INSERT [dbo].[Direccion] ([IdDireccion], [Calle], [NumeroCalle], [Localidad], [IdProvincia], [Piso]) VALUES (1, N'Belgrano', N'999', N'CABA', 1, N'3')
INSERT [dbo].[Direccion] ([IdDireccion], [Calle], [NumeroCalle], [Localidad], [IdProvincia], [Piso]) VALUES (2, N'Alem', N'1055', N'CABA', 1, N'12')
SET IDENTITY_INSERT [dbo].[Direccion] OFF
SET IDENTITY_INSERT [dbo].[DVV] ON 

INSERT [dbo].[DVV] ([IdDVV], [NombreTabla], [ClaveDVV]) VALUES (1, N'Usuario', N'B1WCQPj/Vi0wCxLRzevOJhw+FUA=')
INSERT [dbo].[DVV] ([IdDVV], [NombreTabla], [ClaveDVV]) VALUES (2, N'Solicitud', N'59rY6jPFEZU1y2nwvCVSMhPVVCM=')
SET IDENTITY_INSERT [dbo].[DVV] OFF
SET IDENTITY_INSERT [dbo].[EstadoInventario] ON 

INSERT [dbo].[EstadoInventario] ([IdEstadoInventario], [DescripEstadoInv]) VALUES (1, N'Disponible')
INSERT [dbo].[EstadoInventario] ([IdEstadoInventario], [DescripEstadoInv]) VALUES (2, N'Entregado')
SET IDENTITY_INSERT [dbo].[EstadoInventario] OFF
SET IDENTITY_INSERT [dbo].[EstadoSolicDetalle] ON 

INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (2, N'Cotizado')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (3, N'Partida')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (4, N'Comprar')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (5, N'Adquirido')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (6, N'Entregado')
INSERT [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle], [DescripEstadoSolicDetalle]) VALUES (7, N'Cancelado')
SET IDENTITY_INSERT [dbo].[EstadoSolicDetalle] OFF
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] ON 

INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (2, N'Finalizada')
INSERT [dbo].[EstadoSolicitud] ([IdEstadoSolicitud], [DescripEstadoSolic]) VALUES (3, N'Cancelada')
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
SET IDENTITY_INSERT [dbo].[Familia] ON 

INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (1, N'ABM Solicitud')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (2, N'ABM Partida')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (3, N'ABM Asignacion')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (4, N'ABM Cotizacion')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (5, N'Administrador')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (8, N'PruebaFam2')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (9, N'PruebaFam3')
INSERT [dbo].[Familia] ([IdFamilia], [NombreFamilia]) VALUES (10, N'PruebaFam4')
SET IDENTITY_INSERT [dbo].[Familia] OFF
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [NombreIdioma], [ElIdiomaDefault]) VALUES (1, N'Español', 1)
INSERT [dbo].[Idioma] ([IdIdioma], [NombreIdioma], [ElIdiomaDefault]) VALUES (2, N'English', 0)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (1, 1, N'Escribiente')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (1, 2, N'Writer')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (2, 1, N'Escribiente Auxiliar')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (2, 2, N'Aux Writer')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (3, 1, N'Secretario')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (3, 2, N'Secretary')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (4, 1, N'Fiscal')
INSERT [dbo].[IdiomaCargo] ([IdCargo], [IdIdioma], [DescripCargo]) VALUES (4, 2, N'Prosecutor')
INSERT [dbo].[IdiomaEstadoInventario] ([IdEstadoInventario], [IdIdioma], [DescripEstadoInv]) VALUES (1, 1, N'Disponible')
INSERT [dbo].[IdiomaEstadoInventario] ([IdEstadoInventario], [IdIdioma], [DescripEstadoInv]) VALUES (1, 2, N'Available')
INSERT [dbo].[IdiomaEstadoInventario] ([IdEstadoInventario], [IdIdioma], [DescripEstadoInv]) VALUES (2, 1, N'Entregado')
INSERT [dbo].[IdiomaEstadoInventario] ([IdEstadoInventario], [IdIdioma], [DescripEstadoInv]) VALUES (2, 2, N'Delivered')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (1, 1, N'Pendiente')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (1, 2, N'Pending')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (2, 1, N'Cotizado')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (2, 2, N'Quoted')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (3, 1, N'Partida')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (3, 2, N'Departure')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (4, 1, N'Comprar')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (4, 2, N'Buy')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (5, 1, N'Adquirido')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (5, 2, N'Acquired')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (6, 1, N'Entregado')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (6, 2, N'Delivered')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (7, 1, N'Cancelado')
INSERT [dbo].[IdiomaEstadoSolicDetalle] ([IdEstadoSolicDetalle], [IdIdioma], [DescripEstadoSolicDetalle]) VALUES (7, 2, N'Cancelled')
INSERT [dbo].[IdiomaEstadoSolicitud] ([IdEstadoSolicitud], [IdIdioma], [DescripEstadoSolic]) VALUES (1, 1, N'Pendiente')
INSERT [dbo].[IdiomaEstadoSolicitud] ([IdEstadoSolicitud], [IdIdioma], [DescripEstadoSolic]) VALUES (1, 2, N'Pending')
INSERT [dbo].[IdiomaEstadoSolicitud] ([IdEstadoSolicitud], [IdIdioma], [DescripEstadoSolic]) VALUES (2, 1, N'Finalizada')
INSERT [dbo].[IdiomaEstadoSolicitud] ([IdEstadoSolicitud], [IdIdioma], [DescripEstadoSolic]) VALUES (2, 2, N'Finished')
INSERT [dbo].[IdiomaEstadoSolicitud] ([IdEstadoSolicitud], [IdIdioma], [DescripEstadoSolic]) VALUES (3, 1, N'Cancelada')
INSERT [dbo].[IdiomaEstadoSolicitud] ([IdEstadoSolicitud], [IdIdioma], [DescripEstadoSolic]) VALUES (3, 2, N'Cancelled')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (1, 1, N'Baja')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (1, 2, N'Low')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (2, 1, N'Normal')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (2, 2, N'Normal')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (3, 1, N'Alta')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (3, 2, N'High')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (4, 1, N'Inmediata')
INSERT [dbo].[IdiomaPrioridad] ([IdPrioridad], [IdIdioma], [DescripPrioridad]) VALUES (4, 2, N'Inmediate')
INSERT [dbo].[IdiomaTipoDependencia] ([IdTipoDependencia], [IdIdioma], [DescripTipoDependencia]) VALUES (1, 1, N'Comun')
INSERT [dbo].[IdiomaTipoDependencia] ([IdTipoDependencia], [IdIdioma], [DescripTipoDependencia]) VALUES (1, 2, N'Common')
INSERT [dbo].[IdiomaTipoDependencia] ([IdTipoDependencia], [IdIdioma], [DescripTipoDependencia]) VALUES (2, 1, N'Especial')
INSERT [dbo].[IdiomaTipoDependencia] ([IdTipoDependencia], [IdIdioma], [DescripTipoDependencia]) VALUES (2, 2, N'Special')
INSERT [dbo].[IdiomaTipoTelefono] ([IdTipoTelefono], [IdIdioma], [DescripTipoTel]) VALUES (1, 1, N'Linea')
INSERT [dbo].[IdiomaTipoTelefono] ([IdTipoTelefono], [IdIdioma], [DescripTipoTel]) VALUES (1, 2, N'Line')
INSERT [dbo].[IdiomaTipoTelefono] ([IdTipoTelefono], [IdIdioma], [DescripTipoTel]) VALUES (2, 1, N'Celular')
INSERT [dbo].[IdiomaTipoTelefono] ([IdTipoTelefono], [IdIdioma], [DescripTipoTel]) VALUES (2, 2, N'Cell phone')
SET IDENTITY_INSERT [dbo].[Inventario] ON 

INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (1, 1, NULL, N'2017120319481', 1, 2, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (2, 1, NULL, N'2017120319482', 1, 2, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (3, 2, NULL, N'2017120321341', NULL, 1, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (5, 3, NULL, N'041222461', 1, 1, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (7, 3, NULL, N'091220171', 1, 2, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (8, 3, NULL, N'091220172', 1, 2, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (9, 4, NULL, N'131220171', 1, 1, CAST(550.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (10, 4, NULL, N'131220172', 1, 1, CAST(550.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (11, 1, NULL, N'2408201822401', 1, 2, CAST(8000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (12, 1, NULL, N'2408201822402', 1, 2, CAST(8000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (13, 5, NULL, N'2408181', 1, 1, CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (14, 5, NULL, N'2408182', 1, 1, CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[Inventario] ([IdInventario], [IdBienEspecif], [SerialMaster], [SerieKey], [IdDeposito], [IdEstadoInventario], [Costo]) VALUES (15, 6, NULL, N'2408181', 1, 1, CAST(1000.00 AS Decimal(18, 2)))
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
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1074, CAST(1450.00 AS Decimal(10, 2)), NULL, NULL, CAST(0x0000A83C00B9EBF6 AS DateTime), NULL, 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1076, CAST(1500.00 AS Decimal(10, 2)), CAST(1500.00 AS Decimal(10, 2)), N'IT2017001', CAST(0x0000A83C00D68289 AS DateTime), CAST(0x0000A83E00000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1077, CAST(500.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)), N'IT2017002', CAST(0x0000A83C01844BB7 AS DateTime), CAST(0x0000A83E00000000 AS DateTime), 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1078, CAST(1000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), N'1234rrr', CAST(0x0000A844010C62F7 AS DateTime), CAST(0x0000A84400000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1079, CAST(1000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), N'fff444', CAST(0x0000A847016F9DF5 AS DateTime), CAST(0x0000A84800000000 AS DateTime), 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1080, CAST(1000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), N'1312part1', CAST(0x0000A84801741379 AS DateTime), CAST(0x0000A84800000000 AS DateTime), 1)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1081, CAST(20000.00 AS Decimal(10, 2)), CAST(20000.00 AS Decimal(10, 2)), N'PART300718', CAST(0x0000A92D014F5365 AS DateTime), CAST(0x0000A92D00000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1082, CAST(11000.00 AS Decimal(10, 2)), CAST(11000.00 AS Decimal(10, 2)), N'RRTT5', CAST(0x0000A9300174D0FB AS DateTime), CAST(0x0000A93000000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1083, CAST(17000.00 AS Decimal(10, 2)), CAST(17000.00 AS Decimal(10, 2)), N'aa4455564', CAST(0x0000A9460174C553 AS DateTime), CAST(0x0000A94600000000 AS DateTime), 0)
INSERT [dbo].[Partida] ([IdPartida], [MontoSolicitado], [MontoOtorgado], [NroPartida], [FechaEnvio], [FechaAcreditacion], [Caja]) VALUES (1084, CAST(7000.00 AS Decimal(10, 2)), CAST(7000.00 AS Decimal(10, 2)), N'asdfasdf2', CAST(0x0000A946017D3E64 AS DateTime), CAST(0x0000A94600000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Partida] OFF
SET IDENTITY_INSERT [dbo].[PartidaDetalle] ON 

INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1076, 1, 2332, 136)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1076, 3, 2332, 140)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1077, 2, 2332, 142)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1078, 1, 2333, 143)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1079, 1, 2334, 144)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1080, 2, 2334, 145)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1081, 1, 2336, 146)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1082, 1, 2337, 147)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1083, 1, 2338, 148)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1083, 2, 2338, 149)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (1, 1084, 1, 2339, 150)
INSERT [dbo].[PartidaDetalle] ([IdPartidaDetalle], [IdPartida], [IdSolicitudDetalle], [IdSolicitud], [UIDPartidaDetalle]) VALUES (2, 1084, 2, 2339, 151)
SET IDENTITY_INSERT [dbo].[PartidaDetalle] OFF
SET IDENTITY_INSERT [dbo].[Patente] ON 

INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (1, N'Crear Solicitud')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (2, N'Modificar Solicitud')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (3, N'Baja Solicitud')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (4, N'Crear Bien')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (5, N'Crear Cotizacion')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (6, N'Solicitar Cotizacion')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (7, N'Crear Asignacion')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (8, N'Modificar Asignacion')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (9, N'Crear Partida')
INSERT [dbo].[Patente] ([IdPatente], [NombrePatente]) VALUES (10, N'Modificar Partida')
SET IDENTITY_INSERT [dbo].[Patente] OFF
INSERT [dbo].[Politica] ([IdTipoDependencia], [IdCategoria], [Cantidad]) VALUES (1, 2, 1)
INSERT [dbo].[Politica] ([IdTipoDependencia], [IdCategoria], [Cantidad]) VALUES (1, 3, 3)
SET IDENTITY_INSERT [dbo].[Prioridad] ON 

INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (1, N'Baja')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (2, N'Normal')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (3, N'Alta')
INSERT [dbo].[Prioridad] ([IdPrioridad], [DescripPrioridad]) VALUES (4, N'Inmediata')
SET IDENTITY_INSERT [dbo].[Prioridad] OFF
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([IdProveedor], [AliasProv], [ContactoProv], [MailContactoProv], [Activo]) VALUES (1, N'Proveedor1', N'Juan', N'martinez.juan.marcos@gmail.com', 1)
INSERT [dbo].[Proveedor] ([IdProveedor], [AliasProv], [ContactoProv], [MailContactoProv], [Activo]) VALUES (2, N'Proveedor2', N'Pepe Lopez', N'loyolajavi@gmail.com', 1)
INSERT [dbo].[Proveedor] ([IdProveedor], [AliasProv], [ContactoProv], [MailContactoProv], [Activo]) VALUES (3, N'Empresa1', N'Lola', N'martinez.juan.marcos@gmail.com', 1)
INSERT [dbo].[Proveedor] ([IdProveedor], [AliasProv], [ContactoProv], [MailContactoProv], [Activo]) VALUES (5, N'Dell Latinoamerica', N'Juan Lopez', N'jlopez@dell.com', 1)
INSERT [dbo].[Proveedor] ([IdProveedor], [AliasProv], [ContactoProv], [MailContactoProv], [Activo]) VALUES (6, N'Proveedor3', N'Juan Martinez', N'loyolajavi@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
SET IDENTITY_INSERT [dbo].[Provincia] ON 

INSERT [dbo].[Provincia] ([IdProvincia], [NombreProvincia]) VALUES (1, N'Buenos Aires')
SET IDENTITY_INSERT [dbo].[Provincia] OFF
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (3, 1)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (3, 2)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (3, 3)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (3, 5)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (4, 2)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (5, 6)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (8, 1)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (8, 6)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (9, 2)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (9, 3)
INSERT [dbo].[RelCatProv] ([IdCategoria], [IdProveedor]) VALUES (9, 5)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1203, 1076, 136)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1204, 1076, 136)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1205, 1076, 136)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1206, 1077, 142)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1207, 1077, 142)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1208, 1077, 142)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1209, 1076, 140)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1210, 1076, 140)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1211, 1076, 140)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1212, 1078, 143)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1213, 1078, 143)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1214, 1078, 143)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1218, 1079, 144)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1219, 1079, 144)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1220, 1079, 144)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1221, 1080, 145)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1222, 1080, 145)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1223, 1080, 145)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1230, 1081, 146)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1231, 1081, 146)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1232, 1081, 146)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1233, 1082, 147)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1234, 1082, 147)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1235, 1082, 147)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1263, 1083, 148)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1264, 1083, 148)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1265, 1083, 148)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1266, 1083, 149)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1267, 1083, 149)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1268, 1083, 149)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1275, 1084, 150)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1276, 1084, 150)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1277, 1084, 150)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1278, 1084, 151)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1279, 1084, 151)
INSERT [dbo].[RelCotizPartDetalle] ([IdCotizacion], [IdPartida], [UIDPartidaDetalle]) VALUES (1280, 1084, 151)
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
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2330, 1227)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2330, 1228)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2330, 1229)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2331, 1194)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2331, 1195)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2331, 1196)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2332, 1203)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2332, 1204)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2332, 1205)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2333, 1212)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2333, 1213)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2333, 1214)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2334, 1218)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2334, 1219)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2334, 1220)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2336, 1230)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2336, 1231)
GO
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2336, 1232)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2337, 1233)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2337, 1234)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2337, 1235)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2338, 1263)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2338, 1264)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2338, 1265)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2339, 1275)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2339, 1276)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (1, 2339, 1277)
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
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2331, 1197)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2331, 1198)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2331, 1199)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2332, 1206)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2332, 1207)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2332, 1208)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2334, 1221)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2334, 1222)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2334, 1223)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2338, 1266)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2338, 1267)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2338, 1268)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2339, 1278)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2339, 1279)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (2, 2339, 1280)
GO
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2322, 1191)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2322, 1192)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2322, 1193)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2331, 1200)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2331, 1201)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2331, 1202)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2332, 1209)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2332, 1210)
INSERT [dbo].[RelCotSolDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCotizacion]) VALUES (3, 2332, 1211)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (1, 4, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (1, 6, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (2, 3, 3)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (2, 4, 1)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 2, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 3, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 4, 2)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 6, 1)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (3, 7, 2)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (4, 1, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (4, 6, 3)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (7, 7, 4)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (17, 4, 1)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (18, 4, 1)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (19, 4, 3)
INSERT [dbo].[RelDepAgenteCargo] ([IdAgente], [IdDependencia], [IdCargo]) VALUES (20, 4, 3)
INSERT [dbo].[RelFamFam] ([IdFamiliaPadre], [IdFamiliaHijo]) VALUES (1, 4)
INSERT [dbo].[RelFamFam] ([IdFamiliaPadre], [IdFamiliaHijo]) VALUES (5, 1)
INSERT [dbo].[RelFamFam] ([IdFamiliaPadre], [IdFamiliaHijo]) VALUES (5, 2)
INSERT [dbo].[RelFamFam] ([IdFamiliaPadre], [IdFamiliaHijo]) VALUES (5, 3)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (1, 1)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (1, 9)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (1, 10)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (2, 1)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (2, 9)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (3, 1)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (4, 5)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (4, 8)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (4, 10)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (5, 4)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (5, 10)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (6, 4)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (7, 3)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (8, 3)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (9, 2)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (9, 10)
INSERT [dbo].[RelFamPat] ([IdPatente], [IdFamilia]) VALUES (10, 2)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1076, 136, 1041, 1)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1076, 136, 1041, 2)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1076, 140, 1042, 3)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1077, 142, 1044, 5)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1078, 143, 1045, 7)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1078, 143, 1045, 8)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1079, 144, 1046, 9)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1079, 144, 1046, 10)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1083, 148, 1047, 11)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1083, 148, 1047, 12)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1084, 150, 1048, 13)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1084, 150, 1048, 14)
INSERT [dbo].[RelPDetAdq] ([IdPartida], [UIDPartidaDetalle], [IdAdquisicion], [IdInventario]) VALUES (1084, 151, 1048, 15)
INSERT [dbo].[RelProveedorDire] ([IdProveedor], [IdDireccion]) VALUES (2, 1)
INSERT [dbo].[RelProveedorDire] ([IdProveedor], [IdDireccion]) VALUES (5, 2)
INSERT [dbo].[RelProveedorTel] ([IdProveedor], [IdTelefono]) VALUES (2, 1)
INSERT [dbo].[RelProveedorTel] ([IdProveedor], [IdTelefono]) VALUES (2, 3)
INSERT [dbo].[RelProveedorTel] ([IdProveedor], [IdTelefono]) VALUES (5, 2)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (1, 2326, 1)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (2, 2319, 2)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (2, 2324, 4)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (3, 2331, 1)
INSERT [dbo].[RelSolDetalleAgente] ([IdSolicitudDetalle], [IdSolicitud], [IdAgente]) VALUES (3, 2332, 2)
INSERT [dbo].[RelUsuFam] ([IdUsuario], [IdFamilia]) VALUES (1, 1)
INSERT [dbo].[RelUsuFam] ([IdUsuario], [IdFamilia]) VALUES (1, 3)
INSERT [dbo].[RelUsuFam] ([IdUsuario], [IdFamilia]) VALUES (2, 2)
INSERT [dbo].[RelUsuFam] ([IdUsuario], [IdFamilia]) VALUES (3, 1)
INSERT [dbo].[RelUsuFam] ([IdUsuario], [IdFamilia]) VALUES (6, 10)
INSERT [dbo].[RelUsuPat] ([IdUsuario], [IdPatente]) VALUES (1, 4)
INSERT [dbo].[RelUsuPat] ([IdUsuario], [IdPatente]) VALUES (2, 4)
INSERT [dbo].[RelUsuPat] ([IdUsuario], [IdPatente]) VALUES (5, 4)
SET IDENTITY_INSERT [dbo].[Rendicion] ON 

INSERT [dbo].[Rendicion] ([IdRendicion], [MontoGasto], [IdPartida], [FechaRen]) VALUES (2, CAST(60000.00 AS Decimal(18, 2)), 1062, CAST(0x0000A7CE00000000 AS DateTime))
INSERT [dbo].[Rendicion] ([IdRendicion], [MontoGasto], [IdPartida], [FechaRen]) VALUES (13, CAST(1000.00 AS Decimal(18, 2)), 1078, CAST(0x0000A84400000000 AS DateTime))
INSERT [dbo].[Rendicion] ([IdRendicion], [MontoGasto], [IdPartida], [FechaRen]) VALUES (14, CAST(1100.00 AS Decimal(18, 2)), 1079, CAST(0x0000A84800000000 AS DateTime))
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
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1314, 3, 3, 5, 21)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1315, 2, 2, 1, 22)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1316, 3, 2, 1, 23)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 1317, 2, 2, 3, 24)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2314, 3, 2, 5, 25)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2315, 3, 3, 1, 26)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2316, 3, 3, 5, 27)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2318, 3, 3, 1, 28)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2319, 3, 5, 2, 29)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2321, 5, 2, 2, 64)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2322, 3, 2, 7, 109)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2324, 3, 2, 2, 33)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2325, 3, 4, 2, 86)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2326, 5, 1, 2, 93)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2328, 2, 4, 7, 91)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2329, 3, 2, 2, 96)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2330, 2, 2, 3, 139)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2331, 3, 2, 7, 115)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2332, 3, 2, 6, 121)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2333, 2, 2, 6, 125)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2334, 3, 2, 5, 130)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2335, 3, 1, 7, 149)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2336, 3, 2, 4, 152)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2337, 3, 1, 4, 155)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2338, 3, 2, 6, 165)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (1, 2339, 6, 2, 5, 170)
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
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1314, 2, 2, 5, 48)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1315, 3, 2, 1, 49)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1316, 2, 1, 3, 50)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 1317, 3, 2, 3, 51)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2314, 2, 2, 3, 52)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2315, 2, 3, 1, 53)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2316, 2, 3, 5, 54)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2319, 5, 1, 2, 55)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2321, 2, 1, 1, 65)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2322, 5, 1, 7, 110)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2324, 5, 1, 2, 59)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2326, 2, 2, 2, 94)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2328, 5, 1, 7, 92)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2331, 2, 1, 7, 116)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2332, 2, 1, 5, 122)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2334, 2, 2, 4, 131)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2338, 1, 1, 3, 166)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (2, 2339, 1, 1, 5, 171)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (3, 2322, 2, 1, 7, 111)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (3, 2331, 5, 1, 7, 117)
INSERT [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [IdCategoria], [Cantidad], [IdEstadoSolicDetalle], [UIDSolicDetalle]) VALUES (3, 2332, 5, 1, 5, 123)
SET IDENTITY_INSERT [dbo].[SolicDetalle] OFF
SET IDENTITY_INSERT [dbo].[Solicitud] ON 

INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2310)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2169)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (3, CAST(0x0000A75500000000 AS DateTime), NULL, 1, 4, 1, 2, NULL, 2381)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (4, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 2, 1, 2, NULL, 2440)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (5, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2170)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (6, CAST(0x0000A75500000000 AS DateTime), NULL, 4, 3, 2, 2, NULL, 2348)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (7, CAST(0x0000A75500000000 AS DateTime), NULL, 2, 1, 1, 1, NULL, 2384)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (8, CAST(0x0000A75500000000 AS DateTime), NULL, 1, 1, 1, 1, NULL, 2461)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (9, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2278)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (10, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2307)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (11, CAST(0x0000A75500000000 AS DateTime), NULL, 4, 1, 1, 1, NULL, 2569)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (12, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2226)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (16, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 1, 1, 2, NULL, 2506)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (17, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 2, 1, 1, NULL, 2475)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (21, CAST(0x0000A75500000000 AS DateTime), NULL, 4, 1, 1, 2, NULL, 2207)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (23, CAST(0x0000A75500000000 AS DateTime), NULL, 3, 3, 1, 2, NULL, 2275)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (24, CAST(0x0000A75600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2192)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (25, CAST(0x0000A75600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2253)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (26, CAST(0x0000A75800000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2590)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (27, CAST(0x0000A75800000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2418)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (28, CAST(0x0000A75900000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2431)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (29, CAST(0x0000A75D00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2460)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (30, CAST(0x0000A75D00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2292)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (31, CAST(0x0000A76100000000 AS DateTime), CAST(0x0000A80800000000 AS DateTime), 3, 1, 1, 1, NULL, 2352)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (32, CAST(0x0000A76100000000 AS DateTime), CAST(0x0000A82800000000 AS DateTime), 3, 1, 1, 1, NULL, 2729)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (33, CAST(0x0000A76600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2398)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (34, CAST(0x0000A72B00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2364)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (35, CAST(0x0000A76600000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2272)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (36, CAST(0x0000A76B00000000 AS DateTime), NULL, 3, 1, 1, 1, NULL, 2322)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (37, CAST(0x0000A76B00000000 AS DateTime), CAST(0x0000A80800000000 AS DateTime), 3, 2, 1, 1, 2, 2575)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (38, CAST(0x0000A72B00000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2494)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1305, CAST(0x0000A76F00000000 AS DateTime), CAST(0x0000A82800000000 AS DateTime), 3, 1, 1, 1, 1, 2571)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1306, CAST(0x0000A77000000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2228)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1308, CAST(0x0000A77600000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2457)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1309, CAST(0x0000A77D00000000 AS DateTime), NULL, 1, 1, 1, 1, 4, 2319)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1310, CAST(0x0000A77F00000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2368)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1311, CAST(0x0000A7A000000000 AS DateTime), NULL, 1, 2, 1, 1, 4, 2287)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1312, CAST(0x0000A7AB00000000 AS DateTime), NULL, 1, 1, 1, 1, 4, 2483)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1313, CAST(0x0000A7B400000000 AS DateTime), NULL, 1, 2, 1, 1, 4, 2442)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1314, CAST(0x0000A7B600000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2483)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1315, CAST(0x0000A7B600000000 AS DateTime), NULL, 3, 1, 1, 1, 2, 2215)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1316, CAST(0x0000A7B600000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2368)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (1317, CAST(0x0000A7B600000000 AS DateTime), NULL, 1, 1, 1, 1, 4, 2354)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2314, CAST(0x0000A7B600000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2399)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2315, CAST(0x0000A7B600000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2322)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2316, CAST(0x0000A7B700000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2371)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2317, CAST(0x0000A7D100000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2349)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2318, CAST(0x0000A7DC00000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2072)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2319, CAST(0x0000A7DE00000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2296)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2321, CAST(0x0000A7F200000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2345)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2322, CAST(0x0000A80800000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2301)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2323, CAST(0x0000A80800000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2248)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2324, CAST(0x0000A80900000000 AS DateTime), NULL, 1, 1, 1, 1, 4, 2284)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2325, CAST(0x0000A80B00000000 AS DateTime), NULL, 3, 2, 1, 2, 1, 2209)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2326, CAST(0x0000A81000000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2425)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2327, CAST(0x0000A80F00000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2379)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2328, CAST(0x0000A81900000000 AS DateTime), NULL, 3, 3, 1, 2, 1, 2365)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2329, CAST(0x0000A81C00000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2155)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2330, CAST(0x0000A81C00000000 AS DateTime), NULL, 1, 1, 1, 1, 4, 2493)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2331, CAST(0x0000A83C00000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2255)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2332, CAST(0x0000A83C00000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2388)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2333, CAST(0x0000A84400000000 AS DateTime), NULL, 2, 1, 1, 1, 3, 2263)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2334, CAST(0x0000A84700000000 AS DateTime), NULL, 3, 1, 1, 1, 1, 2314)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2335, CAST(0x0000A92500000000 AS DateTime), CAST(0x0000A92A00000000 AS DateTime), 3, 3, 3, 1, 2, 2232)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2336, CAST(0x0000A92D00000000 AS DateTime), NULL, 2, 2, 1, 1, 3, 2166)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2337, CAST(0x0000A92F00000000 AS DateTime), NULL, 1, 3, 1, 1, 4, 2566)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2338, CAST(0x0000A94500000000 AS DateTime), NULL, 4, 2, 1, 1, 19, 2273)
INSERT [dbo].[Solicitud] ([IdSolicitud], [FechaInicio], [FechaFin], [IdDependencia], [IdPrioridad], [IdEstado], [IdUsuario], [IdAgente], [DVH]) VALUES (2339, CAST(0x0000A94600000000 AS DateTime), NULL, 4, 1, 1, 1, 1, 2546)
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
SET IDENTITY_INSERT [dbo].[Telefono] ON 

INSERT [dbo].[Telefono] ([IdTelefono], [CodArea], [NroTelefono], [IdTipoTelefono]) VALUES (1, 11, 45553355, 1)
INSERT [dbo].[Telefono] ([IdTelefono], [CodArea], [NroTelefono], [IdTipoTelefono]) VALUES (2, 11, 47552093, 1)
INSERT [dbo].[Telefono] ([IdTelefono], [CodArea], [NroTelefono], [IdTipoTelefono]) VALUES (3, 11, 1566552233, 2)
SET IDENTITY_INSERT [dbo].[Telefono] OFF
SET IDENTITY_INSERT [dbo].[TipoBien] ON 

INSERT [dbo].[TipoBien] ([IdTipoBien], [DescripTipoBien]) VALUES (1, N'Hardware')
INSERT [dbo].[TipoBien] ([IdTipoBien], [DescripTipoBien]) VALUES (2, N'Software')
SET IDENTITY_INSERT [dbo].[TipoBien] OFF
SET IDENTITY_INSERT [dbo].[TipoDependencia] ON 

INSERT [dbo].[TipoDependencia] ([IdTipoDependencia], [DescripTipoDependencia]) VALUES (1, N'Comun')
INSERT [dbo].[TipoDependencia] ([IdTipoDependencia], [DescripTipoDependencia]) VALUES (2, N'Especial')
SET IDENTITY_INSERT [dbo].[TipoDependencia] OFF
SET IDENTITY_INSERT [dbo].[TipoTelefono] ON 

INSERT [dbo].[TipoTelefono] ([IdTipoTelefono], [DescripTipoTel]) VALUES (1, N'Linea')
INSERT [dbo].[TipoTelefono] ([IdTipoTelefono], [DescripTipoTel]) VALUES (2, N'Celular')
SET IDENTITY_INSERT [dbo].[TipoTelefono] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual], [Nombre], [Apellido], [Mail], [Activo], [DVH]) VALUES (1, N'pargi', N'tgUs8x9oURN1hCh7q1AcZ18jJGsWGEmsJs6kOKQwLD4=', 1, N'Pepe', N'Argi', N'loyolajavi@gmail.com', 1, 2365)
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual], [Nombre], [Apellido], [Mail], [Activo], [DVH]) VALUES (2, N'lola', N'tgUs8x9oURN1hCh7q1AcZ18jJGsWGEmsJs6kOKQwLD4=', 1, N'Lola', N'Argi', N'loyolajavi@gmail.com', 1, 2436)
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual], [Nombre], [Apellido], [Mail], [Activo], [DVH]) VALUES (3, N'mgulli', N'tgUs8x9oURN1hCh7q1AcZ18jJGsWGEmsJs6kOKQwLD4=', 1, N'Mario', N'Gulli', N'loyolajavi@gmail.com', 1, 2423)
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual], [Nombre], [Apellido], [Mail], [Activo], [DVH]) VALUES (5, N'Paco', N'k5ZeoArUkW+XycwoD25V5dT2umHA5sm/HlKZVW0kWwI=', 1, N'Paco', N'Lopez', N'loyolajavi@gmail.com', 1, 2298)
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Pass], [IdiomaUsuarioActual], [Nombre], [Apellido], [Mail], [Activo], [DVH]) VALUES (6, N'jlopez', N'k5ZeoArUkW+XycwoD25V5dT2umHA5sm/HlKZVW0kWwI=', 1, N'Juan', N'Lopez', N'loyolajavi@gmail.com', 1, 2418)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Inventario]    Script Date: 05/09/2018 21:08:20 ******/
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
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_TipoBien] FOREIGN KEY([IdTipoBien])
REFERENCES [dbo].[TipoBien] ([IdTipoBien])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_TipoBien]
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
ALTER TABLE [dbo].[IdiomaCargo]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaCargo_Cargo] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[Cargo] ([IdCargo])
GO
ALTER TABLE [dbo].[IdiomaCargo] CHECK CONSTRAINT [FK_IdiomaCargo_Cargo]
GO
ALTER TABLE [dbo].[IdiomaCargo]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaCargo_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaCargo] CHECK CONSTRAINT [FK_IdiomaCargo_Idioma]
GO
ALTER TABLE [dbo].[IdiomaEstadoInventario]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaEstadoInv_EstadoInventario] FOREIGN KEY([IdEstadoInventario])
REFERENCES [dbo].[EstadoInventario] ([IdEstadoInventario])
GO
ALTER TABLE [dbo].[IdiomaEstadoInventario] CHECK CONSTRAINT [FK_IdiomaEstadoInv_EstadoInventario]
GO
ALTER TABLE [dbo].[IdiomaEstadoInventario]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaEstadoInv_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaEstadoInventario] CHECK CONSTRAINT [FK_IdiomaEstadoInv_Idioma]
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaEstadoSolicDetalle_Idioma] FOREIGN KEY([IdEstadoSolicDetalle])
REFERENCES [dbo].[EstadoSolicDetalle] ([IdEstadoSolicDetalle])
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicDetalle] CHECK CONSTRAINT [FK_IdiomaEstadoSolicDetalle_Idioma]
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicDetalle]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaEstadoSolicDetalle_Idioma2] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicDetalle] CHECK CONSTRAINT [FK_IdiomaEstadoSolicDetalle_Idioma2]
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicitud]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaEstadoSolic_EstadoSolicitud] FOREIGN KEY([IdEstadoSolicitud])
REFERENCES [dbo].[EstadoSolicitud] ([IdEstadoSolicitud])
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicitud] CHECK CONSTRAINT [FK_IdiomaEstadoSolic_EstadoSolicitud]
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicitud]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaEstadoSolic_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaEstadoSolicitud] CHECK CONSTRAINT [FK_IdiomaEstadoSolic_Idioma]
GO
ALTER TABLE [dbo].[IdiomaPrioridad]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaPrioridad_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaPrioridad] CHECK CONSTRAINT [FK_IdiomaPrioridad_Idioma]
GO
ALTER TABLE [dbo].[IdiomaPrioridad]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaPrioridad_Prioridad] FOREIGN KEY([IdPrioridad])
REFERENCES [dbo].[Prioridad] ([IdPrioridad])
GO
ALTER TABLE [dbo].[IdiomaPrioridad] CHECK CONSTRAINT [FK_IdiomaPrioridad_Prioridad]
GO
ALTER TABLE [dbo].[IdiomaTipoDependencia]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaTipoDependencia_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaTipoDependencia] CHECK CONSTRAINT [FK_IdiomaTipoDependencia_Idioma]
GO
ALTER TABLE [dbo].[IdiomaTipoDependencia]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaTipoDependencia_TipoDependencia] FOREIGN KEY([IdTipoDependencia])
REFERENCES [dbo].[TipoDependencia] ([IdTipoDependencia])
GO
ALTER TABLE [dbo].[IdiomaTipoDependencia] CHECK CONSTRAINT [FK_IdiomaTipoDependencia_TipoDependencia]
GO
ALTER TABLE [dbo].[IdiomaTipoTelefono]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaTipoTelefono_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaTipoTelefono] CHECK CONSTRAINT [FK_IdiomaTipoTelefono_Idioma]
GO
ALTER TABLE [dbo].[IdiomaTipoTelefono]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaTipoTelefono_TipoTelefono] FOREIGN KEY([IdTipoTelefono])
REFERENCES [dbo].[TipoTelefono] ([IdTipoTelefono])
GO
ALTER TABLE [dbo].[IdiomaTipoTelefono] CHECK CONSTRAINT [FK_IdiomaTipoTelefono_TipoTelefono]
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
ALTER TABLE [dbo].[RelCatProv]  WITH CHECK ADD  CONSTRAINT [FK_RelCatProv_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[RelCatProv] CHECK CONSTRAINT [FK_RelCatProv_Categoria]
GO
ALTER TABLE [dbo].[RelCatProv]  WITH CHECK ADD  CONSTRAINT [FK_RelCatProv_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[RelCatProv] CHECK CONSTRAINT [FK_RelCatProv_Proveedor]
GO
ALTER TABLE [dbo].[RelCotizPartDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotizPartDetalle_Cotizacion] FOREIGN KEY([IdCotizacion])
REFERENCES [dbo].[Cotizacion] ([IdCotizacion])
GO
ALTER TABLE [dbo].[RelCotizPartDetalle] CHECK CONSTRAINT [FK_RelCotizPartDetalle_Cotizacion]
GO
ALTER TABLE [dbo].[RelCotizPartDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotizPartDetalle_PartidaDetalle] FOREIGN KEY([IdPartida], [UIDPartidaDetalle])
REFERENCES [dbo].[PartidaDetalle] ([IdPartida], [UIDPartidaDetalle])
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
ALTER TABLE [dbo].[RelFamFam]  WITH CHECK ADD  CONSTRAINT [FK_RelFamFam_Familia] FOREIGN KEY([IdFamiliaPadre])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[RelFamFam] CHECK CONSTRAINT [FK_RelFamFam_Familia]
GO
ALTER TABLE [dbo].[RelFamFam]  WITH CHECK ADD  CONSTRAINT [FK_RelFamFam_Familia1] FOREIGN KEY([IdFamiliaHijo])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[RelFamFam] CHECK CONSTRAINT [FK_RelFamFam_Familia1]
GO
ALTER TABLE [dbo].[RelFamPat]  WITH CHECK ADD  CONSTRAINT [FK_RelFamPat_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[RelFamPat] CHECK CONSTRAINT [FK_RelFamPat_Familia]
GO
ALTER TABLE [dbo].[RelFamPat]  WITH CHECK ADD  CONSTRAINT [FK_RelFamPat_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[RelFamPat] CHECK CONSTRAINT [FK_RelFamPat_Patente]
GO
ALTER TABLE [dbo].[RelPDetAdq]  WITH CHECK ADD  CONSTRAINT [FK_RelPDetAdq_Adquisicion] FOREIGN KEY([IdAdquisicion])
REFERENCES [dbo].[Adquisicion] ([IdAdquisicion])
GO
ALTER TABLE [dbo].[RelPDetAdq] CHECK CONSTRAINT [FK_RelPDetAdq_Adquisicion]
GO
ALTER TABLE [dbo].[RelPDetAdq]  WITH CHECK ADD  CONSTRAINT [FK_RelPDetAdq_Inventario] FOREIGN KEY([IdInventario])
REFERENCES [dbo].[Inventario] ([IdInventario])
GO
ALTER TABLE [dbo].[RelPDetAdq] CHECK CONSTRAINT [FK_RelPDetAdq_Inventario]
GO
ALTER TABLE [dbo].[RelPDetAdq]  WITH CHECK ADD  CONSTRAINT [FK_RelPDetAdq_PartidaDetalle] FOREIGN KEY([IdPartida], [UIDPartidaDetalle])
REFERENCES [dbo].[PartidaDetalle] ([IdPartida], [UIDPartidaDetalle])
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
ALTER TABLE [dbo].[RelUsuFam]  WITH CHECK ADD  CONSTRAINT [FK_RelUsuFam_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[RelUsuFam] CHECK CONSTRAINT [FK_RelUsuFam_Familia]
GO
ALTER TABLE [dbo].[RelUsuFam]  WITH CHECK ADD  CONSTRAINT [FK_RelUsuFam_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[RelUsuFam] CHECK CONSTRAINT [FK_RelUsuFam_Usuario]
GO
ALTER TABLE [dbo].[RelUsuPat]  WITH CHECK ADD  CONSTRAINT [FK_RelUsuPat_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[RelUsuPat] CHECK CONSTRAINT [FK_RelUsuPat_Patente]
GO
ALTER TABLE [dbo].[RelUsuPat]  WITH CHECK ADD  CONSTRAINT [FK_RelUsuPat_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[RelUsuPat] CHECK CONSTRAINT [FK_RelUsuPat_Usuario]
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
