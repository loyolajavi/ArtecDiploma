Imports DiagramaClasesArtec.Entidades

Namespace BLL

    Public Class MediadorSolicitud

        Sub CrearSolicitud(unaSolicitud As Solicitud)

            'BuscarUsuario
            'AsignarResponsable
            'RegistrarNroExpediente


        End Sub

        Function BuscarSolicitud() As Solicitud

        End Function

        Sub AsignarPrioridad(NroSolicitud As Integer)

        End Sub

        Function VerificarPoliticas(unaSolicitud As Solicitud) As Boolean

        End Function

        Sub AsignarResponsableSolicitud(NroUsuario As Integer, NroSolicitud As Integer)

        End Sub

        Sub GuardarImagenEscaneada(NroSolicitud As Integer, RutaOrigen As String)

        End Sub

        Function VerificarCotizacines(unaCotizacion As Cotizacion) As Boolean

            'VerificarPlazoCotizaciones
        End Function

        Sub OrdenarCotizaciones(unaCotizacion As Cotizacion)

        End Sub

        Sub EventoIngresosGastos()

        End Sub


    End Class

End Namespace