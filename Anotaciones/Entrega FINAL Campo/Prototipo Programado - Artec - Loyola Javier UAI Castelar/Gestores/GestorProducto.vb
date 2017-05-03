Imports DiagramaClasesArtec.Entidades

Namespace Gestores

    Public Class GestorProducto

        Sub CrearProducto(unProducto As Producto)

        End Sub

        Function MostrarProducto() As Producto

        End Function

        Function ConsultarStock(NroProducto As Integer) As Integer

        End Function

        Function MostrarProductosXEnviados(FechaInicio As DateTime, FechaFin As DateTime) As List(Of Producto)

        End Function

        Function MostrarProductosAdquiridos(FechaInicio As DateTime, FechaFin As DateTime, unProducto As Producto) As List(Of Producto)

        End Function

        Function MostrarProductosEnviadosDependenciaX(FechaInicio As DateTime, FechaFin As DateTime, NroDependencia As Integer) As List(Of Producto)

        End Function

        Function ListarProductosPendientesEnvio() As List(Of Producto)

        End Function

        Sub AsociarProdSolicitud()

        End Sub

    End Class

End Namespace