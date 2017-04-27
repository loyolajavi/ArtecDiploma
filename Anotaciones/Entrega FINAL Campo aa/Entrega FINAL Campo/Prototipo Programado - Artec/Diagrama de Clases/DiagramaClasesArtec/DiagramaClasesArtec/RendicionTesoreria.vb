Namespace Entidades

    Public Class RendicionTesoreria
        Inherits Rendicion

        Property DiferenciaMonto As Double

        Overrides Sub GenerarRendicion()
            'GenerarDocumentoWord con DiferenciaMonto
        End Sub

    End Class

End Namespace
