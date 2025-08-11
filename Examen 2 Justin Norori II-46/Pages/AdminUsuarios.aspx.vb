Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Public Class AdminUsuarios
    Inherits System.Web.UI.Page

    Private Class Usuario
        Public Property UsuarioId As Integer
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property Role As String
    End Class

    Private Class UsuarioAdminRepository
        Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

        Public Function GetAll() As List(Of Usuario)
            Dim lista As New List(Of Usuario)()
            Dim query As String = "SELECT UsuarioId, Username, Role FROM Usuarios"

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            lista.Add(New Usuario() With {
                                .UsuarioId = reader.GetInt32(0),
                                .Username = reader.GetString(1),
                                .Role = reader.GetString(2)
                            })
                        End While
                    End Using
                End Using
            End Using

            Return lista
        End Function

        Public Sub Insert(usuario As Usuario, password As String)
            Dim query As String = "INSERT INTO Usuarios (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)"
            Dim passwordHash = password

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Username", usuario.Username)
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash)
                    cmd.Parameters.AddWithValue("@Role", usuario.Role)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Update(usuario As Usuario)
            Dim query As String = "UPDATE Usuarios SET Username=@Username, Role=@Role WHERE UsuarioId=@UsuarioId"

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId)
                    cmd.Parameters.AddWithValue("@Username", usuario.Username)
                    cmd.Parameters.AddWithValue("@Role", usuario.Role)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Update(usuario As Usuario, password As String)
            Dim query As String = "UPDATE Usuarios SET Username=@Username, PasswordHash=@PasswordHash, Role=@Role WHERE UsuarioId=@UsuarioId"
            Dim passwordHash = password

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId)
                    cmd.Parameters.AddWithValue("@Username", usuario.Username)
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash)
                    cmd.Parameters.AddWithValue("@Role", usuario.Role)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Delete(usuarioId As Integer)
            Dim query As String = "DELETE FROM Usuarios WHERE UsuarioId=@UsuarioId"

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub
    End Class

    Private repo As New UsuarioAdminRepository()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadUsuarios()
            ClearUsuarioForm()
            lblUsuarioMensaje.Text = String.Empty
        End If
    End Sub

    Private Sub LoadUsuarios()
        gvUsuarios.DataSource = repo.GetAll()
        gvUsuarios.DataBind()
    End Sub

    Protected Sub gvUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim usuarioId As Integer = Convert.ToInt32(gvUsuarios.SelectedDataKey.Value)
        Dim usuario = repo.GetAll().Find(Function(u) u.UsuarioId = usuarioId)

        If usuario IsNot Nothing Then
            hfUsuarioId.Value = usuario.UsuarioId.ToString()
            txtUsername.Text = usuario.Username
            ddlRole.SelectedValue = usuario.Role
            lblUsuarioMensaje.Text = String.Empty
        End If
    End Sub

    Protected Sub gvUsuarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim usuarioId As Integer = Convert.ToInt32(gvUsuarios.DataKeys(e.RowIndex).Value)
        repo.Delete(usuarioId)
        LoadUsuarios()
        ClearUsuarioForm()
        lblUsuarioMensaje.ForeColor = Drawing.Color.Green
        lblUsuarioMensaje.Text = "Usuario eliminado correctamente."
    End Sub

    Protected Sub gvUsuarios_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvUsuarios.PageIndex = e.NewPageIndex
        LoadUsuarios()
    End Sub

    Protected Sub btnGuardarUsuario_Click(sender As Object, e As EventArgs)
        Dim usuario As New Usuario() With {
            .Username = txtUsername.Text.Trim(),
            .Role = ddlRole.SelectedValue
        }

        Dim usuarioIdValue = hfUsuarioId.Value
        Dim password = txtPassword.Text.Trim()

        If Not String.IsNullOrEmpty(usuarioIdValue) AndAlso Integer.TryParse(usuarioIdValue, Nothing) Then
            usuario.UsuarioId = Convert.ToInt32(usuarioIdValue)

            If String.IsNullOrEmpty(password) Then
                repo.Update(usuario)
            Else
                repo.Update(usuario, password)
            End If

            lblUsuarioMensaje.ForeColor = Drawing.Color.Green
            lblUsuarioMensaje.Text = "Usuario actualizado correctamente."
        Else
            If String.IsNullOrEmpty(password) Then
                lblUsuarioMensaje.ForeColor = Drawing.Color.Red
                lblUsuarioMensaje.Text = "La contraseña es obligatoria para un nuevo usuario."
                Return
            End If

            repo.Insert(usuario, password)
            lblUsuarioMensaje.ForeColor = Drawing.Color.Green
            lblUsuarioMensaje.Text = "Usuario agregado correctamente."
        End If

        LoadUsuarios()
        ClearUsuarioForm()
    End Sub

    Protected Sub btnCancelarUsuario_Click(sender As Object, e As EventArgs)
        ClearUsuarioForm()
        lblUsuarioMensaje.Text = String.Empty
    End Sub

    Private Sub ClearUsuarioForm()
        hfUsuarioId.Value = String.Empty
        txtUsername.Text = String.Empty
        txtPassword.Text = String.Empty
        ddlRole.SelectedIndex = 0
        gvUsuarios.SelectedIndex = -1
    End Sub

    Protected Sub btnIrAClientes_Click(sender As Object, e As EventArgs) Handles btnIrAClientes.Click
        Response.Redirect("AdminClientes.aspx")
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub

End Class
