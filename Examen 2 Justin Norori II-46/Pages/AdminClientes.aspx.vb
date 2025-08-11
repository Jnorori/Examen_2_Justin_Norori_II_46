Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class AdminDashboard
    Inherits Page

    Private clienteRepository As New ClienteRepository()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadClientes()
            ClearClienteForm()
            lblClienteMensaje.Text = String.Empty
        End If
    End Sub

    Private Sub LoadClientes()
        gvClientes.DataSource = clienteRepository.GetAll()
        gvClientes.DataBind()
    End Sub

    Protected Sub gvClientes_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim clienteId As Integer = Convert.ToInt32(gvClientes.SelectedDataKey.Value)
        Dim cliente = clienteRepository.GetAll().Find(Function(c) c.ClienteId = clienteId)

        If cliente IsNot Nothing Then
            hfClienteId.Value = cliente.ClienteId.ToString()
            txtFirstName.Text = cliente.FirstName
            txtLastName.Text = cliente.LastName
            txtEmail.Text = cliente.Email
            txtPhone.Text = cliente.Phone
            lblClienteMensaje.Text = String.Empty
        End If
    End Sub

    Protected Sub gvClientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim clienteId As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)
        clienteRepository.Delete(clienteId)
        LoadClientes()
        ClearClienteForm()
        lblClienteMensaje.ForeColor = System.Drawing.Color.Green
        lblClienteMensaje.Text = "Cliente eliminado correctamente."
    End Sub

    Protected Sub gvClientes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvClientes.PageIndex = e.NewPageIndex
        LoadClientes()
    End Sub

    Protected Sub btnGuardarCliente_Click(sender As Object, e As EventArgs)
        Dim cliente As New Cliente() With {
            .FirstName = txtFirstName.Text.Trim(),
            .LastName = txtLastName.Text.Trim(),
            .Email = txtEmail.Text.Trim(),
            .Phone = txtPhone.Text.Trim()
        }

        Dim clienteIdValue = hfClienteId.Value
        If Not String.IsNullOrEmpty(clienteIdValue) AndAlso Integer.TryParse(clienteIdValue, Nothing) Then
            cliente.ClienteId = Convert.ToInt32(clienteIdValue)
            clienteRepository.Update(cliente)
            lblClienteMensaje.ForeColor = System.Drawing.Color.Green
            lblClienteMensaje.Text = "Cliente actualizado correctamente."
        Else
            clienteRepository.Insert(cliente)
            lblClienteMensaje.ForeColor = System.Drawing.Color.Green
            lblClienteMensaje.Text = "Cliente agregado correctamente."
        End If

        LoadClientes()
        ClearClienteForm()
    End Sub

    Protected Sub btnCancelarCliente_Click(sender As Object, e As EventArgs)
        ClearClienteForm()
        lblClienteMensaje.Text = String.Empty
    End Sub

    Private Sub ClearClienteForm()
        hfClienteId.Value = String.Empty
        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPhone.Text = String.Empty
        gvClientes.SelectedIndex = -1
    End Sub

    Protected Sub btnIrAUsuarios_Click(sender As Object, e As EventArgs) Handles btnIrAUsuarios.Click
        Response.Redirect("AdminUsuarios.aspx")
    End Sub

End Class
