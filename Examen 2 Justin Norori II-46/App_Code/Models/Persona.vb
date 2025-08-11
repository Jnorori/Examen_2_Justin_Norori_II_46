

Public Class Persona
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Email As String
        Public Property Phone As String

        Public Sub New()
        End Sub

        Public Sub New(firstName As String, lastName As String, email As String, phone As String)
            Me.FirstName = firstName
            Me.LastName = lastName
            Me.Email = email
            Me.Phone = phone
        End Sub
    End Class

