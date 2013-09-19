Public Class FRM_CUSTOMER_TELNO
    Public ParentFrm As Windows.Forms.Form
    Dim mCustomerId As String = ""
    Dim mSelectedTelNo As String = ""

    Public Sub setInfo(ByVal customerId As String, ByVal customerName As String)
        mCustomerId = customerId
        txtCMName1.Text = customerName
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            'ParentFrm.Tag = Setting_TelNo()
            Setting_TelNo()
            Me.Close()
        Catch ex As Exception
            MsgBox("고객정보를 선택하세요.", MsgBoxStyle.OkOnly, "알림")
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Private Function Setting_TelNo() As String
        Return ""
    End Function

    Private Sub selectId()
        Dim dt1 As DataTable = Nothing

        Try
            txtFindTelNo.Text = ""
            mSelectedTelNo = ""

            Dim sql As String = " select TELNO from t_customer_telno " & _
                                "  WHERE COM_CD = @gsComCd" & _
                                "    AND CUSTOMER_ID like @customerId"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", "%" & mCustomerId.Trim & "%")

            dt1 = DoQuery(sql, parameters)
            DataGridView1.DataSource = Nothing


            DataGridView1.Columns.Clear()

            DataGridView1.DataSource = dt1
            DataGridView1.Columns.Item(0).FillWeight = 20
            DataGridView1.Columns.Item(0).Width = 120
            DataGridView1.Columns.Item(0).HeaderText = "전화번호"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Catch ex As Exception
            Call WriteLog(Me.Name & ":" & ex.ToString)
        Finally
            dt1 = Nothing
        End Try

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If e.RowIndex < 0 Then Exit Try
            Dim i As Integer = e.RowIndex

            With DataGridView1.Rows(i)
                txtFindTelNo.Text = .Cells(0).Value.ToString
                mSelectedTelNo = .Cells(0).Value.ToString
            End With
        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Dim IsInsert As Boolean = False
        Dim dt1 As DataTable = Nothing

        Try
            If mSelectedTelNo.Trim = "" Then
                IsInsert = True
            End If
            '
            If txtFindTelNo.Text.Trim = "" Then
                If IsInsert Then
                    MsgBox("등록할 전화번호가 없습니다.", MsgBoxStyle.OkOnly, "알림")
                Else
                    MsgBox("수정할 전화번호가 없습니다.", MsgBoxStyle.OkOnly, "알림")
                End If
                Exit Sub
            End If

            If gfTelNoTransReturn(txtFindTelNo.Text.Trim) = "000-0000-0000" Then
                MsgBox("등록할 전화번호를 정확히 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            'select COM_CD,CUSTOMER_ID,TELNO_TYPE,TELNO from t_customer_telno

            Dim sql As String = " SELECT COUNT(*) FROM t_customer_telno " & _
                                "  WHERE COM_CD = @gsComCd" & _
                                "    AND CUSTOMER_ID = @customerId" & _
                                "    AND TELNO = @telNo"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", mCustomerId.Trim)
            parameters.Add("@telNo", txtFindTelNo.Text.Trim.Replace("-", ""))

            dt1 = DoQuery(sql, parameters)
            Dim recCount As Integer = 0

            For Each row As DataRow In dt1.Rows
                recCount = row.Item(0)
            Next

            If IsInsert And recCount > 0 Then
                MsgBox("등록할 전화번호가 이미 존재합니다.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            '수정은 삭제후 입력으로 한다.
            If Not IsInsert Then
                If Not DeleteTelNo() Then
                    MsgBox("전화번호를 변경하지 못했습니다..", MsgBoxStyle.OkOnly, "알림")
                    Exit Sub
                End If
            End If

            If Not InsertTelNo() Then
                If IsInsert Then
                    MsgBox("전화번호를 등록하지 못했습니다..", MsgBoxStyle.OkOnly, "알림")
                Else
                    MsgBox("전화번호를 변경하지 못했습니다..", MsgBoxStyle.OkOnly, "알림")
                End If
                Exit Sub
            End If

            If IsInsert Then
                MsgBox("전화번호가 등록되었습니다.", MsgBoxStyle.OkOnly, "알림")
            Else
                MsgBox("선택한 번호가 수정되었습니다.", MsgBoxStyle.OkOnly, "알림")
            End If
            Call selectId()
        Catch ex As Exception
            Call WriteLog(Me.Name & ":btnModify_Click:" & mCustomerId & ":" & txtFindTelNo.Text & ex.ToString)
        Finally
            dt1 = Nothing
        End Try
    End Sub

    Private Function InsertTelNo()
        Dim result As Boolean = True
        Try
            Dim sql As String = "Insert Into t_customer_telno " & _
                                "       (COM_CD, CUSTOMER_ID, TELNO, TELNO_TYPE) " & _
                                "Values (@gsComCd ,@customerId ,@telNo ,'')"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", mCustomerId.Trim)
            parameters.Add("@telNo", txtFindTelNo.Text.Trim.Replace("-", ""))

            If DoExecuteNonQuery(sql, parameters) < 1 Then
                result = False
            End If
        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":InsertTelNo:" & mCustomerId & ":" & txtFindTelNo.Text & ex.ToString)
            result = False
        End Try
        Return result

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '고객정보삭제
        If txtFindTelNo.Text.Trim = "" Then
            MsgBox("삭제할 데이터를 선택 하세요.", MsgBoxStyle.OkOnly, "알림")
            Exit Sub
        End If
        If deleteTelNo() Then
            MsgBox("데이터가 삭제 됐습니다.", MsgBoxStyle.OkOnly, "알림")
            Call selectId()
        Else
            MsgBox("데이터가 삭제되지 않았습니다.", MsgBoxStyle.OkOnly, "알림")
        End If
    End Sub

    ''' <summary>
    ''' 고객정보삭제
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteTelNo() As Boolean
        Dim result As Boolean = True
        Try
            Dim sql As String = " DELETE FROM T_CUSTOMER_TELNO WHERE COM_CD = @gsComCd" & _
                                "' AND CUSTOMER_ID = @customerId" & _
                                "' AND TELNO = @telNo"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", mCustomerId.Trim)
            parameters.Add("@telNo", mSelectedTelNo.Trim)

            If (DoExecuteNonQuery(sql, parameters) < 1) Then
                result = False
            End If

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":DeleteTelNo:" & mCustomerId & ":" & txtFindTelNo.Text & ex.ToString)
            result = False
        End Try
        Return result
    End Function

    Private Sub FRM_CUSTOMER_TELNO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call selectId()
    End Sub

End Class