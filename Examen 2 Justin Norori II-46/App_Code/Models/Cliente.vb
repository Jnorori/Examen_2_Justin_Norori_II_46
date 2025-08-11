
Public Class Cliente
        Inherits Persona

        Public Property ClienteId As Integer
        Public Sub New()
        End Sub

        Public Sub New(clienteId As Integer, firstName As String, lastName As String, email As String, phone As String)
            Me.ClienteId = clienteId
            Me.FirstName = firstName
            Me.LastName = lastName
            Me.Email = email
            Me.Phone = phone
        End Sub

    End Class

