use Artec
go

create table Solicitud 
(
	IdSolicitud INT not null identity (1,1),
	FechaInicio datetime not null,
	FechaFin datetime,
	IdDependencia INT not null,
	IdPrioridad int not null,
	IdResponsable int not null,
	IdEstado int not null,
	CONSTRAINT [PK_Solicitud] primary key (IdSolicitud)
)

create table Nota
(
	IdNota int not null identity(1,1),
	FechaNota datetime not null,
	DescripNota varchar(500),
	IdUsuario int not null,
	Constraint [PK_Nota] primary key (IdNota)
)


alter table Nota
add IdSolicitud int not null


create table Cargo
(
	IdCargo int not null identity(1,1),
	DescripCargo varchar(100) not null,
	Constraint [PK_Cargo] primary key (IdCargo)
)



create table Agente
(
	IdAgente int not null identity(1,1),
	NombreAgente varchar(300) not null,
	ApellidoAgente varchar(300) not null,
	Constraint [PK_Agente] primary key (IdAgente)
)

create table Dependencia
(
	IdDependencia int not null identity(1,1),
	NombreDependencia varchar(300) not null,
	Constraint [PK_Dependencia] primary key (IdDependencia)
)


create table EstadoSolicitud
(
	IdEstadoSolicitud int not null identity(1,1),
	DescripEstadoSolic varchar(50) not null,
	Constraint [PK_EstadoSolicitud] primary key (IdEstadoSolicitud)
)



create table EstadoSolDetalle
(
	IdEstadoSolDetalle int not null identity(1,1),
	DescripSolDetalle varchar(50) not null,
	Constraint [PK_EstadoSolDetalle] primary key (IdEstadoSolDetalle)
)



create table Prioridad
(
	IdPrioridad int not null identity(1,1),
	DescripPrioridad varchar(20) not null,
	Constraint [PK_Prioridad] primary key (IdPrioridad)
)


--Eliminarla
create table TipoBien
(
	IdTipoBien int not null identity(1,1),
	DescripTipoBien varchar(300) not null,
	Constraint [PK_TipoBien] primary key (IdTipoBien)
)


create table Categoria
(
	IdCategoria int not null identity(1,1),
	DescripCategoria varchar(20) not null,
	Constraint [PK_Categoria] primary key (IdCategoria)
)



create table SubCategoria
(
	IdSubCategoria int not null identity(1,1),
	DescripSubcategoria varchar(300) not null,
	IdCategoria int not null,
	Constraint [PK_SubCategoria] primary key (IdSubCategoria)
)



create table Bien
(
	IdBien int not null identity(1,1),
	IdSubCategoria int not null,
	DescripBien varchar(300) not null,
	Homologado bit not null,
	IdTipoLicencia int not null,
	IdMarca int not null,
	IdModeloVersion int null,
	Constraint [PK_Bien] primary key (IdBien)
)


create table Inventario
(
	IdInventario int not null identity(1,1),
	IdBien int not null,
	SerialMaster nvarchar (300) null,
	SerieKey nvarchar (300) not null,
	FechaSuscrip datetime null,
	FechaFinSuscrip datetime null,
	IdIngreso int not null,
	IdDeposito int not null,
	IdEstado int not null,
	DescripTipoBien varchar(300) not null,
	Constraint [PK_Inventario] primary key (IdInventario, IdBien)
)



create table Asignacion
(
	IdAsignacion int not null identity(1,1),
	Fecha datetime not null,
	Constraint [PK_Asignacion] primary key (IdAsignacion)
)

alter table Asignacion
add IdDependencia int not null


create table AsigDetalle
(
	IdAsigDetalle int not null identity(1,1),
	IdAsignacion int not null,
	IdInventario int not null,
	IdSolicDetalle int null,
	IdTipoAsignacion int not null,
	IdAgente int null,
	Observacion varchar(300) null,
	TiempoAsignacion int null,
	Constraint [PK_AsigDetalle] primary key (IdAsigDetalle, IdAsignacion)
)



create table TipoAsignacion
(
	IdTipoAsignacion int not null identity(1,1),
	DescripTipoAsig varchar(100) not null,
	Constraint [PK_TipoAsignacion] primary key (IdTipoAsignacion)
)


create table Marca
(
	IdMarca int not null identity(1,1),
	DescripMarca varchar(200) not null,
	Constraint [PK_Marca] primary key (IdMarca)
)


