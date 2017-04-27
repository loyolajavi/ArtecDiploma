Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Reflection
Imports System.Threading
Imports Framework.Loyola
Imports Framework.Loyola.Servicios


Public Class frmLogin

    'Usuarios:
    'Us: UPrueba Pass: Pass12345
    'Us: LArgi   Pass: Pass54321

    Public IdiomaActual As Integer = Idioma.IdiomaSeleccion.Español

    Private Sub EspañolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspañolToolStripMenuItem.Click

        'Aplicar Idioma al Formulario
        Me.Text = Idioma.ObtenerTexto(Me.Name, Idioma.IdiomaSeleccion.Español)

        'Aplicar Idioma a los controles
        For Each unControl As Control In Me.Controls
            If Not (unControl.GetType().ToString() = "System.Windows.Forms.TextBox") Then
                unControl.Text = Idioma.ObtenerTexto(unControl.Name, Idioma.IdiomaSeleccion.Español)
            End If
        Next

        'Aplicar Idioma al Menu
        Me.menuIdioma.Text = Idioma.ObtenerTexto(Me.menuIdioma.Name, Idioma.IdiomaSeleccion.Español)
        For I = 0 To Me.menuIdioma.DropDownItems.Count - 1
            Me.menuIdioma.DropDownItems(I).Text = Idioma.ObtenerTexto(Me.menuIdioma.DropDownItems(I).Name, Idioma.IdiomaSeleccion.Español)
        Next

        IdiomaActual = Idioma.IdiomaSeleccion.Español

    End Sub

    Private Sub InglésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InglésToolStripMenuItem.Click

        Me.Text = Idioma.ObtenerTexto(Me.Name, Idioma.IdiomaSeleccion.Inglés)
        For Each unControl As Control In Me.Controls
            If Not (unControl.GetType().ToString() = "System.Windows.Forms.TextBox") Then
                unControl.Text = Idioma.ObtenerTexto(unControl.Name, Idioma.IdiomaSeleccion.Inglés)
            End If
        Next
        Me.menuIdioma.Text = Idioma.ObtenerTexto(Me.menuIdioma.Name, Idioma.IdiomaSeleccion.Inglés)
        For I = 0 To Me.menuIdioma.DropDownItems.Count - 1
            Me.menuIdioma.DropDownItems(I).Text = Idioma.ObtenerTexto(Me.menuIdioma.DropDownItems(I).Name, Idioma.IdiomaSeleccion.Inglés)
        Next

        IdiomaActual = Idioma.IdiomaSeleccion.Inglés

    End Sub


    Private Sub btnIngresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIngresar.Click

        Dim unUsuario As New Usuario

        Try
            'EXPRESION REGULAR
            If Not txtUsuario.Text = "" Then
                If ExpresionesRegulares.VerificarPassword(txtContraseña.Text) Then
                    'LOGIN USUARIO - AUTENTICACION
                    Dim unaConexion As New Conexion(Conexion.MotoresDisponibles.SqlServerClient)
                    Try
                        unaConexion.ConexionIniciar("Data Source=PCJAVI\SQLExpress;Initial Catalog=CampoPrototipo;Integrated Security=SSPI")
                        'ENCRIPTACION Y DIGITO VERIFICADOR
                        Dim UsExiste As Integer = unaConexion.Ejecutar("SELECT IdUsuario FROM Usuario WHERE NombreUsuario = @NomUs AND Contraseña = @Contr", False, IConexion.TipoRetorno.Escalar, txtUsuario.Text, DigitosVerificadores.EncodeDV(Encriptacion.Encriptar(txtContraseña.Text))).ResultadoEscalar
                        If (UsExiste) Then
                            Dim Resultado As IDataReader = unaConexion.Ejecutar("SELECT * FROM Usuario WHERE NombreUsuario = @NomUs AND Contraseña = @Contr", False, IConexion.TipoRetorno.Tupla, txtUsuario.Text, DigitosVerificadores.EncodeDV(Encriptacion.Encriptar(txtContraseña.Text))).ResultadoConectado
                            unUsuario = DataReadObjeto.RealizarMapeoUno(Of Usuario)(Resultado)

                            'IMPRIMO EL PASSWORD ENCRIPTADO Y HASHEADO
                            MsgBox("Contraseña Encriptada y con Hash: " + unUsuario.Contraseña)

                            'BITACORA Y MUESTRO MENSAJES SEGUN EL IDIOMA EN QUE SE ENCUENTRE
                            Bitacora.EscribirLog("Se ingresó al sistema", EventLogEntryType.SuccessAudit, "TrabajoDeCampo", Application.ProductName, 1)
                            MessageBox.Show(Idioma.ObtenerTexto("Mensaje1", IdiomaActual), "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            'PATENTE FAMILIA - AUTORIZACION
                            Resultado = Nothing
                            Resultado = unaConexion.Ejecutar("SELECT UF.IdFamilia, Fa.Descripcion FROM UsuarioFamilia UF INNER JOIN Familia Fa ON Fa.IdFamilia = UF.IdFamilia WHERE IdUsuario = @IdUs", False, IConexion.TipoRetorno.Tupla, unUsuario.IdUsuario).ResultadoConectado
                            Dim listaFamilias As List(Of Familia) = DataReadObjeto.RealizarMapeo(Of Familia)(Resultado)

                            'MUESTRO LOS PERMISOS QUE POSEE EL USUARIO
                            For Each unaFamilia In listaFamilias
                                unUsuario.unasFamilias.Add(unaFamilia)
                            Next

                            For Each fami In unUsuario.unasFamilias
                                Resultado = Nothing
                                Resultado = unaConexion.Ejecutar("SELECT FP.IdPatente, Pa.Descripcion FROM FamiliaPatente FP INNER JOIN Patente Pa ON Pa.IdPatente = FP.IdPatente WHERE FP.IdFamilia = @Fami", False, IConexion.TipoRetorno.Tupla, fami.IdFamilia).ResultadoConectado
                                Dim unasPatentes As List(Of Patente) = DataReadObjeto.RealizarMapeo(Of Patente)(Resultado)
                                For Each unaPatente In unasPatentes
                                    fami.UnasPatentes.Add(unaPatente)
                                Next
                            Next


                            For Each perfil In unUsuario.unasFamilias
                                For Each permiso In perfil.UnasPatentes
                                    MsgBox(permiso.Descripcion)
                                Next
                            Next

                            'IR A PANTALLA PRINCIPAL
                            Dim UnafrmPrincipal As New frmPantallaPrincipal
                            UnafrmPrincipal.Show()
                            Me.Hide()
                        Else
                            'BITACORA
                            Bitacora.EscribirLog("Se trató de ingresar al sistema sin éxito", EventLogEntryType.Warning, "TrabajoDeCampo", Application.ProductName, 2)
                            MessageBox.Show(Idioma.ObtenerTexto("Mensaje2", IdiomaActual), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    Catch ex As Exception
                        MsgBox("Error en Buscar Us")

                    Finally
                        unaConexion.ConexionFinalizar()
                    End Try


                Else
                    'BITACORA
                    Bitacora.EscribirLog("Se trató de ingresar al sistema sin éxito - DigitoVerificador", EventLogEntryType.Warning, "TrabajoDeCampo", Application.ProductName, 3)
                    MessageBox.Show(Idioma.ObtenerTexto("Mensaje3", IdiomaActual), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Else
                MessageBox.Show(Idioma.ObtenerTexto("Mensaje4", IdiomaActual), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        Catch ex As Exception
            'MANEJO EXCEPCIONES
            ManejoExcepciones.ManejarError(ex)

        End Try

    End Sub


   
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        'COMPROBAR LA INTEGRIDAD DE LOS DATOS BD - DIGITOS VERIFICADORES
        Dim unaConexion2 As New Conexion(Conexion.MotoresDisponibles.SqlServerClient)
        Try
            'BUSCO LOS DVH
            unaConexion2.ConexionIniciar("Data Source=PCJAVI\SQLExpress;Initial Catalog=CampoPrototipo;Integrated Security=SSPI")
            Dim Resultado2 As IDataReader = unaConexion2.Ejecutar("SELECT DVH FROM Usuario", False, IConexion.TipoRetorno.Tupla).ResultadoConectado
            Dim unUsuario2 As List(Of Usuario) = DataReadObjeto.RealizarMapeo(Of Usuario)(Resultado2)

            'CALCULO EL DVV
            Dim VerifVertical As String = ""
            For Each us2 In unUsuario2
                VerifVertical = us2.DVH + VerifVertical
            Next
            VerifVertical = DigitosVerificadores.EncodeDV(VerifVertical)

            'BUSCO EL DVV EN BD
            Dim VerifVerticalDB As String = unaConexion2.Ejecutar("SELECT DVV FROM DVertical", False, IConexion.TipoRetorno.Escalar).ResultadoEscalar

            'COMPARO LOS DVV
            If (VerifVertical = VerifVerticalDB) Then
                MsgBox("Integridad de Base de Datos: OK")
            Else
                MsgBox("Base de datos Corrupta")
            End If

        Catch ex As Exception
            MsgBox("Error en Crear Us")


        Finally
            unaConexion2.ConexionFinalizar()
        End Try

    End Sub
End Class
