Namespace Entidades

    Public Class Usuario

        Property Nombre As String
        Property Apellido As String
        Property NombreUsuario As String
        Property Legajo As Integer
        Property unCargo As Cargo
        Property Dependencia As Dependencia
        Property Familia As Familia
        Property Patente As Patente
        Property UsuarioRol As Integer
        Enum Rol As Integer
            Solicitante
            Responsable
        End Enum



    End Class

End Namespace