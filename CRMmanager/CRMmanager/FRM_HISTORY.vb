Public Class FRM_HISTORY
    Private ss As New CRMmanager
    Private result As Integer = 0

    Private Sub FRM_HISTORY_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call SetToolBar(False, True, False, False, False, True, True)
    End Sub

    Private Sub FRM_HISTORY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Call SetToolBar(False, True, False, False, False, True, True)

            dpt1.Value = Format(Now, "yyyy-MM-dd")
            dpt2.Value = Format(Now, "yyyy-MM-dd")

            If Not gbUseExcel Then
                btnExcel.Visible = False
                btnSelect.Left = btnExcel.Left
            End If


            cbH1.SelectedIndex = 0
            cbT1.SelectedIndex = 0

            cbH2.SelectedIndex = 23
            cbT2.SelectedIndex = 6

            '************************************** 고객유형 입력 *********************************************
            Dim sqlTemp As String = Find_Query("006")
            Dim dt1 As DataTable = DoQuery(gsConString, sqlTemp)

            cboCustomerType.DataSource = dt1
            cboCustomerType.DisplayMember = dt1.Columns(0).ToString
            cboCustomerType.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboCustomerType, 0)  'cboCustomerType.SelectedIndex = 1
            dt1 = Nothing

            '************************************** 콜백처리결과 입력 *********************************************
            sqlTemp = Find_Query("014")
            dt1 = DoQuery(gsConString, sqlTemp)

            cboCallBackResult.DataSource = dt1
            cboCallBackResult.DisplayMember = dt1.Columns(0).ToString
            cboCallBackResult.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboCallBackResult, 0) 'cboCallBackResult.SelectedIndex = 2
            dt1 = Nothing

            '************************************** 처리유형입력 *********************************************
            sqlTemp = Find_Query("012")
            dt1 = DoQuery(gsConString, sqlTemp)

            cboHandleType.DataSource = dt1
            cboHandleType.DisplayMember = dt1.Columns(0).ToString
            cboHandleType.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboHandleType, 0) 'cboHandleType.SelectedIndex = 1
            dt1 = Nothing

            '************************************** 상담결과 입력 *********************************************
            sqlTemp = Find_Query("004")
            dt1 = DoQuery(gsConString, sqlTemp)

            cboConsultResult.DataSource = dt1
            cboConsultResult.DisplayMember = dt1.Columns(0).ToString
            cboConsultResult.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboConsultResult, 0) 'cboConsultResult.SelectedIndex = 0
            dt1 = Nothing

            '************************************** 상담유형 입력 *********************************************
            sqlTemp = Find_Query("003")
            dt1 = DoQuery(gsConString, sqlTemp)

            cboConsultType.DataSource = dt1
            cboConsultType.DisplayMember = dt1.Columns(0).ToString
            cboConsultType.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboConsultType, 0) 'cboConsultType.SelectedIndex = 0
            dt1 = Nothing

            '************************************** 통화자 *********************************************
            sqlTemp = " SELECT '' ,'XXXX' UNION ALL SELECT LTRIM(RTRIM(USER_NM)), CONCAT(USER_ID,'.',LTRIM(RTRIM(USER_NM))) FROM T_USER WHERE COM_CD = '" & gsCOM_CD & "'"
            dt1 = DoQuery(gsConString, sqlTemp)

            cboUser.DataSource = dt1
            cboUser.DisplayMember = dt1.Columns(0).ToString
            cboUser.ValueMember = dt1.Columns(1).ToString

            setComboSelect(cboUser, 0) 'cboUser.SelectedIndex = 0
            dt1 = Nothing

            SetDetailSearchVisible()

            gsSelect(True)

        Catch ex As Exception
            Call WriteLog("FRM_HISTORY : " & ex.ToString)
        End Try


    End Sub

    Public Sub gsSelect(ByVal isInit As Boolean)
        Dim dt1 As DataTable
        Try
            Dim SQL As String = "Select A.CUSTOMER_ID,A.CUSTOMER_NM "
            SQL = SQL & " ,CONCAT(SUBSTRING(TOND_DD,1,4) , '-' , SUBSTRING(TOND_DD,5,2) , '-' , SUBSTRING(TOND_DD,7,2)) tong_dd "
            SQL = SQL & " ,CONCAT(SUBSTRING(TONG_TIME,1,2) , ':' , SUBSTRING(TONG_TIME,3,2), ':' , SUBSTRING(TONG_TIME,5,2)) tong_time "
            SQL = SQL & " ,TONG_TELNO"
            SQL = SQL & " ,CONCAT(B.CUSTOMER_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "'" & _
                                                        " AND L_MENU_CD = '006' AND S_MENU_CD = B.CUSTOMER_TYPE )) CUSTOMER_TYPE "
            SQL = SQL & " ,CONCAT(HANDLE_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "'" & _
                                                        " AND L_MENU_CD = '012' AND S_MENU_CD = HANDLE_TYPE )) HANDLE_TYPE "
            SQL = SQL & " ,CONCAT(CALL_BACK_RESULT , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "'" & _
                                                        " AND L_MENU_CD = '014' AND S_MENU_CD = CALL_BACK_RESULT )) CALL_BACK_RESULT "
            SQL = SQL & " ,CONCAT(CONSULT_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "'" & _
                                                        " AND L_MENU_CD = '003' AND S_MENU_CD = CONSULT_TYPE )) CONSULT_TYPE "
            SQL = SQL & " ,CONCAT(CONSULT_RESULT , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "'" & _
                                                        " AND L_MENU_CD = '004' AND S_MENU_CD = CONSULT_RESULT )) CONSULT_RESULT"
            SQL = SQL & " ,A.TONG_USER,TONG_CONTENTS, CALL_BACK_YN "
            SQL = SQL & " ,CONCAT(CALL_TYPE , '.' , (SELECT LTRIM(RTRIM(S_MENU_NM)) FROM T_S_CODE WHERE COM_CD = '" & gsCOM_CD & "'" & _
                                                        " AND L_MENU_CD = '005' AND S_MENU_CD = CALL_TYPE )) CALL_TYPE "
            SQL = SQL & " FROM T_CUSTOMER_HISTORY A, T_CUSTOMER B "
            SQL = SQL & " WHERE A.COM_CD = '" & gsCOM_CD & "'"
            SQL = SQL & " AND A.CUSTOMER_ID = B.CUSTOMER_ID"

            '조회항목:고객아이디(customer_id)/통화일자(tong_dd)/통화시간(tong_time)/고객명(customer_nm)/전화번호(tong_telno)/고객유형(customer_type)
            '/상담유형(consult_type)/처리유형(handle_type)/상담결과(consult_result)/콜백여부(callback_result)/통화자(tong)user)/콜타입(call_type)/상담내용(tong_contents)

            If isInit Then '최초조회(당일건)
                Dim tm As String = Format(Now, "yyyyMMdd")
                SQL = SQL & " AND TOND_DD >= '" & tm & "'"
            Else

                SQL = SQL & " AND TOND_DD >= '" & dpt1.Text.ToString.Replace("-", "") & "'"
                SQL = SQL & " AND TOND_DD <= '" & dpt2.Text.ToString.Replace("-", "") & "'"
                SQL = SQL & " AND TONG_TIME >= '" & cbH1.Text & cbT1.Text & "00" & "'"
                SQL = SQL & " AND TONG_TIME <= '" & cbH2.Text & cbT2.Text & "00" & "'"
                SQL = SQL & " AND A.TONG_USER LIKE  '" & cboUser.SelectedValue.ToString.Replace("XXXX", "") & "%'"

                If cboCustomerType.SelectedIndex <> 0 Then
                    SQL = SQL & " AND B.CUSTOMER_TYPE LIKE  '" & cboCustomerType.SelectedValue.ToString.Replace("XXXX", "") & "%'"
                End If
                'If cboConsultType.SelectedIndex >= 0 Then
                '    SQL = SQL & " AND CONSULT_TYPE LIKE  '" & cboConsultType.SelectedValue.ToString.Replace("XXXX", "") & "%'"
                'End If
                If cboConsultType.SelectedIndex <> 0 Then
                    SQL = SQL & " AND CONSULT_TYPE LIKE  '" & cboConsultType.SelectedValue.ToString.Replace("XXXX", "") & "%'"
                End If

                If cboHandleType.SelectedIndex <> 0 Then
                    SQL = SQL & " AND HANDLE_TYPE LIKE  '" & cboHandleType.SelectedValue.ToString.Replace("XXXX", "") & "%'"
                End If
                If cboConsultResult.SelectedIndex <> 0 Then
                    SQL = SQL & " AND CONSULT_RESULT LIKE  '" & cboConsultResult.SelectedValue.ToString.Replace("XXXX", "") & "%'"
                End If

                If cboCallBackResult.SelectedIndex <> 0 Then
                    SQL = SQL & " AND CALL_BACK_YN = 'Y'"
                    SQL = SQL & " AND CALL_BACK_RESULT LIKE  '" & cboCallBackResult.SelectedValue.ToString.Replace("XXXX", "") & "%'"
                End If

                SQL = SQL & " AND ( EXISTS (SELECT * FROM t_customer_telno C WHERE COM_CD ='" & gsCOM_CD & "'"
                SQL = SQL & " AND C.CUSTOMER_ID = A.CUSTOMER_ID "
                SQL = SQL & " AND TELNO LIKE '%" & txtSearch.Text.Trim.Replace("-", "") & "%') "
                SQL = SQL & " OR  TONG_TELNO LIKE  '" & txtSearch.Text.Trim & "%'"
                SQL = SQL & " OR  TONG_CONTENTS LIKE '%" & txtSearch.Text.Trim.Replace("-", "") & "%' "
                SQL = SQL & " OR  EXISTS (SELECT * FROM t_customer C WHERE COM_CD ='" & gsCOM_CD & "'"
                SQL = SQL & " AND C.CUSTOMER_ID = A.CUSTOMER_ID "

                SQL = SQL & " AND ( C_TELNO LIKE '%" & txtSearch.Text.Trim & "%'"
                SQL = SQL & " OR H_TELNO LIKE '%" & txtSearch.Text.Trim & "%'"
                SQL = SQL & " OR COMPANY LIKE '%" & txtSearch.Text.Trim & "%'"
                SQL = SQL & " OR DEPARTMENT LIKE '%" & txtSearch.Text.Trim & "%'"

                SQL = SQL & " OR CUSTOMER_NM LIKE '%" & txtSearch.Text.Trim & "%'))) "

            End If
            SQL = SQL & " ORDER BY CONCAT(TOND_DD, TONG_TIME) DESC "

            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '************************************ 체크하자
            dt1 = DoQuery(gsConString, SQL)
            DataGridView2.DataSource = dt1

            Call subVarInit()
            Call DisplaySubDetail(0)
        Catch ex As Exception
            Call WriteLog("FRM_CUSTOMER : " & ex.ToString)
        Finally
            dt1 = Nothing
            result = 1
        End Try
    End Sub

    Private Sub subVarInit()

        txtSubCustomerName.Text = ""
        txtSubDate.Text = ""
        txtSubTongTime.Text = ""
        txtSubTongNo.Text = ""

        txtSubConsultType.Text = ""
        txtSubConsultResult.Text = ""
        txtSubTongUser.Text = ""
        txtSubTongContents.Text = ""
        txtSubHandleType.Text = ""
        txtSubCallBackResult.Text = ""
        txtSubCustomerType.Text = ""
        txtSubCallbackYN.Text = ""
        txtSubCallType.Text = ""

    End Sub

    Public Sub gsFormExit()
        Try
            Me.Close()
        Catch ex As Exception
            Call WriteLog("FRM_CUSTOMER : " & ex.ToString)
        End Try
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        '조회
        Call gsSelect(False)
    End Sub

    Private Sub Search_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call gsSelect(False)
        End If
    End Sub

    Private Sub DataGridView2_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        Try

            If e.RowIndex < 0 Then Exit Try
            Dim i As Integer = e.RowIndex

            DisplaySubDetail(i)

        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub

    Private Sub DisplaySubDetail(ByVal index As Integer)
        With DataGridView2.Rows(index)
            Call subVarInit()

            txtSubCustomerName.Text = .Cells("customer_nm").Value.ToString
            txtSubTongNo.Text = gfTelNoTransReturn(.Cells("tong_telno").Value.ToString)
            txtSubTongUser.Text = .Cells("tong_user").Value.ToString
            txtSubDate.Text = .Cells("tong_dd").Value.ToString
            txtSubTongTime.Text = .Cells("tong_time").Value.ToString
            txtSubConsultType.Text = .Cells("consult_type").Value.ToString
            txtSubConsultResult.Text = .Cells("consult_result").Value.ToString
            txtSubHandleType.Text = .Cells("handle_type").Value.ToString
            txtSubCallBackResult.Text = .Cells("call_back_result").Value.ToString
            txtSubCustomerType.Text = .Cells("customer_type").Value.ToString
            txtSubCallbackYN.Text = .Cells("call_back_yn").Value.ToString
            txtSubCallType.Text = .Cells("call_type").Value.ToString
            txtSubTongContents.Text = .Cells("tong_contents").Value.ToString

            '조회항목:고객아이디(customer_id)/통화일자(tong_dd)/통화시간(tong_time)/고객명(customer_nm)/전화번호(tong_telno)/고객유형(customer_type)
            '/상담유형(consult_type)/처리유형(handle_type)/상담결과(consult_result)/콜백여부(callback_result)/통화자(tong)user)/콜타입(call_type)/상담내용(tong_contents)

        End With
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        'Call FRM_MAIN.OpenCustomerPopup(txtSubTongNo.Text.Trim, txtDate.Text.Trim.Replace("-", "") & txtTongTime.Text.Trim.Replace(":", ""), "1")
        Dim frm As FRM_MAIN = Me.MdiParent

        Call frm.OpenCustomerPopupMod(txtSubTongNo.Text.Trim, txtSubDate.Text.Trim, txtSubTongTime.Text.Trim)
        'Call frm.menu_popuu("FRM_CUSTOMER_POPUP1")
        'ss.POPUP_Selected(txtSubTongNo.Text.Trim, txtDate.Text.Trim, txtTongTime.Text.Trim)
        'ss.POPUP_Transfer(txtSubTongNo.Text.Trim, txtDate.Text.Trim.Replace("-", "") & txtTongTime.Text.Trim.Replace(":", ""), "1")
    End Sub

    Private Sub FRM_HISTORY_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        'Call gsFormExit()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            With SaveFileDialog1
                .CheckPathExists = True
                .Filter = "Excel통합문서(*.xlsx)|*.xlsx|Excel97-2003문서(*.xls)|*.xls"
                .FileName = "고객상담이력" & "_" & Format(Now, "yyyyMMdd")
                .Title = "고객상담이력 엑셀로 내보내기"
                .ShowDialog()
            End With
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try

    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Try
            result = 0
            Call gsSelect(False)
            While (result = 0)
                Threading.Thread.Sleep(1000)
            End While
            Call Excel_Export2(SaveFileDialog1.FileName, SaveFileDialog1.Title, DataGridView2, "0,1,2,")
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 컬럼선택해서 보이기
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToggleModeSwitch(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleButton1.Click, ToggleButton3.Click, ToggleButton2.Click, ToggleButton6.Click, ToggleButton4.Click, ToggleButton5.Click, ToggleButton7.Click, ToggleButton8.Click
        Dim btn As Elegant.Ui.ToggleButton = sender
        'If DataGridView2.RowCount > 0 Then

        Select Case btn.Tag
            Case 1 '고객유형
                DataGridView2.Columns.Item("customer_type").Visible = btn.Pressed
            Case 2 '처리유형
                DataGridView2.Columns.Item("handle_type").Visible = btn.Pressed
            Case 3 '상담유형
                DataGridView2.Columns.Item("consult_type").Visible = btn.Pressed
            Case 4 '상담결과
                DataGridView2.Columns.Item("consult_result").Visible = btn.Pressed
            Case 5 '콜백여부
                DataGridView2.Columns.Item("call_back_yn").Visible = btn.Pressed
            Case 6 '콜백처리여부
                DataGridView2.Columns.Item("call_back_result").Visible = btn.Pressed
            Case 7 '콜타입
                DataGridView2.Columns.Item("call_type").Visible = btn.Pressed
            Case 8 '상담내용
                DataGridView2.Columns.Item("tong_contents").Visible = btn.Pressed
        End Select

        '값변경가능성 대비 refresh기능
        'End If

    End Sub

    Private Sub cbxDetailSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDetailSearch.CheckedChanged
        SetDetailSearchVisible()
    End Sub

    ''' <summary>
    ''' 상세검색버튼 보이기
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDetailSearchVisible()
        pnlDetailSearch.Visible = cbxDetailSearch.Checked
        If pnlDetailSearch.Visible Then
            pnlSelectColumn.Top = pnlDetailSearch.Bottom
            gbxSearch.Height = gbxSearch.Height + pnlDetailSearch.Height
            DataGridView2.Height = DataGridView2.Height - pnlDetailSearch.Height
        Else
            pnlSelectColumn.Top = pnlDetailSearch.Top
            gbxSearch.Height = gbxSearch.Height - pnlDetailSearch.Height
            DataGridView2.Height = DataGridView2.Height + pnlDetailSearch.Height
        End If

    End Sub
End Class