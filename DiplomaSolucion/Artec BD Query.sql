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



create table TipoBien
(
	IdTipoBien int not null identity(1,1),
	DescripTipoBien varchar(300) not null,
	Constraint [PK_TipoBien] primary key (IdTipoBien)
)


