USE [master]
GO
/****** Object:  Database [Artec]    Script Date: 30/07/2019 23:35:45 ******/
CREATE DATABASE [Artec] ON  PRIMARY 
( NAME = N'Artec', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Artec.mdf' , SIZE = 5184KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Artec_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Artec_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [tecnologia]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [tecnologia] WITH PASSWORD=N'9¤Ë}nBÛèmp¦
;n4xè,c­Rè''', DEFAULT_DATABASE=[Artec], DEFAULT_LANGUAGE=[Español], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [tecnologia] DISABLE
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [NT SERVICE\Winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT Service\MSSQL$SQLEXPRESS]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [NT Service\MSSQL$SQLEXPRESS] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [Javi-PC\Javi]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [Javi-PC\Javi] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/****** Object:  Login [BUILTIN\Usuarios]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [BUILTIN\Usuarios] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'#IõN%Ë;´PàsF¾îõm«ä
Tt', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 30/07/2019 23:35:45 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'¿ní©âYö¯`áìejhº+Tâ|ÉÆ', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
EXEC sys.sp_addsrvrolemember @loginame = N'tecnologia', @rolename = N'sysadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'NT SERVICE\Winmgmt', @rolename = N'sysadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'NT SERVICE\SQLWriter', @rolename = N'sysadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'NT Service\MSSQL$SQLEXPRESS', @rolename = N'sysadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'Javi-PC\Javi', @rolename = N'sysadmin'
GO
USE [Artec]
GO
/****** Object:  User [tecnologia]    Script Date: 30/07/2019 23:35:45 ******/
CREATE USER [tecnologia] FOR LOGIN [tecnologia] WITH DEFAULT_SCHEMA=[dbo]
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'tecnologia'
GO
sys.sp_addrolemember @rolename = N'db_datareader', @membername = N'tecnologia'
GO
sys.sp_addrolemember @rolename = N'db_datawriter', @membername = N'tecnologia'
GO
/****** Object:  StoredProcedure [dbo].[AdjuntoCotizacion]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdjuntoCotizacion]
(
	@IdCotizacion int,
	@IdAdjunto int
)

AS
BEGIN


UPDATE Cotizacion
Set IdAdjunto = @IdAdjunto
where IdCotizacion = @IdCotizacion

END



GO
/****** Object:  StoredProcedure [dbo].[AdjuntoSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdjuntoSolicitud]
(
	@IdSolicitud int,
	@IdAdjunto int
)

AS
BEGIN


UPDATE Solicitud
Set IdAdjunto = @IdAdjunto
where IdSolicitud = @IdSolicitud

END



GO
/****** Object:  StoredProcedure [dbo].[AdquisicionBuscar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdquisicionBuscar]
(
	@IdAdquisicion int = null,
	@IdPartida int = null,
	@NombreDependencia varchar(300) = null,
	@unaFecha datetime = null,
	@unaFechaCompra datetime = null,
	@NroFactura varchar(50) = null,
	@IdSolicitud int = null
	
)


AS
BEGIN

	SET NOCOUNT ON;

select distinct adq.IdAdquisicion, pdet.IdPartida, dep.IdDependencia, dep.NombreDependencia, adq.FechaAdq, adq.FechaCompra, adq.NroFactura, sol.IdSolicitud, adq.MontoCompra, pro.IdProveedor, pro.AliasProv
from Adquisicion adq
INNER JOIN RelPDetAdq rel ON rel.IdAdquisicion = adq.IdAdquisicion
INNER JOIN PartidaDetalle pdet ON pdet.IdPartida = rel.IdPartida and pdet.UIDPartidaDetalle = rel.UIDPartidaDetalle
INNER JOIN SolicDetalle sdet ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle AND sdet.UIDSolicDetalle = pdet.UIDSolicDetalle
INNER JOIN Solicitud sol ON sol.IdSolicitud = sdet.IdSolicitud
INNER JOIN Dependencia dep ON dep.IdDependencia = sol.IdDependencia
INNER JOIN Proveedor pro ON pro.IdProveedor = adq.IdProveedor
WHERE (adq.IdAdquisicion = @IdAdquisicion OR @IdAdquisicion IS NULL)
and (pdet.IdPartida = @IdPartida OR @IdPartida IS NULL)
and (UPPER(dep.NombreDependencia) LIKE UPPER('%' + @NombreDependencia + '%') OR @NombreDependencia IS NULL)
and (adq.FechaAdq = @unaFecha OR @unaFecha IS NULL)
and (adq.FechaCompra = @unaFechaCompra OR @unaFechaCompra IS NULL)
and (UPPER(adq.NroFactura) LIKE UPPER('%' + @NroFactura + '%') OR @NroFactura IS NULL)
and (sol.IdSolicitud = @IdSolicitud OR @IdSolicitud IS NULL)


END



GO
/****** Object:  StoredProcedure [dbo].[AdquisicionCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionEliminar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdquisicionEliminar]
(
	@IdAdquisicion INT
)

AS
BEGIN

DELETE FROM Adquisicion
WHERE IdAdquisicion = @IdAdquisicion



END



GO
/****** Object:  StoredProcedure [dbo].[AdquisicionesConBienesPorIdPartida]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AdquisicionInventariosAsoc]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdquisicionInventariosAsoc]
(
	@IdPartida INT,
	--@UIDPartidaDetalle int,
	@IdAdquisicion int
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT inv.IdInventario, inv.SerieKey, bi.IdBien, cat.DescripCategoria, ma.IdMarca, ma.DescripMarca, mo.IdModeloVersion, mo.DescripModeloVersion, inv.Costo, ti.IdTipoBien, inv.SerialMaster, relpdet.IdPartida, relpdet.UIDPartidaDetalle, relpdet.IdAdquisicion, dep.IdDeposito, pdet.UIDSolicDetalle
FROM Inventario inv
LEFT JOIN Deposito dep ON dep.IdDeposito = inv.IdDeposito
INNER JOIN Bien bi
ON inv.IdBienEspecif = bi.IdBien
INNER JOIN Categoria cat ON cat.IdCategoria = bi.IdCategoria
INNER JOIN TipoBien ti ON cat.IdTipoBien = ti.IdTipoBien
INNER JOIN Marca ma
ON bi.IdMarca = ma.IdMarca
INNER JOIN ModeloVersion mo
ON bi.IdModeloVersion = mo.IdModeloVersion
INNER JOIN RelPDetAdq relpdet
ON relpdet.IdInventario = inv.IdInventario
INNER JOIN PartidaDetalle pdet ON pdet.UIDPartidaDetalle = relpdet.UIDPartidaDetalle
WHERE relpdet.IdPartida = @IdPartida
--and relpdet.UIDPartidaDetalle = @UIDPartidaDetalle
and relpdet.IdAdquisicion = @IdAdquisicion
--and inv.IdEstadoInventario = 1--Disponible


END



GO
/****** Object:  StoredProcedure [dbo].[AdquisicionModificar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdquisicionModificar]
(
	@IdAdquisicion int,
	@FechaAdq datetime,
	@FechaCompra datetime,
	@NroFactura varchar(50),
	@MontoCompra decimal,
	@IdProveedor int
)

AS
BEGIN

	SET NOCOUNT ON;

update Adquisicion
SET 
FechaAdq = @FechaAdq, 
FechaCompra = @FechaCompra,
NroFactura = @NroFactura,
MontoCompra = @MontoCompra,
IdProveedor = @IdProveedor
WHERE IdAdquisicion = @IdAdquisicion

END


GO
/****** Object:  StoredProcedure [dbo].[AgenteBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AgenteCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AgenteModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AgentesTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AgenteTraerCargoPorDep]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AgenteTraerDependencias]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AsigDetalleCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
	@IdSolicitud int,
	@UIDSolicDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO AsigDetalle(IdAsigDetalle, IdAsignacion, IdInventario, IdSolicitudDetalle, IdSolicitud, UIDSolicDetalle)
VALUES (@IdAsigDetalle, @IdAsignacion, @IdInventario, @IdSolicitudDetalle, @IdSolicitud, @UIDSolicDetalle)



END



GO
/****** Object:  StoredProcedure [dbo].[AsigDetalleEliminar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsigDetalleEliminar]
(
	@IdAsigDetalle int,
	@IdAsignacion int
)


AS
BEGIN

DELETE FROM AsigDetalle
WHERE IdAsigDetalle = @IdAsigDetalle
and IdAsignacion = @IdAsignacion

END



GO
/****** Object:  StoredProcedure [dbo].[AsigDetalleReordenar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsigDetalleReordenar]
(
	@IdAsigDetalle int,
	@IdAsignacion int
)

AS
BEGIN

	SET NOCOUNT ON;

update AsigDetalle
SET IdAsigDetalle = (@IdAsigDetalle-1)
WHERE IdAsignacion = @IdAsignacion
and IdAsigDetalle = @IdAsigDetalle

END



GO
/****** Object:  StoredProcedure [dbo].[AsigDetallesEliminarTodos]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsigDetallesEliminarTodos]
(
	@IdAsignacion INT
)


AS
BEGIN

	SET NOCOUNT ON;

DELETE from AsigDetalle
WHERE IdAsignacion = @IdAsignacion


END



GO
/****** Object:  StoredProcedure [dbo].[AsigDetallesTraer]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsigDetallesTraer]
(
	@IdAsignacion INT
	
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT *
FROM AsigDetalle adet
Where IdAsignacion = @IdAsignacion



END



GO
/****** Object:  StoredProcedure [dbo].[AsignacionBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignacionCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignacionEliminar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsignacionEliminar]
(
	@IdAsignacion INT
)


AS
BEGIN

DELETE from Asignacion
WHERE IdAsignacion = @IdAsignacion


END



GO
/****** Object:  StoredProcedure [dbo].[AsignacionModificar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AsignacionModificar]
(
	@Fecha Datetime,
	@IdAsignacion int

)

AS
BEGIN

	SET NOCOUNT ON;

update Asignacion
SET Fecha = @Fecha
WHERE IdAsignacion = @IdAsignacion

END


GO
/****** Object:  StoredProcedure [dbo].[AsignacionTraerBienesAsignados]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[BaseDatosRespaldar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[BienCrear]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BienCrear]
(
	@IdCategoria INT,
	@IdMarca INT,
	@IdModeloVersion INT
)

AS
BEGIN

INSERT INTO Bien (IdCategoria, IdMarca, IdModeloVersion) VALUES (@IdCategoria, @IdMarca, @IdModeloVersion)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[BienTraerIdPorDescripMarcaModelo]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[BitacoraLogCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[BitacoraVerLogs]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CargosTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CargosTraerTodosPorIdioma]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaDetBienesTraerPorIdPartida]    Script Date: 30/07/2019 23:35:45 ******/
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

select cat.DescripCategoria, sdet.Cantidad, cat.IdCategoria, sdet.IdSolicitud, sdet.IdSolicitudDetalle, sdet.UIDSolicDetalle --, tipo.DescripTipoBien
from PartidaDetalle pdet
INNER JOIN SolicDetalle sdet
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle and sdet.UIDSolicDetalle = pdet.UIDSolicDetalle
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
and par.Cancelada = 0


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
/****** Object:  StoredProcedure [dbo].[CategoriaEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaProvAsociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaProvDesasociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaReactivar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerIdCatPorIdBien]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoriaTraerIdCatPorIdBien]
(
	@IdBien INT
)


AS
BEGIN

select cat.IdCategoria
FROM Categoria cat
WHERE cat.IdCategoria in
	(
	 SELECT bi.IdCategoria
	 FROM Bien bi
	 Where bi.IdBien = @IdBien
	)

END



GO
/****** Object:  StoredProcedure [dbo].[CategoriaTraerProveedores]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosActivos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHard]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosHardActivos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoft]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CategoriaTraerTodosSoftActivos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ConfigMailHostTraer]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CotiSolicDetDesasociar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotiSolicDetDesasociar]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@IdCotizacion int,
	@UIDSolicDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelCotSolDetalle
WHERE IdCotizacion = @IdCotizacion
and IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicitudDetalle
and UIDSolicDetalle = @UIDSolicDetalle

END



GO
/****** Object:  StoredProcedure [dbo].[CotiSolicDetDesasociarPorIdSolDet]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotiSolicDetDesasociarPorIdSolDet]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@UIDSolicDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelCotSolDetalle
WHERE IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicitudDetalle
and UIDSolicDetalle = @UIDSolicDetalle

END



GO
/****** Object:  StoredProcedure [dbo].[CotizacionConteo]    Script Date: 30/07/2019 23:35:45 ******/
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

select IdSolicitudDetalle, ISNULL(COUNT(IdCotizacion),0) as Cotizaciones
from RelCotSolDetalle
WHERE IdSolicitud = @IdSolicitud
group by IdSolicitudDetalle

END



GO
/****** Object:  StoredProcedure [dbo].[CotizacionCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionCrearRelSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionCrearRelSolicDetalle]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@IdCotizacion int,
	@UIDSolicDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelCotSolDetalle(IdSolicitudDetalle, IdSolicitud, IdCotizacion, UIDSolicDetalle)
VALUES (@IdSolicitudDetalle, @IdSolicitud, @IdCotizacion, @UIDSolicDetalle)

END



GO
/****** Object:  StoredProcedure [dbo].[CotizacionEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
ON Rel.IdSolicitud = Det.IdSolicitud AND Rel.IdSolicitudDetalle = Det.IdSolicitudDetalle AND Rel.UIDSolicDetalle = Det.UIDSolicDetalle
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
WHERE Sol.IdSolicitud = @IdSolicitud

END



GO
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorSolicitudYDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionTraerPorSolicitudYDetalle]
(
	@IdSolicitudDetalle int,
	@IdSolicitud int,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Det.IdSolicitudDetalle, Det.IdSolicitud, Det.UIDSolicDetalle
from Cotizacion Coti
INNER JOIN Proveedor Prov
ON Coti.IdProveedor = Prov.IdProveedor
INNER JOIN RelCotSolDetalle Rel
ON Coti.IdCotizacion = Rel.IdCotizacion
INNER JOIN SolicDetalle Det
ON Rel.IdSolicitud = Det.IdSolicitud AND Rel.IdSolicitudDetalle = Det.IdSolicitudDetalle AND Rel.UIDSolicDetalle = Det.UIDSolicDetalle
INNER JOIN Solicitud Sol
ON Det.IdSolicitud = Sol.IdSolicitud
WHERE Sol.IdSolicitud = @IdSolicitud
AND Det.IdSolicitudDetalle = @IdSolicitudDetalle
AND Det.UIDSolicDetalle = @UIDSolicDetalle

END



GO
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorUIDPartidaDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[CotizacionTraerPorUIDSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizacionTraerPorUIDSolicDetalle]
(
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

select Coti.IdCotizacion, Coti.MontoCotizado, Coti.FechaCotizacion, Prov.IdProveedor, Prov.AliasProv, Det.IdSolicitudDetalle, Det.IdSolicitud, Det.UIDSolicDetalle
from Cotizacion Coti
INNER JOIN Proveedor Prov
ON Coti.IdProveedor = Prov.IdProveedor
INNER JOIN RelCotSolDetalle Rel
ON Coti.IdCotizacion = Rel.IdCotizacion
INNER JOIN SolicDetalle Det
ON Rel.IdSolicitud = Det.IdSolicitud AND Rel.IdSolicitudDetalle = Det.IdSolicitudDetalle AND Rel.UIDSolicDetalle = Det.UIDSolicDetalle
WHERE Det.UIDSolicDetalle = @UIDSolicDetalle



END



GO
/****** Object:  StoredProcedure [dbo].[CotizTraerRelPartDet]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CotizTraerRelPartDet]
(
	@IdCotizacion int
)


AS
BEGIN

	SET NOCOUNT ON;

select distinct IdCotizacion
from RelCotizPartDetalle
WHERE IdCotizacion = @IdCotizacion


END



GO
/****** Object:  StoredProcedure [dbo].[DependenciaAgenteAgregar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaAgentesQuitarLista]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaModifNombre]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaModifTipoDep]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaReactivar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesPorIdDependencia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerAgentesResp]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerNombrePorIDSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DependenciaTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DepositoTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DireccionCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DireccionProvinciaTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DireccionTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DVActualizarDVH]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DVActualizarDVV]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DVTraerDVHSuma]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[DVTraerDVV]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoInvTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolDetallesTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[EstadoSolicitudTraerTodosPorIdioma]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[EtiquetasTraerTodosPorIdioma]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[EtiquetaTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaEliminarAsocFamilias]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaEliminarAsocPatentes]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaFamiliaAsociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaFamiliaDesasociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteAsociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteDesasociar]    Script Date: 30/07/2019 23:35:45 ******/
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
and IdPatente = @IdPatente

END



GO
/****** Object:  StoredProcedure [dbo].[FamiliasTraerTodas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FamiliasTraerTodas]
AS
	SELECT fam.IdFamilia, fam.NombreFamilia
	FROM Familia fam
	
	



GO
/****** Object:  StoredProcedure [dbo].[FamiliaTraerFamiliasHijas]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaTraerPatentes]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaUsuariosAsociados]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FamiliaUsuariosComprometidos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaActualizarIdiomaDefault]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaCrear]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdiomaCrear]
(
	@NombreIdioma varchar(30)
)

AS
BEGIN

INSERT INTO Idioma(NombreIdioma, ElIdiomaDefault)
VALUES (@NombreIdioma, 0)

SELECT SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[IdiomaTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[IdiomaUsuarioActualModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[InvAdquiridosPorUIDPartidaDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvAdquiridosPorUIDPartidaDetalle]
(
	@UIDPartidaDetalle INT
)


AS
BEGIN

	SET NOCOUNT OFF;

select COUNT(rel.IdInventario) as Comprado
from relpdetadq rel
WHERE UIDPartidaDetalle = @UIDPartidaDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioAdquiridoCantPorPartDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
INNER JOIN Partida par ON par.IdPartida = pdet.IdPartida
LEFT JOIN SolicDetalle sdet
ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle AND pdet.UIDSolicDetalle = sdet.UIDSolicDetalle
WHERE pdet.IdPartida = @IdPartida2
--and sdet.IdEstadoSolicDetalle != 2--Distinto a finalizado 30/10/2017 Comente esto para probar
and par.Cancelada = 0
group by sdet.IdSolicitudDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioEliminar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioEliminar]
(
	@IdInventario INT
)

AS
BEGIN

DELETE FROM Inventario
WHERE IdInventario = @IdInventario


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioEntregadoPorSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioEntregadoPorSolicDetalle]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle INT,
	@UIDSolicDetalle INT
)


AS
BEGIN


select count(asigdet.IdAsigDetalle) as Entregado 
FROM AsigDetalle asigdet
WHERE IdSolicitud = @IdSolicitud
AND IdSolicitudDetalle = @IdSolicitudDetalle
AND UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioEstadoUpdate]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioEstadoUpdate]
(
	@IdInventario INT,
	@IdEstadoInventario INT
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Inventario
SET IdEstadoInventario = @IdEstadoInventario
WHERE IdInventario = @IdInventario


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioHardCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioHardTraerListosParaAsignar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioHardTraerListosParaAsignar]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle int,
	@UIDSolicDetalle int
	
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

SELECT inv.IdInventario, inv.SerieKey, bi.IdBien, cat.DescripCategoria, ma.DescripMarca, mo.DescripModeloVersion
FROM Inventario inv
INNER JOIN Bien bi
ON inv.IdBienEspecif = bi.IdBien
INNER JOIN Categoria cat ON cat.IdCategoria = bi.IdCategoria
INNER JOIN Marca ma
ON bi.IdMarca = ma.IdMarca
INNER JOIN ModeloVersion mo
ON bi.IdModeloVersion = mo.IdModeloVersion
INNER JOIN RelPDetAdq relpdet
ON relpdet.IdInventario = inv.IdInventario
INNER JOIN PartidaDetalle pdet
ON relpdet.IdPartida = pdet.IdPartida and relpdet.UIDPartidaDetalle = pdet.UIDPartidaDetalle
INNER JOIN SolicDetalle sdet
ON pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle AND pdet.UIDSolicDetalle = sdet.UIDSolicDetalle
WHERE sdet.IdSolicitud = @IdSolicitud
--and sdet.IdEstadoSolicDetalle = @IdEstadoSolicDetalle--Adquirido --COMENTADO 30/10/2017 (AL IGUAL QUE EN LOS PARAMETROS)
and sdet.IdSolicitudDetalle = @IdSolicitudDetalle  
and sdet.UIDSolicDetalle = @UIDSolicDetalle
and inv.IdEstadoInventario = 1--Disponible
and sdet.IdEstadoSolicDetalle = 7 --Rendido


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioModificar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioModificar]
(
	@IdInventario INT,
	@IdBien INT,
	@SerieKey nvarchar(300),
	@Costo decimal,
	@MontoCompra decimal,
	@IdAdquisicion int
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE Inventario
SET IdBienEspecif = @IdBien,
    SerieKey = @SerieKey,
	Costo = @Costo
WHERE IdInventario = @IdInventario

UPDATE Adquisicion
set MontoCompra = @MontoCompra
where IdAdquisicion = @IdAdquisicion


END



GO
/****** Object:  StoredProcedure [dbo].[InventarioSoftCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[InventariosTraerListosParaAsignarPorSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[InventarioTraerEstadoPorIdInventario]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InventarioTraerEstadoPorIdInventario]
(
	@IdInventario INT
)

AS
BEGIN

SELECT est.IdEstadoInventario, est.DescripEstadoInv
FROM EstadoInventario est
INNER JOIN Inventario inv ON inv.IdEstadoInventario = est.IdEstadoInventario
WHERE inv.IdInventario = @IdInventario


END



GO
/****** Object:  StoredProcedure [dbo].[MarcaCrear]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MarcaCrear]
(
	@DescripMarca varchar(200)
)

AS
BEGIN

INSERT INTO Marca VALUES (@DescripMarca)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[MarcaTraerPorIdCategoria]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ModeloCrear]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModeloCrear]
(
	@DescripModelo varchar(300)
)

AS
BEGIN

INSERT INTO ModeloVersion VALUES (@DescripModelo)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[ModeloTraerPorMarcaCategoria]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ModificarMailConfig]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModificarMailConfig]
(
	@unMail varchar(300),
	@unPass nvarchar(300),
	@unPuerto int,
	@unHost varchar(50),
	@unSSL bit
	
)

AS
BEGIN

UPDATE ConfigMailHost
SET Remitente = @unMail, 
	Remps = @unPass,
	Puerto = @unPuerto,
	Host = @unHost,
	Ssl = @unSSL

END



GO
/****** Object:  StoredProcedure [dbo].[NotaCrear]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NotaCrear]
(
	@FechaNota datetime,
	@DescripNota varchar(500),
	@IdUsuario int,
	@IdSolicitud int
)

AS
BEGIN

INSERT INTO Nota(FechaNota, DescripNota, IdUsuario, IdSolicitud)
VALUES (@FechaNota, @DescripNota, @IdUsuario, @IdSolicitud)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[NuevoTextoIdioma]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NuevoTextoIdioma]
(
	@NombreControl nvarchar(300),
	@Texto varchar(200),
	@IdIdioma int
)

AS
BEGIN

INSERT INTO Etiqueta Values(@NombreControl, @Texto, @IdIdioma)

END



GO
/****** Object:  StoredProcedure [dbo].[ObtenerNombreAdjuntoCotiz]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerNombreAdjuntoCotiz]
(
	@IdCotizacion INT
)


AS
BEGIN

SELECT ad.Nombre
FROM Adjunto ad
Where ad.IdAdjunto =
	(
		SELECT coti.IdAdjunto
		FROM Cotizacion coti
		WHERE coti.IdCotizacion = @IdCotizacion
	)

END



GO
/****** Object:  StoredProcedure [dbo].[ObtenerNombreAdjuntoSolic]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerNombreAdjuntoSolic]
(
	@IdSolicitud INT
)


AS
BEGIN

SELECT ad.Nombre
FROM Adjunto ad
Where ad.IdAdjunto =
	(
		SELECT sol.IdAdjunto
		FROM Solicitud sol
		WHERE sol.IdSolicitud = @IdSolicitud
	)

END



GO
/****** Object:  StoredProcedure [dbo].[obtenerRutaAdjuntos]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerRutaAdjuntos]

AS

SET NOCOUNT OFF

SELECT ru.DescripRuta
FROM Ruta ru
Where ru.IdRuta = 1




GO
/****** Object:  StoredProcedure [dbo].[obtenerRutaDocumentos]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerRutaDocumentos]

AS

SELECT ru.DescripRuta
FROM Ruta ru
Where ru.IdRuta = 3




GO
/****** Object:  StoredProcedure [dbo].[obtenerRutaPlantillas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerRutaPlantillas]

AS

SELECT ru.DescripRuta
FROM Ruta ru
Where ru.IdRuta = 2




GO
/****** Object:  StoredProcedure [dbo].[PartidaAsociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaCancelar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaCancelar]
(
	@IdPartida int
)


AS
BEGIN

update Partida
set Cancelada = 1
where IdPartida = @IdPartida

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaCrear]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaCrear]
(
	@FechaEnvio Datetime,
	@MontoSolicitado money
	--@MontoOtorgado money,
	--@FechaAcreditacion Datetime,
	--@NroPartida varchar(10)
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO Partida (FechaEnvio, MontoSolicitado, Cancelada)
VALUES (@FechaEnvio, @MontoSolicitado, 0)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleCrearSinCotiz]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaDetalleCrearSinCotiz]
(
	@IdPartidaDetalle int,
	@IdPartida int,
	@IdSolicitud int,
	@IdSolicitudDetalle int,
	@UIDSolicDetalle int
)

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO PartidaDetalle (IdPartidaDetalle, IdPartida, IdSolicitud, IdSolicitudDetalle, UIDSolicDetalle)
VALUES (@IdPartidaDetalle, @IdPartida, @IdSolicitud, @IdSolicitudDetalle, @UIDSolicDetalle)
select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleTraerTodosPorNroPart]    Script Date: 30/07/2019 23:35:45 ******/
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

SELECT dpar.UIDPartidaDetalle, dpar.IdPartidaDetalle, dpar.IdPartida, dsol.IdSolicitud, dsol.IdSolicitudDetalle, Cat.DescripCategoria, dsol.Cantidad, dSol.UIDSolicDetalle
FROM PartidaDetalle dPar
INNER JOIN SolicDetalle dSol
ON dpar.IdSolicitud = dsol.IdSolicitud and dpar.IdSolicitudDetalle = dsol.IdSolicitudDetalle AND dpar.UIDSolicDetalle = dsol.UIDSolicDetalle
INNER JOIN Categoria Cat
ON dSol.IdCategoria = Cat.IdCategoria
WHERE IdPartida = @IdPartida

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaDetalleUIDPorIdCategoriaIdPartida]    Script Date: 30/07/2019 23:35:45 ******/
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
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle AND sdet.UIDSolicDetalle = pdet.UIDSolicDetalle
Where pdet.IdPartida = @IdPartida
and cat.IdCategoria = @IdCategoria

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaEliminar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaEliminar]
(
	@IdPartida INT
)


AS
BEGIN

	
DELETE FROM Partida
Where IdPartida = @IdPartida


END



GO
/****** Object:  StoredProcedure [dbo].[PartidaModEliminarDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaModifDetalles]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidaModifMontoSolic]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidasBuscarPorIdSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
and par.Cancelada = 0

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaTraerIDSiPuedeRendirse]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaTraerIDSiPuedeRendirse]
(
	@IdPartida INT
)


AS
BEGIN

select distinct pdet.IdPartida
FROM SolicDetalle sdet
INNER JOIN PartidaDetalle pdet ON pdet.UIDSolicDetalle = sdet.UIDSolicDetalle and pdet.IdSolicitud = sdet.IdSolicitud and pdet.IdSolicitudDetalle = sdet.IdSolicitudDetalle
where (sdet.IdEstadoSolicDetalle = 5 or sdet.IdEstadoSolicDetalle = 6) --Adquirido y Entregado
and IdPartida = @IdPartida
 
END



GO
/****** Object:  StoredProcedure [dbo].[PartidaTraerPorNroPart]    Script Date: 30/07/2019 23:35:45 ******/
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
and Cancelada = 0

END



GO
/****** Object:  StoredProcedure [dbo].[PartidaTraerPorNroPartConCanceladas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidaTraerPorNroPartConCanceladas]
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
/****** Object:  StoredProcedure [dbo].[PatentesTraerTodas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PatentesTraerTodas]
AS
	SELECT pat.IdPatente, pat.NombrePatente
	FROM Patente pat
	
	



GO
/****** Object:  StoredProcedure [dbo].[PoliticaPorDepYCategCantidad]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PoliticaTraerPorTipoDepYCat]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[PrioridadTraerTodosPorIdioma]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorDireAsociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorDireDesasociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorReactivar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTelAsociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTelDesasociar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerCategorias]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerDirecciones]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTelefonos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[ProveedorTraerTodosActivos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Prueba]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarAdjunto]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarAdjunto]
(
	@Nombre nvarchar(50)
)

AS
BEGIN


INSERT INTO Adjunto(IdRuta, Nombre)
VALUES (1, @Nombre)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[RelCotizPartDetalleCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RelCotSolDetalleDeletePorIdSolicitud (No utilizada)]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelCotSolDetalleDeletePorIdSolicitud (No utilizada)]
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
/****** Object:  StoredProcedure [dbo].[RelDepAgenteCargoCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RelPDetAdqCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RelPdetAdqEliminar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelPdetAdqEliminar]
(
	@IdAdquisicion INT,
	@IdInventario INT
)

AS
BEGIN

DELETE FROM RelPDetAdq
WHERE IdAdquisicion = @IdAdquisicion
and IdInventario = @IdInventario


END



GO
/****** Object:  StoredProcedure [dbo].[RelPdetAdqEliminarTodosPorIdAdq]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelPdetAdqEliminarTodosPorIdAdq]
(
	@IdAdquisicion INT
)

AS
BEGIN

DELETE FROM RelPDetAdq
WHERE IdAdquisicion = @IdAdquisicion



END



GO
/****** Object:  StoredProcedure [dbo].[RelPDetAdqPartidaTieneAdq]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteAgregar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelSolDetalleAgenteAgregar]
(
	@IdSolicitudDetalle INT,
	@IdSolicitud INT,
	@IdAgente INT,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO RelSolDetalleAgente (IdSolicitudDetalle, IdSolicitud, IdAgente, UIDSolicDetalle)
VALUES (@IdSolicitudDetalle, @IdSolicitud, @IdAgente, @UIDSolicDetalle)



END



GO
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RelSolDetalleAgenteEliminarPorSolDet]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RelSolDetalleAgenteEliminarPorSolDet]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle INT,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

DELETE FROM RelSolDetalleAgente
WHERE IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicitudDetalle
and UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[RendicionBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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


SELECT distinct ren.IdRendicion, ren.MontoGasto, ren.IdPartida, ren.FechaRen
FROM Rendicion ren
INNER JOIN Partida par ON par.IdPartida = ren.IdPartida
INNER JOIN PartidaDetalle pdet ON pdet.IdPartida = par.IdPartida
INNER JOIN SolicDetalle sdet ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle AND sdet.UIDSolicDetalle = pdet.UIDSolicDetalle
INNER JOIN Solicitud sol ON sol.IdSolicitud = sdet.IdSolicitud
INNER JOIN Dependencia dep ON dep.IdDependencia = sol.IdDependencia
WHERE (ren.IdRendicion = @IdRendicion OR @IdRendicion IS NULL)
and (par.IdPartida = @IdPartida OR @IdPartida IS NULL)
and (sol.IdSolicitud = @IdSolicitud OR @IdSolicitud IS NULL)
and (UPPER(dep.NombreDependencia) LIKE UPPER('%' + @NombreDependencia + '%') OR @NombreDependencia IS NULL)

END



GO
/****** Object:  StoredProcedure [dbo].[RendicionCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[RendicionTraerIdRendPorIdPartida]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleCantidadPorUIDSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleCantidadPorUIDSolicDetalle]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle INT,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT sdet.Cantidad
FROM SolicDetalle sdet
WHERE sdet.IdSolicitud = @IdSolicitud
and sdet.IdSolicitudDetalle = @IdSolicitudDetalle
and sdet.UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetalleDeletePorSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleEliminarPorId]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleEliminarPorId]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle INT,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

DELETE from SolicDetalle
WHERE IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicitudDetalle
and UIDSolicDetalle = @UIDSolicDetalle

update SolicDetalle
set IdSolicitudDetalle = (IdSolicitudDetalle-1)
where IdSolicitudDetalle > @IdSolicitudDetalle
and IdSolicitud = @IdSolicitud
and UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetalleModificar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleModificar]
(
	@IdSolicitud INT,
	@IdSolicitudDetalle int,
	@Cantidad int,
	@IdCategoria int,
	@UIDSolicDetalle int
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE SolicDetalle
SET Cantidad = @Cantidad,
    IdCategoria = @IdCategoria
WHERE IdSolicitud = @IdSolicitud 
and IdSolicitudDetalle = @IdSolicitudDetalle
and UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetallePartidaDetalleAsociacionTraer]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallePartidaDetalleAsociacionTraer]
(
	@IdSolicitud INT,
	@IdSolicDetalle INT,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT dpar.UIDPartidaDetalle, dpar.IdPartidaDetalle, dpar.IdPartida, dpar.IdSolicitud, dpar.IdSolicitudDetalle, dpar.UIDSolicDetalle
FROM PartidaDetalle dPar
INNER JOIN Partida par ON dPar.IdPartida = par.IdPartida
WHERE dpar.IdSolicitud = @IdSolicitud 
AND dpar.IdSolicitudDetalle = @IdSolicDetalle 
AND dpar.UIDSolicDetalle = @UIDSolicDetalle
and par.Cancelada = 0

END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetallePartidaDetalleAsociacionTraerSinFiltro]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallePartidaDetalleAsociacionTraerSinFiltro]
(
	@IdSolicitud INT,
	@IdSolicDetalle INT,
	@UIDSolicDetalle INT
)


AS
BEGIN

	SET NOCOUNT ON;

SELECT dpar.UIDPartidaDetalle, dpar.IdPartidaDetalle, dpar.IdPartida, dpar.IdSolicitud, dpar.IdSolicitudDetalle, dpar.UIDSolicDetalle
FROM PartidaDetalle dPar
WHERE dpar.IdSolicitud = @IdSolicitud 
AND dpar.IdSolicitudDetalle = @IdSolicDetalle
and dpar.UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetallePorUIDUpdateEstado]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallePorUIDUpdateEstado]
(
	@UIDSolicDetalle int,
	@NuevoEstado int
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE SolicDetalle
SET IdEstadoSolicDetalle = @NuevoEstado
WHERE UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetalleReordenar]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleReordenar]
(
	@IdSolicitud int,
	@IdSolicitudDetalle int,
	@UIDSolicDetalle int
)

--NO LO USO MAS a este STORE
AS
BEGIN

	SET NOCOUNT ON;

update SolicDetalle
SET IdSolicitudDetalle = (@IdSolicitudDetalle-1)
WHERE IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicitudDetalle
and UIDSolicDetalle = @UIDSolicDetalle

END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerAgentesAsociados]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetallesTraerAgentesAsociados]
(
	@IdSolicDetalle INT,
	@IdSolicitud INT,
	@UIDSolicDetalle INT
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
		and rel.UIDSolicDetalle = @UIDSolicDetalle
	)



END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetallesTraerPorNroSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicDetalleTraerEnEstadoAdquirido]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleTraerEnEstadoAdquirido]
(
	@IdSolicitud INT
)


AS
BEGIN

select distinct sdet.IdSolicitud
FROM SolicDetalle sdet
where sdet.IdEstadoSolicDetalle = 5 --Adquirido
and IdSolicitud =@IdSolicitud

END



GO
/****** Object:  StoredProcedure [dbo].[SolicDetalleUpdateEstado]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicDetalleUpdateEstado]
(
	@IdSolicitud INT,
	@IdSolicDetalle int,
	@NuevoEstado int,
	@UIDSolicDetalle int
)


AS
BEGIN

	SET NOCOUNT ON;

UPDATE SolicDetalle
SET IdEstadoSolicDetalle = @NuevoEstado --Todos los bienes del detalle fueron Adquiridos (un 3 debería ser)
WHERE IdSolicitud = @IdSolicitud
and IdSolicitudDetalle = @IdSolicDetalle
and UIDSolicDetalle = @UIDSolicDetalle


END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudBuscar]    Script Date: 30/07/2019 23:35:45 ******/
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
and sol.IdEstado != 3 --Distinto de Cancelada

END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudBuscarConCanceladas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudBuscarConCanceladas]
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
/****** Object:  StoredProcedure [dbo].[SolicitudCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
	
INSERT INTO Solicitud (FechaInicio, IdDependencia,  IdPrioridad, IdEstado, IdUsuario, IdAgente)
VALUES (@FechaInicio, @IdDependencia, @IdPrioridad, @IdEstado, @IdUsuario, @IdAgente)

select SCOPE_IDENTITY()

END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudDetalleCrear]    Script Date: 30/07/2019 23:35:45 ******/
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

INSERT INTO SolicDetalle(IdSolicitudDetalle, IdSolicitud, IdCategoria, Cantidad, IdEstadoSolicDetalle)
VALUES (@IdSolicitudDetalle, @IdSolicitud, @IdCategoria, @Cantidad, @IdEstadoSolDetalle)

select SCOPE_IDENTITY()


END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudModificar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudTraerDatosDVV]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudTraerEstadoPorIdRendicion]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerEstadoPorIdRendicion]
(
	@IdRendicion INT
)


AS
BEGIN


select sol.IdEstado
from Rendicion ren
INNER JOIN Partida par 
ON par.IdPartida = ren.IdPartida
INNER JOIN PartidaDetalle pdet 
ON pdet.IdPartida = par.IdPartida
INNER JOIN SolicDetalle sdet 
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle and sdet.UIDSolicDetalle = pdet.UIDSolicDetalle
INNER JOIN Solicitud sol 
ON sdet.IdSolicitud = sol.IdSolicitud
where ren.IdRendicion = @IdRendicion


END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerIdsolNomdepPorIdPartida]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[SolicitudTraerNotas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerNotas]
(
	@IdSolicitud int
)

AS
BEGIN

SELECT * from Nota
Where IdSolicitud = @IdSolicitud


END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerPorNroSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
and sol.IdEstado != 3 --Cancelada

END



GO
/****** Object:  StoredProcedure [dbo].[SolicitudTraerPorNroSolicitudConCanceladas]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudTraerPorNroSolicitudConCanceladas]
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
/****** Object:  StoredProcedure [dbo].[SolicitudUpdateEstado]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SolicitudUpdateEstado]
(
	@IdSolicitud int,
	@NuevoEstado int,
	@FechaFin datetime
)


AS
BEGIN

UPDATE Solicitud
SET IdEstado = @NuevoEstado, FechaFin = @FechaFin
WHERE IdSolicitud = @IdSolicitud


END



GO
/****** Object:  StoredProcedure [dbo].[TelefonoCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TelefonoTipoTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TelefonoTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerIDTipoBienPorIdCategoria]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTipoBienPorIdCategoria]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoBienTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoDependenciaTraerPorDependencia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoDepTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[TraerLimitePartida]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioActualizarDVH]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioAgregarFamilia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioAgregarPatente]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioCrear]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioEliminar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioModificarApellido]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioModificarMail]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioModificarNombre]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioModificarNomUs]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioModificarPass]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioQuitarFamilia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioQuitarPatente]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioReactivar]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerDatosPorNomUs]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerFamilias]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPatentes]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerPorLogin]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodosActivos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioTraerTodosDatosCompletos]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioVerificarNomUs]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Adjunto]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adjunto](
	[IdAdjunto] [int] IDENTITY(1,1) NOT NULL,
	[IdRuta] [int] NOT NULL,
	[Nombre] [nvarchar](1000) NOT NULL,
	[Tamaño] [int] NULL,
 CONSTRAINT [PK_Adjunto] PRIMARY KEY CLUSTERED 
(
	[IdAdjunto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Adquisicion]    Script Date: 30/07/2019 23:35:45 ******/
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
	[NroFactura] [varchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[Agente]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[AsigDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
	[UIDSolicDetalle] [int] NULL,
 CONSTRAINT [PK_AsigDetalle] PRIMARY KEY CLUSTERED 
(
	[IdAsigDetalle] ASC,
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Bien]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Cargo]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[ConfigMailHost]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[IdCotizacion] [int] IDENTITY(1,1) NOT NULL,
	[MontoCotizado] [money] NOT NULL,
	[FechaCotizacion] [datetime] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdAdjunto] [int] NULL,
 CONSTRAINT [PK_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dependencia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Deposito]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Direccion]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[DVV]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[EstadoInventario]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[EstadoSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 30/07/2019 23:35:45 ******/
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
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaCargo]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaEstadoInventario]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaEstadoSolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaEstadoSolicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaPrioridad]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaTipoDependencia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[IdiomaTipoTelefono]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Inventario]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Limite]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[ModeloVersion]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Nota]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nota](
	[IdNota] [int] IDENTITY(1,1) NOT NULL,
	[FechaNota] [datetime] NOT NULL,
	[DescripNota] [varchar](500) NOT NULL,
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
/****** Object:  Table [dbo].[Partida]    Script Date: 30/07/2019 23:35:45 ******/
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
	[Cancelada] [int] NOT NULL,
 CONSTRAINT [PK_Partida] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PartidaDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
	[UIDSolicDetalle] [int] NULL,
 CONSTRAINT [PK_PartidaDetalle_1] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC,
	[UIDPartidaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patente]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Politica]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Prioridad]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Provincia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelCatProv]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelCotizPartDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelCotSolDetalle]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelCotSolDetalle](
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdCotizacion] [int] NOT NULL,
	[UIDSolicDetalle] [int] NOT NULL,
 CONSTRAINT [PK_RelCotSolDetalle] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC,
	[IdCotizacion] ASC,
	[UIDSolicDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelDepAgenteCargo]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelFamFam]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelFamPat]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelPDetAdq]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelProveedorDire]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelProveedorTel]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelSolDetalleAgente]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelSolDetalleAgente](
	[IdSolicitudDetalle] [int] NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdAgente] [int] NOT NULL,
	[UIDSolicDetalle] [int] NOT NULL,
 CONSTRAINT [PK_RelSolDetalleAgente] PRIMARY KEY CLUSTERED 
(
	[IdSolicitudDetalle] ASC,
	[IdSolicitud] ASC,
	[IdAgente] ASC,
	[UIDSolicDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelUsuFam]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[RelUsuPat]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Rendicion]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Ruta]    Script Date: 30/07/2019 23:35:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruta](
	[IdRuta] [int] IDENTITY(1,1) NOT NULL,
	[DescripRuta] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Ruta] PRIMARY KEY CLUSTERED 
(
	[IdRuta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolicDetalle]    Script Date: 30/07/2019 23:35:45 ******/
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
	[IdSolicitud] ASC,
	[UIDSolicDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 30/07/2019 23:35:45 ******/
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
	[IdAdjunto] [int] NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[TipoBien]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[TipoDependencia]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[TipoTelefono]    Script Date: 30/07/2019 23:35:45 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/07/2019 23:35:45 ******/
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
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Adquisicion]    Script Date: 30/07/2019 23:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_Adquisicion] ON [dbo].[Adquisicion]
(
	[NroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Inventario]    Script Date: 30/07/2019 23:35:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Inventario] ON [dbo].[Inventario]
(
	[IdBienEspecif] ASC,
	[SerieKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adjunto]  WITH CHECK ADD  CONSTRAINT [FK_Adjunto_Ruta] FOREIGN KEY([IdRuta])
REFERENCES [dbo].[Ruta] ([IdRuta])
GO
ALTER TABLE [dbo].[Adjunto] CHECK CONSTRAINT [FK_Adjunto_Ruta]
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
ALTER TABLE [dbo].[AsigDetalle]  WITH CHECK ADD  CONSTRAINT [FK_AsigDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
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
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Cotizacion_Adjunto] FOREIGN KEY([IdAdjunto])
REFERENCES [dbo].[Adjunto] ([IdAdjunto])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_Cotizacion_Adjunto]
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
ALTER TABLE [dbo].[PartidaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PartidaDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
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
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RelCotizPartDetalle] CHECK CONSTRAINT [FK_RelCotizPartDetalle_PartidaDetalle]
GO
ALTER TABLE [dbo].[RelCotSolDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotSolDetalle_Cotizacion] FOREIGN KEY([IdCotizacion])
REFERENCES [dbo].[Cotizacion] ([IdCotizacion])
GO
ALTER TABLE [dbo].[RelCotSolDetalle] CHECK CONSTRAINT [FK_RelCotSolDetalle_Cotizacion]
GO
ALTER TABLE [dbo].[RelCotSolDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RelCotSolDetalle_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
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
ALTER TABLE [dbo].[RelSolDetalleAgente]  WITH CHECK ADD  CONSTRAINT [FK_RelSolDetalleAgente_SolicDetalle] FOREIGN KEY([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
REFERENCES [dbo].[SolicDetalle] ([IdSolicitudDetalle], [IdSolicitud], [UIDSolicDetalle])
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
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Adjunto] FOREIGN KEY([IdAdjunto])
REFERENCES [dbo].[Adjunto] ([IdAdjunto])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Adjunto]
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
