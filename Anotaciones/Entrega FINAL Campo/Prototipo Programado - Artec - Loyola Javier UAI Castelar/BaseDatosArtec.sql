CREATE DATABASE CampoPrototipo
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Familia](
	[IdFamilia] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Familia] ON
INSERT [dbo].[Familia] ([IdFamilia], [Descripcion]) VALUES (1, N'ControlTotal')
INSERT [dbo].[Familia] ([IdFamilia], [Descripcion]) VALUES (2, N'Modificacion')
INSERT [dbo].[Familia] ([IdFamilia], [Descripcion]) VALUES (3, N'Lectura')
INSERT [dbo].[Familia] ([IdFamilia], [Descripcion]) VALUES (4, N'Escritura')
SET IDENTITY_INSERT [dbo].[Familia] OFF
/****** Object:  Table [dbo].[DVertical]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVertical](
	[DVV] [nvarchar](300) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[DVertical] ([DVV]) VALUES (N'diiOfrSqWkAFptUY8QTlwYU+lHY=')
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contraseña] [nvarchar](300) NOT NULL,
	[DVH] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Contraseña], [DVH]) VALUES (1, N'UPrueba', N'TdCljd+zAvJvW67YUl5MJZasXfY=', N'8PPInMATxUWIoXa7Tt+FqRja6YE=')
INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [Contraseña], [DVH]) VALUES (2, N'LArgi', N'B7/caZaRF4uZAajGeA0zwQSP0zI=', N'IRKnOL7HiHuD+8/3Bcg+RIMmih0=')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Table [dbo].[Patente]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patente](
	[IdPatente] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Patente] ON
INSERT [dbo].[Patente] ([IdPatente], [Descripcion]) VALUES (1, N'Leer')
INSERT [dbo].[Patente] ([IdPatente], [Descripcion]) VALUES (2, N'Crear')
INSERT [dbo].[Patente] ([IdPatente], [Descripcion]) VALUES (3, N'Modificar')
INSERT [dbo].[Patente] ([IdPatente], [Descripcion]) VALUES (4, N'Borrar')
INSERT [dbo].[Patente] ([IdPatente], [Descripcion]) VALUES (5, N'Escribir')
SET IDENTITY_INSERT [dbo].[Patente] OFF
/****** Object:  Table [dbo].[Idioma]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([IdIdioma], [Descripcion]) VALUES (2, N'Ingles')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
/****** Object:  Table [dbo].[UsuarioPatente]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPatente](
	[IdUsuario] [int] NOT NULL,
	[IdPatente] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPatente] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioFamilia]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioFamilia](
	[IdUsuario] [int] NOT NULL,
	[IdFamilia] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioFamilia] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UsuarioFamilia] ([IdUsuario], [IdFamilia]) VALUES (1, 1)
INSERT [dbo].[UsuarioFamilia] ([IdUsuario], [IdFamilia]) VALUES (2, 3)
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[IdFamilia] [int] NOT NULL,
	[IdPatente] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaPatente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (1, 1)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (2, 1)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (3, 1)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (4, 1)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (1, 2)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (2, 2)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (4, 2)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (1, 3)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (2, 3)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (1, 4)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (1, 5)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (2, 5)
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente]) VALUES (4, 5)
/****** Object:  Table [dbo].[IdiomaTexto]    Script Date: 08/02/2014 00:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaTexto](
	[IdControl] [int] IDENTITY(1,1) NOT NULL,
	[NombreControl] [varchar](100) NOT NULL,
	[TextoControl] [varchar](300) NOT NULL,
	[IdIdioma] [int] NOT NULL,
 CONSTRAINT [PK_IdiomaTexto] PRIMARY KEY CLUSTERED 
(
	[IdControl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[IdiomaTexto] ON
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (1, N'frmLogin', N'Artec - Ingresar al sistema', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (2, N'frmLogin', N'Artec - Login to system', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (3, N'menuIdioma', N'Eliga el Idioma', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (4, N'menuIdioma', N'Choose Language', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (5, N'EspañolToolStripMenuItem', N'Español', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (6, N'EspañolToolStripMenuItem', N'Spanish', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (7, N'InglésToolStripMenuItem', N'Inglés', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (8, N'InglésToolStripMenuItem', N'English', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (9, N'Label1', N'Usuario', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (10, N'Label1', N'User', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (11, N'lblContraseña', N'Contraseña', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (12, N'lblContraseña', N'Password', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (13, N'btnIngresar', N'Ingresar', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (14, N'btnIngresar', N'Login', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (15, N'ToolStrip1', N'Menu', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (16, N'ToolStrip1', N'Menu', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (17, N'Mensaje1', N'Contraseña Correcta', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (18, N'Mensaje1', N'Correct Password', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (19, N'Mensaje2', N'Contraseña Incorrecta', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (20, N'Mensaje2', N'Wrong Password', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (21, N'Mensaje3', N'La contraseña debe tener al menos 8 Caracteres, una Mayúscula y Numeros', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (22, N'Mensaje3', N'Password must contain at least 8 characters, one uppercase and numbers', 2)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (23, N'Mensaje4', N'Ingrese un Nombre de Usuario', 1)
INSERT [dbo].[IdiomaTexto] ([IdControl], [NombreControl], [TextoControl], [IdIdioma]) VALUES (24, N'Mensaje4', N'Enter an Username', 2)
SET IDENTITY_INSERT [dbo].[IdiomaTexto] OFF
/****** Object:  ForeignKey [FK_UsuarioPatente_Patente]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPatente_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[UsuarioPatente] CHECK CONSTRAINT [FK_UsuarioPatente_Patente]
GO
/****** Object:  ForeignKey [FK_UsuarioPatente_Usuario]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPatente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioPatente] CHECK CONSTRAINT [FK_UsuarioPatente_Usuario]
GO
/****** Object:  ForeignKey [FK_UsuarioFamilia_Familia]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFamilia_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[UsuarioFamilia] CHECK CONSTRAINT [FK_UsuarioFamilia_Familia]
GO
/****** Object:  ForeignKey [FK_UsuarioFamilia_Usuario]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFamilia_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioFamilia] CHECK CONSTRAINT [FK_UsuarioFamilia_Usuario]
GO
/****** Object:  ForeignKey [FK_FamiliaPatente_Familia]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Familia]
GO
/****** Object:  ForeignKey [FK_FamiliaPatente_Patente]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Patente]
GO
/****** Object:  ForeignKey [FK_IdiomaTexto_Idioma]    Script Date: 08/02/2014 00:25:33 ******/
ALTER TABLE [dbo].[IdiomaTexto]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaTexto_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaTexto] CHECK CONSTRAINT [FK_IdiomaTexto_Idioma]
GO