create table ModeloVersion
(
	IdModeloVersion int not null identity(1,1),
	DescripModeloVersion varchar(300) not null,
	Constraint [PK_ModeloVersion] primary key (IdModeloVersion)
)



create table EstadoInventario
(
	IdEstadoInventario int not null identity(1,1),
	DescripEstadoInv varchar(50) not null,
	Constraint [PK_EstadoInventario] primary key (IdEstadoInventario)
)


create table Deposito
(
	IdDeposito int not null identity(1,1),
	NombreDeposito varchar(100) not null,
	Direccion varchar(500) not null,
	Constraint [PK_Deposito] primary key (IdDeposito)
)


create table Adquisicion
(
	IdAdquisicion int not null identity(1,1),
	FechaAdq datetime not null,
	FechaCompra datetime not null,
	NroFactura varchar(50) null,
	NroExpediente varchar(50) null,
	NroOrdenCompra varchar(50) null,
	RutaDocumentos nvarchar(500) null,
	MontoCompra money null,
	IdTipoAdquisicion int not null,
	IdRendicion int null,
	IdProveedor int not null,
	Constraint [PK_Adquisicion] primary key (IdAdquisicion)
)


create table TipoAdquisicion
(
	IdTipoAdquisicion int not null identity(1,1),
	DescripTipoAdq varchar(100) not null,
	Constraint [PK_TipoAdquisicion] primary key (IdTipoAdquisicion)
)


create table Proveedor
(
	IdProveedor int not null identity(1,1),
	NombreProveedor varchar(100) not null,
	ContactoProveedor varchar(100) null,
	MailProveedor nvarchar(200) null,
	Constraint [PK_Proveedor] primary key (IdProveedor)
)


create table Telefono
(
	IdTelefono int not null identity(1,1),
	CodArea int not null,
	NroTelefono int not null,
	IdTipoTelefono int not null,
	Constraint [PK_Telefono] primary key (IdTelefono)
)


create table TipoTelefono
(
	IdTipoTelefono int not null identity(1,1),
	DescripTipoTel varchar(50) not null,
	Constraint [PK_TipoTelefono] primary key (IdTipoTelefono)
)


create table Direccion
(
	IdDireccion int not null identity(1,1),
	Calle varchar(100) not null,
	NumeroCalle varchar(100) not null,
	Localidad varchar(100) null,
	IdProvincia int null,
	Constraint [PK_Direccion] primary key (IdDireccion)
)


create table Provincia
(
	IdProvincia int not null identity(1,1),
	NombreProvincia varchar(100) not null,
	Constraint [PK_Provincia] primary key (IdProvincia)
)

create table Cotizacion
(
	IdCotizacion int not null identity(1,1),
	MontoCotizado money not null,
	FechaCotizacion datetime not null,
	IdProveedor int not null,
	Constraint [PK_Cotizacion] primary key (IdCotizacion)
)


create table Partida
(
	IdPartida int not null identity(1,1),
	MontoSolicitado money not null,
	MontoOtorgado money null,
	NroPartida varchar(10) null,
	FechaEnvio datetime not null,
	FechaAcreditacion datetime null,
	Constraint [PK_Partida] primary key (IdPartida)
)


create table PartidaDetalle
(
	IdPartidaDetalle int not null identity(1,1),
	IdPartida int not null,
	IdSolicDetalle int not null,
	IdAdquisicion int null,
	Constraint [PK_PartidaDetalle] primary key (IdPartidaDetalle, IdPartida)
)


create table Rendicion
(
	IdRendicion int not null identity(1,1),
	MontoGasto money not null,
	IdPartida int not null,
	Constraint [PK_Rendicion] primary key (IdRendicion)
)


create table SolicDetalle
(
	IdSolicitudDetalle int not null identity(1,1),
	IdSolicitud int not null,
	IdSubCategoria int not null,
	Cantidad int not null,
	IdEstadoSolDetalle int not null,
	Constraint [PK_SolicDetalle] primary key (IdSolicitudDetalle, IdSolicitud)
)


create table RelCotSolDetalle
(
	IdSolicitudDetalle int not null,
	IdSolicitud int not null,
	IdCotizacion int not null,
	Constraint [PK_RelCotSolDetalle] primary key (IdSolicitudDetalle, IdSolicitud, IdCotizacion)
)


