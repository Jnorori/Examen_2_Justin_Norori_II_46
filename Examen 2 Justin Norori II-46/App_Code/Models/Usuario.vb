Public Class Usuario
    Public Property UsuarioId As Integer
    Public Property Username As String
    Public Property PasswordHash As String
    Public Property Role As String

    Public Sub New()
    End Sub

    Public Sub New(usuarioId As Integer, username As String, passwordHash As String, role As String)
        Me.UsuarioId = usuarioId
        Me.Username = username
        Me.PasswordHash = passwordHash
        Me.Role = role
    End Sub
End Class


