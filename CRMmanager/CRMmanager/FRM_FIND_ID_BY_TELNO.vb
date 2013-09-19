Public Class FRM_FIND_ID_BY_TELNO
    Public ParentFrm As Windows.Forms.Form
    Dim mEnteringNo As String = ""
    Dim mCustomerId As String = ""

    Public Sub setInfo(ByVal enteringNo As String, ByVal customerName As String)
        mEnteringNo = enteringNo
        txtEnteringNo.Text = enteringNo
        txtCMName1.Text = customerName
        Call queryCustomerInfo()
    End Sub

    Public Sub queryCustomerInfo()
        Call initCustomerInfo()
        Call selectId()
    End Sub

    Public Sub initCustomerInfo()
        mCustomerId = ""
        txtFindCmName1.Text = ""
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            ParentFrm.Tag = Setting_CustomerId()
            Me.Close()
        Catch ex As Exception
            MsgBox("고객정보를 선택하세요.", MsgBoxStyle.OkOnly, "알림")
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Public Function Setting_CustomerId() As String
        Try
            If mCustomerId.Trim = "" Then
                Call WriteLog(Me.Name & " : customerId 없음")
                Exit Try
            End If
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        Finally
            Setting_CustomerId = mCustomerId.Trim
        End Try
    End Function

    Private Sub selectId()
        Dim dt1 As DataTable = Nothing
        Try
            Dim sql As String = _
            " select CUSTOMER_ID,CUSTOMER_NM,C_TELNO,H_TELNO " & _
              " from t_customer " & _
              "WHERE COM_CD = @gsComCd" & _
              "  AND CUSTOMER_NM like @customerNm"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerNm", "%" & txtCMName1.Text.Trim & "%")

            dt1 = DoQuery(sql, parameters)
            DataGridView1.DataSource = Nothing


            DataGridView1.Columns.Clear()

            DataGridView1.DataSource = dt1
            DataGridView1.Columns.Item(0).HeaderText = "고객아이디"
            DataGridView1.Columns.Item(1).HeaderText = "고객"
            DataGridView1.Columns.Item(2).HeaderText = "전화번호"
            DataGridView1.Columns.Item(3).HeaderText = "핸드폰번호"

        Catch ex As Exception
            Call WriteLog(Me.Name & ":" & ex.ToString)
        Finally
            dt1 = Nothing
        End Try

    End Sub

    Private Sub btnCmSelect1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCmSelect1.Click
        Call queryCustomerInfo()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            txtFindCmName1.Text = ""
            mCustomerId = ""

            If e.RowIndex < 0 Then Exit Try
            Dim i As Integer = e.RowIndex

            With DataGridView1.Rows(i)
                mCustomerId = .Cells(0).Value.ToString
                txtFindCmName1.Text = .Cells(1).Value.ToString
            End With

        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub btnTelAdd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTelAdd1.Click

        Dim dt1 As DataTable

        Try
            If txtEnteringNo.Text.Trim = "" Then
                MsgBox("등록할 전화번호가 없습니다.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            If gfTelNoTransReturn(txtEnteringNo.Text.Trim) = "000-0000-0000" Then
                MsgBox("등록할 전화번호를 정확히 입력하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If
            If mCustomerId.Trim = "" Then
                MsgBox("고객정보를 선택하세요. 조회된 고객정보가 없는 경우, 고객정보를 먼저 등록하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            'select COM_CD,CUSTOMER_ID,TELNO_TYPE,TELNO from t_customer_telno

            Dim sql As String = _
            " SELECT COUNT(*) FROM t_customer_telno " & _
            "  WHERE COM_CD = @gsComCd" & _
            "    AND CUSTOMER_ID = @customerId" & _
            "    AND TELNO = @telNo"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", mCustomerId.Trim)
            parameters.Add("@telNo", txtEnteringNo.Text.Trim.Replace("-", ""))

            dt1 = DoQuery(sql, parameters)

            Dim recCnt As Integer = 0

            For Each row As DataRow In dt1.Rows
                recCnt = row.Item(0)
            Next

            If recCnt <= 0 Then
                sql = " INSERT INTO t_customer_telno " & _
                      "             ( COM_CD,CUSTOMER_ID,TELNO) " & _
                      "      VALUES ( @gsComCd, @customerId, @telNo)"
            Else
                MsgBox("이미 등록되어 있는 전화 번호입니다.다른 번호를 등록하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            If DoExecuteNonQuery(sql, parameters) < 1 Then
                MsgBox("전화번호 등록에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("전화번호 등록 실패")
            End If

            MsgBox("선택한 번호가 추가되었습니다.", MsgBoxStyle.OkOnly, "알림")

        Catch ex As Exception
            Call WriteLog(Me.Name & ":" & ex.ToString)
        Finally
            dt1 = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '고객정보삭제
        Try
            If txtFindCmName1.Text.Trim = "" Then
                MsgBox("삭제할 데이터를 선택 하세요.", MsgBoxStyle.OkOnly, "알림")
                Exit Sub
            End If

            Dim SQL As String = " DELETE FROM T_CUSTOMER_TELNO " & _
                                "  WHERE COM_CD = @gsComCd" & _
                                "    AND CUSTOMER_ID = @customerId" & _
                                "    AND TELNO = @telNo"

            Dim parameters As Hashtable = New Hashtable
            parameters.Add("@gsComCd", gsCOM_CD)
            parameters.Add("@customerId", mCustomerId.Trim)
            parameters.Add("@telNo", txtEnteringNo.Text.Trim)

            If DoExecuteNonQuery(SQL, parameters) < 1 Then
                MsgBox("비밀번호 변경에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
                Throw New Exception("비밀번호 변경 실패")
            End If

            MsgBox("데이터가 삭제 됐습니다.", MsgBoxStyle.OkOnly, "알림")

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & ":" & ex.ToString)
        End Try
    End Sub

    Private Sub txtCMName1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCMName1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call queryCustomerInfo()
        End If
    End Sub
End Class