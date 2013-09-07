Imports MySql.Data.MySqlClient
Imports System.Text

Public Class MySQLHandler
    Private connection As New MySqlConnection()
    Private command As New MySqlCommand()
    Private dataAdapter As MySqlDataAdapter

    Public Sub New(ByVal query As String)
        Try

            If connection.State = ConnectionState.Open Then connection.Close()

            connection.ConnectionString = gsConString
            connection.Open()

            command.Connection = connection
            command.CommandText = query

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Public Sub New()
        Try

            If connection.State = ConnectionState.Open Then connection.Close()

            connection.ConnectionString = gsConString
            connection.Open()

            command.Connection = connection

        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    '쿼리변경시 사용
    Public Sub SetQuery(ByVal query As String)
        command.CommandText = query
    End Sub

    '파라미터 리셋
    Public Sub ClearParameters()
        Try
            command.Parameters.Clear()
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    '쿼리파라미터 설정
    Public Sub Parameters(ByVal name As String, ByVal value As String)
        Try
            command.Parameters.AddWithValue(name, value)
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    '트랜잭션실행
    Public Function Execute() As Integer
        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If command.Parameters.Count > 0 Then
                command.Prepare()
            End If

            PrintParameter()

            Return command.ExecuteNonQuery()
        Catch ex As Exception
            WriteLog(ex.ToString)
            Throw ex 'New Exception("쿼리문 오류발생", ex)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Function

    '쿼리실행
    Public Function DoQuery() As DataTable
        Dim dataTable As New DataTable

        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            If command.Parameters.Count > 0 Then
                command.Prepare()
            End If

            dataAdapter = New MySqlDataAdapter(command)

            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

            PrintParameter()

            dataAdapter.Fill(dataTable)

        Catch ex As Exception
            WriteLog(ex.ToString)
            Throw ex 'New Exception("쿼리문 오류발생", ex)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
        Return dataTable
    End Function

    Public Sub PrintParameter()
        Dim queryMessage As String = ""
        Dim i As Integer
        For i = 0 To command.Parameters.Count - 1
            queryMessage += command.Parameters(i).ParameterName & "=" & command.Parameters(i).Value & ControlChars.Cr
        Next i
        WriteLog("query Parameter:" & command.CommandText & ControlChars.Cr & queryMessage)
    End Sub

    ''' <summary>
    ''' Closes the MySqlCommand and MySqlConnection connections
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        Try
            command.Connection.Close()
            connection.Close()
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub
End Class
