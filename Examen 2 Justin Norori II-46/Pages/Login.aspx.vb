Imports System
Imports System.Web.UI
Imports System.Data.SqlClient

Public Class Login
    Inherits Page

    Public Class Usuario
        Public Property UsuarioId As Integer
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property Role As String
    End Class

    Public Class UsuarioRepository
        Private ReadOnly connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

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

    Private usuarioRepo As New UsuarioRepository()

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        lblMessage.Text = String.Empty

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            lblMessage.Text = "Please enter username and password."
            lblMessage.ForeColor = System.Drawing.Color.Red
            Return
        End If

        Try
            Dim usuario As Usuario = usuarioRepo.GetByUsername(username)

            If usuario IsNot Nothing AndAlso usuario.PasswordHash = password Then

                Session("CurrentUser") = usuario


                If usuario.Role = "Admin" Then
                    Response.Redirect("AdminClientes.aspx")
                ElseIf usuario.Role = "User" Then
                    Response.Redirect("Clientes.aspx")
                Else

                    Response.Redirect("Home.aspx")
                End If
            Else
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Text = "Invalid username or password."
            End If

        Catch ex As Exception
            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "An error occurred: " & ex.Message
        End Try
    End Sub
End Class




