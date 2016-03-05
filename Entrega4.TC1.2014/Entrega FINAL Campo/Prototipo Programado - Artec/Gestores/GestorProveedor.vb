Imports DiagramaClasesArtec.Entidades

Namespace Gestores

    Public Class GestorProveedor

        Sub CrearProveedor(unProveedor As Proveedor)

        End Sub

        Function MostrarProveedores() As List(Of Proveedor)

        End Function

        Function MostrarProveedor() As Proveedor

        End Function

        Function MostrarProveedoresSegunProducto(NroProducto As Integer) As List(Of Proveedor)

        End Function


        Sub AsociarProveedorProducto(NroProducto As Integer, NroProveedor As Integer)

        End Sub

        Sub PuntarProveedor(unPuntaje As Integer, NroProveedor As Proveedor)

        End Sub

    End Class

End Namespace