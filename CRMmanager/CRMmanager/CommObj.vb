Module CommObj
    Public Class CListItem
        Private mText As String
        Private mValue As Integer

        Public Sub New(ByVal pText As String, ByVal pValue As Integer)
            mText = pText
            mValue = pValue
        End Sub

        Public ReadOnly Property Text() As String
            Get
                Return mText
            End Get
        End Property

        Public ReadOnly Property Value() As Integer
            Get
                Return mValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return mText
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            ' ----- Allow IndexOf() and Contains() searches by ItemData.
            If (TypeOf obj Is Integer) Then
                Return CBool(CInt(obj) = mValue)
            Else
                Return MyBase.Equals(obj)
            End If
        End Function
    End Class
End Module
