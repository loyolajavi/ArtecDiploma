Namespace Entidades

    Public Class PartidaEspecial

        Property IdPartidaEspecial As Integer
        Property NroPartidaEspecialOtorgada As String
        Property FechaPedido As DateTime
        Property FechaAcreditacion As DateTime
        Property Monto As Double
        Property CantidadCotizaciones As Integer
        Enum TipoPartida
            Caja
            Especial
            Dependencia
        End Enum
        Property unaRendicion As Rendicion

    End Class

End Namespace