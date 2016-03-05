Namespace Entidades

    Public Class Solicitud

        Property IdSolicitud As Integer
        Property NroExpediente As String
        Property Fecha As Date
        Property unResponsable As Usuario
        Property unSolicitante As Usuario
        Property unEstado As Integer
        Property unaPrioridad As Integer
        Property unosDetallesSolicitud As List(Of DetalleSolicitud)
        Property unasCotizaciones As List(Of Cotizacion)

    End Class

End Namespace