use Artec
go

create table Solicitud 
(
	NroSolicitud INT not null identity (1,1),
	FechaInicio datetime not null,
	FechaFin datetime,
	IdDependencia INT not null,
	IdPrioridad int not null,
	IdResponsable int not null,
	IdEstado int not null,
	CONSTRAINT [PK_Solicitud] primary key (NroSolicitud)
)

create table Nota
(
	IdNota int not null identity(1,1),
	FechaNota datetime not null,
	DescripNota varchar(500),
	IdUsuario int not null,
	Constraint [PK_Nota] primary key (IdNota)
)

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
	SerialMaster nvarchar (300) null,
	SerieKey nvarchar (300) not null,
	FechaSuscrip datetime null,
	FechaFinSuscrip datetime null,
	IdIngreso int not null,
	IdDeposito int not null,
	IdEstado int not null,
	DescripTipoBien varchar(300) not null,
	Constraint [PK_Inventario] primary key (IdInventario)
)


