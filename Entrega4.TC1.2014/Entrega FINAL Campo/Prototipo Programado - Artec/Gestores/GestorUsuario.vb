Imports DiagramaClasesArtec.Entidades

Namespace Gestores

    Public Class GestorUsuario

        Function BuscarUsuario(unUsuario As String) As Boolean

        End Function

        Function MostrarUsuario(unUsuario As String) As Usuario

        End Function

        Function MostrarListaUsuarios() As List(Of Usuario)


        End Function


        Function LoguearUsuarioTF(Us As String, Pass As String) As Boolean

        End Function

        Function LoguearUsuario(Us As String, Pass As String) As Usuario

        End Function

        Sub CrearUsuario(unUsuario As Usuario)

        End Sub

        Sub ModificarUsuario(unUsuario As Usuario)

        End Sub

        Sub EliminarUsuario(unUsuario As Usuario)

        End Sub


        Function VerificarCargo(unUsuario As Usuario) As Boolean

        End Function

    End Class

End Namespace