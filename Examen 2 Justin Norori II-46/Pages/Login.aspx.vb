Imports System.Web.Security
Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Private userRepo As New UsuarioRepository()

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            lblMessage.Text = "Please enter username and password."
            Return
        End If

        Dim usuario = userRepo.GetByUsername(username)

        If usuario IsNot Nothing AndAlso usuario.PasswordHash = password Then ' En producción compara hash
            Dim authTicket = New FormsAuthenticationTicket(1, usuario.Username, DateTime.Now, DateTime.Now.AddMinutes(30), False, usuario.Role)
            Dim encryptedTicket = FormsAuthentication.Encrypt(authTicket)
            Dim authCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            Response.Cookies.Add(authCookie)
            Response.Redirect("Clientes.aspx")
        Else
            lblMessage.Text = "Invalid username or password."
        End If
    End Sub
End Class
