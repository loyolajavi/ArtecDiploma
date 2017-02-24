use Artec3
go

/*create table Dependencia
	(
		IdDependencia int identity (1,1) primary key not null,
		DependenciaNombre varchar (200) not null,
	)
*/


/*create table Nota
	(
		IdNota int identity (1,1) primary key not null,
		NotaDetalle varchar (1000) not null,
		FechaNota datetime not null,

	)
*/


--create table Usuario
--	(
--		IdUsuario int identity (1,1) primary key not null,
--		Nombre varchar (50) not null,
--		Apellido varchar (50) not null,
		
--	)


--create table Cargo
--	(
--		IdCargo int identity (1,1) primary key not null,
--		DescripCargo varchar (50) not null,
--	)


--create table ZDepUsu
--	(
--		IdUsuario int not null,
--		IdDependencia int  not null,
--	)

--alter table ZDepUsu
--	add IdCargo int not null


--create table UsuarioSistema
--	(
--		IdUsuario int identity (1,1) primary key not null,
--		NombreUsuario varchar (50),
--		Contrasena nvarchar (300),
--	)



--create table Bien
--	(
--		IdBien int identity (1,1) primary key not null,
--		DescripcionBien varchar (100) not null,
--		IdTipoBien int not null
--	)

--create table TipoBien
--	(
--		IdTipoBien int identity (1,1) primary key not null,
--		DescripTipoBien varchar (20) not null
--	)


--create table BienEspecif
--	(
--		IdBienEspecif int identity (1,1) primary key not null,
--		DescripBienEspecif varchar (200) not null,
--		Licenciado int null,
--		Homologado int null,
--		IdMarca int not null,
--		IdModeloVersion int not null,
--		IdBien int not null,
--		Cantidad int not null
--	)

--alter table BienEspecif
--add constraint FK_BienEspecif_Bien
--	Foreign key (IdBien)
--	references Bien(IdBien)
--	on delete cascade
--	on update cascade

--create table BienInventario
--	(
--		IdBienInventario int identity (1,1) primary key not null,
--		Serie nvarchar (50) not null,
--		Llave nvarchar (100) null,
--		Disponible int not null,
--		IdBienEspecif int not null,
--		IdCompra int null,
--	)

--create table Remito
--	(
--		IdRemito int identity (1,1) primary key not null,
--		FechaRemito varchar (200) not null,
--		IdDependencia int not null,

--	)


--create table RemitoDetalle
--	(
--		IdRemitoDetalle int identity (1,1) primary key not null,
--		IdRemito int not null,
--		IdBienInventario int not null,
--		IdSolicitudDetalle int not null
--	)


--create table cotizacion
--	(
--		IdCotizacion int identity (1,1) primary key not null,
--		FechaCotizacion datetime not null,
--		MontoCotizacion money not null,
--		IdPartidaDetalle int null,
--		IdProveedor int not null,
--		ProductoCotizado nvarchar (100),	
	
--	)

--create table ZCotSolicDet
--	(
--		IdSolicitudDetalle int not null,
--		IdCotizacion int not null	
--	)