create table RelDepAgenteCargo
(
	IdAgente int not null,
	IdDependencia int not null,
	IdCargo int not null,
	Constraint [PK_RelDepAgenteCargo] primary key (IdAgente, IdDependencia, IdCargo)
)


create table RelSolDetalleAgente
(
	IdSolicitudDetalle int not null,
	IdSolicitud int not null,
	IdAgente int not null,
	Constraint [PK_RelSolDetalleAgente] primary key (IdSolicitudDetalle, IdSolicitud, IdAgente)
)




--*********************************************
--*********************************************
--RELACIONES
--*********************************************
--*********************************************

--FORANEAS DE RelDepAgenteCargo******************************************
ALTER TABLE RelDepAgenteCargo ADD CONSTRAINT [FK_RelDepAgenteCar_Cargo] 
FOREIGN KEY (IdCargo) REFERENCES Cargo(IdCargo)

ALTER TABLE RelDepAgenteCargo ADD CONSTRAINT [FK_RelDepAgenteCar_Agente] 
FOREIGN KEY (IdAgente) REFERENCES Agente(IdAgente)

ALTER TABLE RelDepAgenteCargo ADD CONSTRAINT [FK_RelDepAgenteCar_Dependencia] 
FOREIGN KEY (IdDependencia) REFERENCES Dependencia(IdDependencia)


--FORANEAS DE Nota******************************************
ALTER TABLE Nota ADD CONSTRAINT [FK_Nota_Solicitud] 
FOREIGN KEY (IdSolicitud) REFERENCES Solicitud(IdSolicitud)


--FORANEAS DE SOLICITUD******************************************
ALTER TABLE Solicitud ADD CONSTRAINT [FK_Solicitud_Dependencia] 
FOREIGN KEY (IdDependencia) REFERENCES Dependencia(IdDependencia)

ALTER TABLE Solicitud ADD CONSTRAINT [FK_Solicitud_Estado] 
FOREIGN KEY (IdEstado) REFERENCES EstadoSolicitud(IdEstadoSolicitud)

ALTER TABLE Solicitud ADD CONSTRAINT [FK_Solicitud_Prioridad] 
FOREIGN KEY (IdPrioridad) REFERENCES Prioridad(IdPrioridad)


--FORANEAS DE SOLICDETALLE******************************************
ALTER TABLE SolicDetalle ADD CONSTRAINT [FK_SolicDetalle_Solicitud] 
FOREIGN KEY (IdSolicitud) REFERENCES Solicitud(IdSolicitud)

ALTER TABLE SolicDetalle ADD CONSTRAINT [FK_SolicDetalle_EstadoSolDetalle] 
FOREIGN KEY (IdEstadoSolDetalle) REFERENCES EstadoSolDetalle(IdEstadoSolDetalle)

ALTER TABLE SolicDetalle ADD CONSTRAINT [FK_SolicDetalle_SubCategoria] 
FOREIGN KEY (IdSubCategoria) REFERENCES SubCategoria(IdSubCategoria)


--FORANEAS DE RelSolDetalleAgente******************************************
ALTER TABLE RelSolDetalleAgente ADD CONSTRAINT [FK_RelSolDetalleAgente_SolicDetalle] 
FOREIGN KEY (IdSolicitudDetalle, IdSolicitud) REFERENCES SolicDetalle(IdSolicitudDetalle, IdSolicitud)

ALTER TABLE RelSolDetalleAgente ADD CONSTRAINT [FK_RelSolDetalleAgente_Agente] 
FOREIGN KEY (IdAgente) REFERENCES Agente(IdAgente)


--FORANEAS DE RelCotSolDetalle******************************************
ALTER TABLE RelCotSolDetalle ADD CONSTRAINT [FK_RelCotSolDetalle_SolicDetalle] 
FOREIGN KEY (IdSolicitudDetalle, IdSolicitud) REFERENCES SolicDetalle(IdSolicitudDetalle, IdSolicitud)

ALTER TABLE RelCotSolDetalle ADD CONSTRAINT [FK_RelCotSolDetalle_Cotizacion] 
FOREIGN KEY (IdCotizacion) REFERENCES Cotizacion(IdCotizacion)


--FORANEAS DE COTIZACION******************************************
--ALTER TABLE RelCotSolDetalle ADD CONSTRAINT [FK_RelCotSolDetalle_SolicDetalle] 
--FOREIGN KEY (IdSolicitudDetalle, IdSolicitud) REFERENCES SolicDetalle(IdSolicitudDetalle, IdSolicitud)