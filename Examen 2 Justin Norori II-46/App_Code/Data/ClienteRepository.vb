Imports System.Data
Imports System.Data.SqlClient
Imports Examen_2_Justin_Norori_II_46


Public Class ClienteRepository
        Private dbHelper As New DatabaseHelper()

        Public Function GetAll() As List(Of Cliente)
            Dim lista As New List(Of Cliente)
            Dim dt As DataTable = dbHelper.ExecuteQuery("SELECT * FROM Clientes")
            For Each row As DataRow In dt.Rows
                lista.Add(New Cliente With {
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


