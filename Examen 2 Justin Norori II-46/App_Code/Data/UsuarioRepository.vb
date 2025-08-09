Imports System.Data.SqlClient

Public Class UsuarioRepository
        Private ReadOnly connectionString As String

        Public Sub New()
            Me.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        End Sub

        Public Function GetByUsername(username As String) As Usuario
            Dim usuario As Usuario = Nothing
            Dim query As String = "SELECT UsuarioId, Username, PasswordHash, Role FROM Usuarios WHERE Username = @Username"

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Username", username)
                    conn.Open()
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            usuario = New Usuario() With {
                                .UsuarioId = reader.GetInt32(0),
                                .Username = reader.GetString(1),
                                .PasswordHash = reader.GetString(2),
                                .Role = reader.GetString(3)
                            }
                        End If
                    End Using
                End Using
            End Using

            Return usuario
        End Function
    End Class

