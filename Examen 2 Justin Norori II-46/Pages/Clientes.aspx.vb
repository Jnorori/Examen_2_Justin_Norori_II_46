Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Cliente
    Public Property ClienteId As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
    Public Property Phone As String
End Class

Public Class ClienteRepository
    Private dbHelper As New DatabaseHelper()

    Public Function GetAll() As List(Of Cliente)
        Dim lista As New List(Of Cliente)()
        Dim dt = dbHelper.ExecuteQuery("SELECT ClienteId, FirstName, LastName, Email, Phone FROM Clientes")
        For Each row As System.Data.DataRow In dt.Rows
            lista.Add(New Cliente() With {
                .ClienteId = Convert.ToInt32(row("ClienteId")),
                .FirstName = row("FirstName").ToString(),
                .LastName = row("LastName").ToString(),
                .Email = row("Email").ToString(),
                .Phone = row("Phone").ToString()
            })
        Next
        Return lista
    End Function

    Public Sub Insert(cliente As Cliente)
        Dim query As String = "INSERT INTO Clientes (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)"
        Dim parameters As New List(Of SqlParameter) From {
            dbHelper.CreateParameter("@FirstName", cliente.FirstName),
            dbHelper.CreateParameter("@LastName", cliente.LastName),
            dbHelper.CreateParameter("@Email", cliente.Email),
            dbHelper.CreateParameter("@Phone", cliente.Phone)
        }
        dbHelper.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Update(cliente As Cliente)
        Dim query As String = "UPDATE Clientes SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone WHERE ClienteId=@ClienteId"
        Dim parameters As New List(Of SqlParameter) From {
            dbHelper.CreateParameter("@ClienteId", cliente.ClienteId),
            dbHelper.CreateParameter("@FirstName", cliente.FirstName),
            dbHelper.CreateParameter("@LastName", cliente.LastName),
            dbHelper.CreateParameter("@Email", cliente.Email),
            dbHelper.CreateParameter("@Phone", cliente.Phone)
        }
        dbHelper.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Delete(clienteId As Integer)
        Dim query As String = "DELETE FROM Clientes WHERE ClienteId=@ClienteId"
        Dim parameters As New List(Of SqlParameter) From {
            dbHelper.CreateParameter("@ClienteId", clienteId)
        }
        dbHelper.ExecuteNonQuery(query, parameters)
    End Sub
End Class

Partial Public Class Clientes
    Inherits Page

    Private clienteRepo As New ClienteRepository()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim clientes = clienteRepo.GetAll()
        gvClientes.DataSource = clientes
        gvClientes.DataBind()
    End Sub

    ' Este método es el que faltaba para la paginación
    Protected Sub gvClientes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvClientes.PageIndexChanging
        gvClientes.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub
End Class